
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
    public partial class ResultForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ResultForm()
        {
            InitializeComponent();

            //JSBeautifyOptions
        }
      //  private JSBeautifyLib.JSBeautify Beautify = new JSBeautifyLib.JSBeautify();
        private void ResultForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // suspend layout to avoid blinking
                textBox.SuspendLayout();

                // get insertion point
                int insPt = textBox.SelectionStart;

                // preserve text from after insertion pont to end of RTF content
                string postRTFContent = textBox.Text.Substring(insPt);

                // remove the content after the insertion point
                textBox.Text = textBox.Text.Substring(0, insPt);

                // add the clipboard content and then the preserved postRTF content
                textBox.Text += (string)Clipboard.GetData("Text") + postRTFContent;

                // adjust the insertion point to just after the inserted text
                textBox.SelectionStart = textBox.TextLength - postRTFContent.Length;

                // restore layout
                textBox.ResumeLayout();

                // cancel the paste
                e.Handled = true;
            } 
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //JSBeautify jsb = new JSBeautify(textBox.Text, new JSBeautifyOptions { preserve_newlines = false });
          
            //textBox.Text = jsb.GetResult();
        }
    }
}
