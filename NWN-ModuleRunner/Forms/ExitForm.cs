using NWN_ModuleRunner.Services;
using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Forms
{
    public partial class ExitForm : Form
    {
        private Parameters parameters;

        public ExitForm(Parameters parameters)
        {
            this.parameters = parameters;

            InitializeComponent();
        }

        private void Btn_Y_Click(object sender, EventArgs e)
        {
            if (parameters == null)
            {
                MessageBox.Show("Invalid parameters. Saving is aborted.");
            }
            else
            {
                parameters.ShowFinalDialog = !CB_Stop.Checked;
                if (!ParametersHelper.TryWriteParameters(parameters))
                    MessageBox.Show("Error occured while saving parameters. Open log file for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void Btn_N_Click(object sender, EventArgs e)
        {
            Parameters parameters = ParametersHelper.ReadOrDefaultParameters();

            if (parameters.ShowFinalDialog != !CB_Stop.Checked)
            {
                parameters.ShowFinalDialog = !CB_Stop.Checked;
                ParametersHelper.TryWriteParameters(parameters);
            }

            Close();
        }
    }
}
