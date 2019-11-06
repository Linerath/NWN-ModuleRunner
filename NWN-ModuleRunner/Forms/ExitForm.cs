using System;
using System.Windows.Forms;
using NWN_ModuleRunner.Services;

namespace NWN_ModuleRunner.Forms
{
    public partial class ExitForm : Form
    {
        private ParametersService service;

        private const String SAVE_ERROR = "Error has occured while saving parameters. Open log file for details.";


        public ExitForm(ParametersService service)
        {
            this.service = service;

            InitializeComponent();
        }


        private void SaveAndClose()
        {
            if (!service.TryWriteParameters())
                MessageBox.Show(SAVE_ERROR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Y_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void Btn_YR_Click(object sender, EventArgs e)
        {
            service.ShowFinalDialog = false;
            SaveAndClose();
        }

        private void Btn_N_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
