using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Tracker
{
    public partial class TrackElement : UserControl
    {
        public TrackElement(int notenumber)
        {
            InitializeComponent();
            Label.Text = notenumber.ToString();
            
        }
        
    }
}
