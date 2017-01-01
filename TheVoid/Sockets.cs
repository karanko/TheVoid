using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheVoid
{
    public class Sockets
    {
        public static void UDPServer(int port)
        {
            try
            {
                new Thread(() =>
                       {
                       try
                       {
                           byte[] data = new byte[1024];
                           IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                           UdpClient newsock = new UdpClient(ipep);
                           Utility.Print("UDPServer Started on port " + port);
                           IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

                           data = newsock.Receive(ref sender);// why is this here?
                           while (true)
                           {
                               data = newsock.Receive(ref sender);
                               new Thread(() =>
                                  {
                                      try
                                      {
                                          string thiscms = Encoding.ASCII.GetString(data, 0, data.Length);
                                          Combustion.Execute("default",thiscms,"system");
                                      }
                                      catch (Exception ex)
                                      {
                                          Utility.Print("UDPException:" + ex.Message);
                                      }
                                  }).Start();
                           }
                           }
                           catch (Exception ex)
                           {
                               Utility.Print(ex.Message);
                           }
                       }).Start();
            }
            catch(Exception ex)
            {
                Utility.Print(ex.Message);
            }
        }

         public static void UDPClientSimple( string message)
        {
            UDPClient(IPAddress.Broadcast, 9068, message);
        }
        public static void UDPClient(IPAddress SERVER_IP, int PORT_NO, string message)
        {
            new Thread(() =>
                {
         UDPClientDirect( SERVER_IP,  PORT_NO,  message);
                }).Start();
        }

        public static void UDPClientDirect(IPAddress SERVER_IP, int PORT_NO, string message)
        {
            try
            {
                byte[] data = new byte[1024];
                message = message.Replace(Environment.NewLine, "");
                message = message.Replace("   ,   ", "");
                message.Trim();
                if (message.EndsWith("  ,"))
                {
                    message = message.Remove(message.Length - 1);
                }


                Thread.CurrentThread.IsBackground = true;
                    data = Encoding.ASCII.GetBytes(message + Environment.NewLine + ";"   );
                    if (data.Length > 0)
                    {
                        var client = new UdpClient();
                        IPEndPoint ep = new IPEndPoint(SERVER_IP, PORT_NO);
                        client.Connect(ep);
                        client.Send(data, data.Length);
                        client.Close();
                    }
             
            }
            catch (Exception ex)
            {
                Utility.Print(ex.Message);
            }
        }

    }
}
