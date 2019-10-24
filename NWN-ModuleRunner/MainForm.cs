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
            if (AreCoordinatesValid)
                PerformClick((int)X0.Value, (int)Y0.Value);
        }

        private void InitParams()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            X0.Minimum = 0;
            X0.Maximum = w;
            Y0.Minimum = 0;
            Y0.Maximum = h;

            X0.Value = w / 2;
            Y0.Value = h / 2;
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
