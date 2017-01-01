using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TheVoid.Service
{
  
    public class Service : IService
    {
        public List<TheVoid.CI.Page> APCPages()
        {
            return TheVoid.CI.APC.ListPages();
        }
   
        public List<string> ListEngines()
        {
            return TheVoid.Combustion.ListEngines();
        }
        public void Execute(string engine, string command)
        {
            TheVoid.Combustion.Execute(engine, command);
        }

        public string Evaluate(string engine, string command)
        {
            return TheVoid.Combustion.Evaluate(engine, command);
        }
        public void CreateEngines(string engine)
        {
            TheVoid.Combustion.Execute(engine, "enginecreatedon = Date.now();");
        }

       // public void CreateArray(string engine,string name,int[] array)
       // {
       ////     string arraystring = TheVoid.Combustion.BuildArray(name,array);
       //  //   TheVoid.Combustion.Execute(engine, arraystring);

       // }
        public string[] ListMessages(int lastmessage = 0)
        {
            return Utility.Messages.ToArray();            
        }

 
    }
}
