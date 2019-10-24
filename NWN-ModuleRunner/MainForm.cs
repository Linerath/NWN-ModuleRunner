using NWN_ModuleRunner.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWN_ModuleRunner
{
    public partial class MainForm : Form
    {
        [DllImport("User32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        public MainForm()
        {
            InitializeComponent();
            InitParams();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (AreParametersValid)
                PerformClick((int)X0.Value, (int)Y0.Value);
        }

        private void InitParams()
        {
            for (int i = 1; i <= Screen.AllScreens.Length; ++i)
                Cmb_Screens.Items.Add(i.ToString());

            if (Cmb_Screens.Items.Count < 1)
            {
                MessageBox.Show("No screens are recognized.", "Error", MessageBoxButtons.OK);
                Environment.Exit(0);
                //Application.Exit();
            }

            Cmb_Screens.SelectedIndex = 0;

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            X0.Minimum = 0;
            X0.Maximum = w;
            Y0.Minimum = 0;
            Y0.Maximum = h;

            X0.Value = w / 2;
            Y0.Value = h / 2;
        }

        #region Form validity
        private bool AreParametersValid
        {
            get
            {
                return AreCoordinatesValid && IsScreenValid;
            }
        }

        private bool AreCoordinatesValid
        {
            get
            {
                int w = Screen.PrimaryScreen.Bounds.Width;
                int h = Screen.PrimaryScreen.Bounds.Height;

                return X0.Value >= 0 && X0.Value <= w
                    && Y0.Value >= 0 && Y0.Value <= h;
            }
        }

        private bool IsScreenValid
        {
            get
            {
                return Cmb_Screens.SelectedIndex >= 0;
            }
        }
        #endregion

        #region Mouse
        private void PerformClick()
        {
            mouse_event(0x0002 | 0x0004, 0, 0, 0, IntPtr.Zero);
        }

        private void PerformClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);

            PerformClick();
        }
        #endregion
    }
}
