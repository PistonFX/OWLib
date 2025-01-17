// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xACCDE63F, 168)]
    public class STUCelebration : STUInstance
    {
        [STUField(0x71D9486D, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 24
        public STUUnlocks m_celebrationUnlocks;

        [STUField(0xED999C8B, 32)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_celebrationType;

        [STUField(0x752FEF56, 48)] // size: 16
        public teStructuredDataAssetRef<STUStat> m_752FEF56 = 0x8600000000003F5;

        [STUField(0x34AC2796, 64, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_1ED304DF[] m_34AC2796;

        [STUField(0xFE3E185A, 80)] // size: 16
        public teStructuredDataAssetRef<STU_2B8093CD>[] m_FE3E185A;

        [STUField(0x38BFB46C, 96)] // size: 16
        public teStructuredDataAssetRef<STUResourceKey> m_resourceKey;

        [STUField(0x1DAD9B7C, 112, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_C12AE264[] m_1DAD9B7C;

        [STUField(0x5B32D0EF, 128, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_0F32B4E9[] m_5B32D0EF;

        [STUField(0xF81F4386, 144)] // size: 8
        public teStructuredDataDateAndTime m_startTime;

        [STUField(0xFBEBAD6F, 152)] // size: 8
        public teStructuredDataDateAndTime m_endTime;

        [STUField(0xEDE36CB7, 160)] // size: 8
        public ulong m_resourceKeyId;
    }
}
