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
    public class Client
    {
        public static void UDPSend(System.Net.IPAddress SERVER_IP, int PORT_NO, string message)
        {
            byte[] data = new byte[1024];
            message = message.Replace(Environment.NewLine, "");
            message = message.Replace("   ,   ", "");
            message.Trim();
            if (message.EndsWith("  ,"))
            {
                message = message.Remove(message.Length - 1);
            }

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                data = Encoding.ASCII.GetBytes(message + Environment.NewLine);
                if (data.Length > 0)
                {
                    var client = new UdpClient();
                    IPEndPoint ep = new IPEndPoint(SERVER_IP, PORT_NO);
                    client.Connect(ep);
                    client.Send(data, data.Length);
                    client.Close();
                }
            }).Start();
        }

    }
}
