// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x00C21225, 56)]
    public class STUVoiceLineInstance : STUInstance
    {
        [STUField(0x43C90056, 8)] // size: 16
        public teStructuredDataAssetRef<STU_7A68A730> m_43C90056;

        [STUField(0xAF226247, 24, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_F746901F m_AF226247;

        [STUField(0xBC474019, 32, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUVoiceLine m_voiceLineRuntime;

        [STUField(0x38BFB46C, 40)] // size: 8
        public ulong m_resourceKey = 0x0;

        [STUField(0xECC13477, 48)] // size: 4
        public uint m_ECC13477 = 0x0;

        [STUField(0x3BE06155, 52)] // size: 4
        public uint m_3BE06155 = 0x0;
    }
}
