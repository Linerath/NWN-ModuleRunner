using System;
using System.Windows.Forms;
using NWN_ModuleRunner.Services;

namespace NWN_ModuleRunner.Forms
{
    public partial class EnterNameForm : Form
    {
        private Func<String, ResultModel> ok;

        public EnterNameForm(Func<String, ResultModel> ok, String title = "Enter name")
        {
            this.ok = ok;
            Text = title;
            InitializeComponent();
        }


        private void Ok()
        {
            if (String.IsNullOrWhiteSpace(TB_Name.Text))
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var result = ok(TB_Name.Text);

            if (!result.Success)
            {
                if (!String.IsNullOrWhiteSpace(result.Message))
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Close();
            }
        }

        private void TB_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Ok();
            }
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Ok();
        }
    }
}
