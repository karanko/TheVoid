using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackStrip1.track = new Track();
            trackStrip1.track.Channel = 1;
            trackStrip1.FillTrack();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
