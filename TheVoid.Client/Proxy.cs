using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVoid.Client.Service;

namespace TheVoid.Client
{
    public class Proxy
    {
        public static TheVoid.Client.Service.ServiceClient Service = new TheVoid.Client.Service.ServiceClient();

        public static Page[] listAPCPages()
        {
            return Service.APCPages();
        }
        public static void Execute(string engine, string command)
        {
            Service.Execute(engine, command);
        }
        public static void Execute(string command)
        {
            Service.Execute("default", command);
        }
        public static string Evaluate(string command)
        {
            return Service.Evaluate("default", command);
        }

        public static string Evaluate(string engine, string command)
        {
       
            return Service.Evaluate(engine, command);
        }

        public static string[] Engines()
        {
            return Service.ListEngines();
        }

        public static string[] ListAllMessages()
        {
            return Service.Evaluate("default","JSON.parse(listprintmessagesjson());").Replace(Environment.NewLine, String.Empty).Split(',');
        }
        //    public static string[] ListLastMessages(int count)
        //    {
        //        string[] m = Service.ListMessages(0);
        //         count =  m.Count()-count;
        //        if(count < 0)
        //        {
        //            count = 0;
        //        }
        //        return m.Skip(count).ToArray();        

        //    }
    }
}
