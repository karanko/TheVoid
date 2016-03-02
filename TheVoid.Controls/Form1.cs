using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.clipGrid1.Rows = 8;
            this.clipGrid1.Columns = 8;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.clipGrid1.FillTableWithClips();

        }
    }
}
