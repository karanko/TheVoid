using System;
using System.Threading;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class MessagesForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MessagesForm()
        {
            InitializeComponent();

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

        private void MessagesForm_Load(object sender, EventArgs e)
        {

        }

    
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            listBox.BeginUpdate();
            try
            {
               
                listBox.Items.Clear();
                listBox.Items.AddRange(TheVoid.Client.Proxy.Evaluate("JSON.parse(listprintmessagesjson());")
                    .Replace(Environment.NewLine,String.Empty).Split(','));
              
               
            }
            catch (Exception ex)
            { System.Diagnostics.Debug.WriteLine(ex);
            listBox.Items.Add(ex.Message);
            }
            listBox.EndUpdate();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
