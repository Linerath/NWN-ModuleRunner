using NWN_ModuleRunner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Forms
{
    public partial class MainForm : Form
    {
        private Parameters prevParameters = null;
        private Parameters parameters = null;
        private IntPtr[] hookIds = new IntPtr[] { IntPtr.Zero, IntPtr.Zero };

        private bool exit = false;

        private Func<bool> areParametersChanged;

        public MainForm()
        {
            InitializeComponent();

            parameters = ParametersHelper.ReadOrDefaultParameters();
            prevParameters = parameters.Clone() as Parameters;
            SyncScreenParams();
            SyncUIParams();

            areParametersChanged = () =>
            {
                return !parameters.Equals(prevParameters);
            };

            hookIds[0] = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, KeyboardProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            hookIds[1] = PInvokeHelper.SetKeyboardLLHook(KeyboardProcLL);
        }


        private void Start()
        {
            if (AreParametersValid)
                PerformClick((int)X0.Value, (int)Y0.Value);
            else
                Error("One or more parameter is invalid.");
        }

        private void SyncScreenParams()
        {
            // Screens.
            for (int i = 1; i <= Screen.AllScreens.Length; ++i)
                Cmb_Screens.Items.Add(i.ToString());

            if (Cmb_Screens.Items.Count < 1)
            {
                Error("No screens are recognized.");
                Environment.Exit(0);
            }

            Cmb_Screens.SelectedIndex = 0;

            // Resolution.
            X0.Minimum = 0;
            X0.Maximum = Screen.PrimaryScreen.Bounds.Width;
            Y0.Minimum = 0;
            Y0.Maximum = Screen.PrimaryScreen.Bounds.Height;
        }

        private void SyncUIParams()
        {
            if (parameters == null)
                return;

            BindingOff();
            X0.Value = parameters.Points[0].X;
            Y0.Value = parameters.Points[0].Y;
            BindingOn();
        }

        private int KeyboardProc(int code, IntPtr wParam, IntPtr lParam)
        {
            //if (code >= 0 && wParam == (IntPtr)PInvokeHelper.WM_KEYDOWN)
            if (code == 3)
            {
                #region K
                Keys keyPressed = (Keys)wParam.ToInt32();

                if (keyPressed == Keys.F1)
                {
                    if (Cursor.Position.X > X0.Maximum || Cursor.Position.Y > Y0.Maximum)
                    {
                        Error("Coordinates are out of boundaries");
                    }
                    else
                    {
                        ChangePoint(0, Cursor.Position.X, Cursor.Position.Y);
                        SyncUIParams();
                    }
                }
                #endregion
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private int KeyboardProcLL(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)PInvokeHelper.WM_KEYDOWN)
            {
                #region K
                Keys keyPressed = (Keys)Marshal.ReadInt32(lParam);

                if (keyPressed == Keys.F5)
                {
                    Start();
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

        private void Error(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BindingOn()
        {
            X0.ValueChanged += Coordinates_ValueChanged;
            Y0.ValueChanged += Coordinates_ValueChanged;
        }

        private void BindingOff()
        {
            X0.ValueChanged -= Coordinates_ValueChanged;
            Y0.ValueChanged -= Coordinates_ValueChanged;
        }

        // PROTOTYPE
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
            Start();
        }

        private void Coordinates_ValueChanged(object sender, EventArgs e)
        {
            ChangePoint(0, (int)X0.Value, (int)Y0.Value);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parameters.ShowFinalDialog)
            {
                if (!exit && areParametersChanged())
                {
                    foreach (var hookId in hookIds)
                    {
                        if (hookId.ToInt64() > 0)
                            PInvokeHelper.UnhookWindowsHookEx(hookId);
                    }

                    ExitForm exitForm = new ExitForm(parameters);
                    exitForm.Show(this);
                    exit = true;
                    exitForm.FormClosed += delegate (object obj, FormClosedEventArgs agrs)
                    {
                        Application.Exit();
                    };
                    e.Cancel = true;
                }
            }
            else
            {
                if (parameters.SaveParameters)
                {
                    if (!ParametersHelper.TryWriteParameters(parameters))
                        Error("Error occured while saving parameters. Open log file for details.");
                }
            }
        }
        #endregion
    }
}
