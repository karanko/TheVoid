using System;

namespace TheVoid.CosmicController
{
    public partial class ObjectTree : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ObjectTree()
        {
            InitializeComponent();
            RefreshTree();
        }
        private bool _isrefreshing = false;
        public void RefreshTree()
        {
            string cmd = @" Object.keys(this).filter(function(x){if (!(this[x] instanceof Function)) return false; return !/\[native code\]/.test(this[x].toString()) ? true : false;});/*do not log*/";
            _isrefreshing = true;
            listBox.BeginUpdate();
            try
            {
                listBox.Items.Clear();
                listBox.Items.AddRange(TheVoid.Client.Proxy.Evaluate(cmd).Split(','));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                listBox.Items.Add(ex.Message);
                listBox.Sorted = true; 
            }
            listBox.EndUpdate();
            _isrefreshing = false;
        }
        private void ObjectTree_Load(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isrefreshing)
            {
                textBox.Text = TheVoid.Client.Proxy.Evaluate(listBox.SelectedItem.ToString());
            }
        }
    }
}
