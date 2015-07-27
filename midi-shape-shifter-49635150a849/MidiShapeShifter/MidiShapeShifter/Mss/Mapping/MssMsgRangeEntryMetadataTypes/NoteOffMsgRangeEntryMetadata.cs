﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiShapeShifter.Mss.Mapping.MssMsgRangeEntryMetadataTypes
{
    public class NoteOffMsgRangeEntryMetadata : MidiMsgRangeEntryMetadata
    {
        public override MssMsgType MsgType
        {
            get { return MssMsgType.NoteOff; }
        }
    }
}
