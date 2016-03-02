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
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
            tx = new Track() { Channel = 1 };
        }
        private Track tx;
        private void Window_TextChanged(object sender, EventArgs e)
        {
            Window.Text = DrawTrack(tx);
        }


        string DrawTrack(Track track)
        {

            string result = String.Empty
                ;
            result += String.Format("Channel:{0:D2}|Steps:{1}", track.Channel, track.Steps.Count()) + Environment.NewLine;
            result += String.Format("Mute:{0}|Solo:{1}", track.Mute,track.Solo)+Environment.NewLine;
                    

//            result += Environment.NewLine;
            string t = "";
            int i = 1;
            foreach(var step in track.Steps)
            {
                t += String.Format("{0:D2}  |   {1:D3}  |   {2:D3}  |   {3:D4}", i++, step.Note, step.Velocity, step.Length) + Environment.NewLine;
            }

            result += t;

            return result;

        }

    }
}
