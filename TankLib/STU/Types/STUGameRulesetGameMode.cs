// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x2E1A0A0B, 104)]
    public class STUGameRulesetGameMode : STUInstance
    {
        [STUField(0xEB4F2408, 0)] // size: 16
        public teStructuredDataAssetRef<STUGameMode> m_gamemode;

        [STUField(0x3CE93B76, 16, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUGameModeVarValuePair[] m_3CE93B76;

        [STUField(0xAD4BF17F, 32, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUGameModeVarValuePair[] m_AD4BF17F;

        [STUField(0xD440A0F7, 48, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUGameRulesetTeam[] m_teams;

        [STUField(0xDB2577DB, 64)] // size: 4
        public STUXPGainType[] m_DB2577DB;

        [STUField(0xCA7E6EDC, 80)] // size: 16
        public teStructuredDataAssetRef<ulong> m_description;

        [STUField(0x0DD0C65E, 96)] // size: 1
        public byte m_0DD0C65E;

        [STUField(0xE4CF1D64, 97)] // size: 1
        public byte m_E4CF1D64;

        [STUField(0x1D5809A3, 98)] // size: 1
        public byte m_1D5809A3;
    }
}
