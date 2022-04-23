// Generated by TankLibHelper
using TankLib.Math;
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x7725B6D6, 184)]
    public class STUGenericSettings_Nameplates : STUGenericSettings_Base
    {
        [STUField(0x582FD847, 8)] // size: 16
        public teStructuredDataAssetRef<ulong> m_582FD847;
        
        [STUField(0xBEAF73B8, 24)] // size: 16
        public teStructuredDataAssetRef<ulong> m_BEAF73B8;
        
        [STUField(0xC95E70CF, 40, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_FAA3F9A2 m_C95E70CF;
        
        [STUField(0xB8938E78, 48)] // size: 16
        public teColorRGBA m_backgroundColor = new teColorRGBA(0.05f, 0.05f, 0.05f, 0.93f);
        
        [STUField(0x8B7F6B0C, 64)] // size: 12
        public teColorRGB m_8B7F6B0C = new teColorRGB(1f, 0.065f, 0.019f);
        
        [STUField(0xA699CE1C, 76)] // size: 12
        public teColorRGB m_A699CE1C = new teColorRGB(0.065f, 0.019f, 1f);
        
        [STUField(0x950E2A8F, 88)] // size: 4
        public float m_950E2A8F = 20f;
        
        [STUField(0x9D442A12, 92)] // size: 4
        public float m_9D442A12 = 10f;
        
        [STUField(0xBD5D0EA8, 96)] // size: 4
        public float m_BD5D0EA8 = 0.8f;
        
        [STUField(0x6C703AAF, 100)] // size: 4
        public float m_6C703AAF = 0.3f;
        
        [STUField(0x620F883F, 104)] // size: 4
        public float m_620F883F = 0.6f;
        
        [STUField(0xA373BBA0, 108)] // size: 4
        public float m_A373BBA0 = 0.3f;
        
        [STUField(0x53B51068, 112)] // size: 4
        public float m_53B51068 = 22f;
        
        [STUField(0xF201584C, 116)] // size: 4
        public float m_F201584C = 10f;
        
        [STUField(0x0E9C9C80, 120)] // size: 4
        public Enum_EE8D87E7 m_0E9C9C80;
        
        [STUField(0xC6C76DAF, 124)] // size: 4
        public int m_C6C76DAF = 0x190;
        
        [STUField(0x126BF429, 128)] // size: 4
        public int m_126BF429 = 0x5;
        
        [STUField(0x8C167EFF, 132)] // size: 4
        public float m_8C167EFF = 15f;
        
        [STUField(0x8FF7841C, 136)] // size: 4
        public float m_8FF7841C = 35f;
        
        [STUField(0x85587E17, 140)] // size: 4
        public float m_85587E17 = 1E-05f;
        
        [STUField(0x1DE67E91, 144)] // size: 4
        public float m_1DE67E91 = 0.00021f;
        
        [STUField(0xD1195FED, 148)] // size: 4
        public float m_D1195FED = 11f;
        
        [STUField(0xEF5CE860, 152)] // size: 4
        public float m_EF5CE860 = 5f;
        
        [STUField(0xF09A2168, 156)] // size: 4
        public float m_F09A2168 = 150f;
        
        [STUField(0xCE86B746, 160)] // size: 4
        public float m_CE86B746 = 90f;
        
        [STUField(0x449E32A3, 164)] // size: 4
        public uint m_449E32A3 = 0x14;
        
        [STUField(0xC0ACAD1E, 168)] // size: 4
        public uint m_C0ACAD1E = 0x5;
        
        [STUField(0xA9391B0F, 172)] // size: 4
        public uint m_A9391B0F = 0x1;
        
        [STUField(0x1D79B55F, 176)] // size: 1
        public byte m_1D79B55F = 0x0;
        
        [STUField(0x288D781A, 177)] // size: 1
        public byte m_288D781A = 0x0;
    }
}
