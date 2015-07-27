﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using MidiShapeShifter.Mss.Parameters;

using MidiShapeShifter.CSharpUtil;

namespace MidiShapeShifter.Mss
{

    public enum EquationType { Curve, Point };    


    /// <summary>
    ///     Contains information about a curve's shape and how it is being entered.
    /// </summary>
    [DataContract]
    public class CurveShapeInfo : ICloneable
    {
        public const string DEFAULT_EQUATION = "input";

        /// <summary>
        ///     This list contains the equation for each line segment.
        /// </summary>
        [DataMember]
        public List<string> CurveEquations;

        /// <summary>
        ///     This list contains the coordinates for each user control point. A coordinate can 
        ///     be specified by an equation but the euqation cannot contain variables like x, y or 
        ///     z. The equations can however contain variables that can always be evaluated to a 
        ///     number like a, b or c.
        /// </summary>
        [DataMember]
        public List<XyPoint<string>> PointEquations;

        /// <summary>
        /// The index of the currently selected equation. This index corresponds to an index in the 
        /// list CurveEquations or the list PointEquations.
        /// </summary>
        [DataMember]
        public int SelectedEquationIndex;

        /// <summary>
        /// Specifies which list the index specified in SelectedEquationIndex referes to.
        /// </summary>
        [DataMember]
        public EquationType SelectedEquationType;

        [DataMember]
        public List<MssParamInfo> ParamInfoList;

        public bool AllEquationsAreValid;

        public CurveShapeInfo()
        {
            ConstructNonSerializableMembers();
        }

        [OnDeserializing]
        protected void OnDeserializing(StreamingContext context)
        {
            ConstructNonSerializableMembers();
        }

        protected void ConstructNonSerializableMembers() 
        {
            this.AllEquationsAreValid = false;
        }

        public void InitWithDefaultValues()
        {
            this.CurveEquations = new List<string>();
            this.PointEquations = new List<XyPoint<string>>();

            this.SelectedEquationIndex = 0;
            this.SelectedEquationType = EquationType.Curve;

            this.ParamInfoList = CreateDefaultPresetParamInfoList();

            this.CurveEquations.Add(DEFAULT_EQUATION);
        }

        protected static List<MssParamInfo> CreateDefaultPresetParamInfoList()
        {
            List<MssParamInfo> presetParamInfoList = new List<MssParamInfo>();

            MssParamInfo defaultParameterInfo = new MssNumberParamInfo();
            defaultParameterInfo.Init("");

            MssParamInfo tempParameterInfo;

            tempParameterInfo = defaultParameterInfo.Clone();
            tempParameterInfo.Name = MssParameters.GetDefaultPresetName(MssParameterID.Preset1);
            presetParamInfoList.Add(tempParameterInfo);

            tempParameterInfo = defaultParameterInfo.Clone();
            tempParameterInfo.Name = MssParameters.GetDefaultPresetName(MssParameterID.Preset2);
            presetParamInfoList.Add(tempParameterInfo);

            tempParameterInfo = defaultParameterInfo.Clone();
            tempParameterInfo.Name = MssParameters.GetDefaultPresetName(MssParameterID.Preset3);
            presetParamInfoList.Add(tempParameterInfo);

            tempParameterInfo = defaultParameterInfo.Clone();
            tempParameterInfo.Name = MssParameters.GetDefaultPresetName(MssParameterID.Preset4);
            presetParamInfoList.Add(tempParameterInfo);

            tempParameterInfo = defaultParameterInfo.Clone();
            tempParameterInfo.Name = MssParameters.GetDefaultPresetName(MssParameterID.Preset5);
            presetParamInfoList.Add(tempParameterInfo);

            return presetParamInfoList;
        }


        object ICloneable.Clone()
        {
            return Clone();
        }

        public CurveShapeInfo Clone()
        {
            CurveShapeInfo curveInfoClone = new CurveShapeInfo();

            curveInfoClone.CurveEquations = new List<string>(this.CurveEquations.Clone());
            curveInfoClone.PointEquations = this.PointEquations.Clone();
            curveInfoClone.SelectedEquationIndex = this.SelectedEquationIndex;
            curveInfoClone.SelectedEquationType = this.SelectedEquationType;
            curveInfoClone.ParamInfoList = this.ParamInfoList.Clone();
            curveInfoClone.AllEquationsAreValid = this.AllEquationsAreValid;

            return curveInfoClone;
        }
    }
}
