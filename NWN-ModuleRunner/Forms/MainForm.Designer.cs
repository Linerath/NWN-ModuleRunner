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
            this.X0 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Y0 = new System.Windows.Forms.NumericUpDown();
            this.Cmb_Screens = new System.Windows.Forms.ComboBox();
            this.Lbl_Screen = new System.Windows.Forms.Label();
            this.Lbl_Cursor = new System.Windows.Forms.Label();
            this.Lbl_CursorXY = new System.Windows.Forms.Label();
            this.Lbl_Hint0 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.X0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y0)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Start.Location = new System.Drawing.Point(186, 55);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(94, 56);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // X0
            // 
            this.X0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.X0.Location = new System.Drawing.Point(96, 55);
            this.X0.Name = "X0";
            this.X0.Size = new System.Drawing.Size(84, 25);
            this.X0.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(71, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // Y0
            // 
            this.Y0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Y0.Location = new System.Drawing.Point(96, 86);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(84, 25);
            this.Y0.TabIndex = 3;
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
            this.Lbl_Hint0.Location = new System.Drawing.Point(12, 124);
            this.Lbl_Hint0.Name = "Lbl_Hint0";
            this.Lbl_Hint0.Size = new System.Drawing.Size(345, 17);
            this.Lbl_Hint0.TabIndex = 9;
            this.Lbl_Hint0.Text = "Press \"F1\" to set coordinates from current cursor position";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 151);
            this.Controls.Add(this.Lbl_Hint0);
            this.Controls.Add(this.Lbl_CursorXY);
            this.Controls.Add(this.Lbl_Cursor);
            this.Controls.Add(this.Lbl_Screen);
            this.Controls.Add(this.Cmb_Screens);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Y0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.X0);
            this.Controls.Add(this.Btn_Start);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWN Module runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.X0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.NumericUpDown X0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Y0;
        private System.Windows.Forms.ComboBox Cmb_Screens;
        private System.Windows.Forms.Label Lbl_Screen;
        private System.Windows.Forms.Label Lbl_Cursor;
        private System.Windows.Forms.Label Lbl_CursorXY;
        private System.Windows.Forms.Label Lbl_Hint0;
    }
}

