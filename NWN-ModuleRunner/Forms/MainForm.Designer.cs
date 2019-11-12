namespace NWN_ModuleRunner.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_AddClick = new System.Windows.Forms.Button();
            this.Btn_RemoveClick = new System.Windows.Forms.Button();
            this.Btn_BGMode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Hint1 = new System.Windows.Forms.Label();
            this.Lbl_Hint0 = new System.Windows.Forms.Label();
            this.Lbl_Hint2 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.CB_Template = new System.Windows.Forms.ComboBox();
            this.Lbl_Template = new System.Windows.Forms.Label();
            this.Btn_RemoveTemplate = new System.Windows.Forms.Button();
            this.Btn_AddTemplate = new System.Windows.Forms.Button();
            this.Btn_SelectChangeApp = new System.Windows.Forms.Button();
            this.Lbl_AppPath = new System.Windows.Forms.Label();
            this.Lbl_RemoveApp = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs_Clicks = new System.Windows.Forms.TabControl();
            this.Btn_Hotkeys = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.Tabs_Clicks.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Start.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Btn_Start.FlatAppearance.BorderSize = 2;
            this.Btn_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.Btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Start.Location = new System.Drawing.Point(12, 289);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(378, 30);
            this.Btn_Start.TabIndex = 5;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_AddClick
            // 
            this.Btn_AddClick.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_AddClick.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_AddClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_AddClick.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_AddClick.Location = new System.Drawing.Point(12, 93);
            this.Btn_AddClick.Name = "Btn_AddClick";
            this.Btn_AddClick.Size = new System.Drawing.Size(30, 25);
            this.Btn_AddClick.TabIndex = 2;
            this.Btn_AddClick.Text = "+";
            this.Btn_AddClick.UseVisualStyleBackColor = true;
            this.Btn_AddClick.Click += new System.EventHandler(this.Btn_AddClick_Click);
            // 
            // Btn_RemoveClick
            // 
            this.Btn_RemoveClick.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_RemoveClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_RemoveClick.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_RemoveClick.Location = new System.Drawing.Point(43, 93);
            this.Btn_RemoveClick.Name = "Btn_RemoveClick";
            this.Btn_RemoveClick.Size = new System.Drawing.Size(30, 25);
            this.Btn_RemoveClick.TabIndex = 3;
            this.Btn_RemoveClick.Text = "-";
            this.Btn_RemoveClick.UseVisualStyleBackColor = true;
            this.Btn_RemoveClick.Click += new System.EventHandler(this.Btn_RemoveClick_Click);
            // 
            // Btn_BGMode
            // 
            this.Btn_BGMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_BGMode.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_BGMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_BGMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_BGMode.Location = new System.Drawing.Point(12, 325);
            this.Btn_BGMode.Name = "Btn_BGMode";
            this.Btn_BGMode.Size = new System.Drawing.Size(111, 30);
            this.Btn_BGMode.TabIndex = 6;
            this.Btn_BGMode.UseVisualStyleBackColor = true;
            this.Btn_BGMode.Click += new System.EventHandler(this.Btn_BGMode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.Lbl_Hint1);
            this.groupBox1.Controls.Add(this.Lbl_Hint0);
            this.groupBox1.Controls.Add(this.Lbl_Hint2);
            this.groupBox1.Location = new System.Drawing.Point(12, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 80);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_Hint1
            // 
            this.Lbl_Hint1.AutoSize = true;
            this.Lbl_Hint1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint1.Location = new System.Drawing.Point(6, 33);
            this.Lbl_Hint1.Name = "Lbl_Hint1";
            this.Lbl_Hint1.Size = new System.Drawing.Size(36, 17);
            this.Lbl_Hint1.TabIndex = 20;
            this.Lbl_Hint1.Text = "hint1";
            this.Lbl_Hint1.Visible = false;
            // 
            // Lbl_Hint0
            // 
            this.Lbl_Hint0.AutoSize = true;
            this.Lbl_Hint0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint0.Location = new System.Drawing.Point(6, 50);
            this.Lbl_Hint0.Name = "Lbl_Hint0";
            this.Lbl_Hint0.Size = new System.Drawing.Size(36, 17);
            this.Lbl_Hint0.TabIndex = 19;
            this.Lbl_Hint0.Text = "hint0";
            this.Lbl_Hint0.Visible = false;
            // 
            // Lbl_Hint2
            // 
            this.Lbl_Hint2.AutoSize = true;
            this.Lbl_Hint2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint2.Location = new System.Drawing.Point(6, 16);
            this.Lbl_Hint2.Name = "Lbl_Hint2";
            this.Lbl_Hint2.Size = new System.Drawing.Size(36, 17);
            this.Lbl_Hint2.TabIndex = 18;
            this.Lbl_Hint2.Text = "hint2";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Clear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Clear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Clear.Location = new System.Drawing.Point(317, 93);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(69, 26);
            this.Btn_Clear.TabIndex = 4;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // CB_Template
            // 
            this.CB_Template.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CB_Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Template.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Template.FormattingEnabled = true;
            this.CB_Template.Location = new System.Drawing.Point(75, 30);
            this.CB_Template.Name = "CB_Template";
            this.CB_Template.Size = new System.Drawing.Size(253, 25);
            this.CB_Template.TabIndex = 1;
            this.CB_Template.SelectedIndexChanged += new System.EventHandler(this.CB_Template_SelectedIndexChanged);
            // 
            // Lbl_Template
            // 
            this.Lbl_Template.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Lbl_Template.AutoSize = true;
            this.Lbl_Template.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Template.Location = new System.Drawing.Point(9, 33);
            this.Lbl_Template.Name = "Lbl_Template";
            this.Lbl_Template.Size = new System.Drawing.Size(64, 17);
            this.Lbl_Template.TabIndex = 21;
            this.Lbl_Template.Text = "Template:";
            // 
            // Btn_RemoveTemplate
            // 
            this.Btn_RemoveTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_RemoveTemplate.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_RemoveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_RemoveTemplate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_RemoveTemplate.Location = new System.Drawing.Point(334, 30);
            this.Btn_RemoveTemplate.Name = "Btn_RemoveTemplate";
            this.Btn_RemoveTemplate.Size = new System.Drawing.Size(25, 25);
            this.Btn_RemoveTemplate.TabIndex = 23;
            this.Btn_RemoveTemplate.Text = "-";
            this.Btn_RemoveTemplate.UseVisualStyleBackColor = true;
            this.Btn_RemoveTemplate.Click += new System.EventHandler(this.Btn_RemoveTemplate_Click);
            // 
            // Btn_AddTemplate
            // 
            this.Btn_AddTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_AddTemplate.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_AddTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_AddTemplate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_AddTemplate.Location = new System.Drawing.Point(365, 30);
            this.Btn_AddTemplate.Name = "Btn_AddTemplate";
            this.Btn_AddTemplate.Size = new System.Drawing.Size(25, 25);
            this.Btn_AddTemplate.TabIndex = 24;
            this.Btn_AddTemplate.Text = "+";
            this.Btn_AddTemplate.UseVisualStyleBackColor = true;
            this.Btn_AddTemplate.Click += new System.EventHandler(this.Btn_AddTemplate_Click);
            // 
            // Btn_SelectChangeApp
            // 
            this.Btn_SelectChangeApp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_SelectChangeApp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_SelectChangeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SelectChangeApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_SelectChangeApp.Location = new System.Drawing.Point(12, 61);
            this.Btn_SelectChangeApp.Name = "Btn_SelectChangeApp";
            this.Btn_SelectChangeApp.Size = new System.Drawing.Size(84, 25);
            this.Btn_SelectChangeApp.TabIndex = 26;
            this.Btn_SelectChangeApp.Text = "Select app";
            this.Btn_SelectChangeApp.UseVisualStyleBackColor = true;
            this.Btn_SelectChangeApp.Click += new System.EventHandler(this.Btn_SelectChangeApp_Click);
            // 
            // Lbl_AppPath
            // 
            this.Lbl_AppPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Lbl_AppPath.AutoSize = true;
            this.Lbl_AppPath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_AppPath.Location = new System.Drawing.Point(114, 68);
            this.Lbl_AppPath.Name = "Lbl_AppPath";
            this.Lbl_AppPath.Size = new System.Drawing.Size(25, 13);
            this.Lbl_AppPath.TabIndex = 21;
            this.Lbl_AppPath.Text = "abc";
            // 
            // Lbl_RemoveApp
            // 
            this.Lbl_RemoveApp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Lbl_RemoveApp.AutoSize = true;
            this.Lbl_RemoveApp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_RemoveApp.Location = new System.Drawing.Point(97, 65);
            this.Lbl_RemoveApp.Name = "Lbl_RemoveApp";
            this.Lbl_RemoveApp.Size = new System.Drawing.Size(16, 17);
            this.Lbl_RemoveApp.TabIndex = 27;
            this.Lbl_RemoveApp.Text = "X";
            this.Lbl_RemoveApp.Click += new System.EventHandler(this.Lbl_RemoveApp_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(402, 24);
            this.MainMenu.TabIndex = 29;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Visible = false;
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revertChangesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // revertChangesToolStripMenuItem
            // 
            this.revertChangesToolStripMenuItem.Name = "revertChangesToolStripMenuItem";
            this.revertChangesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.revertChangesToolStripMenuItem.Text = "Revert changes";
            this.revertChangesToolStripMenuItem.Click += new System.EventHandler(this.revertChangesToolStripMenuItem_Click);
            // 
            // Tabs_Clicks
            // 
            this.Tabs_Clicks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Tabs_Clicks.Controls.Add(this.tabPage1);
            this.Tabs_Clicks.Location = new System.Drawing.Point(12, 124);
            this.Tabs_Clicks.Name = "Tabs_Clicks";
            this.Tabs_Clicks.SelectedIndex = 0;
            this.Tabs_Clicks.Size = new System.Drawing.Size(378, 159);
            this.Tabs_Clicks.TabIndex = 30;
            // 
            // Btn_Hotkeys
            // 
            this.Btn_Hotkeys.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Hotkeys.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Hotkeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Hotkeys.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Hotkeys.Location = new System.Drawing.Point(307, 325);
            this.Btn_Hotkeys.Name = "Btn_Hotkeys";
            this.Btn_Hotkeys.Size = new System.Drawing.Size(83, 30);
            this.Btn_Hotkeys.TabIndex = 31;
            this.Btn_Hotkeys.Text = "hotkeys";
            this.Btn_Hotkeys.UseVisualStyleBackColor = true;
            this.Btn_Hotkeys.Click += new System.EventHandler(this.Btn_Hotkeys_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(370, 133);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(317, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Clone";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(277, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Clone";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 444);
            this.Controls.Add(this.Btn_Hotkeys);
            this.Controls.Add(this.Tabs_Clicks);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Btn_BGMode);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Lbl_RemoveApp);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_AddClick);
            this.Controls.Add(this.Btn_RemoveClick);
            this.Controls.Add(this.Lbl_AppPath);
            this.Controls.Add(this.Btn_SelectChangeApp);
            this.Controls.Add(this.Btn_AddTemplate);
            this.Controls.Add(this.Btn_RemoveTemplate);
            this.Controls.Add(this.Lbl_Template);
            this.Controls.Add(this.CB_Template);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWN Module runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Tabs_Clicks.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_AddClick;
        private System.Windows.Forms.Button Btn_RemoveClick;
        private System.Windows.Forms.Button Btn_BGMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Hint1;
        private System.Windows.Forms.Label Lbl_Hint0;
        private System.Windows.Forms.Label Lbl_Hint2;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.ComboBox CB_Template;
        private System.Windows.Forms.Label Lbl_Template;
        private System.Windows.Forms.Button Btn_RemoveTemplate;
        private System.Windows.Forms.Button Btn_AddTemplate;
        private System.Windows.Forms.Button Btn_SelectChangeApp;
        private System.Windows.Forms.Label Lbl_AppPath;
        private System.Windows.Forms.Label Lbl_RemoveApp;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl Tabs_Clicks;
        private System.Windows.Forms.Button Btn_Hotkeys;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

