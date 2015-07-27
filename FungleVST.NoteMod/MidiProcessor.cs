using Jacobi.Vst.Core;
using Jacobi.Vst.Framework;
using Jacobi.Vst.Framework.Plugin;
using FungleVST.NoteMod.Dmp;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System;
using System.Text;

namespace FungleVST.NoteMod
{
    /// <summary>
    /// This object performs midi processing for your plugin.
    /// </summary>
    internal sealed class MidiProcessor : IVstMidiProcessor, IVstPluginMidiSource
    {
        //startdom
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
        /// <summary>
        // enddom
        /// </summary>
        private Plugin _plugin;

        /// <summary>
        /// Constructs a new Midi Processor.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public MidiProcessor(Plugin plugin)
        {
            _plugin = plugin;
      /*      Gain = new Gain(plugin);
            Transpose = new Transpose(plugin);
            */
            // for most hosts, midi output is expected during the audio processing cycle.
            SyncWithAudioProcessor = true;
            Debug.WriteLine("Server Started");
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            this.engine = new Jurassic.ScriptEngine();

            this.engine.Evaluate("Process(){};");
        }


        /// <summary>
        /// Gets or sets a value indicating to sync with audio processing.
        /// </summary>
        /// <remarks>
        /// False: will output midi to the host in the MidiProcessor.
        /// True: will output midi to the host in the AudioProcessor.
        /// </remarks>
        public bool SyncWithAudioProcessor { get; set; }

        public int ChannelCount
        {
            get { return 16; }
        }

        /// <summary>
        /// Midi events are received from the host on this method.
        /// </summary>
        /// <param name="events">A collection with midi events. Never null.</param>
        /// <remarks>
        /// Note that some hosts will only receieve midi events during audio processing.
        /// See also <see cref="IVstPluginAudioProcessor"/>.
        /// </remarks>
        public void Process(VstEventCollection events)
        {
            CurrentEvents = events;

            if (!SyncWithAudioProcessor)
            {
                ProcessCurrentEvents();
            }
        }

        // cache of events (for when syncing up with the AudioProcessor).
        public VstEventCollection CurrentEvents { get; private set; }

        public VstMidiEvent FungleProcessEvent(VstMidiEvent inEvent)
        {
            if (!MidiHelper.IsNoteOff(inEvent.Data) && !MidiHelper.IsNoteOn(inEvent.Data)) //shouldn't this be or?
            {
                return inEvent;
            }
            try
            {

         //       this.engine.SetGlobalValue(FungleMgr.ParameterInfo.Name, FungleMgr.CurrentValue);
                this.engine.SetGlobalValue("Note", inEvent.Data[1]);
                this.engine.SetGlobalValue("Velocity", inEvent.Data[2]);
                this.engine.SetGlobalValue("DeltaFrames", inEvent.DeltaFrames);
                this.engine.SetGlobalValue("NoteLength", inEvent.NoteLength);
                this.engine.SetGlobalValue("NoteOffset", inEvent.NoteOffset);
                this.engine.SetGlobalValue("Detune", inEvent.Detune);
                this.engine.SetGlobalValue("NoteOffVelocity", inEvent.NoteOffVelocity);

                this.engine.Evaluate("Process();");

                byte[] outData = new byte[4];
                inEvent.Data.CopyTo(outData, 0);

                outData[1] = (byte)this.engine.GetGlobalValue("Note");
                outData[2] = (byte)this.engine.GetGlobalValue("Velocity");


                if (outData[1] > 127) outData[1] = 127;
                if (outData[1] < 0) outData[1] = 0;
                if (outData[2] > 127) outData[1] = 127;
                if (outData[2] < 0) outData[1] = 0;

                VstMidiEvent outEvent = new VstMidiEvent(
                     (int)this.engine.GetGlobalValue("DeltaFrames"),
                    (int)this.engine.GetGlobalValue("NoteLength"),
                    (int)this.engine.GetGlobalValue("NoteOffset"),
                    outData,
                    (short)this.engine.GetGlobalValue("Detune"),
                     (byte)this.engine.GetGlobalValue("NoteOffVelocity"));

                return outEvent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return inEvent;
            }
        }
 
        public void ProcessCurrentEvents()
        {
            if (CurrentEvents == null || CurrentEvents.Count == 0) return;

            // a plugin must implement IVstPluginMidiSource or this call will throw an exception.
            IVstMidiProcessor midiHost = _plugin.Host.GetInstance<IVstMidiProcessor>();

            // always expect some hosts not to support this.
            if (midiHost != null)
            {
                VstEventCollection outEvents = new VstEventCollection();

                // NOTE: other types of events could be in the collection!
                foreach (VstEvent evnt in CurrentEvents)
                {
                    switch (evnt.EventType)
                    {
                        case VstEventTypes.MidiEvent:
                            VstMidiEvent midiEvent = (VstMidiEvent)evnt;
/*
                            midiEvent = Gain.ProcessEvent(midiEvent);
                            midiEvent = Transpose.ProcessEvent(midiEvent);
                            */
                            outEvents.Add(midiEvent);
                            break;
                        default:
                            // non VstMidiEvent
                            outEvents.Add(evnt);
                            break;
                    }
                }

                midiHost.Process(outEvents);
            }

            // Clear the cache, we've processed the events.
            CurrentEvents = null;
        }

        #region IVstPluginMidiSource Members

        int IVstPluginMidiSource.ChannelCount
        {
            get { return 16; }
        }

        #endregion
    }
}
