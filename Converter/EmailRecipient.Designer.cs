namespace Converter
{
    partial class frmEmailRecipient
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
            this.tbxStep = new System.Windows.Forms.TextBox();
            this.tbxAssy = new System.Windows.Forms.TextBox();
            this.cbxStation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxWC = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbxStep
            // 
            this.tbxStep.Location = new System.Drawing.Point(285, 257);
            this.tbxStep.Name = "tbxStep";
            this.tbxStep.Size = new System.Drawing.Size(248, 26);
            this.tbxStep.TabIndex = 11;
            // 
            // tbxAssy
            // 
            this.tbxAssy.Location = new System.Drawing.Point(285, 143);
            this.tbxAssy.Name = "tbxAssy";
            this.tbxAssy.Size = new System.Drawing.Size(248, 26);
            this.tbxAssy.TabIndex = 12;
            // 
            // cbxStation
            // 
            this.cbxStation.FormattingEnabled = true;
            this.cbxStation.Location = new System.Drawing.Point(285, 199);
            this.cbxStation.Name = "cbxStation";
            this.cbxStation.Size = new System.Drawing.Size(248, 28);
            this.cbxStation.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Step";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "WC";
            // 
            // cbxWC
            // 
            this.cbxWC.FormattingEnabled = true;
            this.cbxWC.Location = new System.Drawing.Point(285, 88);
            this.cbxWC.Name = "cbxWC";
            this.cbxWC.Size = new System.Drawing.Size(248, 28);
            this.cbxWC.TabIndex = 5;
            // 
            // frmEmailRecipient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxStep);
            this.Controls.Add(this.tbxAssy);
            this.Controls.Add(this.cbxStation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxWC);
            this.Name = "frmEmailRecipient";
            this.Text = "EmailRecipient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxStep;
        private System.Windows.Forms.TextBox tbxAssy;
        private System.Windows.Forms.ComboBox cbxStation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxWC;
    }
}