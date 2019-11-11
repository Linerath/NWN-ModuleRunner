using NWN_ModuleRunner.Controls;
using NWN_ModuleRunner.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
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

        private bool performs = false;
        private bool stop = false;
        private bool bgMode = false;

        private const String NUD_X = "NUD_X";
        private const String NUD_Y = "NUD_Y";
        private const String NUD_CLICKS_COUNT = "NUD_CLICKS_COUNT";
        private const String NUD_DELAY_BEFORE = "NUD_DELAY_BEFORE";
        private const String CB_Enabled = "CB_Enabled";
        private const String CB_Right = "CB_Right";

        private const String ERROR = "Critical error has occured. Open log file for details.";
        private const String SAVE_ERROR = "Error has occured while saving parameters. Open log file for details.";

        private readonly Dictionary<KeyPurpose, Keys> hotkeys = new Dictionary<KeyPurpose, Keys>
        {
            [KeyPurpose.FirstTemplate] = Keys.F1,
            [KeyPurpose.SecondTemplate] = Keys.F2,
            [KeyPurpose.ThirdTemplate] = Keys.F3,
            [KeyPurpose.FourthTemplate] = Keys.F4,

            [KeyPurpose.Start] = Keys.F5,
            [KeyPurpose.Stop] = Keys.F6,
            [KeyPurpose.SetPoint] = Keys.F9,
            [KeyPurpose.AddClick] = Keys.F12,
        };


        public MainForm()
        {
            InitializeComponent();
            Lbl_Hint0.Text = $"Press \"{hotkeys[KeyPurpose.Start]}\" to start";
            Lbl_Hint1.Text = $"Press \"{hotkeys[KeyPurpose.AddClick]}\" to create new click";
            Lbl_Hint2.Text = $"Press \"{hotkeys[KeyPurpose.SetPoint]}\" to set coordinates from current cursor position";

            keyboardDelegate = new PInvokeHelper.HookProc(KeyboardProc);
            keyboardLLDelegate = new PInvokeHelper.HookProc(KeyboardProcLL);

            service = new ParametersService();
            selectedTemplate = service.Templates.FirstOrDefault();

            //SyncScreenParams();
            SyncUIParams();

            Hook();
        }


        private void Start()
        {
            if (AreParametersValid)
            {
                if (!String.IsNullOrWhiteSpace(selectedTemplate.AppPath))
                    Process.Start(selectedTemplate.AppPath);

                foreach (var click in selectedTemplate.Clicks)
                {
                    if (stop)
                    {
                        stop = false;
                        return;
                    }

                    if (!click.Enabled)
                        continue;

                    if (click.DelayBefore > 0)
                        Thread.Sleep(click.DelayBefore);
                    for (int i = 0; i < click.Count; i++)
                    {
                        if (stop)
                        {
                            stop = false;
                            return;
                        }
                        PerformClick(click.Point.X, click.Point.Y, click.Right);
                    }
                }
            }
            else
                Error("One or more parameter is invalid.");
        }

        private void Stop()
        {
            stop = true;
        }

        private void TestClick(Click click)
        {
            Cursor.Position = new Point(click.Point.X, click.Point.Y);
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

        private void SyncUIParams(bool global = false)
        {
            BindingOff();

            CB_Template.Items.Clear();
            foreach (var item in service.Templates)
                CB_Template.Items.Add(item.Name ?? "?");

            if (selectedTemplate != null)
            {
                CB_Template.SelectedIndex = GetTemplateIndex(selectedTemplate);
                if (global || selectedTemplate.Clicks.Count != Tabs_Clicks.TabCount)
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

                        // Test button
                        Button test = new Button()
                        {
                            Text = "test",
                            Font = new Font("Segoe UI", 8),
                            Size = new Size(40, 23),
                            Location = new Point(254, 107),
                        };
                        test.Click += Btn_Test_Click;

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
                        Tabs_Clicks.TabPages[i].Controls.Add(test);
                    }
                }
                else
                {
                    foreach (TabPage tabPage in Tabs_Clicks.TabPages)
                    {
                        Click click = GetCurrentClickObj();

                        (this[tabPage, ControlType.CoordinateX] as NumericUpDown).Value = click.Point.X;
                        (this[tabPage, ControlType.CoordinateY] as NumericUpDown).Value = click.Point.Y;
                        (this[tabPage, ControlType.ClicksCount] as NumericUpDown).Value = click.Count;
                        (this[tabPage, ControlType.Delay] as NumericUpDown).Value = click.DelayBefore;
                        (this[tabPage, ControlType.Enabled] as CheckBox).Checked = click.Enabled;
                        (this[tabPage, ControlType.RightClick] as CheckBox).Checked = click.Right;
                    }
                }
            }

            SyncStartApp();
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
                Click click = GetCurrentClickObj();

                (this[ControlType.CoordinateX] as NumericUpDown).Value = click.Point.X;
                (this[ControlType.CoordinateY] as NumericUpDown).Value = click.Point.Y;
                (this[ControlType.ClicksCount] as NumericUpDown).Value = click.Count;
                (this[ControlType.Delay] as NumericUpDown).Value = click.DelayBefore;
                (this[ControlType.Enabled] as CheckBox).Checked = click.Enabled;
                (this[ControlType.RightClick] as CheckBox).Checked = click.Right;
            }

            Btn_RemoveClick.Enabled = selectedTemplate.Clicks.Count > 1;

            BindingOn(Tabs_Clicks.SelectedTab);
        }

        private void SyncStartApp()
        {
            Btn_SelectChangeApp.Text = String.IsNullOrWhiteSpace(selectedTemplate.AppPath)
                ? "Select app"
                : "Change app";

            Lbl_AppPath.Text = Path.GetFileName(selectedTemplate.AppPath);
            Lbl_RemoveApp.Visible = !String.IsNullOrWhiteSpace(selectedTemplate.AppPath);
        }

        private void SyncBGMode()
        {
            Btn_BGMode.Text = $"Turn BG mode {(bgMode ? "off" : "on")}";
            Lbl_Hint0.Visible = bgMode;
            Lbl_Hint1.Visible = bgMode;
        }

        private void Hook()
        {
            hookIds[0] = PInvokeHelper.SetWindowsHookEx(PInvokeHelper.HookType.WH_KEYBOARD, keyboardDelegate, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            hookIds[1] = PInvokeHelper.SetKeyboardLLHook(keyboardLLDelegate);
        }

        private void Unhook()
        {
            foreach (var hookId in hookIds)
            {
                if (hookId.ToInt64() > 0)
                    PInvokeHelper.UnhookWindowsHookEx(hookId);
            }
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

                    if (performs)
                    {
                        if (keyPressed == hotkeys[KeyPurpose.Stop]
                         || keyPressed == hotkeys[KeyPurpose.FirstTemplate] || keyPressed == hotkeys[KeyPurpose.SecondTemplate]
                         || keyPressed == hotkeys[KeyPurpose.ThirdTemplate] || keyPressed == hotkeys[KeyPurpose.FourthTemplate])
                        {
                            Stop();
                        }
                    }

                    if (keyPressed == hotkeys[KeyPurpose.FirstTemplate])
                    {
                        TrySelectTemplate(0);
                    }
                    else if (keyPressed == hotkeys[KeyPurpose.SecondTemplate])
                    {
                        TrySelectTemplate(1);
                    }
                    else if (keyPressed == hotkeys[KeyPurpose.ThirdTemplate])
                    {
                        TrySelectTemplate(2);
                    }
                    else if (keyPressed == hotkeys[KeyPurpose.FourthTemplate])
                    {
                        TrySelectTemplate(3);
                    }
                    if (keyPressed == hotkeys[KeyPurpose.SetPoint])
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
            if (performs || bgMode)
            {
                if (code >= 0 && wParam == (IntPtr)PInvokeHelper.WM_KEYDOWN)
                {
                    Keys keyPressed = (Keys)Marshal.ReadInt32(lParam);

                    if (performs)
                    {
                        if (keyPressed == hotkeys[KeyPurpose.Stop]
                         || (bgMode &&  (keyPressed == hotkeys[KeyPurpose.FirstTemplate] || keyPressed == hotkeys[KeyPurpose.SecondTemplate]
                         || keyPressed == hotkeys[KeyPurpose.ThirdTemplate] || keyPressed == hotkeys[KeyPurpose.FourthTemplate])))
                        {
                            Stop();
                        }
                    }

                    if (bgMode)
                    {
                        if (keyPressed == hotkeys[KeyPurpose.FirstTemplate])
                        {
                            TrySelectTemplate(0);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.SecondTemplate])
                        {
                            TrySelectTemplate(1);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.ThirdTemplate])
                        {
                            TrySelectTemplate(2);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.FourthTemplate])
                        {
                            TrySelectTemplate(3);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.Start])
                        {
                            Btn_Start_Click(null, null);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.SetPoint])
                        {
                            ChangeCurrentClickCursorPoint(Cursor.Position.X, Cursor.Position.Y);
                        }
                        else if (keyPressed == hotkeys[KeyPurpose.AddClick])
                        {
                            AddClick();
                        }
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
            if (this[tabPage, ControlType.CoordinateX] is NumericUpDown nudX)
                nudX.ValueChanged += Coordinates_ValueChanged;
            if (this[tabPage, ControlType.CoordinateY] is NumericUpDown nudY)
                nudY.ValueChanged += Coordinates_ValueChanged;
            if (this[tabPage, ControlType.ClicksCount] is NumericUpDown nudCount)
                nudCount.ValueChanged += ClickCount_ValueChanged;
            if (this[tabPage, ControlType.Delay] is NumericUpDown nudDelay)
                nudDelay.ValueChanged += DelayBefore_ValueChanged;
            if (this[tabPage, ControlType.Enabled] is CheckBox cbEnabled)
                cbEnabled.CheckedChanged += Enabled_CheckedChanged;
            if (this[tabPage, ControlType.RightClick] is CheckBox cbRight)
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
            if (this[tabPage, ControlType.CoordinateX] is NumericUpDown nudX)
                nudX.ValueChanged -= Coordinates_ValueChanged;
            if (this[tabPage, ControlType.CoordinateY] is NumericUpDown nudY)
                nudY.ValueChanged -= Coordinates_ValueChanged;
            if (this[tabPage, ControlType.ClicksCount] is NumericUpDown nudCount)
                nudCount.ValueChanged -= ClickCount_ValueChanged;
            if (this[tabPage, ControlType.Delay] is NumericUpDown nudDelay)
                nudDelay.ValueChanged -= DelayBefore_ValueChanged;
            if (this[tabPage, ControlType.Enabled] is CheckBox cbEnabled)
                cbEnabled.CheckedChanged -= Enabled_CheckedChanged;
            if (this[tabPage, ControlType.RightClick] is CheckBox cbRight)
                cbRight.CheckedChanged -= Right_CheckedChanged;
        }

        private void TrySelectTemplate(int index)
        {
            if (index < 0 || index >= service.Templates.Count)
                return;

            selectedTemplate = GetTemplate(index);

            if (selectedTemplate == null)
            {
                Error(ERROR);
                return;
            }

            SyncUIParams();
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

        private ResultModel TryAddTemplate(String name)
        {
            var result = service.TryAddTemplate(name);

            if (result.Success)
            {
                selectedTemplate = service.Templates.LastOrDefault();
                SyncUIParams();
            }

            return result;
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

            NumericUpDown nudX = this[ControlType.CoordinateX] as NumericUpDown;
            NumericUpDown nudY = this[ControlType.CoordinateY] as NumericUpDown;

            if (Cursor.Position.X > nudX.Maximum || Cursor.Position.Y > nudY.Maximum)
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
        private Control this[ControlType controlType]
        {
            get
            {
                return this[Tabs_Clicks.SelectedTab, controlType];
            }
        }

        private Control this[TabPage tabPage, ControlType controlType]
        {
            get
            {
                switch (controlType)
                {
                    case ControlType.CoordinateX:
                        return tabPage.Controls[NUD_X];
                    case ControlType.CoordinateY:
                        return tabPage.Controls[NUD_Y];
                    case ControlType.ClicksCount:
                        return tabPage.Controls[NUD_CLICKS_COUNT];
                    case ControlType.Delay:
                        return tabPage.Controls[NUD_DELAY_BEFORE];
                    case ControlType.Enabled:
                        return tabPage.Controls[CB_Enabled];
                    case ControlType.RightClick:
                        return tabPage.Controls[CB_Right];
                    default:
                        return null;
                }
            }
        }
        #endregion

        #region Form validity
        private bool AreParametersValid
        {
            get
            {
                return IsAppPathValid && AreCoordinatesValid;
            }
        }

        private bool IsAppPathValid
        {
            get
            {
                return String.IsNullOrWhiteSpace(selectedTemplate.AppPath)
                    || File.Exists(selectedTemplate.AppPath);
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
                    NumericUpDown nudX = this[ControlType.CoordinateX] as NumericUpDown;
                    NumericUpDown nudY = this[ControlType.CoordinateY] as NumericUpDown;

                    result = result
                        && nudX.Value >= 0 && nudX.Value <= w
                        && nudY.Value >= 0 && nudY.Value <= h;
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
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "JSON files (*.json)|*.json"
            };

            using (ofd)
            {
                DialogResult ofdResult = ofd.ShowDialog(this);

                if (ofdResult == DialogResult.OK && File.Exists(ofd.FileName))
                {
                    if (service.AreParametersChanged)
                    {
                        ExitForm exitForm = new ExitForm(service);
                        DialogResult result = exitForm.ShowDialog(this);
                    }

                    service.ReadNewParameters(ofd.FileName);
                    selectedTemplate = service.Templates.FirstOrDefault();
                    SyncUIParams(true);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json",
            };

            using (sfd)
            {
                DialogResult sofdResult = sfd.ShowDialog(this);

                if (sofdResult == DialogResult.OK)
                {
                    service.TryWriteParameters(sfd.FileName);
                }
            }
        }

        private void revertChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (service.AreParametersChanged)
            {
                if (MessageBox.Show("Are you sure?", "Revert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    service.Reset();
                    selectedTemplate = service.Templates.FirstOrDefault();
                    SyncUIParams(true);
                }
            }
        }

        private void CB_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrySelectTemplate(CB_Template.SelectedIndex);
        }

        private void Btn_AddTemplate_Click(object sender, EventArgs e)
        {
            EnterNameForm nameForm = new EnterNameForm(TryAddTemplate, "Template name");
            nameForm.ShowDialog(this);
        }

        private void Btn_RemoveTemplate_Click(object sender, EventArgs e)
        {
            RemoveCurrentTemplate();
        }

        private void Btn_SelectChangeApp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe",
            };

            using (ofd)
            {
                DialogResult result = ofd.ShowDialog(this);

                if (result == DialogResult.OK && File.Exists(ofd.FileName))
                {
                    selectedTemplate.AppPath = ofd.FileName;
                    SyncStartApp();
                }
            }
        }

        private void Lbl_RemoveApp_Click(object sender, EventArgs e)
        {
            selectedTemplate.AppPath = null;
            SyncStartApp();
        }

        private async void Btn_Start_Click(object sender, EventArgs e)
        {
            performs = true;
            Lbl_Hint0.Visible = false;
            Lbl_Hint1.Visible = true;
            String oldText = Lbl_Hint1.Text;
            Lbl_Hint1.Text = $"Press \"{hotkeys[KeyPurpose.Stop]}\" to stop performing";
            Lbl_Hint2.Visible = false;
            Enabled = false;

            await Task.Run(() =>
            {
                Start();
            });

            Enabled = true;
            Lbl_Hint0.Visible = bgMode;
            Lbl_Hint1.Visible = bgMode;
            Lbl_Hint1.Text = oldText;
            Lbl_Hint2.Visible = true;
            performs = false;
        }

        private void Coordinates_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Parent is TabPage tabPage)
            {
                NumericUpDown nudX = this[ControlType.CoordinateX] as NumericUpDown;
                NumericUpDown nudY = this[ControlType.CoordinateY] as NumericUpDown;

                ChangePoint(GetCurrentClickObj(), (int)nudX.Value, (int)nudY.Value);
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

        private void Btn_Test_Click(object sender, EventArgs e)
        {
            TestClick(GetCurrentClickObj());
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
                if (service.AreParametersChanged)
                {
                    Unhook();

                    ExitForm exitForm = new ExitForm(service);
                    DialogResult result = exitForm.ShowDialog(this);
                    e.Cancel = result == DialogResult.Cancel;
                }
            }
            else
            {
                if (!service.TryWriteParameters())
                    Error(SAVE_ERROR);
            }
        }

        private void Btn_Debug_Click(object sender, EventArgs e)
        {
            //var s = (Tabs_Clicks.TabPages[0].Controls[NUD_X] as NumericUpDown);

            //s.V

            //MessageBox.Show(s.ToString());

            //(this[Tabs_Clicks.TabPages[1], ControlType.CoordinateX] as NumericUpDown).Value += 10;

            PInvokeHelper.mouse_event(MouseEvents.MOUSEEVENTF_MOVE | MouseEvents.MOUSEEVENTF_ABSOLUTE, 100, 100, 0, IntPtr.Zero);
        }
        #endregion
    }

    internal enum ControlType : byte
    {
        CoordinateX,
        CoordinateY,
        ClicksCount,
        Delay,
        Enabled,
        RightClick,
    }

    internal enum KeyPurpose : byte
    {
        FirstTemplate,
        SecondTemplate,
        ThirdTemplate,
        FourthTemplate,
        Start,
        Stop,
        SetPoint,
        AddClick,
    }
}
