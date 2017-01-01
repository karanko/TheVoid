using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class HistoryForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public HistoryForm()
        {
            InitializeComponent();
            this.Text = "History";
            Thread sampleThread = new Thread(delegate()
            {
                // Invoke your control like this
                this.Invoke(new MethodInvoker(delegate()
                {
                    timer1.Start();
                }));
            });
            //  sampleThread.Start();
            timer1.Start();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox.BeginUpdate();


            try
            {
                string messagesraw = TheVoid.Client.Proxy.Evaluate("listexecutionmessages();");
                var messages = Newtonsoft.Json.Linq.JArray.Parse(messagesraw);
                listBox.Items.Clear();
                //  listBox.Items.Add(messages[i]["Value"].ToString());

                int i = 0;
                while (i < messages.Count)
                {

                    listBox.Items.Add(messages[i]["Value"].ToString());
                    i++;
                }



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                listBox.Items.Add(ex.Message);
            }
            listBox.EndUpdate();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
