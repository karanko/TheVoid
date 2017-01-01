using Bespoke.Common;
using Bespoke.Common.Osc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid
{
    public class OSC
    {
        private  OscServer oscServer;
        private  readonly int Port = 9001;
		private  readonly string AliveMethod = "/osctest/alive";
        private  readonly string TestMethod = "/osctest/test";

        private  int sBundlesReceivedCount;
        private  int sMessagesReceivedCount;
        private string BuildObjectUpdateString(string Address, IList<object> objs)
        {
            string result;
            try
            {
                result = Address.TrimStart('/').TrimEnd('/').Replace('/', '.');
                // int c = objs.Count
                for (int i = 0; i < (objs.Count - 1); i++)
                {

                    if (objs[i] != null)
                    {
                        string dataString = (objs[i] is byte[] ? BitConverter.ToString((byte[])objs[i]) : objs[i].ToString());


                        result = result + "." + dataString.Trim();

                    }
                }

                string dataString2 = (objs[objs.Count - 1] is byte[] ? BitConverter.ToString((byte[])objs[objs.Count - 1]) : objs[objs.Count - 1].ToString());

                result = "dotted_put('" + result + "', " + dataString2 + ");";


                //Utility.Print(result);
                return result;

            }
            catch (Exception ex) { Utility.Print(ex.Message);
           }
            return null;

        }
        public void Start()
        {
            Utility.Print("Starting OSC Server:" + oscServer.TransportType.ToString() + ":" + oscServer.Port.ToString());
            oscServer.Start();

        }
        public void Stop()
        {
            oscServer.Stop();

        }
        public OSC()
        {
            oscServer = new OscServer(TransportType.Udp, IPAddress.Loopback, Port);
            oscServer.FilterRegisteredMethods = false;
            oscServer.RegisterMethod(AliveMethod);
            oscServer.RegisterMethod(TestMethod);
            oscServer.BundleReceived += new EventHandler<OscBundleReceivedEventArgs>(oscServer_BundleReceived);
            oscServer.MessageReceived += new EventHandler<OscMessageReceivedEventArgs>(oscServer_MessageReceived);
            oscServer.ReceiveErrored += new EventHandler<ExceptionEventArgs>(oscServer_ReceiveErrored);
            oscServer.ConsumeParsingExceptions = false;

        }
             private  void oscServer_BundleReceived(object sender, OscBundleReceivedEventArgs e)
        {
            sBundlesReceivedCount++;

            OscBundle bundle = e.Bundle;
                 
             Utility.Print(String.Format("\nBundle Received [{0}:{1}]: Nested Bundles: {2} Nested Messages: {3}", bundle.SourceEndPoint.Address, bundle.TimeStamp, bundle.Bundles.Count, bundle.Messages.Count));
          //  Console.WriteLine("Total Bundles Received: {0}", sBundlesReceivedCount);
        }

		private  void oscServer_MessageReceived(object sender, OscMessageReceivedEventArgs e)
		{
            sMessagesReceivedCount++;
            OscMessage message = e.Message;

          //  Console.WriteLine(string.Format("\nMessage Received [{0}]: {1}", message.SourceEndPoint.Address, message.Address));
           // Console.WriteLine(string.Format("Message contains {0} objects.", message.Data.Count));
            Combustion.Execute( "default",BuildObjectUpdateString( message.Address,message.Data ),"system");
              /*   
            for (int i = 0; i < message.Data.Count; i++)
            {
                string dataString = "Nil";


                if (message.Data[i] != null)
           
                {
                    try
                    {
                        dataString = (message.Data[i] is byte[] ? BitConverter.ToString((byte[])message.Data[i]) : message.Data[i].ToString());
       //                 TheVoid.Client.Proxy.Execute(string.Format("{0} = '{1}';", message.Address.Replace(@"/","").Trim().ToLower(), dataString));
                    }
                    catch(Exception ex)
                    { System.Diagnostics.Debug.WriteLine(ex.Message); }
                }
                Console.WriteLine(string.Format("[{0}]: {1}", i, dataString));
            }

            Console.WriteLine("Total Messages Received: {0}", sMessagesReceivedCount);
            */
		}
        private  void oscServer_ReceiveErrored(object sender, ExceptionEventArgs e)
        {
            Utility.Print(String.Format("Error during reception of packet: {0}", e.Exception.Message));
        }
    }
}
