﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DataTool.DataModels;
using DataTool.DataModels.Hero;
using DataTool.FindLogic;
using DataTool.Flag;
using DataTool.Helper;
using DataTool.JSON;
using TankLib;
using TankLib.STU.Types;
using static DataTool.Helper.STUHelper;
using static DataTool.Helper.IO;
using SkinTheme = DataTool.SaveLogic.Unlock.SkinTheme;

namespace DataTool.ToolLogic.Extract {
    [Tool("extract-hero-voice", Description = "Extracts hero voicelines.", CustomFlags = typeof(ExtractFlags))]
    class ExtractHeroVoice : ExtractHeroVoiceBetter {
        protected override string Container => "HeroVoice";
    }

    [Tool("extract-hero-voice-better", IsSensitive = true, Description = "Extracts hero voicelines but groups them a bit better.", CustomFlags = typeof(ExtractFlags))]
    class ExtractHeroVoiceBetter : QueryParser, ITool {
        public Dictionary<string, string> QueryNameOverrides => null;
        public List<QueryType> QueryTypes => new List<QueryType>();
        protected virtual string Container => "BetterHeroVoice";
        private static readonly HashSet<ulong> SoundIdCache = new HashSet<ulong>();

        public void Parse(ICLIFlags toolFlags) {
            string basePath;
            if (toolFlags is ExtractFlags flags) {
                basePath = Path.Combine(flags.OutputPath, Container);
            } else {
                throw new Exception("no output path");
            }

            // Do normal heroes first then NPCs, this is because NPCs have a lot of duplicate sounds and normal heroes (should) have none
            // so any duplicate sounds would only come up while processing NPCs which can be ignored as they (probably) belong to heroes
            var heroes = Program.TrackedFiles[0x75]
                .Select(x => new Hero(x))
                .OrderBy(x => !x.IsHero)
                .ThenBy(x => x.GUID.GUID)
                .ToArray();

            var validHeroes = Helpers.GetHeroNamesMapping();
            var parsedTypes = ParseQuery(flags, QueryTypes, validNames: validHeroes);

            foreach (var hero in heroes) {
                // if we have a query, check if we should process this hero
                if (parsedTypes != null) {
                    var config = GetQuery(parsedTypes, hero.Name?.ToLowerInvariant(), "*", teResourceGUID.Index(hero.GUID).ToString("X"));
                    if (config.Count == 0) {
                        continue;
                    }
                }

                string heroName = GetValidFilename(GetCleanString(hero.STU.m_0EDCE350) ?? $"Unknown{teResourceGUID.Index(hero.GUID)}");

                Logger.Log($"Processing {heroName}");

                Combo.ComboInfo baseInfo = default;
                var heroVoiceSetGuid = GetInstance<STUVoiceSetComponent>(hero.STU.m_gameplayEntity)?.m_voiceDefinition;

                if (SaveVoiceSet(flags, basePath, heroName, "Default", heroVoiceSetGuid, ref baseInfo)) {
                    var skins = new ProgressionUnlocks(hero.STU).GetUnlocksOfType(UnlockType.Skin);

                    foreach (var unlock in skins) {
                        var unlockSkinTheme = unlock.STU as STUUnlock_SkinTheme;
                        if (unlockSkinTheme?.m_0B1BA7C1 != 0) {
                            continue; // no idea what this is
                        }

                        TACTLib.Logger.Debug("Tool", $"Processing skin {unlock.GetName()}");
                        Combo.ComboInfo info = default;
                        var skinTheme = GetInstance<STUSkinBase>(unlockSkinTheme.m_skinTheme);
                        if (skinTheme == null) {
                            continue;
                        }

                        SaveVoiceSet(flags, basePath, heroName, GetValidFilename(unlock.GetName()), heroVoiceSetGuid, ref info, baseInfo, SkinTheme.GetReplacements(skinTheme));
                    }
                }
            }
        }

        public static bool SaveVoiceSet(ExtractFlags flags, string basePath, string heroName, string unlockName, ulong? voiceSetGuid, ref Combo.ComboInfo info, Combo.ComboInfo baseCombo = null, Dictionary<ulong, ulong> replacements = null, bool ignoreGroups = false) {
            if (voiceSetGuid == null) {
                return false;
            }

            info = new Combo.ComboInfo();
            var saveContext = new SaveLogic.Combo.SaveContext(info);
            Combo.Find(info, voiceSetGuid.Value, replacements);

            // if we're processing a skin, baseCombo is the combo from the hero, this remove duplicate check removes any sounds that belong to the base hero
            // this ensures you only get sounds unique to the skin when processing a skin
            if (baseCombo != null) {
                if (!Combo.RemoveDuplicateVoiceSetEntries(baseCombo, ref info, voiceSetGuid.Value, Combo.GetReplacement(voiceSetGuid.Value, replacements)))
                    return false;
            }

            foreach (var voiceSet in info.m_voiceSets) {
                if (voiceSet.Value.VoiceLineInstances == null) continue;

                foreach (var voicelineInstanceInfo in voiceSet.Value.VoiceLineInstances) {
                    foreach (var voiceLineInstance in voicelineInstanceInfo.Value) {
                        if (!voiceLineInstance.SoundFiles.Any()) {
                            continue;
                        }

                        var stimulus = GetInstance<STUVoiceStimulus>(voiceLineInstance.VoiceStimulus);
                        if (stimulus == null) continue;

                        var groupName = GetVoiceGroup(voiceLineInstance.VoiceStimulus, stimulus.m_category) ??
                                        Path.Combine("Unknown",$"{teResourceGUID.Index(voiceLineInstance.VoiceStimulus):X}.{teResourceGUID.Type(voiceLineInstance.VoiceStimulus):X3}");

                        var stack = new List<string> { basePath };

                        CalculatePathStack(flags, heroName, unlockName, ignoreGroups ? "" : groupName, stack);

                        var path = Path.Combine(stack.Where(x => x.Length > 0).ToArray());

                        stack.Clear();
                        stack.Add(basePath);

                        string hero03FDir;
                        if (flags.VoiceGroup03FInType) {
                            hero03FDir = Path.Combine(path, "03F");
                        } else {
                            CalculatePathStack(flags, heroName, unlockName, "03F", stack);
                            hero03FDir = Path.Combine(stack.ToArray());
                        }

                        // 99% of voiceline instances only have a single sound file however there are cases where some NPCs have multiple
                        // the Junkenstein Narrator is an example, the lines are the same however they are spoken differently.
                        foreach (var soundFile in voiceLineInstance.SoundFiles) {
                            var soundFileGuid = teResourceGUID.AsString(soundFile);
                            string filename = null;

                            if (!flags.VoiceGroupByHero && !ignoreGroups) {
                                filename = $"{heroName}-{soundFileGuid}";
                            }

                            if (SoundIdCache.Contains(soundFile)) {
                                TACTLib.Logger.Debug("Tool", "Duplicate sound detected, ignoring.");
                                continue;
                            }

                            SoundIdCache.Add(soundFile);
                            //SaveLogic.Combo.SaveSoundFile(flags, path, saveContext, soundFile, true, filename);
                            SaveLogic.Combo.SaveVoiceLineInstance(flags, path, voiceLineInstance, filename, soundFile);
                        }

                        // Saves Wrecking Balls squeak sounds, no other heroes have sounds like this it seems
                        var stuSound = GetInstance<STUSound>(voiceLineInstance.ExternalSound);
                        if (stuSound?.m_C32C2195?.m_soundWEMFiles != null) {
                            foreach (var mSoundWemFile in stuSound?.m_C32C2195?.m_soundWEMFiles) {
                                if (BadSoundFiles.Contains(mSoundWemFile)) {
                                    continue;
                                }

                                SaveLogic.Combo.SaveSoundFile(flags, hero03FDir, mSoundWemFile);
                            }
                        }
                    }
                }
            }

            return true;
        }

        private static void CalculatePathStack(ExtractFlags flags, string heroName, string unlockName, string groupName, List<string> stack) {
            if (flags.VoiceGroupByLocale) {
                stack.Add(Program.Client.CreateArgs.SpeechLanguage ?? "enUS");
            }

            if (flags.VoiceGroupByHero) {
                stack.Add(heroName);

                if (flags.VoiceGroupBySkin) {
                    stack.Add(unlockName);
                }

                if (flags.VoiceGroupByType) {
                    stack.Add(groupName);
                }
            } else if (flags.VoiceGroupByType) {
                stack.Add(groupName);
            }
        }

        public static string GetVoiceGroup(ulong stimulusGuid, ulong categoryGuid) {
            return GetNullableGUIDName(stimulusGuid) ?? GetNullableGUIDName(categoryGuid);
        }

        // these are weird UI sounds that seem to be on every STUSound
        public static readonly HashSet<ulong> BadSoundFiles = new HashSet<ulong>() {
            0x7C0000000147482, // 000000147482.03F
            0x7C00000000958E8, // 0000000958E8.03F
            0x7C00000000958E6, // 0000000958E6.03F
            0x7C00000001BD800, // 0000001BD800.03F
            0x07C00000001BD7FF, // 0000001BD7FF.03F
        };
    }
}
