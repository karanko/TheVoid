namespace Jacobi.Vst.Samples.MidiNoteMapper
{
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Implements the incoming Midi event handling for the plugin.
    /// </summary>
    class MidiProcessor : IVstMidiProcessor
    {
        public Jurassic.ScriptEngine engine;
        private TcpListener tcpListener;
        private Thread listenThread;
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

                    Debug.WriteLine("TCPException:" + ex.Message);
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

                    Debug.WriteLine("TCPException2:" + ex.Message);
                }
            }

            tcpClient.Close();
        }


        private Plugin _plugin;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public MidiProcessor(Plugin plugin)
        {
            _plugin = plugin;
            Events = new VstEventCollection();
            NoteOnEvents = new Queue<byte>();
            this.engine = new Jurassic.ScriptEngine();
            try
            {
                Debug.WriteLine("Server Started");
                this.tcpListener = new TcpListener(IPAddress.Any, 3000);
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();

                this.engine.SetGlobalFunction("include", new Action<string>(path => engine.Evaluate(new System.Net.WebClient().DownloadString(path))));
                this.engine.SetGlobalFunction("log", new Action<string>(str => Debug.WriteLine(str)));
                this.engine.SetGlobalFunction("udp", new Action<string>(message => UDPSend(System.Net.IPAddress.Parse("127.0.0.1"), 999, message)));
                this.engine.Evaluate("function Process(){}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Gets the midi events that should be processed in the current cycle.
        /// </summary>
        public VstEventCollection Events { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating wether non-mapped midi events should be passed to the output.
        /// </summary>
        public bool MidiThru { get; set; }

        /// <summary>
        /// The raw note on note numbers.
        /// </summary>
        public Queue<byte> NoteOnEvents { get; private set; }

        #region IVstMidiProcessor Members

        public int ChannelCount
        {
            get { return _plugin.ChannelCount; }
        }

        public void Process(VstEventCollection events)
        {
            foreach (VstEvent evnt in events)
            {
                

                if (evnt.EventType != VstEventTypes.MidiEvent) continue;

                VstMidiEvent midiEvent = (VstMidiEvent)evnt;
                VstMidiEvent mappedEvent = null;

                if ( ((midiEvent.Data[0] & 0xF0) == 0x80 || (midiEvent.Data[0] & 0xF0) == 0x90))
                {
                    try
                    {
                     
                        //       this.engine.SetGlobalValue(FungleMgr.ParameterInfo.Name, FungleMgr.CurrentValue);
                        this.engine.SetGlobalValue("Note", midiEvent.Data[1]);
                        //this.engine.SetGlobalValue("Data0", midiEvent.Data[0]);
                      //  this.engine.SetGlobalValue("Data4", midiEvent.Data[4]);
                        this.engine.SetGlobalValue("Velocity", midiEvent.Data[2]);
                        this.engine.SetGlobalValue("DeltaFrames", midiEvent.DeltaFrames);
                        this.engine.SetGlobalValue("NoteLength", midiEvent.NoteLength);
                        this.engine.SetGlobalValue("NoteOffset", midiEvent.NoteOffset);
                        this.engine.SetGlobalValue("Detune", midiEvent.Detune);
                        this.engine.SetGlobalValue("NoteOffVelocity", midiEvent.NoteOffVelocity);

                        this.engine.Evaluate("Process();");

                        byte[] outData = new byte[4];
                        midiEvent.Data.CopyTo(outData, 0);

                        outData[0] = (byte)Convert.ToInt32(this.engine.GetGlobalValue("Note").ToString());
                        outData[2] = (byte)Convert.ToInt32(this.engine.GetGlobalValue("Velocity").ToString());

                        Events.Add(new VstMidiEvent(
                     (int)this.engine.GetGlobalValue("DeltaFrames"),
                    0,
                    0,
                   outData,
                    midiEvent.Detune,
                    midiEvent.NoteOffVelocity));


                       
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);

                    }
/*
                    if(_plugin.NoteMap.Contains(midiEvent.Data[1]))
                    {
                        byte[] midiData = new byte[4];
                        midiData[0] = midiEvent.Data[0];
                        midiData[1] = _plugin.NoteMap[midiEvent.Data[1]].OutputNoteNumber;
                        

                        mappedEvent = new VstMidiEvent(midiEvent.DeltaFrames, 
                            midiEvent.NoteLength, 
                            midiEvent.NoteOffset, 
                            midiData, 
                            midiEvent.Detune, 
                            midiEvent.NoteOffVelocity);

                        Events.Add(mappedEvent);

                        // add raw note-on note numbers to the queue
                        if((midiEvent.Data[0] & 0xF0) == 0x90)
                        {
                            lock (((ICollection)NoteOnEvents).SyncRoot)
                            {
                                NoteOnEvents.Enqueue(midiEvent.Data[1]);
                            }
                        }
                    }
                    else if (MidiThru)
                    {
                        // add original event
                        Events.Add(evnt);
                    }*/
                }
            }
        }

        #endregion
    }
}
