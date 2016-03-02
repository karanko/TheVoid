using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Server
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            try
            {
                textBox1.Text = Combustion.TickFunction;
                comboBox1.Items.AddRange(TheVoid.Midi.GetMIDIInDevices());
                comboBox1.SelectedIndex = Midi.MidiInDeviceNumber;
                comboBox2.Items.AddRange(TheVoid.Midi.GetMIDIOutDevices());
                comboBox2.SelectedIndex = Midi.MidiOutDeviceNumber;
                numericUpDown1.Value = Midi.MidiInChannelNumber;
                numericUpDown2.Value = Midi.MidiOutChannelNumber;


            }
            catch (Exception ex)
            { Utility.Print(ex); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Midi.MidiInDeviceNumber = comboBox1.SelectedIndex;
               // Options.Write("midiindevice", comboBox1.SelectedIndex);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Options.Write("midioutdevice", comboBox2.SelectedIndex);
            Midi.MidiOutDeviceNumber = comboBox2.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Options.Write("midiinchannel", numericUpDown1.Value);
            Midi.MidiInChannelNumber = (int)numericUpDown1.Value;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
          //  Options.Write("midioutchannel", numericUpDown2.Value);
            Midi.MidiOutChannelNumber = (int)numericUpDown2.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Combustion.TickFunction = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ClockOut().Show();
        }
    }
}
