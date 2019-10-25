using NWN_ModuleRunner.Properties;
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
        private IntPtr hookId = IntPtr.Zero;

        public MainForm()
        {
            InitializeComponent();
            InitParams();

            hookId = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, KeyboardProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        private void InitParams()
        {
            for (int i = 1; i <= Screen.AllScreens.Length; ++i)
                Cmb_Screens.Items.Add(i.ToString());

            if (Cmb_Screens.Items.Count < 1)
            {
                MessageBox.Show("No screens are recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
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
                        X0.Value = Cursor.Position.X;
                        Y0.Value = Cursor.Position.Y;
                    }
                }
                #endregion
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
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
        }
        #endregion
    }

    internal static class PInvokeHelper
    {
        [DllImport("User32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);
        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, int dwThreadId);
        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        internal delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        internal enum HookType
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }
    }
}
