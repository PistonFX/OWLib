﻿// File auto generated by STUHashTool
using static STULib.Types.Generic.Common;

namespace STULib.Types {
    [STU(0x8CE1D110)]
    public class STUHeroUnlocks : STUInstance {
        [STUField(0x473494FF)]
        public EventUnlockInfo[] LootboxUnlocks;

        [STUField(0xBF482AA3)]
        public UnlockInfo SystemUnlocks;

        [STUField(0xDB803F2F)]
        public UnlockInfo[] Unlocks; 

        [STUField(0x9135A4B2)]
        public UnlockInfo UnknownUnlocks; 

        public class EventUnlockInfo {
            [STUField(0xDB803F2F)]
            public UnlockInfo Data;

            [STUField(0x7AB4E3F8)]
            public uint EventID;
        }

        public class UnlockInfo {
            [STUField(0xDB803F2F)]
            public STUGUID[] Unlocks;
        }
    }
}