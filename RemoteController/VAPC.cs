using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVoid;

namespace RemoteController
{
   public class VAPC
    {
        private static int _midiportin = -1;
        private static int _midiportout = -1;
        private static void MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            try
            {
                // Exit if the MidiEvent is null or is the AutoSensing command code  
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.AutoSensing)
                {
                    return;
                }

                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
                {
                    var x = ((NoteOnEvent)e.MidiEvent);
                    
                }
                    
            }
            catch (Exception ex)
            {
                Utility.Print(ex.Message);
                Utility.Print(ex.Message);
            }
        }

        public static void QuickNoteout(int note, int vel)
        {
            try
            {
                Debug.WriteLine(note+"-"+vel);
                Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StartNote(note, vel, 1).RawData);
                Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StopNote(note, vel, 1).RawData);
            }
            catch
            { }

        }
       public static bool GuessMidiPorts()
       {

           int i = 0;
           if (_midiportin == -1)
           {
               foreach (var x in TheVoid.Midi.GetMIDIInDevices())
               {
                   if (x.ToLower().Contains("apc") & x.ToLower().Contains("mini"))
                   {
                       Utility.Print("Found VAPC in");
                       _midiportin = i;
                       Midi.MidiInDevice(_midiportin).MessageReceived += VAPC.MessageReceived;
                   }
                   i++;
               }
           }
           if (_midiportout == -1)
           {
               i = 0;
               foreach (var x in TheVoid.Midi.GetMIDIOutDevices())
               {
                   if (x.ToLower().Contains("apc") & x.ToLower().Contains("mini"))
                   {
                       Utility.Print("Found VAPC out");
                       _midiportout = i;
                   }
                   i++;
               }
           }
           if (_midiportout != -1 & _midiportin != -1)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

    }
}
