using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid.CI
{
    public static class APC
    {


        public static bool GuessMidiPorts()
        {

            int i = 0;
            if (_midiportin == -1)
            {
                foreach (var x in TheVoid.Midi.GetMIDIInDevices())
                {
                    if (x.ToLower().Contains("apc") & x.ToLower().Contains("mini"))
                    {
                        Utility.Print("Found APC in");
                        _midiportin = i;
                        Midi.MidiInDevice(_midiportin).MessageReceived += APC.MessageReceived;
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
                        Utility.Print("Found APC out");
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


        public static void init()
        {

            var ran = new Random(DateTime.Now.Millisecond);

            //master page


            for (int i = 0; i < 8; i++)
            {
                _pages.Add(new Page() { Note = 36 + i });
                for (int x = 0; x < 4; x++)
                {
                    // _pages[i].Pattern.WriteStep(ran.Next(1, _pages[i].Pattern.Length), true);
                }
            }

            _pages.Add(new Page() { led = LED.Red, Note = 1 });
            _pages.LastOrDefault().Pattern.Length = 8;
            for (int i = 0; i < _pages.LastOrDefault().Pattern.Length; i++)
            {
                _pages.LastOrDefault().Pattern.WriteStep(i, true);
            }
            System.Threading.Thread.Sleep(300);
            _currentpage = 0;
            DrawCurrentPage();

        }
        private static int _midiportin = -1;
        private static int _midiportout = -1;
        private static List<Page> _pages = new List<Page>();
        private static int _currentpage;
        private static bool _shiftisdown = false;

        private static Dictionary<int, int> controlchangecache = new Dictionary<int, int>();
        private static Dictionary<int, int> notecache = new Dictionary<int, int>();
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
                    APC.SetCCValue((int)x.Controller, (int)x.ControllerValue);


                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
                {
                    var x = ((NoteOnEvent)e.MidiEvent);
                    if (_shiftisdown)
                    {
                        if (x.NoteNumber <= 63)
                        {
                            _pages[_currentpage].Pattern.Length = x.NoteNumber + 1;
                            Debug.WriteLine(_pages[_currentpage].Pattern.Length);
                        }

                    }
                    else if (x.NoteNumber == 83)
                    {
                        Page(_currentpage).Solo = !Page(_currentpage).Solo;
                        int i = 0;
                        while (i < _pages.Count)
                        {
                            if (i != _currentpage)
                            {
                                _pages[i].Solo = false;
                            }
                            i++;
                        }
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber == 89)
                    {
                        int i = 0;
                        while (i < _pages.Count)
                        {
                            if (i != _currentpage)
                            {
                                _pages[i].Pattern.Clear();
                            }
                            i++;
                        }
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber == 82)
                    {
                        Page(_currentpage).Pattern.Clear();
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber == 85)
                    {
                        Page(_currentpage).Mute = !Page(_currentpage).Mute;
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber <= 63)
                    {
                        MainGridHandler(x.NoteNumber);
                    }
                    else if (x.NoteNumber == 64)
                    {
                        _currentpage = (_currentpage + 1) % _pages.Count;
                        // System.Threading.Thread.Sleep(100);
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber == 65)
                    {
                        _currentpage = (_currentpage - 1) % _pages.Count;
                        if (_currentpage < 0)
                        {
                            _currentpage = _pages.Count - 1;
                        }
                        // System.Threading.Thread.Sleep(100);
                        DrawPage(_currentpage);
                    }
                    else if (x.NoteNumber == 98)
                    {
                        _shiftisdown = true;
                    }
                }
                else if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
                {
                    var x = ((NoteEvent)e.MidiEvent);

                    if (x.NoteNumber == 98)
                    {
                        _shiftisdown = false;
                    }
                }
                else
                {
                    //Utility.Print(e.MidiEvent.ToString());
                    //Utility.Print(e.MidiEvent.CommandCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.Print(ex.Message);
                Utility.Print(ex.Message);
            }
        }

        public static void SetCCValue(int CC, int value)
        {
            if (value > 127 | value < 0)
            {
                throw new Exception("CC value outside of range:" + CC + ":" + value);
            }

            if (!APC.controlchangecache.Keys.Contains(CC))
            {
                APC.controlchangecache.Add(CC, value);
            }
            APC.controlchangecache[CC] = value;
            if ((CC >= 48) && (CC <= 55))
            {
                _pages[CC - 48].Vel = value;
                if (_currentpage != CC - 48 & _shiftisdown)
                {
                    SelectPage(CC - 48);

                }
            }
        }

        public enum LED
        {
            Off = 0, Green = 1, GreenBlink = 2, Red = 3, RedBlink = 4, Yellow = 5, YellowBlink = 6
        }

        private static void SetLED(int note, LED led)
        {
            int channel = 1;

            if (!APC.notecache.Keys.Contains(note))
            {
                APC.notecache.Add(note, Convert.ToInt16(led));
            }
            else
            {
                Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StopNote(note, 0, channel).RawData);
                APC.notecache[note] = Convert.ToInt16(led);
            }

            if (led == 0)
            {
                Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StartNote(note, APC.notecache[note], channel).RawData);
                APC.notecache.Remove(note);
            }
            else
            {
                Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StartNote(note, APC.notecache[note], channel).RawData);
            }
        }


        private static void MainGridHandler(int note)
        {


            _pages[_currentpage].Pattern.WriteStep(note, !_pages[_currentpage].Pattern.RecallStep(note));
            DrawPage(_currentpage, false);

            // int col = -1;
            // if (APC.notecache.Keys.Contains(note))
            // {
            //     col = APC.notecache[note];
            // }
            // else
            // {
            //     col = 3;

            // }
            //// Debug.WriteLine(col);
            // if (col == 3)
            // {
            //     col = 5;
            // }
            // else if (col == 5)
            // {
            //     col = 1;
            // }
            // else if (col == 1)
            // {
            //     col = 0;
            // }
            // else if (col <= 0)
            // {
            //     col = 3;
            // }

            // Debug.WriteLine(col);
            //APC.SetLED(note, (LED)col);

        }

        public static void ClearBoard()
        {
            //  
            for (int note = 0; note <= 63; note++)
            {
                try
                {
                    //  Utility.Print(note);

                    Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StopNote(note, 0, 1).RawData);
                    Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StartNote(note, 0, 1).RawData);
                    Midi.MidiOutDevice(_midiportout).Send(MidiMessage.StopNote(note, 0, 1).RawData);
                }
                catch (Exception ex)
                {
                    Utility.Print(ex);
                }
            }
            notecache.Clear();

        }


        private static void DrawCurrentPage()
        {
            DrawPage(_currentpage);
        }

        private static void DrawPage(int number, bool clear = true)
        {
            Page page = _pages[number];
            if (clear)
            {
                System.Threading.Thread.Sleep(150);
                ClearBoard();
            }
            int i = 0;
            while (i <= page.Pattern.MaxSteps)
            {
                if (page.Pattern.RecallStep(i))
                {
                    SetLED(i, page.led);
                }
                else
                {
                    SetLED(i, LED.Off);
                }
                i++;
            }

            if (Page(_currentpage).Solo)
            {
                SetLED(83, LED.Red);
            }
            else
            {
                SetLED(83, LED.Off);
            }

            if (Page(_currentpage).Mute)
            {
                SetLED(85, LED.Red);
            }
            else
            {
                SetLED(85, LED.Off);
            }


        }

        public static List<TheVoid.CI.Page> ListPages()
        {
            return _pages;
        }

        public static Page Page(int i)
        {

            return _pages[i];
        }
        public static void SelectPage(int i)
        {
            if (_currentpage != i)
            {
                _currentpage = i;
                DrawCurrentPage();
            }

        }
    }
}
