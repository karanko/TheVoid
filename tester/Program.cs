using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {

            using (JavascriptContext context = new JavascriptContext())
            {
               
               
                // Setting external parameters for the context
                context.SetParameter("SP", new System.Media.SoundPlayer());
                context.SetParameter("message", "Hello World !");
                context.SetParameter("number", 1);
                while (true)
                {
                    // Script
                    string script = Console.ReadLine();

                    // Running the script
                 //   context.Run(script);
                    try
                    {
                        // Getting a parameter
                        Console.WriteLine(context.Run(script));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        
                    }
                }
            }
        }
    }


}
