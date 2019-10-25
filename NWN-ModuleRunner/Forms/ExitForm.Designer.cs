﻿namespace NWN_ModuleRunner.Forms
{
    partial class ExitForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Y = new System.Windows.Forms.Button();
            this.Btn_N = new System.Windows.Forms.Button();
            this.CB_Stop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save parameters?";
            // 
            // Btn_Y
            // 
            this.Btn_Y.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Y.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Y.Location = new System.Drawing.Point(32, 73);
            this.Btn_Y.Name = "Btn_Y";
            this.Btn_Y.Size = new System.Drawing.Size(72, 26);
            this.Btn_Y.TabIndex = 1;
            this.Btn_Y.Text = "Yes";
            this.Btn_Y.UseVisualStyleBackColor = true;
            this.Btn_Y.Click += new System.EventHandler(this.Btn_Y_Click);
            // 
            // Btn_N
            // 
            this.Btn_N.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_N.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_N.Location = new System.Drawing.Point(110, 73);
            this.Btn_N.Name = "Btn_N";
            this.Btn_N.Size = new System.Drawing.Size(72, 26);
            this.Btn_N.TabIndex = 2;
            this.Btn_N.Text = "No";
            this.Btn_N.UseVisualStyleBackColor = true;
            this.Btn_N.Click += new System.EventHandler(this.Btn_N_Click);
            // 
            // CB_Stop
            // 
            this.CB_Stop.AutoSize = true;
            this.CB_Stop.Location = new System.Drawing.Point(49, 39);
            this.CB_Stop.Name = "CB_Stop";
            this.CB_Stop.Size = new System.Drawing.Size(117, 17);
            this.CB_Stop.TabIndex = 3;
            this.CB_Stop.Text = "Don\'t ask me again";
            this.CB_Stop.UseVisualStyleBackColor = true;
            // 
            // ExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 115);
            this.Controls.Add(this.CB_Stop);
            this.Controls.Add(this.Btn_N);
            this.Controls.Add(this.Btn_Y);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExitForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Y;
        private System.Windows.Forms.Button Btn_N;
        private System.Windows.Forms.CheckBox CB_Stop;
    }
}