using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteController
{
    public partial class LilButton : UserControl
    {
        public LilButton()
        {
            InitializeComponent();
            note = 0;
        }
       public int note;
        private void button_Click(object sender, EventArgs e)
        {
            RemoteController.VAPC.QuickNoteout(note, 127);
        }
    }
}
