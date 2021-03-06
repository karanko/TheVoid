﻿using System;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class CommandForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public CommandForm(string content = null)
        {
            InitializeComponent();

            Command.Text = content;

        }

        private void CommandForm_Load(object sender, EventArgs e)
        {

        }

        private void CommandForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
            {
                try
                {
                    if (Command.SelectionLength > 1)
                    {
                        ((MainForm)this.ParentForm).Result.textBox.Text = Client.Proxy.Evaluate("Default", Command.SelectedText);
                    }
                    else
                    {
                        ((MainForm)this.ParentForm).Result.textBox.Text = Client.Proxy.Evaluate("Default", Command.Text);

                    }
                    // listBox1.Items.Clear();
                    // listBox1.Items.AddRange(service.ListMessages(listBox1.Items.Count));
                    this.Text = this.Text.Replace("*", "");
                    ((MainForm)this.ParentForm).ObsList.RefreshTree();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              //  System.Diagnostics.Debug.WriteLine("Test");

            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                // suspend layout to avoid blinking
                Command.SuspendLayout();

                // get insertion point
                int insPt = Command.SelectionStart;

                // preserve text from after insertion pont to end of RTF content
                string postRTFContent = Command.Text.Substring(insPt);

                // remove the content after the insertion point
                Command.Text = Command.Text.Substring(0, insPt);

                // add the clipboard content and then the preserved postRTF content
                Command.Text += (string)Clipboard.GetData("Text") + postRTFContent;

                // adjust the insertion point to just after the inserted text
                Command.SelectionStart = Command.TextLength - postRTFContent.Length;

                // restore layout
                Command.ResumeLayout();

                // cancel the paste
                e.Handled = true;
            } 
        }

        private void Command_TextChanged(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("*", "") + "*";
        
        }
    }
}
