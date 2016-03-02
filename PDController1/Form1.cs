using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDController1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SendToPD(string route,object message)
        {

            TheVoid.Sockets.UDPClientDirect(System.Net.IPAddress.Broadcast, 9999, route + " " + message.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.wav";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
               SendToPD("open",theDialog.FileName.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendToPD("pd", "audio-properties");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SendToPD("pd", "perf " + Convert.ToInt16(checkBox1.Checked));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SendToPD("pd", "dsp " + Convert.ToDouble(checkBox2.Checked));
            Debug.WriteLine(checkBox2.Checked);
        }
    }
}
