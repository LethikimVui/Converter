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
            this.cbxStep = new System.Windows.Forms.ComboBox();
            this.tbxAssy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxRouteStep = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveSQLServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 246);
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
            this.cbxWC.Location = new System.Drawing.Point(135, 19);
            this.cbxWC.Name = "cbxWC";
            this.cbxWC.Size = new System.Drawing.Size(341, 28);
            this.cbxWC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "WC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assembly #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Step";
            // 
            // cbxStep
            // 
            this.cbxStep.FormattingEnabled = true;
            this.cbxStep.Location = new System.Drawing.Point(135, 133);
            this.cbxStep.Name = "cbxStep";
            this.cbxStep.Size = new System.Drawing.Size(341, 28);
            this.cbxStep.TabIndex = 3;
            // 
            // tbxAssy
            // 
            this.tbxAssy.Location = new System.Drawing.Point(135, 74);
            this.tbxAssy.Name = "tbxAssy";
            this.tbxAssy.Size = new System.Drawing.Size(341, 26);
            this.tbxAssy.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "RouteStep";
            // 
            // tbxRouteStep
            // 
            this.tbxRouteStep.Location = new System.Drawing.Point(135, 185);
            this.tbxRouteStep.Name = "tbxRouteStep";
            this.tbxRouteStep.Size = new System.Drawing.Size(341, 26);
            this.tbxRouteStep.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 55);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSaveSQLServer
            // 
            this.btnSaveSQLServer.Location = new System.Drawing.Point(12, 246);
            this.btnSaveSQLServer.Name = "btnSaveSQLServer";
            this.btnSaveSQLServer.Size = new System.Drawing.Size(84, 55);
            this.btnSaveSQLServer.TabIndex = 5;
            this.btnSaveSQLServer.Text = "Save SQLServer";
            this.btnSaveSQLServer.UseVisualStyleBackColor = true;
            this.btnSaveSQLServer.Click += new System.EventHandler(this.BtnSaveSQLServer_Click);
            // 
            // frmStationConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 336);
            this.Controls.Add(this.btnSaveSQLServer);
            this.Controls.Add(this.tbxRouteStep);
            this.Controls.Add(this.tbxAssy);
            this.Controls.Add(this.cbxStep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxWC);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmStationConfiguration";
            this.Text = "StationConfiguration";
            this.TopMost = true;
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
        private System.Windows.Forms.ComboBox cbxStep;
        private System.Windows.Forms.TextBox tbxAssy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxRouteStep;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveSQLServer;
    }
}