using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WCFTest;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://127.0.0.1:8181/hello");

            using (ServiceHost host = new ServiceHost(typeof(WCFTest.Service), baseAddress))
            {

                host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), "Service");

                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
