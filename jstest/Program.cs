using System;
using Fungle.Core;

namespace jstest
{
    class Program
    {
      

        public static void Log(string message)
        {
            Console.WriteLine("LOG:" + message);
            System.Diagnostics.Debug.WriteLine("LOG:" + message);
        }

        static void Main(string[] args)
        {
            var engine = new Jurassic.ScriptEngine();
            engine.LoadFunctions();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower().Equals("exit"))
                {
                    break;
                }
                try
                {
                    string output = engine.Evaluate(input).ToString();
                    if (!output.Equals("undefined"))
                    {
                    Console.WriteLine(output);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
