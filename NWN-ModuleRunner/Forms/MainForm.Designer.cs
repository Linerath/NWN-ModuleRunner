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
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Btn_Remove = new System.Windows.Forms.Button();
            this.Btn_BGMode = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Hint1 = new System.Windows.Forms.Label();
            this.Lbl_Hint0 = new System.Windows.Forms.Label();
            this.Lbl_Hint2 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Start.Location = new System.Drawing.Point(87, 176);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(109, 56);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Tabs_Clicks
            // 
            this.Tabs_Clicks.Location = new System.Drawing.Point(12, 12);
            this.Tabs_Clicks.Name = "Tabs_Clicks";
            this.Tabs_Clicks.SelectedIndex = 0;
            this.Tabs_Clicks.Size = new System.Drawing.Size(361, 159);
            this.Tabs_Clicks.TabIndex = 12;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Add.Location = new System.Drawing.Point(12, 177);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(25, 25);
            this.Btn_Add.TabIndex = 13;
            this.Btn_Add.Text = "+";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Btn_Remove
            // 
            this.Btn_Remove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Remove.Location = new System.Drawing.Point(43, 177);
            this.Btn_Remove.Name = "Btn_Remove";
            this.Btn_Remove.Size = new System.Drawing.Size(25, 25);
            this.Btn_Remove.TabIndex = 14;
            this.Btn_Remove.Text = "-";
            this.Btn_Remove.UseVisualStyleBackColor = true;
            this.Btn_Remove.Click += new System.EventHandler(this.Btn_Remove_Click);
            // 
            // Btn_BGMode
            // 
            this.Btn_BGMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_BGMode.Location = new System.Drawing.Point(202, 177);
            this.Btn_BGMode.Name = "Btn_BGMode";
            this.Btn_BGMode.Size = new System.Drawing.Size(109, 56);
            this.Btn_BGMode.TabIndex = 15;
            this.Btn_BGMode.UseVisualStyleBackColor = true;
            this.Btn_BGMode.Click += new System.EventHandler(this.Btn_BGMode_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Save.Location = new System.Drawing.Point(326, 177);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(47, 25);
            this.Btn_Save.TabIndex = 16;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_Hint1);
            this.groupBox1.Controls.Add(this.Lbl_Hint0);
            this.groupBox1.Controls.Add(this.Lbl_Hint2);
            this.groupBox1.Location = new System.Drawing.Point(12, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 80);
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
            this.Btn_Clear.Location = new System.Drawing.Point(12, 207);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(56, 25);
            this.Btn_Clear.TabIndex = 19;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 331);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_BGMode);
            this.Controls.Add(this.Btn_Remove);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.Tabs_Clicks);
            this.Controls.Add(this.Btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWN Module runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TabControl Tabs_Clicks;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Button Btn_Remove;
        private System.Windows.Forms.Button Btn_BGMode;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Hint1;
        private System.Windows.Forms.Label Lbl_Hint0;
        private System.Windows.Forms.Label Lbl_Hint2;
        private System.Windows.Forms.Button Btn_Clear;
    }
}

