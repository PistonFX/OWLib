﻿using System;
using System.IO;
using DataTool.FindLogic;
using DataTool.Flag;
using STULib.Types;
using TankLib;
using static DataTool.Program;
using static DataTool.Helper.IO;
using static DataTool.Helper.STUHelper;

namespace DataTool.ToolLogic.Extract.Debug {
    [Tool("extract-debug-voiceset", Description = "Extract VoiceSets (debug)", TrackTypes = new ushort[] {0x5F}, CustomFlags = typeof(ExtractFlags), IsSensitive = true)]
    public class ExtractDebugVoiceSet : ITool {
        public void IntegrateView(object sender) {
            throw new NotImplementedException();
        }

        public void Parse(ICLIFlags toolFlags) {
            ExtractVoiceSets(toolFlags);
        }

        public void ExtractVoiceSets(ICLIFlags toolFlags) {
            string basePath;
            if (toolFlags is ExtractFlags flags) {
                basePath = flags.OutputPath;
            } else {
                throw new Exception("no output path");
            }

            const string container = "DebugVoiceSet";
            
            foreach (ulong key in TrackedFiles[0x5F]) {
                if (teResourceGUID.Index(key) != 0x19F) continue;

                string voiceMaterDir = Path.Combine(basePath, container, GetFileName(key));
                
                Combo.ComboInfo info = new Combo.ComboInfo();
                Combo.Find(info, key);
                SaveLogic.Combo.SaveVoiceSet(flags, voiceMaterDir, info, key);

                // foreach (STUVoiceLineInstance voiceLineInstance in voiceSet.VoiceLineInstances) {
                //     if (voiceLineInstance?.SoundDataContainer == null) continue;
                //     
                //     Combo.ComboInfo info = new Combo.ComboInfo();
                //
                //     Combo.Find(info, voiceLineInstance.SoundDataContainer.SoundbankMasterResource);
                //
                //     foreach (ulong soundInfoNew in info.Sounds.Keys) {
                //         SaveLogic.Combo.SaveSound(flags, voiceMaterDir, info, soundInfoNew);
                //     }
                // }
            }
        }
    }
}