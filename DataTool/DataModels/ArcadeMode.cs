﻿using System.Runtime.Serialization;
using TankLib;
using TankLib.STU.Types;
using DataTool.Helper;
using static DataTool.Helper.IO;

namespace DataTool.DataModels {
    [DataContract]
    public class ArcadeMode {
        [DataMember]
        public teResourceGUID GUID;
        
        [DataMember]
        public string Name;
        
        [DataMember]
        public string Description;

        [DataMember]
        public teResourceGUID Image;
        
        [DataMember]
        public teResourceGUID Brawl;
        
        [DataMember]
        public teResourceGUID[] Children;
        
        [DataMember]
        public teResourceGUID[] Unknown;
        
        public ArcadeMode(ulong key) {
            STU_E3594B8E stu = STUHelper.GetInstance<STU_E3594B8E>(key);
            if (stu == null) return;
            Init(stu, key);
        }

        public ArcadeMode(STU_E3594B8E stu) {
            Init(stu);
        }

        private void Init(STU_E3594B8E arcade, ulong key = default) {
            GUID = (teResourceGUID) key;
            Name = GetString(arcade.m_name);
            Description = GetString(arcade.m_description);
            Image = arcade.m_21EB3E73;
            Unknown = Helper.JSON.FixArray(arcade.m_5797DE13);

            switch (arcade) {
                case STU_598579A3 a1:
                    Brawl = a1.m_5DC61E59;
                    break;
                case STU_19C05237 a2:
                    Children = Helper.JSON.FixArray(a2.m_children);
                    break;
                default:
                    break;
            }
        }
    }
}