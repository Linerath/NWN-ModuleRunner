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
            this.Tabs_Clicks = new System.Windows.Forms.TabControl();
            this.Btn_AddClick = new System.Windows.Forms.Button();
            this.Btn_RemoveClick = new System.Windows.Forms.Button();
            this.Btn_BGMode = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Hint1 = new System.Windows.Forms.Label();
            this.Lbl_Hint0 = new System.Windows.Forms.Label();
            this.Lbl_Hint2 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_Revert = new System.Windows.Forms.Button();
            this.CB_Template = new System.Windows.Forms.ComboBox();
            this.Lbl_Template = new System.Windows.Forms.Label();
            this.Btn_RemoveTemplate = new System.Windows.Forms.Button();
            this.Btn_AddTemplate = new System.Windows.Forms.Button();
            this.Btn_Debug = new System.Windows.Forms.Button();
            this.Btn_SelectChangeApp = new System.Windows.Forms.Button();
            this.Lbl_AppPath = new System.Windows.Forms.Label();
            this.Lbl_RemoveApp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Start.Location = new System.Drawing.Point(81, 184);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(109, 56);
            this.Btn_Start.TabIndex = 5;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Tabs_Clicks
            // 
            this.Tabs_Clicks.Location = new System.Drawing.Point(6, 19);
            this.Tabs_Clicks.Name = "Tabs_Clicks";
            this.Tabs_Clicks.SelectedIndex = 0;
            this.Tabs_Clicks.Size = new System.Drawing.Size(361, 159);
            this.Tabs_Clicks.TabIndex = 0;
            this.Tabs_Clicks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tabs_Clicks_KeyPress);
            // 
            // Btn_AddClick
            // 
            this.Btn_AddClick.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_AddClick.Location = new System.Drawing.Point(6, 184);
            this.Btn_AddClick.Name = "Btn_AddClick";
            this.Btn_AddClick.Size = new System.Drawing.Size(30, 25);
            this.Btn_AddClick.TabIndex = 2;
            this.Btn_AddClick.Text = "+";
            this.Btn_AddClick.UseVisualStyleBackColor = true;
            this.Btn_AddClick.Click += new System.EventHandler(this.Btn_AddClick_Click);
            // 
            // Btn_RemoveClick
            // 
            this.Btn_RemoveClick.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_RemoveClick.Location = new System.Drawing.Point(45, 184);
            this.Btn_RemoveClick.Name = "Btn_RemoveClick";
            this.Btn_RemoveClick.Size = new System.Drawing.Size(30, 25);
            this.Btn_RemoveClick.TabIndex = 3;
            this.Btn_RemoveClick.Text = "-";
            this.Btn_RemoveClick.UseVisualStyleBackColor = true;
            this.Btn_RemoveClick.Click += new System.EventHandler(this.Btn_RemoveClick_Click);
            // 
            // Btn_BGMode
            // 
            this.Btn_BGMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_BGMode.Location = new System.Drawing.Point(196, 184);
            this.Btn_BGMode.Name = "Btn_BGMode";
            this.Btn_BGMode.Size = new System.Drawing.Size(109, 56);
            this.Btn_BGMode.TabIndex = 6;
            this.Btn_BGMode.UseVisualStyleBackColor = true;
            this.Btn_BGMode.Click += new System.EventHandler(this.Btn_BGMode_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Save.Location = new System.Drawing.Point(311, 184);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(56, 25);
            this.Btn_Save.TabIndex = 7;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl_Hint1);
            this.groupBox1.Controls.Add(this.Lbl_Hint0);
            this.groupBox1.Controls.Add(this.Lbl_Hint2);
            this.groupBox1.Location = new System.Drawing.Point(12, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 80);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_Hint1
            // 
            this.Lbl_Hint1.AutoSize = true;
            this.Lbl_Hint1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint1.Location = new System.Drawing.Point(90, 32);
            this.Lbl_Hint1.Name = "Lbl_Hint1";
            this.Lbl_Hint1.Size = new System.Drawing.Size(184, 17);
            this.Lbl_Hint1.TabIndex = 20;
            this.Lbl_Hint1.Text = "Press \"F12\" to create new click";
            this.Lbl_Hint1.Visible = false;
            // 
            // Lbl_Hint0
            // 
            this.Lbl_Hint0.AutoSize = true;
            this.Lbl_Hint0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint0.Location = new System.Drawing.Point(125, 15);
            this.Lbl_Hint0.Name = "Lbl_Hint0";
            this.Lbl_Hint0.Size = new System.Drawing.Size(112, 17);
            this.Lbl_Hint0.TabIndex = 19;
            this.Lbl_Hint0.Text = "Press \"F5\" to start";
            this.Lbl_Hint0.Visible = false;
            // 
            // Lbl_Hint2
            // 
            this.Lbl_Hint2.AutoSize = true;
            this.Lbl_Hint2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint2.Location = new System.Drawing.Point(10, 55);
            this.Lbl_Hint2.Name = "Lbl_Hint2";
            this.Lbl_Hint2.Size = new System.Drawing.Size(345, 17);
            this.Lbl_Hint2.TabIndex = 18;
            this.Lbl_Hint2.Text = "Press \"F9\" to set coordinates from current cursor position";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Clear.Location = new System.Drawing.Point(6, 215);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(69, 25);
            this.Btn_Clear.TabIndex = 4;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Btn_Revert);
            this.groupBox2.Controls.Add(this.Tabs_Clicks);
            this.groupBox2.Controls.Add(this.Btn_Start);
            this.groupBox2.Controls.Add(this.Btn_AddClick);
            this.groupBox2.Controls.Add(this.Btn_Clear);
            this.groupBox2.Controls.Add(this.Btn_RemoveClick);
            this.groupBox2.Controls.Add(this.Btn_BGMode);
            this.groupBox2.Controls.Add(this.Btn_Save);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 250);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // Btn_Revert
            // 
            this.Btn_Revert.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Revert.Location = new System.Drawing.Point(311, 215);
            this.Btn_Revert.Name = "Btn_Revert";
            this.Btn_Revert.Size = new System.Drawing.Size(56, 25);
            this.Btn_Revert.TabIndex = 8;
            this.Btn_Revert.Text = "Revert";
            this.Btn_Revert.UseVisualStyleBackColor = true;
            this.Btn_Revert.Click += new System.EventHandler(this.Btn_Revert_Click);
            // 
            // CB_Template
            // 
            this.CB_Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Template.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CB_Template.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Template.FormattingEnabled = true;
            this.CB_Template.Location = new System.Drawing.Point(75, 6);
            this.CB_Template.Name = "CB_Template";
            this.CB_Template.Size = new System.Drawing.Size(121, 25);
            this.CB_Template.TabIndex = 1;
            this.CB_Template.SelectedIndexChanged += new System.EventHandler(this.CB_Template_SelectedIndexChanged);
            // 
            // Lbl_Template
            // 
            this.Lbl_Template.AutoSize = true;
            this.Lbl_Template.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Template.Location = new System.Drawing.Point(9, 9);
            this.Lbl_Template.Name = "Lbl_Template";
            this.Lbl_Template.Size = new System.Drawing.Size(64, 17);
            this.Lbl_Template.TabIndex = 21;
            this.Lbl_Template.Text = "Template:";
            // 
            // Btn_RemoveTemplate
            // 
            this.Btn_RemoveTemplate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_RemoveTemplate.Location = new System.Drawing.Point(202, 6);
            this.Btn_RemoveTemplate.Name = "Btn_RemoveTemplate";
            this.Btn_RemoveTemplate.Size = new System.Drawing.Size(25, 25);
            this.Btn_RemoveTemplate.TabIndex = 23;
            this.Btn_RemoveTemplate.Text = "-";
            this.Btn_RemoveTemplate.UseVisualStyleBackColor = true;
            this.Btn_RemoveTemplate.Click += new System.EventHandler(this.Btn_RemoveTemplate_Click);
            // 
            // Btn_AddTemplate
            // 
            this.Btn_AddTemplate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_AddTemplate.Location = new System.Drawing.Point(233, 6);
            this.Btn_AddTemplate.Name = "Btn_AddTemplate";
            this.Btn_AddTemplate.Size = new System.Drawing.Size(25, 25);
            this.Btn_AddTemplate.TabIndex = 24;
            this.Btn_AddTemplate.Text = "+";
            this.Btn_AddTemplate.UseVisualStyleBackColor = true;
            this.Btn_AddTemplate.Click += new System.EventHandler(this.Btn_AddTemplate_Click);
            // 
            // Btn_Debug
            // 
            this.Btn_Debug.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Debug.Location = new System.Drawing.Point(323, 6);
            this.Btn_Debug.Name = "Btn_Debug";
            this.Btn_Debug.Size = new System.Drawing.Size(63, 25);
            this.Btn_Debug.TabIndex = 25;
            this.Btn_Debug.Text = "Debug";
            this.Btn_Debug.UseVisualStyleBackColor = true;
            this.Btn_Debug.Visible = false;
            this.Btn_Debug.Click += new System.EventHandler(this.Btn_Debug_Click);
            // 
            // Btn_SelectChangeApp
            // 
            this.Btn_SelectChangeApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_SelectChangeApp.Location = new System.Drawing.Point(12, 37);
            this.Btn_SelectChangeApp.Name = "Btn_SelectChangeApp";
            this.Btn_SelectChangeApp.Size = new System.Drawing.Size(84, 25);
            this.Btn_SelectChangeApp.TabIndex = 26;
            this.Btn_SelectChangeApp.Text = "Select app";
            this.Btn_SelectChangeApp.UseVisualStyleBackColor = true;
            this.Btn_SelectChangeApp.Click += new System.EventHandler(this.Btn_SelectChangeApp_Click);
            // 
            // Lbl_AppPath
            // 
            this.Lbl_AppPath.AutoSize = true;
            this.Lbl_AppPath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_AppPath.Location = new System.Drawing.Point(114, 44);
            this.Lbl_AppPath.Name = "Lbl_AppPath";
            this.Lbl_AppPath.Size = new System.Drawing.Size(25, 13);
            this.Lbl_AppPath.TabIndex = 21;
            this.Lbl_AppPath.Text = "abc";
            // 
            // Lbl_RemoveApp
            // 
            this.Lbl_RemoveApp.AutoSize = true;
            this.Lbl_RemoveApp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_RemoveApp.Location = new System.Drawing.Point(97, 41);
            this.Lbl_RemoveApp.Name = "Lbl_RemoveApp";
            this.Lbl_RemoveApp.Size = new System.Drawing.Size(16, 17);
            this.Lbl_RemoveApp.TabIndex = 27;
            this.Lbl_RemoveApp.Text = "X";
            this.Lbl_RemoveApp.Click += new System.EventHandler(this.Lbl_RemoveApp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 398);
            this.Controls.Add(this.Lbl_RemoveApp);
            this.Controls.Add(this.Lbl_AppPath);
            this.Controls.Add(this.Btn_SelectChangeApp);
            this.Controls.Add(this.Btn_Debug);
            this.Controls.Add(this.Btn_AddTemplate);
            this.Controls.Add(this.Btn_RemoveTemplate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Lbl_Template);
            this.Controls.Add(this.CB_Template);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWN Module runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TabControl Tabs_Clicks;
        private System.Windows.Forms.Button Btn_AddClick;
        private System.Windows.Forms.Button Btn_RemoveClick;
        private System.Windows.Forms.Button Btn_BGMode;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Hint1;
        private System.Windows.Forms.Label Lbl_Hint0;
        private System.Windows.Forms.Label Lbl_Hint2;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_Template;
        private System.Windows.Forms.Label Lbl_Template;
        private System.Windows.Forms.Button Btn_RemoveTemplate;
        private System.Windows.Forms.Button Btn_AddTemplate;
        private System.Windows.Forms.Button Btn_Debug;
        private System.Windows.Forms.Button Btn_Revert;
        private System.Windows.Forms.Button Btn_SelectChangeApp;
        private System.Windows.Forms.Label Lbl_AppPath;
        private System.Windows.Forms.Label Lbl_RemoveApp;
    }
}

