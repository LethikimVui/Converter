namespace Converter
{
    partial class frmStationConfiguration
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxWC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStation = new System.Windows.Forms.ComboBox();
            this.tbxAssy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxStep = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSide = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 55);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cbxWC
            // 
            this.cbxWC.FormattingEnabled = true;
            this.cbxWC.Location = new System.Drawing.Point(212, 23);
            this.cbxWC.Name = "cbxWC";
            this.cbxWC.Size = new System.Drawing.Size(341, 28);
            this.cbxWC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "WC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assembly #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Station";
            // 
            // cbxStation
            // 
            this.cbxStation.FormattingEnabled = true;
            this.cbxStation.Location = new System.Drawing.Point(212, 137);
            this.cbxStation.Name = "cbxStation";
            this.cbxStation.Size = new System.Drawing.Size(341, 28);
            this.cbxStation.TabIndex = 3;
            // 
            // tbxAssy
            // 
            this.tbxAssy.Location = new System.Drawing.Point(212, 78);
            this.tbxAssy.Name = "tbxAssy";
            this.tbxAssy.Size = new System.Drawing.Size(341, 26);
            this.tbxAssy.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Step";
            // 
            // tbxStep
            // 
            this.tbxStep.Location = new System.Drawing.Point(212, 189);
            this.tbxStep.Name = "tbxStep";
            this.tbxStep.Size = new System.Drawing.Size(341, 26);
            this.tbxStep.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(422, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 55);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Side";
            // 
            // cbxSide
            // 
            this.cbxSide.FormattingEnabled = true;
            this.cbxSide.Location = new System.Drawing.Point(212, 243);
            this.cbxSide.Name = "cbxSide";
            this.cbxSide.Size = new System.Drawing.Size(341, 28);
            this.cbxSide.TabIndex = 6;
            // 
            // frmStationConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 450);
            this.Controls.Add(this.cbxSide);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxStep);
            this.Controls.Add(this.tbxAssy);
            this.Controls.Add(this.cbxStation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxWC);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmStationConfiguration";
            this.Text = "StationConfiguration";
            this.Load += new System.EventHandler(this.FrmStationConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxWC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStation;
        private System.Windows.Forms.TextBox tbxAssy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxStep;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSide;
    }
}