using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid.Console
{
    class Program
    {
        static void Main(string[] args)
        {
       
            TheVoid.Client.Service.ServiceClient service =  new TheVoid.Client.Service.ServiceClient();
            while (true)
            {
                try
                {
                    System.Console.WriteLine(service.Evaluate("default", System.Console.ReadLine()));
                }
                catch (Exception ex) { System.Console.WriteLine(ex.Message); }
            }
        
        }
    }
}
