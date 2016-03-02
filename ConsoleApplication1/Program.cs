using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TheVoid.CI.APC.ClearBoard();
            TheVoid.CI.APC.GuessMidiPorts();
            TheVoid.CI.APC.init();
            Console.ReadLine();
            TheVoid.CI.APC.ClearBoard();

        }
    }
}
