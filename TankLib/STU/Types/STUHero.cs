// Generated by TankLibHelper
using TankLib.Math;
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x7C3457DC, 792)]
    public class STUHero : STUShippable
    {
        [STUField(0x950BBA06, 32)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_gameplayEntity;

        [STUField(0x0EDCE350, 48)] // size: 16
        public teStructuredDataAssetRef<ulong> m_0EDCE350;

        [STUField(0x5DCD82C0, 64)] // size: 16
        public teStructuredDataAssetRef<STUVoiceStimulus> m_5DCD82C0;

        [STUField(0xE04197AF, 80)] // size: 16
        public teStructuredDataAssetRef<STUGameRulesetSchema>[] m_gameRulesetSchemas;

        [STUField(0x2C54AEAF, 96)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_category;

        [STUField(0xF2D8DE15, 112)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier>[] m_F2D8DE15;

        [STUField(0x3446F580, 128)] // size: 16
        public teStructuredDataAssetRef<STU_7AC5B87B> m_3446F580;

        [STUField(0x322C521A, 144)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_322C521A;

        [STUField(0x26D71549, 160)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_26D71549;

        [STUField(0x8125713E, 176)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_8125713E;

        [STUField(0xAC91BECC, 192)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_previewEmoteEntity;

        [STUField(0x0F4BFD2C, 208)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_0F4BFD2C;

        [STUField(0x0145ED07, 224)] // size: 16
        public teStructuredDataAssetRef<STUAnimAlias> m_0145ED07;

        [STUField(0x31C64364, 240)] // size: 16
        public teStructuredDataAssetRef<STUAnimBlendTreeSet> m_31C64364;

        [STUField(0xD207D258, 256)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_D207D258;

        [STUField(0x06FAEF85, 272)] // size: 16
        public teStructuredDataAssetRef<STUAnimAlias> m_06FAEF85;

        [STUField(0xAEF1C962, 288)] // size: 16
        public teStructuredDataAssetRef<STUHardPoint> m_AEF1C962;

        [STUField(0x419D3CA5, 304)] // size: 16
        public teStructuredDataAssetRef<STUAnimBlendTreeSet> m_419D3CA5;

        [STUField(0x6BEC6706, 320)] // size: 16
        public teStructuredDataAssetRef<STUAnimation> m_6BEC6706;

        [STUField(0x3CFE2624, 336)] // size: 16
        public teStructuredDataAssetRef<STUAnimation> m_3CFE2624;

        [STUField(0xCFC554DC, 352)] // size: 16
        public teStructuredDataAssetRef<STUAnimBlendTreeSet> m_CFC554DC;

        [STUField(0xFCD2B649, 368, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_A0872511[] m_previewWeaponEntities;

        [STUField(0xC2FE396F, 384, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_A0872511[] m_C2FE396F;

        [STUField(0x9DC376A4, 400, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_A0872511[] m_9DC376A4;

        [STUField(0x8203BFE1, 416, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_1A496D3C[] m_8203BFE1;

        [STUField(0xFC833C02, 432, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_C0D5117B[] m_FC833C02;

        [STUField(0xA341183E, 448, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_8A1F18F9[] m_A341183E;

        [STUField(0x77FED604, 464)] // size: 16
        public teStructuredDataAssetRef<STULoadout>[] m_heroLoadout;

        [STUField(0xD12CB4EA, 480)] // size: 16
        public teStructuredDataAssetRef<STU_1DEBD356>[] m_D12CB4EA;

        [STUField(0x9F34BD31, 496)] // size: 16
        public teStructuredDataAssetRef<STU_7C128E17> m_9F34BD31;

        [STUField(0x34D442AA, 512)] // size: 16
        public teStructuredDataAssetRef<STU_67A38DF7> m_34D442AA;

        [STUField(0x4C064598, 528)] // size: 16
        public teStructuredDataAssetRef<STU_67A38DF7> m_4C064598;

        [STUField(0x4DEC4E30, 544)] // size: 16
        public teStructuredDataAssetRef<STU_67A38DF7> m_4DEC4E30;

        [STUField(0xF921CC3F, 560)] // size: 16
        public teStructuredDataAssetRef<STUUnlock> m_F921CC3F;

        [STUField(0x485AA39C, 576)] // size: 16
        public teStructuredDataAssetRef<STUProgressionUnlocks> m_heroProgression;

        [STUField(0x418F797D, 592, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public StatEventScoreScaler[] m_418F797D;

        [STUField(0xFF3C2071, 608)] // size: 16
        public teStructuredDataAssetRef<STUAchievement>[] m_achievements;

        [STUField(0xA5C9CA02, 624)] // size: 16
        public teString m_internalName;

        [STUField(0xB20C2C32, 640)] // size: 16
        public teStructuredDataAssetRef<STU_1C5DE3A3> m_B20C2C32;

        [STUField(0x6C61AEC3, 656)] // size: 16
        public teStructuredDataAssetRef<STU_1C5DE3A3> m_6C61AEC3;

        [STUField(0x893AAB2B, 672)] // size: 16
        public teStructuredDataAssetRef<ulong>[] m_heroEffects;

        [STUField(0x84625AA3, 688, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_63172E83[] m_skinThemes;

        [STUField(0xEBC69014, 704)] // size: 16
        public teStructuredDataAssetRef<STUHeroWeapon> m_EBC69014;

        [STUField(0xE25DDDA1, 720)] // size: 16
        public teColorRGBA m_heroColor;

        [STUField(0x163DD68B, 736)] // size: 12
        public teVec3 m_163DD68B;

        [STUField(0xA7562960, 748, ReaderType = typeof(InlineInstanceFieldReader))] // size: 12
        public STU_6AD90337 m_A7562960;

        [STUField(0xED98DBD7, 760)] // size: 4
        public float m_ED98DBD7;

        [STUField(0xC39495FA, 764)] // size: 4
        public float m_C39495FA;

        [STUField(0x44D13CC2, 768)] // size: 4
        public int m_44D13CC2 = -1;

        [STUField(0xAF4EC410, 772)] // size: 4
        public STUHeroSize m_heroSize;

        [STUField(0x7D88A63A, 776)] // size: 4
        public Enum_0C014B4A m_gender = Enum_0C014B4A.Generic;

        [STUField(0x64DC571F, 780)] // size: 1
        public byte m_64DC571F;

        [STUField(0x5E3C55AE, 781)] // size: 1
        public byte m_5E3C55AE;

        [STUField(0x906C3711, 782)] // size: 1
        public byte m_906C3711;

        [STUField(0xC93CEDD2, 783)] // size: 1
        public byte m_C93CEDD2;

        [STUField(0x40B57B0B, 784)] // size: 1
        public byte m_40B57B0B = 0x0;
    }
}
