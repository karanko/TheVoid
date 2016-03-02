using JSBeautifyLib;
using Jurassic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public class Engine
    {
        private static Dictionary<string,string> ListFunctionsInCode(string code)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();


            foreach( var x in code.Replace("function", "^").Split('^'))
            {
               
                    if (x.Trim().IndexOf("{") > 0)
                    {
                        string y = x.Substring(0, x.Trim().IndexOf("{") + 1).Trim();
                        string z = y.Substring(0, y.Trim().IndexOf("(")).Trim();
                        //   Utility.Print(x);
                      //  Utility.Print(y);
                      //  Utility.Print(z);
                        result.Add(z," function "+x);
                    }
                
            }
            return result;

        }
        private static string Beautify(string script)
        {
            return new JSBeautify(script, new JSBeautifyOptions { preserve_newlines = true }).GetResult();
        }

     //   public string Name;
        private  Dictionary<string, Delegate> functiondelegates
        {
            get
            {
                var fd = new Dictionary<string, Delegate>();
                fd.Add("GetMIDIInDevices", new Func<string, string>(str => JsonConvert.SerializeObject(Midi.GetMIDIInDevices())));
                fd.Add("GetMIDIOutDevices", new Func<string, string>(str => JsonConvert.SerializeObject(Midi.GetMIDIOutDevices())));
                fd.Add("ResetMidiDevices", new Action<string>(str => Midi.ResetMidiDevices()));
                fd.Add("ClearMidiDevices", new Action<string>(str => Midi.ClearMidiDevices()));
                fd.Add("broadcast", new Action<string>(str => Sockets.UDPClientSimple(str)));
             

                fd.Add("log", new Action<string>(str => Utility.Print(str)));
                fd.Add("cls", new Action<string>(i1 => TheVoid.Utility.Messages.Clear()));
                fd.Add("SetBPM", new Action<int>(i1 => Midi.SyncOutBPM(i1)));
                fd.Add("ClockRun", new Action<bool>(i1 => Midi.SyncOutClock(i1)));
                fd.Add("ConsoleBeep", new Action<int>(i1 => Console.Beep(i1, 200)));
                fd.Add("Exec", new Action<string>(code => this.Evaluate( code)));
                fd.Add("Include", new Action<string>(path => this.Evaluate( new System.Net.WebClient().DownloadString(path))));
                fd.Add("readcache", new Func<string, string>(path => Beautify(System.IO.File.ReadAllText(@"cache.js"))));
                fd.Add("savetocache", new Action<string>(str => System.IO.File.WriteAllText(@"cache.js", Beautify(str))));
                fd.Add("echotest", new Func<string, string>(str => str.ToString()));
                
                fd.Add("NoteOutRaw", new Action<string>(i1 => Midi.NoteOut(i1)));
                fd.Add("CCOutRaw", new Action<string>(i1 => Midi.CCOut(i1)));
                fd.Add("PatchChangeRaw", new Action<string>(i1 => Midi.PatchChange(i1)));
                fd.Add("CCIn", new Action<int>(i1 => Midi.GetCCValue(i1)));

                // apc
                fd.Add("apcpageraw", new Func<int, string>(str => JsonConvert.SerializeObject(CI.APC.Page(str))));
                fd.Add("apcselectpage", new Action<int>(str => CI.APC.SelectPage(str)));
                fd.Add("apcclearpage", new Action<int>(i => CI.APC.Page(i).Pattern.Clear()));
                fd.Add("apcpatternraw", new Func<string, bool>(str => CI.APC.Page(Convert.ToInt16(str.Split('|')[0])).Pattern.RecallStep(Convert.ToInt16(str.Split('|')[1]))));

                //ui helpers
                fd.Add("listprintmessagesjson", new Func<string, string>(str => JsonConvert.SerializeObject(TheVoid.Utility.Messages.ToArray())));
                
                return fd;
            }
        }
        private  Dictionary<string, string> functionalias
        {
            get
            {
                var fa = new Dictionary<string, string>();
                fa.Add("print", "function print(){log();}");
                //midi sync

                //fa.Add("setbpm", "function setbpm(value){SetBPM(value);}");

                fa.Add("clockrun", "function clockrun(value){ClockRun(value);}");
                fa.Add("loadtocache", "function loadtocache(path){Include('cache.js');}");


               // fa.Add("Require", "function Require(path){Include(path);}");
                fa.Add("include", "function include(path){Include(path);}");
                fa.Add("require", "function require(path){Include(path);}");
           //     fa.Add("Load", "function Load(path){Include(path);}");
             //   fa.Add("load", "function load(path){Include(path);}");
                //fa.Add("CLS", "function CLS(){cls();}");
                fa.Add("noteout", "function noteout(note,vel,channel,length){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length);}");
                //fa.Add("NoteOut", "function NoteOut(note,vel,channel,length){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length);}");


                fa.Add("ccin", "function ccin(value){CCIn(value);}");

               // fa.Add("CCOut", "function CCOut(controller,value,channel){CCOutRaw(controller+'|'+value+'|'+channel);}");
                fa.Add("ccout", "function ccout(controller,value,channel){CCOutRaw(controller+'|'+value+'|'+channel);}");
                //fa.Add("PatchChange", "function PatchChange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.Add("patchchange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.Add("programchange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
               // fa.Add("ProgramChange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.Add("apcpatternraw", "function apcpat(page,step){return apcpatternraw(page+'|'+step);}");

                return fa;
            }
        }

        public  string Evaluate(string script)
        {
          //  ListFunctionsInCode(script);
            return Beautify(_engine.Evaluate(Beautify(script)).ToString());
        }
        public  void Execute(string script)
        {
           // ListFunctionsInCode(script);

            _engine.Execute(Beautify(script));
        }

        public Engine()
        {
            _engine = new ScriptEngine();
            if (!_engine.HasGlobalValue("EngineIsInitialised"))
            {
                Utility.Print("Initialising");

                _engine.SetGlobalValue("EngineIsInitialised", true);
                _engine.SetGlobalValue("seed", new Random().Next(1, 9000));


                foreach (var Function in functiondelegates)
                {
                    try
                    {
                        if (Utility.GetConfigSettingBool("Verbose", false))
                        {
                            Utility.Print("Loading Function:", Function.Key);
                        }
                        _engine.SetGlobalFunction(Function.Key, Function.Value);
                    }
                    catch (Exception ex) { Utility.Print(ex.Message); }
                }

                foreach (var Function in functionalias)
                {
                    try
                    {
                        if (Utility.GetConfigSettingBool("Verbose", false))
                        {
                        Utility.Print("Loading Alias:" + Function.Key);
                        }
                        _engine.Execute(Function.Value);
                    }
                    catch (Exception ex) { Utility.Print(ex.Message); }
                }
            
                foreach (var Function in ListFunctionsInCode( Properties.Resources.InternalFunctions))
                {
                    try
                    {
                        Utility.Print("Loading InternalFunctions:", Function.Key);
                        _engine.Execute(Function.Value);
                    }
                    catch (Exception ex) { Utility.Print(ex.Message); }
                }
/*
                string code = System.IO.File.ReadAllText("cache.js");
                foreach (var Function in ListFunctionsInCode(code))
                {
                      try
                    {
                        Utility.Print("Loading FunctionFromFile:", Function.Key);
                    _engine.Execute(Function.Value);
                    }
                      catch (Exception ex) { Utility.Print(ex.Message); }
                }
                */
                
            }
        }

        private ScriptEngine _engine;

        // proxy
        public void SetGlobalValue(string variableName, object value) { _engine.SetGlobalValue(variableName, value); }
    }

}
