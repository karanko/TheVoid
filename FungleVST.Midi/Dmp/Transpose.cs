using Jacobi.Vst.Framework;
using Jacobi.Vst.Core;
using System;
using System.Diagnostics;

namespace FungleVST.Midi.Dmp
{
    internal sealed class Transpose
    {
        private static readonly string ParameterCategoryName = "Trasnpose";

        private Plugin _plugin;
       


        public Transpose(Plugin plugin)
        {
            _plugin = plugin;
    //    this.engine.SetGlobalFunction("Console", new Action<int>(value => Debug.WriteLine(value)));

            
            InitializeParameters();

            _plugin.Opened += new System.EventHandler(Plugin_Opened);
        }

        private void Plugin_Opened(object sender, System.EventArgs e)
        {
            TransposeMgr.HostAutomation = _plugin.Host.GetInstance<IVstHostAutomation>();

            _plugin.Opened -= new System.EventHandler(Plugin_Opened);
        }

        public VstParameterManager TransposeMgr { get; private set; }

        private void InitializeParameters()
        {
            // all parameter definitions are added to a central list.
            VstParameterInfoCollection parameterInfos = _plugin.PluginPrograms.ParameterInfos;

            // retrieve the category for all delay parameters.
            VstParameterCategory paramCategory =
                _plugin.PluginPrograms.GetParameterCategory(ParameterCategoryName);

            // delay time parameter
            VstParameterInfo paramInfo = new VstParameterInfo();
            paramInfo.Category = paramCategory;
            paramInfo.CanBeAutomated = true;
            paramInfo.Name = "Transp.";
            paramInfo.Label = "Halfs";
            paramInfo.ShortLabel = "#";
            paramInfo.MinInteger = -100;
            paramInfo.MaxInteger = 100;
            paramInfo.LargeStepFloat = 5.0f;
            paramInfo.SmallStepFloat = 1.0f;
            paramInfo.StepFloat = 2.0f;
            paramInfo.DefaultValue = 0.0f;
            TransposeMgr = new VstParameterManager(paramInfo);
            VstParameterNormalizationInfo.AttachTo(paramInfo);
            parameterInfos.Add(paramInfo);

        }

        public VstMidiEvent ProcessEvent(VstMidiEvent inEvent)
        {
            if (!MidiHelper.IsNoteOff(inEvent.Data) && !MidiHelper.IsNoteOn(inEvent.Data))
            {
                return inEvent;
            }
        /*
            this.engine.SetGlobalValue("Transp", TransposeMgr.CurrentValue);
            this.engine.SetGlobalValue("Note", inEvent.Data[1]);
            this.engine.SetGlobalValue("Velocity", inEvent.Data[2]);
            this.engine.SetGlobalValue("DeltaFrames", inEvent.DeltaFrames);
            this.engine.SetGlobalValue("NoteLength",  inEvent.NoteLength);
            this.engine.SetGlobalValue("NoteOffset",  inEvent.NoteOffset);
            this.engine.SetGlobalValue("Detune",  inEvent.Detune);
            this.engine.SetGlobalValue("NoteOffVelocity",  inEvent.NoteOffVelocity);

//            this.engine.Evaluate("Process();");

            byte[] outData = new byte[4];
            inEvent.Data.CopyTo(outData, 0);

            this.engine.SetGlobalValue("Transp", TransposeMgr.CurrentValue);
            this.engine.SetGlobalValue("Note", inEvent.Data[1]);
            this.engine.SetGlobalValue("Vel", inEvent.Data[2]);
            this.engine.SetGlobalValue("DeltaFrames", inEvent.DeltaFrames);
            this.engine.SetGlobalValue("NoteLength", inEvent.NoteLength);
            this.engine.SetGlobalValue("NoteOffset", inEvent.NoteOffset);
            this.engine.SetGlobalValue("Detune", inEvent.Detune);
            this.engine.SetGlobalValue("NoteOffVelocity", inEvent.NoteOffVelocity);

            outData[1] =  (byte)this.engine.GetGlobalValue("Note");
            outData[2] = (byte)this.engine.GetGlobalValue("Velocity");

            *//*
            if (outData[1] > 127)outData[1] = 127;
            if (outData[1] < 0)outData[1] = 0;
            if (outData[2] > 127) outData[1] = 127;
            if (outData[2] < 0) outData[1] = 0;

            VstMidiEvent outEvent = new VstMidiEvent(
                 (int)this.engine.GetGlobalValue("DeltaFrames"),
                (int)this.engine.GetGlobalValue("NoteLength"),
                (int)this.engine.GetGlobalValue("NoteOffset"),
                outData,
                (short)this.engine.GetGlobalValue("Detune"),
                 (byte)this.engine.GetGlobalValue("NoteOffVelocity"));
            */
            return inEvent;
        }
    }
}
