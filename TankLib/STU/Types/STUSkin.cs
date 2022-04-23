// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xF6CCDAFC, 272)]
    public class STUSkin : STUSkinBase
    {
        [STUField(0x40996075, 104)] // size: 16
        public teStructuredDataAssetRef<ulong> m_40996075;
        
        [STUField(0x0EDCE350, 120)] // size: 16
        public teStructuredDataAssetRef<ulong> m_0EDCE350;
        
        [STUField(0xA5C9CA02, 136)] // size: 16
        public teString m_internalName;
        
        [STUField(0xF61E3F46, 152)] // size: 16
        public teString m_skinCode;
        
        [STUField(0x84625AA3, 168)] // size: 16
        public teStructuredDataAssetRef<STUSkinTheme>[] m_skinThemes;
        
        [STUField(0x37AB13D3, 184)] // size: 16
        public teStructuredDataAssetRef<STUHero> m_hero;
        
        [STUField(0x053595FD, 200)] // size: 16
        public teStructuredDataAssetRef<ulong> m_skinThumbnail;
        
        [STUField(0xDBEF61FE, 216)] // size: 16
        public teStructuredDataAssetRef<ulong>[] m_skinEffects;
        
        [STUField(0x38BFB46C, 232)] // size: 16
        public teStructuredDataAssetRef<STUResourceKey> m_resourceKey;
        
        [STUField(0x49A51309, 248)] // size: 16
        public teString m_49A51309;
        
        [STUField(0x62746D34, 264)] // size: 1
        public byte m_62746D34 = 0x0;
    }
}
