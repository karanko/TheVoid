﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using MidiShapeShifter.Mss.Generator;

namespace MidiShapeShifter.Mss.MssMsgInfoTypes
{
    public class GeneratorMsgInfo : MssMsgInfo
    {
        protected IGeneratorMappingManager genMappingMgr;

        public void Init(IGeneratorMappingManager genMappingMgr)
        {
            this.genMappingMgr = genMappingMgr;
        }

        public override MssMsgType MsgType
        {
            get { return MssMsgType.Generator; }
        }

        public override string ConvertData1ToString(double Data1)
        {
            string data1String = "";

            bool idExists = this.genMappingMgr.RunFuncOnMappingEntry((int)Data1,
                (genEntry) => data1String = genEntry.GenConfigInfo.Name);

            if (idExists)
            {
                return data1String;
            }
            else
            {
                return "";
            }        
        }

        public override string ConvertData2ToString(double Data2)
        {
            return MssMsgUtil.UNUSED_MSS_MSG_STRING;
        }

        public override string ConvertData3ToString(double Data3)
        {
            return Math.Round(Data3 * 100).ToString() + "%";
        }
    }
}
