using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheVoid
{
    public class Midi
    {
        private Dictionary<int, MidiOut> D_midiOut = new Dictionary<int, MidiOut>();
        private Dictionary<int, MidiIn> D_midiInt = new Dictionary<int, MidiIn>();
        private MidiOut MidiOutDevice(int i)
        {
            try
            {
                if (!D_midiOut.ContainsKey(i))
                {
                    D_midiOut.Add(i, new MidiOut(i));
                    Debug.WriteLine("Add_Midiout:" + D_midiInt[i]);

                }

                return D_midiOut[i];
            }
            catch(Exception ex)
            {

                Debug.WriteLine(ex);
            }
            return null;
        }
        public MidiIn MidiInDevice(int i)
        {
            try
            {
                if (!D_midiInt.ContainsKey(i))
                {
                    D_midiInt.Add(i, new MidiIn(i));
                    D_midiInt[i].Start();
                    Debug.WriteLine("Add_MidiIN:" + D_midiInt[i]);
                }
               
                return D_midiInt[i];
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            return null;
        }
       
       public  string[] GetMIDIInDevices()
        {
            // Get a list of devices  
            string[] returnDevices = new string[MidiIn.NumberOfDevices];

            // Get the product name for each device found  
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                returnDevices[device] = MidiIn.DeviceInfo(device).ProductName;
                Debug.WriteLine("Add:"+returnDevices[device]);
            }
            return returnDevices;
        }
       public string[] GetMIDIOutDevices()
       {
           // Get a list of devices  
           string[] returnDevices = new string[MidiOut.NumberOfDevices];

           // Get the product name for each device found  
           for (int device = 0; device < MidiOut.NumberOfDevices; device++)
           {
               returnDevices[device] = MidiOut.DeviceInfo(device).ProductName;
               Debug.WriteLine("Add:" + returnDevices[device]);
           }
           return returnDevices;
       } 

        public void ResetMidiOutDevices()
        {
            foreach (var x in D_midiOut)
            {
                x.Value.Reset();
            }

        }
        public void ClearMidiOutDevices()
        {
            foreach (var x in D_midiOut)
            {
                x.Value.Close();
                x.Value.Dispose();
            }
            D_midiOut.Clear();
        }
        private void NoteOut(int note, int vel, int channel, int length, int device = 0)
        {

            this.MidiOutDevice(device).Send(MidiMessage.StartNote(note, vel, channel).RawData);
            System.Threading.Thread.Sleep(length);
            this.MidiOutDevice(device).Send(MidiMessage.StopNote(note, 0, channel).RawData);

        }
        private void CCOut(int controller, int value, int channel, int device = 0)
        {

            this.MidiOutDevice(device).Send(MidiMessage.ChangeControl(controller, value, channel).RawData);

        }
        private void PatchChange( int value, int channel, int device = 0)
        {

            this.MidiOutDevice(device).Send(MidiMessage.ChangePatch(value, channel).RawData);

        }
        public void CCOut(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    CCOut(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Convert.ToInt16(words[2]), Convert.ToInt16(words[3]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine("CCOut:", ex);
                }
            }).Start();
        }
        public void NoteOut(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    NoteOut(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Convert.ToInt16(words[2]), Convert.ToInt16(words[3]), Convert.ToInt16(words[4]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine("NoteOut:", ex);
                }
            }).Start();
        }
        public void PatchChange(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    PatchChange(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Convert.ToInt16(words[2]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine("PatchChange:", ex);
                }
            }).Start();
        }

    }

     partial class Combustion
    {

        public Midi Midi = new Midi();

        public void CombustionMidi()
        {
            this.Midi = new Midi();

            functiondelegates.Add("NoteOutRaw", new Action<string>(i1 => this.Midi.NoteOut(i1)));
            functiondelegates.Add("CCOutRaw", new Action<string>(i1 => this.Midi.CCOut(i1)));
            functiondelegates.Add("PatchChangeRaw", new Action<string>(i1 => this.Midi.PatchChange(i1)));
            functionalias.Add("noteout", "function noteout(note,vel,channel,length,device){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length+'|'+device);}");
            functionalias.Add("NoteOut", "function NoteOut(note,vel,channel,length,device){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length+'|'+device);}");
            functionalias.Add("CCOut", "function CCOut(controller,value,channel,device){CCOutRaw(controller+'|'+value+'|'+channel+'|'+device);}");
            functionalias.Add("ccout", "function ccout(controller,value,channel,device){CCOutRaw(controller+'|'+value+'|'+channel+'|'+device);}");
            functionalias.Add("PatchChange", "function PatchChange(value,channel,device){PatchChangeRaw(value+'|'+channel+'|'+device);}");
            functionalias.Add("patchchange", "function patchchange(value,channel,device){PatchChangeRaw(value+'|'+channel+'|'+device);}");
            functionalias.Add("programchange", "function patchchange(value,channel,device){PatchChangeRaw(value+'|'+channel+'|'+device);}");
            functionalias.Add("ProgramChange", "function patchchange(value,channel,device){PatchChangeRaw(value+'|'+channel+'|'+device);}");


        }

          
    }
}
