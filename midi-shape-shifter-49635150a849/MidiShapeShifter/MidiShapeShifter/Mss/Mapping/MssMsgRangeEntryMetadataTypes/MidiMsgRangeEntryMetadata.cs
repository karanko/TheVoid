﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using MidiShapeShifter.Mss.MssMsgInfoTypes;

namespace MidiShapeShifter.Mss.Mapping.MssMsgRangeEntryMetadataTypes
{
    public abstract class MidiMsgRangeEntryMetadata : MssMsgRangeEntryMetadata
    {
        protected string CHAN_RANGE_STR = "Channel Range:";
        protected string PARAM_RANGE_STR = "Param Range:";

        protected int paramRangeBottom;
        protected int paramRangeTop;
        protected int chanRangeBottom;
        protected int chanRangeTop;

        public override Control EntryField1
        {
            get
            {
                if (this.ioCatagory == IoType.Input)
                {
                    return this.mappingDlg.inEntryField1TextBox;
                }
                else if (this.ioCatagory == IoType.Output)
                {
                    return this.mappingDlg.outEntryField1TextBox;
                }
                else
                {
                    Debug.Assert(false);
                    return null;
                }
            }
        }

        public override Control EntryField2
        {
            get
            {
                if (this.ioCatagory == IoType.Input)
                {
                    return this.mappingDlg.inEntryField2TextBox;
                }
                else if (this.ioCatagory == IoType.Output)
                {
                    return this.mappingDlg.outEntryField2TextBox;
                }
                else
                {
                    Debug.Assert(false);
                    return null;
                }
            }
        }

        protected override void SetEntryField1FromRange(IMssMsgRange msgRange)
        {
            EntryField1.Text = msgRange.GetData1RangeStr(this.mappingDlg.MsgInfoFactory);
        }

        protected override void SetEntryField2FromRange(IMssMsgRange msgRange)
        {
            EntryField2.Text = msgRange.GetData2RangeStr(this.mappingDlg.MsgInfoFactory);
        }

        //set the properties of all the the controls in the entryFields member variable whose properties should differ 
        //from the default properties set in SetMappingDlgEntryFieldsDefaultProperties().
        protected override void SetMappingDlgEntryFieldCustomProperties()
        {
            this.EntryField1Lbl.Visible = true;
            this.EntryField1Lbl.Text = CHAN_RANGE_STR;

            this.EntryField1.Visible = true;

            this.EntryField2Lbl.Visible = true;
            this.EntryField2Lbl.Text = PARAM_RANGE_STR;

            this.EntryField2.Visible = true;
        }

        public override bool SetData1RangeFromField(out string errorMsg)
        {
            string userInput = this.EntryField1.Text;
            int rangeBottom;
            int rangeTop;
            IMssMsgInfo msgInfo = this.mappingDlg.MsgInfoFactory.Create(this.MsgType);

            bool userInputIsValid = GetRangeFromUserInput(userInput,
                (int)msgInfo.MinData1Value, (int)msgInfo.MaxData1Value,
                out rangeBottom, out rangeTop, 
                out errorMsg);

            this.msgRange.Data1RangeBottom = rangeBottom;
            this.msgRange.Data1RangeTop = rangeTop;

            return userInputIsValid;
        }

        public override bool SetData2RangeFromField(out string errorMsg)
        {
            string userInput = this.EntryField2.Text;
            int rangeBottom;
            int rangeTop;
            IMssMsgInfo msgInfo = this.mappingDlg.MsgInfoFactory.Create(this.MsgType);

            bool userInputIsValid = GetRangeFromUserInput(userInput,
                (int)msgInfo.MinData2Value, (int)msgInfo.MaxData2Value,
                out rangeBottom, out rangeTop,
                out errorMsg);

            this.msgRange.Data2RangeBottom = rangeBottom;
            this.msgRange.Data2RangeTop = rangeTop;

            return userInputIsValid;

        }

        public virtual bool GetRangeFromUserInput(string userInput, int minValue, int maxValue,
                                               out int rangeBottom, out int rangeTop, out string errorMsg)
        {
            int singleRangeValue;
            int tempRangeTop;
            int tempRangeBottom;

            errorMsg = "";
            bool validFormat;
            bool validRange;

            if (EntryFieldInterpretingUtils.InterpretAsInt(userInput, out singleRangeValue))
            {
                rangeTop = singleRangeValue;
                rangeBottom = singleRangeValue;
                validFormat = true;
            }
            else if (EntryFieldInterpretingUtils.InterpretAsRangeAllStr(userInput))
            {
                rangeTop = maxValue;
                rangeBottom = minValue;
                validFormat = true;
            }
            else if (EntryFieldInterpretingUtils.InterpretAsRangeOfInts(userInput, out tempRangeTop, out tempRangeBottom))
            {
                rangeTop = tempRangeTop; 
                rangeBottom = tempRangeBottom;
                validFormat = true;
            }
            else
            {
                errorMsg = "Invalid range format";
                rangeTop = MssMsgUtil.UNUSED_MSS_MSG_DATA;
                rangeBottom = MssMsgUtil.UNUSED_MSS_MSG_DATA;
                validFormat = false;
            }

            if (validFormat == true)
            {
                if (rangeBottom >= minValue && rangeTop <= maxValue)
                {
                    validRange = true;
                }
                else
                {
                    errorMsg = "Out of range";
                    validRange = false;
                }
            }
            else 
            {
                validRange = false;
            }

            return validRange;
        }

        protected override bool canSelectSameAsInput
        {
            get { return true; }
        }
    }
}
