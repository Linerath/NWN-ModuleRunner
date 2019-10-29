using NWN_ModuleRunner.Controls;
using NWN_ModuleRunner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Forms
{
    public partial class MainForm : Form
    {
        private ParametersService service;
        private Template selectedTemplate;
        //private Timer

        private IntPtr[] hookIds = new IntPtr[] { IntPtr.Zero, IntPtr.Zero };
        private PInvokeHelper.HookProc keyboardDelegate = null;
        private PInvokeHelper.HookProc keyboardLLDelegate = null;

        private bool bgMode = false;
        private bool exit = false;

        private const String NUD_X = "NUD_X";
        private const String NUD_Y = "NUD_Y";
        private const String NUD_CLICKS_COUNT = "NUD_CLICKS_COUNT";
        private const String NUD_DELAY_BEFORE = "NUD_DELAY_BEFORE";
        private const String CB_Enabled = "CB_Enabled";
        private const String CB_Right = "CB_Right";

        private const String ERROR = "Critical error has occured. Open log file for details.";
        private const String SAVE_ERROR = "Error has occured while saving parameters. Open log file for details.";


        public MainForm()
        {
            InitializeComponent();

            keyboardDelegate = new PInvokeHelper.HookProc(KeyboardProc);
            keyboardLLDelegate = new PInvokeHelper.HookProc(KeyboardProcLL);

            service = new ParametersService();
            selectedTemplate = service.Templates.FirstOrDefault();

            //SyncScreenParams();
            SyncUIParams();

            hookIds[0] = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, keyboardDelegate, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            hookIds[1] = PInvokeHelper.SetKeyboardLLHook(keyboardLLDelegate);
        }


        private void Start()
        {
            if (AreParametersValid)
            {
                foreach (var click in selectedTemplate.Clicks)
                {
                    if (!click.Enabled)
                        continue;

                    if (click.DelayBefore > 0)
                        Thread.Sleep(click.DelayBefore);
                    for (int i = 0; i < click.Count; i++)
                    {
                        PerformClick(click.Point.X, click.Point.Y, click.Right);
                    }
                }
            }
            else
                Error("One or more parameter is invalid.");
        }

        private void SyncScreenParams()
        {
            // Screens.
            //for (int i = 1; i <= Screen.AllScreens.Length; ++i)
            //    Cmb_Screens.Items.Add(i.ToString());

            //if (Cmb_Screens.Items.Count < 1)
            //{
            //    Error("No screens are recognized.");
            //    Environment.Exit(0);
            //}

            //Cmb_Screens.SelectedIndex = 0;
        }

        private void SyncUIParams()
        {
            BindingOff();

            CB_Template.Items.Clear();
            foreach (var item in service.Templates)
                CB_Template.Items.Add(item.Name ?? "?");

            if (selectedTemplate != null)
            {
                CB_Template.SelectedIndex = GetTemplateIndex(selectedTemplate);
                if (selectedTemplate.Clicks.Count != Tabs_Clicks.TabCount)
                {
                    Tabs_Clicks.TabPages.Clear();
                    for (int i = 0; i < selectedTemplate.Clicks.Count; ++i)
                    {
                        Click click = selectedTemplate.Clicks[i];

                        TabPageMeta page = new TabPageMeta(click, $"#{i + 1}");
                        Tabs_Clicks.TabPages.Add(page);

                        // X
                        Label x = new Label()
                        {
                            Text = "X",
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(19, 17),
                            Location = new Point(27, 34),
                        };
                        NumericUpDown nud_x = new NumericUpDown()
                        {
                            Minimum = 0,
                            Maximum = Screen.PrimaryScreen.Bounds.Width,
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(85, 25),
                            Location = new Point(52, 32),
                            Name = NUD_X,
                        };
                        nud_x.Value = click.Point.X >= nud_x.Minimum && click.Point.X <= nud_x.Maximum
                            ? click.Point.X
                            : 0;

                        // Y
                        Label y = new Label()
                        {
                            Text = "Y",
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(19, 17),
                            Location = new Point(27, 65),
                        };
                        NumericUpDown nud_y = new NumericUpDown()
                        {
                            Minimum = 0,
                            Maximum = Screen.PrimaryScreen.Bounds.Height,
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(85, 25),
                            Location = new Point(52, 63),
                            Name = NUD_Y,
                        };
                        nud_y.Value = click.Point.Y >= nud_y.Minimum && click.Point.Y <= nud_y.Maximum
                            ? click.Point.Y
                            : 0;

                        // Clicks count
                        Label count = new Label()
                        {
                            Text = "Clicks count",
                            Font = new Font("Segoe UI", 9),
                            Size = new Size(75, 17),
                            Location = new Point(150, 34),
                        };
                        NumericUpDown nud_count = new NumericUpDown()
                        {
                            Minimum = 1,
                            Maximum = 10,
                            Value = click.Count,
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(85, 25),
                            Location = new Point(225, 32),
                            Name = NUD_CLICKS_COUNT,
                        };

                        // Delay before
                        Label delay = new Label()
                        {
                            Text = "Delay before (ms)",
                            Font = new Font("Segoe UI", 9),
                            Size = new Size(75, 17),
                            Location = new Point(150, 65),
                        };
                        NumericUpDown nud_delay = new NumericUpDown()
                        {
                            Minimum = 0,
                            Maximum = 10000, // 10 sec - max delay
                            Value = click.DelayBefore,
                            Font = new Font("Segoe UI", 10),
                            Size = new Size(85, 25),
                            Location = new Point(225, 63),
                            Name = NUD_DELAY_BEFORE,
                        };

                        // Enabled
                        CheckBox enabled = new CheckBox()
                        {
                            Text = "Enabled",
                            Name = CB_Enabled,
                            Checked = click.Enabled,
                            Font = new Font("Segoe UI", 9),
                            AutoSize = true,
                            Location = new Point(3, 113),
                        };

                        // Right
                        CheckBox right = new CheckBox()
                        {
                            Text = "Right click",
                            Name = CB_Right,
                            Checked = click.Right,
                            Font = new Font("Segoe UI", 9),
                            AutoSize = true,
                            Location = new Point(71, 113),
                        };

                        // Clone button
                        Button clone = new Button()
                        {
                            Text = "clone",
                            Font = new Font("Segoe UI", 8),
                            Size = new Size(50, 23),
                            Location = new Point(300, 107),
                        };
                        clone.Click += Btn_Clone_Click;

                        Tabs_Clicks.TabPages[i].Controls.Add(x);
                        Tabs_Clicks.TabPages[i].Controls.Add(nud_x);
                        Tabs_Clicks.TabPages[i].Controls.Add(y);
                        Tabs_Clicks.TabPages[i].Controls.Add(nud_y);
                        Tabs_Clicks.TabPages[i].Controls.Add(count);
                        Tabs_Clicks.TabPages[i].Controls.Add(nud_count);
                        Tabs_Clicks.TabPages[i].Controls.Add(delay);
                        Tabs_Clicks.TabPages[i].Controls.Add(nud_delay);
                        Tabs_Clicks.TabPages[i].Controls.Add(enabled);
                        Tabs_Clicks.TabPages[i].Controls.Add(right);
                        Tabs_Clicks.TabPages[i].Controls.Add(clone);
                    }
                }
                else
                {
                    foreach (TabPage tabPage in Tabs_Clicks.TabPages)
                    {
                        (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(tabPage);
                        NumericUpDown nudCount = GetTabClicksCountControl(tabPage);
                        NumericUpDown nudDelay = GetTabDelayControl(tabPage);
                        CheckBox cbEnabled = GetCurrentEnabledControl(tabPage);
                        CheckBox cbRight = GetCurrentRightClickControl(tabPage);

                        Click click = GetCurrentClickObj();

                        NUDs.Item1.Value = click.Point.X;
                        NUDs.Item2.Value = click.Point.Y;
                        nudCount.Value = click.Count;
                        nudDelay.Value = click.DelayBefore;
                        cbEnabled.Checked = click.Enabled;
                        cbRight.Checked = click.Right;
                    }
                }
            }

            SyncBGMode();

            Btn_RemoveTemplate.Enabled = service.Templates.Count > 1;
            Btn_RemoveClick.Enabled = selectedTemplate.Clicks.Count > 1;

            BindingOn();
        }

        private void SyncCurrentClick()
        {
            BindingOff(Tabs_Clicks.SelectedTab);

            if (selectedTemplate != null)
            {
                (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(Tabs_Clicks.SelectedTab);
                NumericUpDown nudCount = GetTabClicksCountControl(Tabs_Clicks.SelectedTab);
                NumericUpDown nudDelay = GetTabDelayControl(Tabs_Clicks.SelectedTab);
                CheckBox cbEnabled = GetCurrentEnabledControl(Tabs_Clicks.SelectedTab);
                CheckBox cbRight = GetCurrentRightClickControl(Tabs_Clicks.SelectedTab);

                Click click = GetCurrentClickObj();

                NUDs.Item1.Value = click.Point.X;
                NUDs.Item2.Value = click.Point.Y;
                nudCount.Value = click.Count;
                nudDelay.Value = click.DelayBefore;
                cbEnabled.Checked = click.Enabled;
                cbRight.Checked = click.Right;
            }

            Btn_RemoveClick.Enabled = selectedTemplate.Clicks.Count > 1;

            BindingOn(Tabs_Clicks.SelectedTab);
        }

        private void SyncBGMode()
        {
            Btn_BGMode.Text = $"Turn BG mode {(bgMode ? "off" : "on")}";
            Lbl_Hint0.Visible = bgMode;
            Lbl_Hint1.Visible = bgMode;
        }

        private int KeyboardProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (!bgMode)
            {
                //if (code >= 0 && wParam == (IntPtr)PInvokeHelper.WM_KEYDOWN)
                if (code == 3)
                {
                    #region K
                    Keys keyPressed = (Keys)wParam.ToInt32();

                    if (keyPressed == Keys.F9)
                    {
                        ChangeCurrentClickCursorPoint(Cursor.Position.X, Cursor.Position.Y);
                    }
                    #endregion
                }
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private int KeyboardProcLL(int code, IntPtr wParam, IntPtr lParam)
        {
            if (bgMode)
            {
                if (code >= 0 && wParam == (IntPtr)PInvokeHelper.WM_KEYDOWN)
                {
                    Keys keyPressed = (Keys)Marshal.ReadInt32(lParam);

                    if (keyPressed == Keys.F5)
                    {
                        Start();
                    }
                    else if (keyPressed == Keys.F9)
                    {
                        ChangeCurrentClickCursorPoint(Cursor.Position.X, Cursor.Position.Y);
                    }
                    else if (keyPressed == Keys.F12)
                    {
                        AddClick();
                    }
                }
            }

            return PInvokeHelper.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private void BindingOn()
        {
            CB_Template.SelectedIndexChanged += CB_Template_SelectedIndexChanged;
            foreach (TabPage tab in Tabs_Clicks.TabPages)
            {
                BindingOn(tab);
            }
        }

        private void BindingOn(TabPage tabPage)
        {
            (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(tabPage);
            NumericUpDown nudCount = GetTabClicksCountControl(tabPage);
            NumericUpDown nudDelay = GetTabDelayControl(tabPage);
            CheckBox cbEnabled = GetTabEnabledControl(tabPage);
            CheckBox cbRight = GetTabRightClickControl(tabPage);

            if (NUDs.Item1 != null)
                NUDs.Item1.ValueChanged += Coordinates_ValueChanged;
            if (NUDs.Item2 != null)
                NUDs.Item2.ValueChanged += Coordinates_ValueChanged;
            if (nudCount != null)
                nudCount.ValueChanged += ClickCount_ValueChanged;
            if (nudDelay != null)
                nudDelay.ValueChanged += DelayBefore_ValueChanged;
            if (cbEnabled != null)
                cbEnabled.CheckedChanged += Enabled_CheckedChanged;
            if (cbRight != null)
                cbRight.CheckedChanged += Right_CheckedChanged;
        }

        private void BindingOff()
        {
            CB_Template.SelectedIndexChanged -= CB_Template_SelectedIndexChanged;
            foreach (TabPage tab in Tabs_Clicks.TabPages)
            {
                BindingOff(tab);
            }
        }

        private void BindingOff(TabPage tabPage)
        {
            (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(tabPage);
            NumericUpDown nudCount = GetTabClicksCountControl(tabPage);
            NumericUpDown nudDelay = GetTabDelayControl(tabPage);
            CheckBox cbEnabled = GetTabEnabledControl(tabPage);
            CheckBox cbRight = GetTabRightClickControl(tabPage);

            if (NUDs.Item1 != null)
                NUDs.Item1.ValueChanged -= Coordinates_ValueChanged;
            if (NUDs.Item2 != null)
                NUDs.Item2.ValueChanged -= Coordinates_ValueChanged;
            if (nudCount != null)
                nudCount.ValueChanged -= ClickCount_ValueChanged;
            if (nudDelay != null)
                nudDelay.ValueChanged -= DelayBefore_ValueChanged;
            if (cbEnabled != null)
                cbEnabled.CheckedChanged -= Enabled_CheckedChanged;
            if (cbRight != null)
                cbRight.CheckedChanged -= Right_CheckedChanged;
        }

        private void SelectNextTab(bool forward = true)
        {
            if (Tabs_Clicks.TabCount == 1)
                return;

            if (forward)
            {
                if (Tabs_Clicks.SelectedIndex == Tabs_Clicks.TabCount - 1)
                    Tabs_Clicks.SelectedIndex = 0;
                else
                    ++Tabs_Clicks.SelectedIndex;
            }
            else
            {
                if (Tabs_Clicks.SelectedIndex == 0)
                    Tabs_Clicks.SelectedIndex = Tabs_Clicks.TabCount - 1;
                else
                    --Tabs_Clicks.SelectedIndex;
            }
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

        #region Template/clicks manipulations
        private Template GetTemplate(int index)
        {
            if (index < 0 || index >= service.Templates.Count)
            {
                Error(ERROR);
                return null;
            }

            return service.Templates[index];
        }

        private int GetTemplateIndex(Template template)
        {
            if (template == null)
            {
                Error(ERROR);
                return -1;
            }

            return service.Templates.FindIndex(x => x == template);
        }

        private void AddTemplate()
        {
            service.AddTemplate($"Tmp_{service.Templates.Count}");
            selectedTemplate = service.Templates.LastOrDefault();
            SyncUIParams();
        }

        private void RemoveCurrentTemplate()
        {
            if (service.TryRemoveTemplate(selectedTemplate))
            {
                selectedTemplate = service.Templates.FirstOrDefault();
                SyncUIParams();
            }
        }

        private void AddClick()
        {
            service.AddClick(selectedTemplate);
            SyncUIParams();
            Tabs_Clicks.SelectedIndex = Tabs_Clicks.TabCount - 1;
        }

        private void RemoveCurrentClick()
        {
            int index = Tabs_Clicks.SelectedIndex;

            service.RemoveClick(selectedTemplate, GetCurrentClickObj());
            SyncUIParams();

            if (index != 0)
            {
                if (index <= Tabs_Clicks.TabCount - 1)
                    Tabs_Clicks.SelectedIndex = index;
                else
                    Tabs_Clicks.SelectedIndex = index - 1;
            }
        }

        private void RemoveAllClicks()
        {
            service.RemoveAllClicks(selectedTemplate);
            SyncUIParams();
        }

        private void CloneClick()
        {
            service.CloneClick(selectedTemplate, GetCurrentClickObj());
            SyncUIParams();
            Tabs_Clicks.SelectedIndex = Tabs_Clicks.TabCount - 1;
        }

        private Click GetCurrentClickObj()
        {
            TabPageMeta tabPage = Tabs_Clicks.SelectedTab as TabPageMeta;

            if (tabPage == null || tabPage.ClickObj == null)
                throw new Exception(ERROR);

            return tabPage.ClickObj;
        }

        private void ChangeCurrentClickCursorPoint(int x, int y)
        {
            Click click = GetCurrentClickObj();
            if (click == null)
            {
                MessageBox.Show(ERROR);
                return;
            }

            var NUDs = GetCurrentCoordinatesControls();

            if (Cursor.Position.X > NUDs.Item1.Maximum || Cursor.Position.Y > NUDs.Item2.Maximum)
            {
                Error("Coordinates are out of boundaries");
                return;
            }

            service.ChangeClickPoint(selectedTemplate, click, new Point(x, y));
            SyncCurrentClick();
        }

        private void ChangePoint(Click click, int x, int y)
        {
            if (click == null)
            {
                MessageBox.Show(ERROR);
                return;
            }

            service.ChangeClickPoint(selectedTemplate, click, new Point(x, y));
        }
        #endregion

        #region Getting Controls
        private (NumericUpDown, NumericUpDown) GetCurrentCoordinatesControls()
        {
            return GetTabCoordinatesControls(Tabs_Clicks.SelectedTab);
        }

        private NumericUpDown GetCurrentClicksCountControl(TabPage tabPage)
        {
            return GetTabClicksCountControl(Tabs_Clicks.SelectedTab);
        }

        private NumericUpDown GetCurrentDelayControl()
        {
            return GetTabDelayControl(Tabs_Clicks.SelectedTab);
        }

        private CheckBox GetCurrentEnabledControl(TabPage tabPage)
        {
            return GetTabEnabledControl(Tabs_Clicks.SelectedTab);
        }

        private CheckBox GetCurrentRightClickControl(TabPage tabPage)
        {
            return GetTabRightClickControl(Tabs_Clicks.SelectedTab);
        }


        private (NumericUpDown, NumericUpDown) GetTabCoordinatesControls(TabPage tabPage)
        {
            NumericUpDown x = tabPage.Controls[NUD_X] as NumericUpDown;
            NumericUpDown y = tabPage.Controls[NUD_Y] as NumericUpDown;

            return (x, y);
        }

        private NumericUpDown GetTabClicksCountControl(TabPage tabPage)
        {
            NumericUpDown result = tabPage.Controls[NUD_CLICKS_COUNT] as NumericUpDown;

            return result;
        }

        private NumericUpDown GetTabDelayControl(TabPage tabPage)
        {
            NumericUpDown result = tabPage.Controls[NUD_DELAY_BEFORE] as NumericUpDown;

            return result;
        }

        private CheckBox GetTabEnabledControl(TabPage tabPage)
        {
            CheckBox result = tabPage.Controls[CB_Enabled] as CheckBox;

            return result;
        }

        private CheckBox GetTabRightClickControl(TabPage tabPage)
        {
            CheckBox result = tabPage.Controls[CB_Right] as CheckBox;

            return result;
        }
        #endregion

        #region Form validity
        private bool AreParametersValid
        {
            get
            {
                return AreCoordinatesValid;
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
                    (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(item);

                    result = result
                        && NUDs.Item1.Value >= 0 && NUDs.Item1.Value <= w
                        && NUDs.Item2.Value >= 0 && NUDs.Item2.Value <= h;
                }

                return result;
            }
        }

        //private bool IsScreenValid
        //{
        //    get
        //    {
        //        return Cmb_Screens.SelectedIndex >= 0;
        //    }
        //}
        #endregion

        #region Mouse
        private void PerformClick(bool right = false)
        {
            if (!right)
                PInvokeHelper.mouse_event(MouseEvents.MOUSEEVENTF_LEFTDOWN | MouseEvents.MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            else
                PInvokeHelper.mouse_event(MouseEvents.MOUSEEVENTF_RIGHTDOWN | MouseEvents.MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
        }

        private void PerformClick(int x, int y, bool right = false)
        {
            Cursor.Position = new Point(x, y);

            PerformClick(right);
        }
        #endregion

        #region Events
        private void CB_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTemplate = GetTemplate(CB_Template.SelectedIndex);

            if (selectedTemplate != null)
            {
                SyncUIParams();
            }
        }

        private void Btn_AddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void Btn_RemoveTemplate_Click(object sender, EventArgs e)
        {
            RemoveCurrentTemplate();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Coordinates_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Parent is TabPage tabPage)
            {
                (NumericUpDown, NumericUpDown) NUDs = GetTabCoordinatesControls(tabPage);
                ChangePoint(GetCurrentClickObj(), (int)NUDs.Item1.Value, (int)NUDs.Item2.Value);
            }
        }

        private void ClickCount_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                GetCurrentClickObj().Count = (int)nud.Value;
            }
        }

        private void DelayBefore_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                GetCurrentClickObj().DelayBefore = (int)nud.Value;
            }
        }

        private void Enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                GetCurrentClickObj().Enabled = cb.Checked;
            }
        }

        private void Right_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                GetCurrentClickObj().Right = cb.Checked;
            }
        }

        private void Btn_Clone_Click(object sender, EventArgs e)
        {
            CloneClick();
        }

        private void Btn_AddClick_Click(object sender, EventArgs e)
        {
            AddClick();
        }

        private void Btn_RemoveClick_Click(object sender, EventArgs e)
        {
            RemoveCurrentClick();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            RemoveAllClicks();
        }

        private void Btn_BGMode_Click(object sender, EventArgs e)
        {
            bgMode = !bgMode;

            SyncBGMode();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (service.TryWriteParameters())
            {
                MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Error(SAVE_ERROR);
            }
        }

        private void Tabs_Clicks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'q')
                SelectNextTab(false);
            else if (e.KeyChar == 'e')
                SelectNextTab();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (service.ShowFinalDialog)
            {
                if (!exit && service.AreParametersChanged)
                {
                    foreach (var hookId in hookIds)
                    {
                        if (hookId.ToInt64() > 0)
                            PInvokeHelper.UnhookWindowsHookEx(hookId);
                    }

                    ExitForm exitForm = new ExitForm(service);
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
                if (service.SaveParameters)
                {
                    if (!service.TryWriteParameters())
                        Error(SAVE_ERROR);
                }
            }
        }
        #endregion
    }
}
