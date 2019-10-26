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
            this.Cmb_Screens = new System.Windows.Forms.ComboBox();
            this.Lbl_Screen = new System.Windows.Forms.Label();
            this.Lbl_Cursor = new System.Windows.Forms.Label();
            this.Lbl_CursorXY = new System.Windows.Forms.Label();
            this.Lbl_Hint0 = new System.Windows.Forms.Label();
            this.Lbl_Hint1 = new System.Windows.Forms.Label();
            this.Tabs_Clicks = new System.Windows.Forms.TabControl();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Btn_Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Start.Location = new System.Drawing.Point(132, 199);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(109, 56);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Cmb_Screens
            // 
            this.Cmb_Screens.Enabled = false;
            this.Cmb_Screens.FormattingEnabled = true;
            this.Cmb_Screens.Location = new System.Drawing.Point(68, 9);
            this.Cmb_Screens.Name = "Cmb_Screens";
            this.Cmb_Screens.Size = new System.Drawing.Size(74, 21);
            this.Cmb_Screens.TabIndex = 5;
            // 
            // Lbl_Screen
            // 
            this.Lbl_Screen.AutoSize = true;
            this.Lbl_Screen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Screen.Location = new System.Drawing.Point(12, 9);
            this.Lbl_Screen.Name = "Lbl_Screen";
            this.Lbl_Screen.Size = new System.Drawing.Size(50, 17);
            this.Lbl_Screen.TabIndex = 6;
            this.Lbl_Screen.Text = "Screen:";
            // 
            // Lbl_Cursor
            // 
            this.Lbl_Cursor.AutoSize = true;
            this.Lbl_Cursor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Cursor.Location = new System.Drawing.Point(148, 9);
            this.Lbl_Cursor.Name = "Lbl_Cursor";
            this.Lbl_Cursor.Size = new System.Drawing.Size(50, 17);
            this.Lbl_Cursor.TabIndex = 7;
            this.Lbl_Cursor.Text = "Cursor:";
            this.Lbl_Cursor.Visible = false;
            // 
            // Lbl_CursorXY
            // 
            this.Lbl_CursorXY.AutoSize = true;
            this.Lbl_CursorXY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_CursorXY.Location = new System.Drawing.Point(201, 9);
            this.Lbl_CursorXY.Name = "Lbl_CursorXY";
            this.Lbl_CursorXY.Size = new System.Drawing.Size(23, 17);
            this.Lbl_CursorXY.TabIndex = 8;
            this.Lbl_CursorXY.Text = "XY";
            this.Lbl_CursorXY.Visible = false;
            // 
            // Lbl_Hint0
            // 
            this.Lbl_Hint0.AutoSize = true;
            this.Lbl_Hint0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint0.Location = new System.Drawing.Point(12, 275);
            this.Lbl_Hint0.Name = "Lbl_Hint0";
            this.Lbl_Hint0.Size = new System.Drawing.Size(345, 17);
            this.Lbl_Hint0.TabIndex = 9;
            this.Lbl_Hint0.Text = "Press \"F1\" to set coordinates from current cursor position";
            // 
            // Lbl_Hint1
            // 
            this.Lbl_Hint1.AutoSize = true;
            this.Lbl_Hint1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lbl_Hint1.Location = new System.Drawing.Point(129, 258);
            this.Lbl_Hint1.Name = "Lbl_Hint1";
            this.Lbl_Hint1.Size = new System.Drawing.Size(112, 17);
            this.Lbl_Hint1.TabIndex = 10;
            this.Lbl_Hint1.Text = "Press \"F5\" to start";
            // 
            // Tabs_Clicks
            // 
            this.Tabs_Clicks.Location = new System.Drawing.Point(12, 50);
            this.Tabs_Clicks.Name = "Tabs_Clicks";
            this.Tabs_Clicks.SelectedIndex = 0;
            this.Tabs_Clicks.Size = new System.Drawing.Size(343, 143);
            this.Tabs_Clicks.TabIndex = 12;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Add.Location = new System.Drawing.Point(16, 195);
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
            this.Btn_Remove.Location = new System.Drawing.Point(47, 195);
            this.Btn_Remove.Name = "Btn_Remove";
            this.Btn_Remove.Size = new System.Drawing.Size(25, 25);
            this.Btn_Remove.TabIndex = 14;
            this.Btn_Remove.Text = "-";
            this.Btn_Remove.UseVisualStyleBackColor = true;
            this.Btn_Remove.Click += new System.EventHandler(this.Btn_Remove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 301);
            this.Controls.Add(this.Btn_Remove);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.Tabs_Clicks);
            this.Controls.Add(this.Lbl_Hint1);
            this.Controls.Add(this.Lbl_Hint0);
            this.Controls.Add(this.Lbl_CursorXY);
            this.Controls.Add(this.Lbl_Cursor);
            this.Controls.Add(this.Lbl_Screen);
            this.Controls.Add(this.Cmb_Screens);
            this.Controls.Add(this.Btn_Start);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWN Module runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.ComboBox Cmb_Screens;
        private System.Windows.Forms.Label Lbl_Screen;
        private System.Windows.Forms.Label Lbl_Cursor;
        private System.Windows.Forms.Label Lbl_CursorXY;
        private System.Windows.Forms.Label Lbl_Hint0;
        private System.Windows.Forms.Label Lbl_Hint1;
        private System.Windows.Forms.TabControl Tabs_Clicks;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Button Btn_Remove;
    }
}

