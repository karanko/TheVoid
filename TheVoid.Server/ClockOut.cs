using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace TheVoid.Server
{
    public partial class ClockOut : Form
    {
        public ClockOut()
        {
            InitializeComponent();
            checkBox1.Checked = false;
           // numericUpDown1.Value = 110;
            comboBox1.Items.AddRange(TheVoid.Midi.GetMIDIOutDevices());
            comboBox1.SelectedIndex = TheVoid.Midi.MidiSyncOutDeviceNumber;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.RegisterWaitForSingleObject(new System.Threading.AutoResetEvent(false), (state, bTimeout) => Debug.WriteLine(state), "This is my state variable", TimeSpan.FromSeconds(5), true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TheVoid.Midi.SyncOutClock(checkBox1.Checked);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TheVoid.Midi.SyncOutBPM((int)numericUpDown1.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TheVoid.Midi.MidiSyncOutDeviceNumber = comboBox1.SelectedIndex;
            Utility.Print(TheVoid.Midi.MidiSyncOutDeviceNumber);
        }
    }
}
