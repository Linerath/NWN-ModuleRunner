using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();

            LB_Log.Items.Clear();
        }

        public void WriteLog(String text)
        {
            LB_Log.Items.Add(text);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LB_Log.Items.Clear();
        }
    }
}
