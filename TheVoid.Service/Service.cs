using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TheVoid.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService
    {
   
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

        public void CreateArray(string engine,string name,int[] array)
        {
       //     string arraystring = TheVoid.Combustion.BuildArray(name,array);
         //   TheVoid.Combustion.Execute(engine, arraystring);

        }
        public string[] ListMessages(int lastmessage = 0)
        {
           
              
                    return Utility.Messages.ToArray();
               
          
        }

 
    }
}
