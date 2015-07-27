using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public static class Extend
    {
        //    public static Jurassic.ScriptEngine LoadFunctions(this Jurassic.ScriptEngine engine)
        //    {


        //        var GlobalFunctions = new List<KeyValuePair<string, Delegate>>() { 
        //            new KeyValuePair<string, Delegate>("ConsoleBeep", new Action<int>(i1 => Console.Beep(i1, 200))),
        //      //      new KeyValuePair<string, Delegate>("NoteOutRaw", new Action<string>(i1 => NoteOut(i1))),
        //            new KeyValuePair<string, Delegate>("Log", new Action<string>(message =>  Server.UDPSend(System.Net.IPAddress.Parse("255.255.255.255"), 514, message))), //use syslog port
        //            new KeyValuePair<string, Delegate>("UDPSendL", new Action<string>(message =>  Server.UDPSend(System.Net.IPAddress.Parse("127.0.0.1"), 9051, message))), //use syslog port
        //            new KeyValuePair<string, Delegate>("m", new Action<string>(message =>  Server.UDPSend(System.Net.IPAddress.Parse("192.168.0.10"), 5140, message))), //use syslog port

        //            new KeyValuePair<string, Delegate>("ConsoleLog", new Action<string>(str => ConsoleLog(str))),
        //            new KeyValuePair<string, Delegate>("Exec", new Action<string>(code => engine.Evaluate(code))),
        //            new KeyValuePair<string, Delegate>("Include", new Action<string>(path => engine.Evaluate(new System.Net.WebClient().DownloadString(path)))),             
        //        };
        //        foreach (var Function in GlobalFunctions)
        //        {
        //            ConsoleLog("Loading Function:" + Function.Key);
        //            engine.SetGlobalFunction(Function.Key, Function.Value);
        //        }

        //        var Alias = new List<KeyValuePair<string, string>>() { 
        //            new KeyValuePair<string, string>("Require", "function Require(path){Include(path);}"),
        //            new KeyValuePair<string, string>("Load", "function Load(path){Include(path);}"),
        //            new KeyValuePair<string, string>("Note", "function Note(key,oct){return (oct*12)+key;}"),
        //            new KeyValuePair<string, string>("s", "function s(message){UDPSendL(message)}"),
        //            new KeyValuePair<string, string>("noteout", "function noteout(note,vel,channel,length,device){NoteOutRaw(note+'|'+vel+'|'+channel+'|'+length+'|'+device);}"),

        //        };
        //        foreach (var Function in Alias)
        //        {
        //            ConsoleLog("Loading Alias:" + Function.Key);
        //            engine.Evaluate(Function.Value);
        //        }
        //        return engine;
        //    }

        //    static void ConsoleLog(string message)
        //    {
        //        Console.WriteLine("LOG:" + message);
        //        System.Diagnostics.Debug.WriteLine("LOG:" + message);
        //    }
        //}
    }
}