﻿using System;
using System.IO;
using System.Text;
using TankLib.Math;
using TankLib.DataSerializer;
using static TankLib.DataSerializer.Logical;

namespace TankLib
{
    public class teHighlight : ReadableData
    {
        public class FillerStruct : ReadableData
        {
            public uint Unknown62;
            public uint Unknown63;
            public uint Unknown64;
            public byte Unknown65;
        }

        [Flags]
        public enum HighlightUIFlags : int
        {
            Top5Highlight = 0x1, // Displayed in the "Top 5" section
            ManualHighlight = 0x2, // Displayed in the "36 manual highlights" section
            Viewed = 0x4, // if false, game will display "New" label
            HasBeenExported = 0x8 // if true, game will display "Recorded" label
        }

        [Flags]
        public enum HighlightKind : byte
        {
            Top5Highlight = 0x0, // Displayed in the "Top 5" section
            PlayOfTheGame = 0x1, // POTG
            ManualHighlight = 0x4, // if false, game will display "New" label
        }

        public byte FormatVersion;
        public teChecksum Checksum;
        public int DataLength;
        public long Unknown1;
        public long Unknown2;
        public long Unknown3;
        public long Unknown4;
        public int ReplayVersion;
        public int BuildVersion;
        public long PlayerId;
        public HighlightUIFlags Flags;
        public teResourceGUID Map;
        public teResourceGUID Gamemode;
        [DynamicSizeArray(typeof(int), typeof(HighlightInfo))]
        public HighlightInfo[] Info;
        [DynamicSizeArray(typeof(int), typeof(teHeroData))]
        public teHeroData[] Heroes;
        public uint Unknown5;
        public uint Unknown6;
        [DynamicSizeArray(typeof(byte), typeof(FillerStruct))]
        public FillerStruct[] FillerStructs;

        public class HighlightInfo : ReadableData
        {
            [NullPaddedString]
            public string PlayerName;

            public byte UnknownByte;

            public HighlightKind Kind;
            public uint Unknown1;
            public uint Unknown2;
            public float Unknown3;
            public float Unknown4;
            public uint Elevation;
            public uint TeamSpawnNumber;
            public teVec3 Position;
            public teVec3 Direction;
            public teVec3 Up;
            public teResourceGUID Hero;
            public teResourceGUID ItemSkinKey;
            public teResourceGUID ItemWSkinKey;

            public teResourceGUID TeamA;
            public teResourceGUID TeamB;

            public teResourceGUID HighlightIntro;
            public teResourceGUID HighlightType;
            public ulong Timestamp;

            public teUUID UUID;
        }

        public static readonly int MAGIC = Util.GetMagicBytesBE('p', 'h', 'l'); // Player HighLight

        [Skip]
        public MemoryStream Replay;

        public teHighlight(Stream stream, bool leaveOpen = false)
        {
            using (BinaryReader reader = new BinaryReader(stream, Encoding.Default, leaveOpen))
            {
                if ((reader.ReadInt32() & Util.BYTE_MASK_3) == MAGIC)
                {
                    stream.Position -= 1;
                    Read(reader);
                    int size = reader.ReadInt32();
                    Replay = new MemoryStream(reader.ReadBytes(size));
                }
            }
        }
    }
}
