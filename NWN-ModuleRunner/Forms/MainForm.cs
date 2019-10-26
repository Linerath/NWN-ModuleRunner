using NWN_ModuleRunner.Controls;
using NWN_ModuleRunner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Forms
{
    public partial class MainForm : Form
    {
        private Parameters prevParameters = null;
        private Parameters parameters = null;
        private IntPtr[] hookIds = new IntPtr[] { IntPtr.Zero, IntPtr.Zero };

        private PInvokeHelper.HookProc keyboardDelegate = null;
        private PInvokeHelper.HookProc keyboardLLDelegate = null;
        private Func<bool> areParametersChanged;

        private bool exit = false;


        public MainForm()
        {
            InitializeComponent();

            keyboardDelegate = new PInvokeHelper.HookProc(KeyboardProc);
            keyboardLLDelegate = new PInvokeHelper.HookProc(KeyboardProcLL);

            parameters = ParametersHelper.ReadOrDefaultParameters();
            NormalizeParameters();
            prevParameters = parameters.Clone() as Parameters;
            SyncScreenParams();
            SyncUIParams();

            areParametersChanged = () =>
            {
                return !parameters.Equals(prevParameters);
            };

            hookIds[0] = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, keyboardDelegate, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            hookIds[1] = PInvokeHelper.SetKeyboardLLHook(keyboardLLDelegate);
        }


        private void Start()
        {
            if (AreParametersValid)
            {
                foreach (var click in parameters.Clicks)
                {
                    if (click.DelayBefore > 0)
                        Thread.Sleep(click.DelayBefore);
                    for (int i = 0; i < click.Count; i++)
                    {
                        PerformClick(click.Point.X, click.Point.Y);
                    }
                }
            }
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
        }

        private void SyncUIParams()
        {
            if (parameters == null)
                return;

            BindingOff();

            if (Tabs_Clicks.TabCount != parameters.Clicks.Count)
            {
                Tabs_Clicks.TabPages.Clear();

                for (int i = 0; i < parameters.Clicks.Count; ++i)
                {
                    Click click = parameters.Clicks[i];

                    Tabs_Clicks.TabPages.Add($"#{i + 1}");

                    // X
                    Label x = new Label()
                    {
                        Text = "X",
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(19, 17),
                        Location = new Point(27, 34),
                    };
                    NumericUpDownMeta nud_x = new NumericUpDownMeta(click)
                    {
                        Minimum = 0,
                        Maximum = Screen.PrimaryScreen.Bounds.Width,
                        Value = click.Point.X,
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(85, 25),
                        Location = new Point(52, 32),
                        Name = "NUD_X",
                    };

                    // Y
                    Label y = new Label()
                    {
                        Text = "Y",
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(19, 17),
                        Location = new Point(27, 65),
                    };
                    NumericUpDownMeta nud_y = new NumericUpDownMeta(click)
                    {
                        Minimum = 0,
                        Maximum = Screen.PrimaryScreen.Bounds.Height,
                        Value = click.Point.Y,
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(85, 25),
                        Location = new Point(52, 63),
                        Name = "NUD_Y",
                    };

                    // Clicks count
                    Label count = new Label()
                    {
                        Text = "Clicks count",
                        Font = new Font("Segoe UI", 9),
                        Size = new Size(75, 17),
                        Location = new Point(150, 34),
                    };
                    NumericUpDownMeta nud_count = new NumericUpDownMeta(click)
                    {
                        Minimum = 1,
                        Maximum = 10,
                        Value = click.Count,
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(85, 25),
                        Location = new Point(225, 32),
                        Name = "NUD_CLICKS_COUNT",
                    };

                    // Delay before
                    Label delay = new Label()
                    {
                        Text = "Delay before (ms)",
                        Font = new Font("Segoe UI", 9),
                        Size = new Size(75, 17),
                        Location = new Point(150, 65),
                    };
                    NumericUpDownMeta nud_delay = new NumericUpDownMeta(click)
                    {
                        Minimum = 0,
                        Maximum = 10000, // 10 sec - max delay
                        Value = click.DelayBefore,
                        Font = new Font("Segoe UI", 10),
                        Size = new Size(85, 25),
                        Location = new Point(225, 63),
                        Name = "NUD_DELAY_BEFORE",
                    };

                    Tabs_Clicks.TabPages[i].Controls.Add(x);
                    Tabs_Clicks.TabPages[i].Controls.Add(nud_x);
                    Tabs_Clicks.TabPages[i].Controls.Add(y);
                    Tabs_Clicks.TabPages[i].Controls.Add(nud_y);
                    Tabs_Clicks.TabPages[i].Controls.Add(count);
                    Tabs_Clicks.TabPages[i].Controls.Add(nud_count);
                    Tabs_Clicks.TabPages[i].Controls.Add(delay);
                    Tabs_Clicks.TabPages[i].Controls.Add(nud_delay);
                }
            }
            else
            {
                foreach (TabPage tabPage in Tabs_Clicks.TabPages)
                {
                    (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(tabPage);
                    NumericUpDownMeta nudCount = GetTabClicksCountControl(tabPage);
                    NumericUpDownMeta nudDelay = GetTabDelayControl(tabPage);

                    Click click = NUDs.Item1.Click;

                    NUDs.Item1.Value = click.Point.X;
                    NUDs.Item2.Value = click.Point.Y;
                    nudCount.Value = click.Count;
                    nudDelay.Value = click.DelayBefore;
                }
            }

            Btn_Remove.Enabled = parameters.Clicks.Count > 1;

            BindingOn();
        }

        private void NormalizeParameters()
        {
            if (parameters == null)
                return;

            if (parameters.Clicks == null)
                parameters.Clicks = new List<Click>(10);
            if (parameters.Clicks.Count <= 0)
                parameters.Clicks.Add(new Click());

            foreach (var click in parameters.Clicks)
            {
                if (click.Count < 1)
                    click.Count = 1;
            }
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
                    (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetCurrentCoordinatesControls();

                    if (Cursor.Position.X > NUDs.Item1.Maximum || Cursor.Position.Y > NUDs.Item2.Maximum)
                    {
                        Error("Coordinates are out of boundaries");
                    }
                    else
                    {
                        ChangePoint(Cursor.Position.X, Cursor.Position.Y);
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
                Keys keyPressed = (Keys)Marshal.ReadInt32(lParam);

                if (keyPressed == Keys.F5)
                {
                    Start();
                }
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private void ChangePoint(int x, int y)
        {
            ChangePoint(Tabs_Clicks.SelectedTab, x, y);
        }

        private void ChangePoint(TabPage tabPage, int x, int y)
        {
            if (tabPage == null)
            {
                MessageBox.Show("Critical message has occured. Open log file for details.");
                return;
            }

            (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(tabPage);

            ChangePoint(NUDs.Item1.Click, x, y);
        }

        private void ChangePoint(Click click, int x, int y)
        {
            if (click == null)
            {
                MessageBox.Show("Critical message has occured. Open log file for details.");
                return;
            }

            var e = parameters.Clicks.FirstOrDefault(c => c == click);

            if (e != null)
            {
                e.Point = new Point(x, y);
            }
        }

        private void BindingOn()
        {
            foreach (TabPage tab in Tabs_Clicks.TabPages)
            {
                (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(tab);
                NumericUpDownMeta nudCount = GetTabClicksCountControl(tab);
                NumericUpDownMeta nudDelay = GetTabDelayControl(tab);

                if (NUDs.Item1 != null)
                    NUDs.Item1.ValueChanged += Coordinates_ValueChanged;
                if (NUDs.Item2 != null)
                    NUDs.Item2.ValueChanged += Coordinates_ValueChanged;
                if (nudCount != null)
                    nudCount.ValueChanged += ClickCount_ValueChanged;
                if (nudDelay != null)
                    nudDelay.ValueChanged += DelayBefore_ValueChanged;
            }
        }

        private void BindingOff()
        {
            foreach (TabPage tab in Tabs_Clicks.TabPages)
            {
                (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(tab);
                NumericUpDownMeta nudCount = GetTabClicksCountControl(tab);
                NumericUpDownMeta nudDelay = GetTabDelayControl(tab);

                if (NUDs.Item1 != null)
                    NUDs.Item1.ValueChanged -= Coordinates_ValueChanged;
                if (NUDs.Item2 != null)
                    NUDs.Item2.ValueChanged -= Coordinates_ValueChanged;
                if (nudCount != null)
                    nudCount.ValueChanged -= ClickCount_ValueChanged;
                if (nudDelay != null)
                    nudDelay.ValueChanged -= DelayBefore_ValueChanged;
            }
        }

        private (NumericUpDownMeta, NumericUpDownMeta) GetCurrentCoordinatesControls()
        {
            return GetTabCoordinatesControls(Tabs_Clicks.SelectedTab);
        }

        private NumericUpDownMeta GetCurrentDelayControl()
        {
            return GetTabDelayControl(Tabs_Clicks.SelectedTab);
        }

        private (NumericUpDownMeta, NumericUpDownMeta) GetTabCoordinatesControls(TabPage tabPage)
        {
            NumericUpDownMeta x = tabPage.Controls["NUD_X"] as NumericUpDownMeta;
            NumericUpDownMeta y = tabPage.Controls["NUD_Y"] as NumericUpDownMeta;

            return (x, y);
        }

        private NumericUpDownMeta GetTabClicksCountControl(TabPage tabPage)
        {
            NumericUpDownMeta result = tabPage.Controls["NUD_CLICKS_COUNT"] as NumericUpDownMeta;

            return result;
        }

        private NumericUpDownMeta GetTabDelayControl(TabPage tabPage)
        {
            NumericUpDownMeta result = tabPage.Controls["NUD_DELAY_BEFORE"] as NumericUpDownMeta;

            return result;
        }

        private void Error(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                bool result = true;
                foreach (TabPage item in Tabs_Clicks.TabPages)
                {
                    (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(item);

                    result = result
                        && NUDs.Item1.Value >= 0 && NUDs.Item1.Value <= w
                        && NUDs.Item2.Value >= 0 && NUDs.Item2.Value <= h;
                }

                return result;
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
            if (sender is NumericUpDownMeta nud && nud.Parent is TabPage tabPage)
            {
                (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetTabCoordinatesControls(tabPage);
                ChangePoint(nud.Click, (int)NUDs.Item1.Value, (int)NUDs.Item2.Value);
            }
        }

        private void ClickCount_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDownMeta nud)
            {
                nud.Click.Count = (int)nud.Value;
            }
        }

        private void DelayBefore_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDownMeta nud)
            {
                nud.Click.DelayBefore = (int)nud.Value;
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            parameters.Clicks.Add(new Click());
            SyncUIParams();
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            if (parameters.Clicks.Count > 1)
            {
                (NumericUpDownMeta, NumericUpDownMeta) NUDs = GetCurrentCoordinatesControls();

                parameters.Clicks.Remove(NUDs.Item1.Click);

                SyncUIParams();
            }
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
