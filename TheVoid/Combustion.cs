using Jurassic;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public partial class  Combustion
    {

        private Dictionary<string, ScriptEngine> Engines;
        private Dictionary<string, Delegate> functiondelegates = new Dictionary<string,Delegate>();
        private Dictionary<string, string> functionalias = new Dictionary<string, string>();
    //    public Midi Midi;
        public Dictionary<string, object> GlobalVariables;
        public Dictionary<string, string> Functions;
        public List<string> ExecutingFunctions;

        public Combustion()
        {
            this.ExecutingFunctions = new List<string>();
        //    this.Midi = new Midi();
            this.Engines =  new Dictionary<string, Jurassic.ScriptEngine>();
            this.GlobalVariables = new Dictionary<string, object>();
            this.Functions = new Dictionary<string, string>();
            this.GlobalVariables.Add("seed", new Random().Next(1, 30));
            this.Functions.Add("dump", "x=(seed%tick);");
           // this.ExecutingFunctions.Add("dump");
          //  this.Functions.Add("hhy", "uuyyy");
            if(System.IO.File.Exists("demofunction.txt"))
            {
                this.Functions.Add("Demo", System.IO.File.ReadAllText("demofunction.txt"));
                this.ExecutingFunctions.Add("Demo");
            }
            if (System.IO.File.Exists("demofunctiondrum.txt"))
            {
                this.Functions.Add("DemoDrum", System.IO.File.ReadAllText("demofunctiondrum.txt"));
                this.ExecutingFunctions.Add("DemoDrum");
            }

            functiondelegates.Add("log", new Action<string>(str => System.Diagnostics.Debug.WriteLine(str)));
            functiondelegates.Add("ConsoleBeep", new Action<int>(i1 => Console.Beep(i1, 200)));
            functiondelegates.Add("Exec", new Action<string>(code => this.Engines["master"].Evaluate(code)));
            functiondelegates.Add("Include", new Action<string>(path => this.Engines["master"].Evaluate(new System.Net.WebClient().DownloadString(path))));

            functionalias.Add("Require", "function Require(path){Include(path);}");
            functionalias.Add("include", "function include(path){Include(path);}");
            functionalias.Add("require", "function require(path){Include(path);}");
            functionalias.Add("Load", "function Load(path){Include(path);}");
            functionalias.Add("load", "function load(path){Include(path);}");
            CombustionMidi();
        }
        
        private object GetVariable(string name,object isnotset)
        {
                        name = name.ToLower();
            if (!this.GlobalVariables.ContainsKey(name))
            {
                this.GlobalVariables.Add(name, isnotset);
            }
            return this.GlobalVariables[name];
        }
        private object SetVariable(string name,object value)
        {
            name = name.ToLower();
            if (!this.GlobalVariables.ContainsKey(name))
            {
                this.GlobalVariables.Add(name, value);
            }
            else
            {
                this.GlobalVariables[name] = value;
            }
            return this.GlobalVariables[name];
        }
        

        private ScriptEngine Engine(string enginename)
        {
            enginename = enginename.ToLower();
            if (!this.Engines.ContainsKey(enginename))
            {
                this.Engines.Add(enginename, new ScriptEngine());

                 foreach (var Function in functiondelegates)
                 {
                     Debug.WriteLine("Loading Function:" + Function.Key);
                      this.Engines[enginename].SetGlobalFunction(Function.Key, Function.Value);
                 }
                 foreach (var Function in functionalias)
                 {
                       Debug.WriteLine("Loading Alias:" + Function.Key);
                      this.Engines[enginename].Execute(Function.Value);
                 }
                
            }
           
            return this.Engines[enginename];
        }
        public void Execute(string enginename,string script)
        {
            try
            {
                this.Engine(enginename).Execute(script);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void SetGlobalVariables()
        {
            SetAllVariables(GlobalVariables);
        }
        private void SetAllVariables(Dictionary<string, object> globaloverride)
        {
            foreach (var e in this.Engines.Values)
            {
                foreach (var v in globaloverride)
                {
                    e.SetGlobalValue(v.Key, v.Value);
                }
            }
        }        
        private void SetFunctions()
        {
            try
            {
                foreach (var e in this.Engines.Values)
                {
                    try
                    {
                        foreach (var v in this.Functions)
                        {
                            try
                            {
                                e.Execute("function " + v.Key + "(){" + v.Value + "}");
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        /*
        public void AddGlobalVariable(string s, object o )
        {

            GlobalVariables.Add(s,o);

        }*/

        public void tickhandler(object source, System.Timers.ElapsedEventArgs e)
        {
            SetVariable("tick",(int)GetVariable("tick", 0) + 1);
            this.SetGlobalVariables();
            SetFunctions();
            foreach (var x in this.ExecutingFunctions)
            {
               
                    this.Execute(x.ToLower(), x + "();");
              
                //    new Thread(this.thisthing).Start();
            }
        }
    }

}
