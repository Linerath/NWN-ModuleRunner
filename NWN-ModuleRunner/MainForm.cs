using NWN_ModuleRunner.Properties;
using NWN_ModuleRunner.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWN_ModuleRunner
{
    public partial class MainForm : Form
    {
        private Parameters parameters = null;
        private IntPtr hookId = IntPtr.Zero;

        public MainForm()
        {
            InitializeComponent();
            parameters = ParametersHelper.ReadOrDefaultParameters();
            SyncScreenParams();
            SyncParams();

            hookId = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, KeyboardProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        private void SyncScreenParams()
        {
            // Screens.
            for (int i = 1; i <= Screen.AllScreens.Length; ++i)
                Cmb_Screens.Items.Add(i.ToString());

            if (Cmb_Screens.Items.Count < 1)
            {
                MessageBox.Show("No screens are recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            Cmb_Screens.SelectedIndex = 0;

            // Resolution.
            X0.Minimum = 0;
            X0.Maximum = Screen.PrimaryScreen.Bounds.Width;
            Y0.Minimum = 0;
            Y0.Maximum = Screen.PrimaryScreen.Bounds.Height;
        }

        private void SyncParams()
        {
            if (parameters == null)
                return;

            X0.Value = parameters.Points.FirstOrDefault().X;
            Y0.Value = parameters.Points.FirstOrDefault().Y;
        }

        private int KeyboardProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code == 3)
            {
                #region K
                Keys keyPressed = (Keys)wParam.ToInt32();

                if (keyPressed == Keys.F1)
                {
                    if (Cursor.Position.X > X0.Maximum || Cursor.Position.Y > Y0.Maximum)
                    {
                        MessageBox.Show("Coordinates are out of boundaries", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ChangePoint(0, Cursor.Position.X, Cursor.Position.Y);
                        SyncParams();
                    }
                }
                #endregion
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private void ChangePoint(int pointIndex, int x, int y)
        {
            if (pointIndex < 0 || pointIndex >= parameters.Points.Count)
            {
                MessageBox.Show("Message has occured. Open log file for details.");
                return;
            }

            parameters.Points[pointIndex] = new Point(x, y);
        }

        private void UpdateCursorPosition()
        {
            //Lbl_CursorXY.Text = $"{Cursor.Position.X};{Cursor.Position.Y}";
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
            PInvokeHelper.mouse_event(0x0002 | 0x0004, 0, 0, 0, IntPtr.Zero);
        }

        private void PerformClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);

            PerformClick();
        }
        #endregion

        #region Events
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (AreParametersValid)
                PerformClick((int)X0.Value, (int)Y0.Value);
            else
                MessageBox.Show("One or more parameter is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hookId.ToInt64() > 0)
                PInvokeHelper.UnhookWindowsHookEx(hookId);

            var answer = MessageBox.Show("Save parameters?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                if (parameters == null)
                {
                    MessageBox.Show("Invalid parameters. Saving is aborted.");
                }
                else
                {
                    if (!ParametersHelper.TryWriteParameters(parameters))
                        MessageBox.Show("Error occured while saving parameters. Open log file for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
