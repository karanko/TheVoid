using System;

namespace TheVoid.Client
{
    public class Proxy
    {
        public static TheVoid.Client.ServiceProxy.ServiceClient _service = new TheVoid.Client.ServiceProxy.ServiceClient();

        public static TheVoid.Client.ServiceProxy.Page[] listAPCPages()
        {
            return _service.APCPages();
        }
        public static void Execute(string engine, string command)
        {
            _service.Execute(engine, command);
        }
        public static void Execute(string command)
        {
            _service.Execute("default", command);
        }
        public static string Evaluate(string command)
        {
            return _service.Evaluate("default", command);
        }

        public static string Evaluate(string engine, string command)
        {

            return _service.Evaluate(engine, command);
        }

        public static string[] Engines()
        {
            return _service.ListEngines();
        }

        public static string[] ListAllMessages()
        {
            return _service.Evaluate("default", "JSON.parse(listprintmessagesjson());").Replace(Environment.NewLine, String.Empty).Split(',');
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
