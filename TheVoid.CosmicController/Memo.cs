using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class Memo : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Memo()
        {
            InitializeComponent();
            try
            {
                richTextBox1.Rtf = System.IO.File.ReadAllText("Memo.rtf");
            }
            catch { }
        }

        private void Memo_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
            System.IO.File.WriteAllText("Memo.rtf", richTextBox1.Rtf);
            }
            catch { }
        }
    }
}
