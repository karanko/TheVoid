using JSBeautifyLib;

using NAudio.Midi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public static class  Combustion
    {

        private static ConcurrentDictionary<string, TheVoid.Engine> Engines = new ConcurrentDictionary<string, TheVoid.Engine>();
    //    public static Midi Midi;
        private static ConcurrentDictionary<string, object> GlobalVariables = new ConcurrentDictionary<string, object>();
        //public static ConcurrentDictionary<string, string> Functions = = new ConcurrentDictionary<string, string>();
        //public static List<string> ExecutingFunctions = new List<string>();

        //private static string Beautify(string script)
        //{
        //    return new JSBeautify(script, new JSBeautifyOptions { preserve_newlines = true }).GetResult();
        //}
        public static string TickFunction
        {
            get { return Options.Read("TickFunction", "bang()"); }
            set { Options.Write("TickFunction", value); }
        }
         public static List<string> ListEngines()  
         {
             return TheVoid.Combustion.Engines.Keys.ToList<string>();
         }
        public static void init()
        {

           // ExecutingFunctions 
        //    Midi = new Midi();
         //   Engines = 
            //GlobalVariables
            //Functions 
       
          //  Functions.TryAdd("dump", "x=(seed%tick);");
          // //- Functions.TryAdd("tick", "now = Date.now();");
          // // ExecutingFunctions.TryAdd("dump");
          ////  Functions.TryAdd("hhy", "uuyyy");
          //  if(System.IO.File.Exists("demofunction.txt"))
          //  {
          //      Functions.TryAdd("Demo", System.IO.File.ReadAllText("demofunction.txt"));
          //    //  ExecutingFunctions.TryAdd("Demo");
          //  }
          //  if (System.IO.File.Exists("demofunctiondrum.txt"))
          //  {
          //      Functions.TryAdd("DemoDrum", System.IO.File.ReadAllText("demofunctiondrum.txt"));
          //     // ExecutingFunctions.TryAdd("DemoDrum");
          //  }
            // Export my own api to the JavaScript world
        
              //CombustionMidi();

            /* create default engine */
         //   Execute("Default", "");

        }
        
        private static object GetVariable(string name,object isnotset)
        {
                        name = name.ToLower();
            if (!GlobalVariables.ContainsKey(name))
            {
                GlobalVariables.TryAdd(name, isnotset);
            }
            return GlobalVariables[name];
        }
        private static object SetVariable(string name,object value)
        {
            name = name.ToLower();
            if (!GlobalVariables.ContainsKey(name))
            {
                GlobalVariables.TryAdd(name, value);
            }
            else
            {
                GlobalVariables[name] = value;
            }
            return GlobalVariables[name];
        }
        

        private static TheVoid.Engine Engine(string enginename)
        {
            enginename = enginename.ToLower();
            if (!Engines.ContainsKey(enginename))
            {
                Engines.TryAdd(enginename, new TheVoid.Engine());               
            }
           
            return Engines[enginename];
        }
        //public static void Execute(string script)
        //{
        //    Execute("default", script);
        //}
        public static void Execute(string enginename ,string script,string user = "unknown")
        {
            try
            {
                Engine(enginename).Execute(script, user);
            }
            catch(Exception ex)
            {
                Utility.Print(ex.Message);
                Utility.Print(script);
            }
        }
        //public static string  Evaluate( string script)
        //{
        //   return  Evaluate("default", script);
        //}
        public static string Evaluate(string enginename, string script, string user = "unknown")
        {
            try
            {

                return Engine(enginename).Evaluate(script,user);
                
            }
            catch (Exception ex)
            {
                Utility.Print(ex.Message);
                return null;
            }
        }
        private static void SetGlobalVariables()
        {
            SetAllVariables(GlobalVariables);
        }
        private static void SetAllVariables(ConcurrentDictionary<string, object> globaloverride)
        {
            foreach (var e in Engines.Values)
            {
                foreach (var v in globaloverride)
                {
                    e.SetGlobalValue(v.Key, v.Value);
                }
            }
        }

     /*   public static string BuildArray(string arrayname, int[] ooo)
        {
            string result = arrayname + " = [];";
            int i = 1;
            foreach (var x in ooo)
            {
                result += arrayname + "[" + i.ToString() + "] = " + x.ToString() + ";";
            }
            return result;
        }*/
      /*  private static void SetFunctions()
        {
            try
            {
                foreach (var e in Engines.Values)
                {
                    try
                    {
                        foreach (var v in Functions)
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
        */
        public static void Stop()
        {
            try
            {
                SetVariable("tick", -1);
                SetGlobalVariables();
                //SetFunctions();
                Utility.Print("Stop");

            }
            catch (Exception ex)
            {

                Utility.Print(ex.Message);
            }
        }
  
        public static void Start()
        {
            try
            {
                SetVariable("tick", 0);
                SetGlobalVariables();
                //SetFunctions();
                /*  foreach (var x in ExecutingFunctions)
                  {

                      Execute(x.ToLower(), x + "();");

                      //    new Thread(thisthing).Start();
                  }*/
                Utility.Print("Start");

            }
            catch (Exception ex)
            {

                Utility.Print(ex.Message);
            }
        }
        public static void Tick()
        {
            try
            {
                SetVariable("tick", (int)GetVariable("tick", 0) + 1);
                SetGlobalVariables();
                //SetFunctions();
                /*  foreach (var x in ExecutingFunctions)
                  {

                      Execute(x.ToLower(), x + "();");

                      //    new Thread(thisthing).Start();
                  }*/
            }
            catch (Exception ex)
            {

                Utility.Print(ex.Message);
            }
            foreach (var x in ListEngines())
            {
                try
                {
                    Execute(x, Combustion.TickFunction + ";");
                }
                catch (Exception ex)
                {

                    Utility.Print(ex.Message);
                }
            }

        }
    }

}
