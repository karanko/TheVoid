using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Server
{
    public partial class VoidWindow : Form
    {
  
        public VoidWindow()
        {
          //  new FastEval().Show();
            TheVoid.Utility.Print("------- TheVoid -------");
            TheVoid.Utility.Print("Started:"+TheVoid.Combustion.Evaluate("Date.now();"));
            TheVoid.CI.APC.ClearBoard();
            TheVoid.CI.APC.GuessMidiPorts();
            TheVoid.CI.APC.init();

            InitializeComponent();
            toolStripTextBox1.Text = Combustion.TickFunction;
            notifyIcon.Visible = false;
           
          //  this.ShowInTaskbar = false;
          //  notifyIcon.Visible = false;
          
           // TheVoid.Combustion.init();
            listBox1.ScrollAlwaysVisible = false;

            
            try
            {
                host = new ServiceHost(typeof(TheVoid.Service.Service), new Uri("http://0.0.0.0:9066/TheVoid"));
                
                smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true; 
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

                host.OpenTimeout = new TimeSpan(0, 0, 3);
                host.CloseTimeout = new TimeSpan(0, 0, 3);
                host.Description.Behaviors.Add(smb);
             
                TheVoid.Utility.Print("------- Engines -------");
                foreach (var x in TheVoid.Combustion.ListEngines())
                {
                    TheVoid.Utility.Print(x);
                }
                TheVoid.Utility.Print("------- Addresses -------");
                foreach (var x in host.BaseAddresses)
                {
                    TheVoid.Utility.Print(x);
                }
                Sockets.UDPServer(9067);
                oscserver = new OSC();
                oscserver.Start();

                LeftStatusLabel.Text = Application.ProductName;
                RightStatusLabel.Text = Application.ProductVersion;
                TheVoid.Utility.Print("-------");
                TheVoid.Utility.Print("Open Host");
                TheVoid.Utility.Print("------- Midi -------");

                TheVoid.Utility.Print("Midi In Device:" + Midi.GetMIDIInDevices()[Midi.MidiInDeviceNumber]);
                TheVoid.Utility.Print("Midi Out Device:" + Midi.GetMIDIOutDevices()[Midi.MidiOutDeviceNumber]);

                host.Open();
            }
            catch(Exception ex)
            {
                TheVoid.Utility.Print(ex.Message);

            }
            TheVoid.Utility.Messages.CollectionChanged += Messages_CollectionChanged;
            TheVoid.Utility.Print("Init Complete");
            Log.Checked = Utility.Log;
        }

        private void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
          //  throw new NotImplementedException();
          //  System.Diagnostics.Debug.WriteLine("changed");
            try
            {
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(TheVoid.Utility.Messages.ToArray());
                if (listBox1.Items.Count > 0)
                {
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                listBox1.EndUpdate();
             /*   if (notifyIcon.Visible)
                {
                    if (listBox1.Items.Count > 0)
                    {
                        notifyIcon.BalloonTipTitle = this.Text;
               
                    notifyIcon.BalloonTipText = listBox1.Items[listBox1.Items.Count - 1].ToString();
                    }
                    notifyIcon.ShowBalloonTip(500);
                }
                */
               
            }
            catch { }
        }

        OSC oscserver;
        ServiceHost host; 
        ServiceMetadataBehavior smb;
              
            
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        public bool AllowClose = true;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AllowClose)
            {
                try
                {
                    host.Close();
                    oscserver.Stop();
                    TheVoid.CI.APC.ClearBoard();
                    Environment.Exit(0);
                }
                catch { }
            }
            else
            {
                e.Cancel = true;
                

                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                this.Hide();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
               // notifyIcon.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
                this.ShowInTaskbar = true ;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
          
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OptionsForm().Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OptionsForm().Show();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.Messages.Clear();
            Utility.Messages.Add("------- TheVoid -------");
        }

        private void gOToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Combustion.TickFunction = toolStripTextBox1.Text;

        }

        private void toolStripTextBox1_DoubleClick(object sender, EventArgs e)
        {
            Combustion.Execute("default", toolStripTextBox1.Text);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Log_Click(object sender, EventArgs e)
        {
            Utility.Log = Log.Checked;
        }
    }
}
