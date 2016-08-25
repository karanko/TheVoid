using NAudio.Midi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheVoid
{
    public static class Midi
    {
        public static int MidiInChannelNumber
        {
            get { return Options.Read("MidiInChannel", 1); }
            set { Options.Write("MidiInChannel", value); }
        }
        public static int MidiOutChannelNumber
        {
            get { return Options.Read("MidiOutChannel", 1); }
            set { Options.Write("MidiOutChannel", value); }
        }
        public static int MidiInDeviceNumber
        {
            get {var devnum = Options.Read("MidiInDevice", 0);
            try
            {
                 
               MidiInDevice(devnum).Start();
            }
            catch (Exception ex) { Utility.Print(ex.Message); }
            return devnum;
            }
            set { Options.Write("MidiInDevice", value); try
            { MidiInDevice(value).Start(); }
            catch (Exception ex) { Utility.Print(ex.Message); }
            }
        }
        public static int MidiOutDeviceNumber
        {
            get { return Options.Read("MidiOutDevice", 0); }
            set { Options.Write("MidiOutDevice", value); }
        }

        public static int MidiSyncOutDeviceNumber
        {
            get
            {
                return Options.Read("MidiSyncOutDevice", MidiOutDeviceNumber); 
            }
            set { Options.Write("MidiSyncOutDevice", value); }
        }
        
        public static bool SyncOutClock(bool run )
        {
          if(aTimer == null)
          {
              Utility.Print("SyncOutClock: init");
              Thread.CurrentThread.Priority = ThreadPriority.Highest;

              aTimer = new System.Timers.Timer();
              aTimer.Elapsed += new System.Timers.ElapsedEventHandler(midisyncElapsedEventHandler);
           //   aTimer.SynchronizingObject

          }
             aTimer.Enabled = run;
          try
          {
              if (aTimer.Enabled)
              {
                  MidiOutDevice(MidiSyncOutDeviceNumber).Send(Convert.ToInt16(MidiCommandCode.StartSequence));
              }
              else
              {
               
                  MidiOutDevice(MidiSyncOutDeviceNumber).Send(Convert.ToInt16(MidiCommandCode.StopSequence));

              }
          }
          catch (Exception ex)
          {
              Utility.Print(ex.Message);
          }

        //   Utility.Print("SyncOutClock Enabled: " + aTimer.Enabled);
            
                return aTimer.Enabled;
            //    = 500;
        }
        public static void SyncOutBPM(double BPM)
        {
                int beats = 4;
                int bars = 4;
                aTimer.Interval = ((60*1000) / BPM) / (double)tickdivider / (beats * bars);

            Utility.Print("Interval:" + aTimer.Interval);

            //    = 500;
            //   aTimer.Elapsed += new ElapsedEventHandler(tick);
        }

        private static System.Timers.Timer aTimer;
          private static void midisyncElapsedEventHandler(object source, System.Timers.ElapsedEventArgs e)
          {
              try
              {
                  MidiOutDevice(MidiSyncOutDeviceNumber).Send(Convert.ToInt16(MidiCommandCode.TimingClock));
               //   MidiOutDevice(MidiSyncOutDeviceNumber).Send(Convert.ToInt16(MidiCommandCode.TimingClock));
                //  Utility.Print("tickout");
              }
              catch (Exception ex) { 
                  Utility.Print(ex.Message);
               }
         
          }
      //  public static MidiIn midiIn;
       // private static bool monitoring;
        //private static int midiInDevice;
         private static int rawticks = 0;
       //  private static int tickdivider = 6;
         private static int tickdivider
         {
             get
             {
                 return Options.Read("tickdivider", 6);
             }
             set { Options.Write("tickdivider", value); }
         }
         private static bool clockrunning = false;

        private static ConcurrentDictionary<int, int> controlchangecache = new ConcurrentDictionary<int,int>();
        public static int GetCCValue(int CC)
        {
            int result = -1;
            if( Midi.controlchangecache.Keys.Contains(CC))
            {
                result =  Midi.controlchangecache[CC];
            }
            return result;
        }
        public static void SetCCValue(int CC, int value)
        {
            if(value > 127 | value < 0 )
            {
                throw new Exception("CC value outside of range:"+CC+":"+value);
            }

            if (!Midi.controlchangecache.Keys.Contains(CC))
            {
                 Midi.controlchangecache.TryAdd(CC,value);
            }
            Midi.controlchangecache[CC] = value ;
          
        }

        public static string[] GetMIDIInDevices()
        {
            // Get a list of devices  
            string[] returnDevices = new string[MidiIn.NumberOfDevices];

            // Get the product name for each device found  
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                returnDevices[device] = MidiIn.DeviceInfo(device).ProductName;
            }
            return returnDevices;
        }
        public static string[] GetMIDIOutDevices()
        {
            // Get a list of devices  
            string[] returnDevices = new string[MidiOut.NumberOfDevices];

            // Get the product name for each device found  
            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                returnDevices[device] = MidiOut.DeviceInfo(device).ProductName;
            }
            return returnDevices;
        }

        private static ConcurrentDictionary<int, MidiOut> D_midiOut = new ConcurrentDictionary<int, MidiOut>();
        private static ConcurrentDictionary<int, MidiIn> D_midiIn = new ConcurrentDictionary<int, MidiIn>();
        
        public static MidiIn MidiInDevice(int i)
        {
            try
            {
                if (!D_midiIn.ContainsKey(i))
                {
                    D_midiIn.TryAdd(i, new MidiIn(i));
                    D_midiIn[i].MessageReceived += Midi.MessageReceived;
                    D_midiIn[i].Start();
                }

                return D_midiIn[i];
            }
            catch (Exception ex)
            {

                Utility.Print(ex);
                ClearMidiDevices();
            }
            return null;
        }
        public static MidiOut MidiOutDevice(int i)
        {
            try
            {
                if (!D_midiOut.ContainsKey(i))
                {
                    D_midiOut.TryAdd(i, new MidiOut(i));
                }

                return D_midiOut[i];
            }
            catch(Exception ex)
            {

                Utility.Print(ex);
              //  ClearMidiDevices();
            }
            return null;
        }
        public static void ResetMidiDevices()
        {
            foreach (var x in D_midiOut)
            {
                x.Value.Reset();
            }
            foreach (var x in D_midiIn)
            {
                x.Value.Reset();
            }

        }
        public static void ClearMidiDevices()
        {
            foreach (var x in D_midiOut)
            {
                try
                {
                    x.Value.Close();
                    x.Value.Dispose();
                }
                catch { }
            }
            D_midiOut.Clear();

            foreach (var x in D_midiIn)
            { try
                {
                x.Value.Close();
                x.Value.Dispose();
                }
            catch { }
            }
            D_midiIn.Clear();
        }
        private static void NoteOut(int note, int vel, int channel, int length, int device = 0)
        {

            MidiOutDevice(device).Send(MidiMessage.StartNote(note, vel, channel).RawData);
            System.Threading.Thread.Sleep(length);
            MidiOutDevice(device).Send(MidiMessage.StopNote(note, 0, channel).RawData);

        }
        private static void CCOut(int controller, int value, int channel, int device = 0)
        {

            MidiOutDevice(device).Send(MidiMessage.ChangeControl(controller, value, channel).RawData);

        }
        private static void PatchChange(int value, int channel, int device = 0)
        {

            MidiOutDevice(device).Send(MidiMessage.ChangePatch(value, channel).RawData);

        }
        public static void CCOut(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    CCOut(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Convert.ToInt16(words[2]),Midi.MidiOutDeviceNumber);
                }
                catch (Exception ex)
                {

                     TheVoid.Utility.Print("CCOut:", ex);
                }
            }).Start();
        }
        public static void NoteOut(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                try
                {
                    int n, v, c, l;
                    if (int.TryParse(words[0], out n) && int.TryParse(words[1], out v) && int.TryParse(words[2], out c) && int.TryParse(words[3], out l))
                    {
                        NoteOut(n,v,c,l, Midi.MidiOutDeviceNumber);
                    }
                    else
                    {
                        TheVoid.Utility.Print("NoteOut:","Failed to input:"+ allparams);
                    }
                }
                catch (Exception ex)
                {

                     TheVoid.Utility.Print("NoteOut:", ex);
                }
            }).Start();
        }
        public static void PatchChange(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    PatchChange(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Midi.MidiOutDeviceNumber);
                }
                catch (Exception ex)
                {

                     TheVoid.Utility.Print("PatchChange:", ex);
                }
            }).Start();
        }

        private static void MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            try
            {
                // Exit if the MidiEvent is null or is the AutoSensing command code  
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.AutoSensing)
                {
                    return;
                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.ControlChange)
                {
                    var x = ((ControlChangeEvent)e.MidiEvent);

                    if (x.Channel.Equals(Midi.MidiInChannelNumber))
                    {
                        Midi.SetCCValue((int)x.Controller, (int)x.ControllerValue);
                    }
                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.TimingClock)
                {
                    rawticks++;
                    if (rawticks % tickdivider == 0)
                    {
                    //    if (clockrunning )
                        {
                            Combustion.Tick();
                        }
                    }
                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.StartSequence)
                {
                    rawticks = 0;
                    clockrunning = true;
                    Combustion.Start();
                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.StopSequence)
                {
                    clockrunning = false;

                    Combustion.Stop();
                }
                else
                {
                //    Utility.Print(e.MidiEvent.ToString());
                //    Utility.Print(e.MidiEvent.CommandCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.Print(ex.Message);
            }
        }

    }

}
