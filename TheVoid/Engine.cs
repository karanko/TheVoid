using JSBeautifyLib;
using Jurassic;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public class Engine
    {
        private static ConcurrentDictionary<string,string> ListFunctionsInCode(string code)
        {
            ConcurrentDictionary<string, string> result = new ConcurrentDictionary<string, string>();


            foreach( var x in code.Replace("function", "^").Split('^'))
            {
               
                    if (x.Trim().IndexOf("{") > 0)
                    {
                        string y = x.Substring(0, x.Trim().IndexOf("{") + 1).Trim();
                        string z = y.Substring(0, y.Trim().IndexOf("(")).Trim();
                        //   Utility.Print(x);
                      //  Utility.Print(y);
                      //  Utility.Print(z);
                        result.TryAdd(z," function "+x);
                    }
                
            }
            return result;

        }
        private static string Beautify(string script)
        {
            return new JSBeautify(script, new JSBeautifyOptions { preserve_newlines = true }).GetResult();
        }

     //   public string Name;
        private  ConcurrentDictionary<string, Delegate> functiondelegates
        {
            get
            {
                var fd = new ConcurrentDictionary<string, Delegate>();
                fd.TryAdd("GetMIDIInDevices", new Func<string, string>(str => JsonConvert.SerializeObject(Midi.GetMIDIInDevices())));
                fd.TryAdd("GetMIDIOutDevices", new Func<string, string>(str => JsonConvert.SerializeObject(Midi.GetMIDIOutDevices())));
                fd.TryAdd("ResetMidiDevices", new Action<string>(str => Midi.ResetMidiDevices()));
                fd.TryAdd("ClearMidiDevices", new Action<string>(str => Midi.ClearMidiDevices()));
                fd.TryAdd("broadcast", new Action<string>(str => Sockets.UDPClientSimple(str)));
             

                fd.TryAdd("log", new Action<string>(str => Utility.Print(str)));
                fd.TryAdd("cls", new Action<string>(i1 => TheVoid.Utility.Messages.Clear()));
            //    fd.TryAdd("SetBPM", new Action<int>(i1 => Midi.SyncOutBPM(i1)));
            //    fd.TryAdd("ClockRun", new Action<bool>(i1 => Midi.SyncOutClock(i1)));
                fd.TryAdd("ConsoleBeep", new Action<int>(i1 => Console.Beep(i1, 200)));
                fd.TryAdd("Exec", new Action<string>(code => this.Evaluate( code)));
                fd.TryAdd("Include", new Action<string>(path => this.Evaluate( new System.Net.WebClient().DownloadString(path))));
                fd.TryAdd("readcache", new Func<string, string>(path => Beautify(System.IO.File.ReadAllText(@"cache.js"))));
                fd.TryAdd("savetocache", new Action<string>(str => System.IO.File.WriteAllText(@"cache.js", Beautify(str))));
                fd.TryAdd("echotest", new Func<string, string>(str => str.ToString()));
                
                fd.TryAdd("NoteOutRaw", new Action<string>(i1 => Midi.NoteOut(i1)));
                fd.TryAdd("CCOutRaw", new Action<string>(i1 => Midi.CCOut(i1)));
                fd.TryAdd("PatchChangeRaw", new Action<string>(i1 => Midi.PatchChange(i1)));
                fd.TryAdd("CCIn", new Action<int>(i1 => Midi.GetCCValue(i1)));

                // apc

                fd.TryAdd("apcpageraw", new Func<int, string>(str => JsonConvert.SerializeObject(CI.APC.Page(str))));
                fd.TryAdd("apcselectpage", new Action<int>(str => CI.APC.SelectPage(str)));
                fd.TryAdd("apcclearpage", new Action<int>(i => CI.APC.Page(i).Pattern.Clear()));
                fd.TryAdd("apcpatternraw", new Func<string, bool>(str => CI.APC.Page(Convert.ToInt16(str.Split('|')[0])).Pattern.RecallStep(Convert.ToInt16(str.Split('|')[1]))));
                
            
                //ui helpers
                fd.TryAdd("listprintmessagesjson", new Func<string, string>(str => JsonConvert.SerializeObject(TheVoid.Utility.Messages.ToArray())));
                fd.TryAdd("listbuiltinfunctionalias", new Func<string, string>(str => JsonConvert.SerializeObject(this.functionalias.Keys.ToArray())));
                fd.TryAdd("listbuiltinfunctiondelegates", new Func<string, string>(str => JsonConvert.SerializeObject(this.functiondelegates.Keys.ToArray())));


                // database
                fd.TryAdd("dbstore", new Func<string, object, bool >((s1,s2) => Database.Store(s1,s2)));
                fd.TryAdd("dbrecall", new Func<string, object, object>((s1,s2) => Database.Recall(s1,s2)));


                return fd;
            }
        }
        private  ConcurrentDictionary<string, string> functionalias
        {
            get
            {
                var fa = new ConcurrentDictionary<string, string>();
                fa.TryAdd("print", "function print(){log();}");
                //midi sync

                //fa.TryAdd("setbpm", "function setbpm(value){SetBPM(value);}");

                fa.TryAdd("clockrun", "function clockrun(value){ClockRun(value);}");
                fa.TryAdd("loadtocache", "function loadtocache(path){Include('cache.js');}");


               // fa.TryAdd("Require", "function Require(path){Include(path);}");
                fa.TryAdd("include", "function include(path){Include(path);}");
                fa.TryAdd("require", "function require(path){Include(path);}");
           //     fa.TryAdd("Load", "function Load(path){Include(path);}");
             //   fa.TryAdd("load", "function load(path){Include(path);}");
                //fa.TryAdd("CLS", "function CLS(){cls();}");
                fa.TryAdd("noteout", "function noteout(note,vel,channel,length){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length);}");
                //fa.TryAdd("NoteOut", "function NoteOut(note,vel,channel,length){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length);}");


                fa.TryAdd("ccin", "function ccin(value){CCIn(value);}");

               // fa.TryAdd("CCOut", "function CCOut(controller,value,channel){CCOutRaw(controller+'|'+value+'|'+channel);}");
                fa.TryAdd("ccout", "function ccout(controller,value,channel){CCOutRaw(controller+'|'+value+'|'+channel);}");
                //fa.TryAdd("PatchChange", "function PatchChange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.TryAdd("patchchange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.TryAdd("programchange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
               // fa.TryAdd("ProgramChange", "function patchchange(value,channel){PatchChangeRaw(value+'|'+channel);}");
                fa.TryAdd("apcpatternraw", "function apcpat(page,step){return apcpatternraw(page+'|'+step);}");

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
