using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static public MidiIn midiIn;
        static int rawticks;
        static int clockticks;

        public static void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            try
            {
                // Exit if the MidiEvent is null or is the AutoSensing command code  
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.AutoSensing)
                {
                    return;
                }

                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.StartSequence)
                {
                    Console.WriteLine("Start");
                    rawticks = -1;
                    clockticks = -1;

                } 
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.StopSequence)
                {
                    Console.WriteLine("Stop");
                    rawticks = -1;

                }
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.ContinueSequence)
                {
                    Console.WriteLine("ContinueSequence");
                   

                }
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.MetaEvent)
                {
                    Console.WriteLine(e.MidiEvent.GetAsShortMessage());
                }
              
                if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.TimingClock)
                {
                    rawticks++;
                    if (rawticks%6 == 0 &&  clockticks != ((rawticks/6)+1)%32)
                    {
                        clockticks = ((rawticks/6))%32;
                        Console.WriteLine("clockticks:" + clockticks);

                    }
                //    Console.WriteLine(e.MidiEvent.AbsoluteTime);
                    
                  //  Console.WriteLine("rawticks:" + rawticks);
                  
                }

        
             /*   Console.WriteLine(e.MidiEvent.ToString());* 
                Console.WriteLine(e.MidiEvent.CommandCode.ToString());
              */
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }
       /* public static void StartMonitoring(int MIDIInDevice)
        {
            if (midiIn == null)
            {
                midiIn = new MidiIn(MIDIInDevice);
            }
            midiIn.Start();
            monitoring = true;
        }*/
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
        static void Main(string[] args)
        {
            foreach (var x in GetMIDIInDevices())
            {
                Console.WriteLine(x);

            }
            midiIn = new MidiIn(3);
            midiIn.Start();
        
          //  StartMonitoring(1);

            // Add the event handler, to handle the MIDI messages received 
            midiIn.MessageReceived += new EventHandler<MidiInMessageEventArgs>(midiIn_MessageReceived);
            Console.ReadLine();
        }


    }
}
