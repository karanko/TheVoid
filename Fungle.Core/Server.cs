using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NAudio.Midi;

namespace Fungle.Core
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private Jurassic.ScriptEngine engine;
       // private MidiOut midiOut;
        private Dictionary<int, MidiOut> D_midiOut;
        private Dictionary<string, object> D_params;

        public Server()
        {
            Console.WriteLine("Server Started");
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            this.engine =  new Jurassic.ScriptEngine().LoadFunctions();
            this.engine.SetGlobalFunction("NoteOutRaw",  new Action<string>(i1 => NoteOut(i1)));
            this.D_midiOut = new Dictionary<int, MidiOut>();
            this.D_params = new Dictionary<string, object>();
          //  this.midiOut = new MidiOut(2);
            UDPListener(9050);            
        }

        private MidiOut GetMidiOut(int i)
        {
                if (!D_midiOut.ContainsKey(i))
                {
                    D_midiOut.Add(i, new MidiOut(i));
                }
                return D_midiOut[i];           
        }

        private void ResetMidiOut()
        {
            foreach (var x in D_midiOut)
            {
                x.Value.Reset();
            }

        }
        private void ClearMidiOut()
        {
            foreach (var x in D_midiOut)
            {
                x.Value.Close();
                x.Value.Dispose();
            }
            D_midiOut.Clear();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Priority = ThreadPriority.Highest;
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] message = new byte[4096];
            int bytesRead;
            string input = "";
            string output = "";

            byte[] buffer = encoder.GetBytes("Welcome");
            clientStream.Write(buffer, 0, buffer.Length);
        
            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                //message has successfully been received
             
                try
                {
                  
                    input = encoder.GetString(message, 0, bytesRead);
                    output = this.engine.Evaluate(input).ToString();
                  

                }
                catch (Exception ex)
                {

                    Console.WriteLine("TCPException:" + ex.Message);
                }
                output = output + Environment.NewLine + ">";
                if (output.Contains("undefined"))
                {
                    output = "";
                }
                try
                {
                    buffer = encoder.GetBytes(output);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("TCPException2:" + ex.Message);
                }
            }

            tcpClient.Close();
        }

        private void UDPListener(int port)
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
            UdpClient newsock = new UdpClient(ipep);
            Console.WriteLine("UDPServer Started on port " + port );
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            
            data = newsock.Receive(ref sender);
            while (true)
            {
                data = newsock.Receive(ref sender);
                new Thread(() =>
                   {
                       try
                       {
                           engine.Evaluate(Encoding.ASCII.GetString(data, 0, data.Length));
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("UDPException:" + ex.Message);
                       }
                   }).Start();
            }
        }

        public static void UDPSend(IPAddress SERVER_IP, int PORT_NO, string message)
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

        private void NoteOut(int note, int vel, int channel, int length, int device = 0)
        {
      
                GetMidiOut(device).Send(MidiMessage.StartNote(note, vel, channel).RawData);
                System.Threading.Thread.Sleep(length);
                GetMidiOut(device).Send(MidiMessage.StopNote(note, 0, channel).RawData);
            
        }
        //private void CCOut(int controller, int value, int channel,  int device = 0)
        //{

        //        GetMidiOut(device).Send(MidiMessage.ChangeControl(controller, value, channel).RawData);
            
        //}
        private void CCOut(int controller, int value, int channel, int device = 0)
        {

                GetMidiOut(device).Send(MidiMessage.ChangeControl(controller, value, channel).RawData);
        
        }
        public void NoteOut(string allparams)
        {
            string[] words = allparams.Split('|');
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    NoteOut(Convert.ToInt16(words[0]), Convert.ToInt16(words[1]), Convert.ToInt16(words[2]), Convert.ToInt16(words[3]), 0);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("NoteOut:", ex);
                }
            }).Start();
        }
    }


}
