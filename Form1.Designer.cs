namespace WindowsFormsApp2
{
    partial class frmConverter
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
            this.components = new System.ComponentModel.Container();
            this.btn_CustName = new System.Windows.Forms.Button();
            this.tbxBackUpPath = new System.Windows.Forms.TextBox();
            this.btnBackUpPathBrowser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTARPath = new System.Windows.Forms.TextBox();
            this.tbxXMLPath = new System.Windows.Forms.TextBox();
            this.btnTarPathBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXMLPathBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.tmrAutoRun = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnAutoRun = new System.Windows.Forms.Button();
            this.tmrCleanFile = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_CustName
            // 
            this.btn_CustName.Location = new System.Drawing.Point(309, 440);
            this.btn_CustName.Name = "btn_CustName";
            this.btn_CustName.Size = new System.Drawing.Size(152, 55);
            this.btn_CustName.TabIndex = 2;
            this.btn_CustName.Text = "Check CustName";
            this.btn_CustName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_CustName.UseVisualStyleBackColor = true;
            this.btn_CustName.Click += new System.EventHandler(this.btn_CustName_Click);
            // 
            // tbxBackUpPath
            // 
            this.tbxBackUpPath.Location = new System.Drawing.Point(123, 229);
            this.tbxBackUpPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxBackUpPath.Name = "tbxBackUpPath";
            this.tbxBackUpPath.Size = new System.Drawing.Size(316, 26);
            this.tbxBackUpPath.TabIndex = 34;
            // 
            // btnBackUpPathBrowser
            // 
            this.btnBackUpPathBrowser.Location = new System.Drawing.Point(446, 225);
            this.btnBackUpPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackUpPathBrowser.Name = "btnBackUpPathBrowser";
            this.btnBackUpPathBrowser.Size = new System.Drawing.Size(46, 35);
            this.btnBackUpPathBrowser.TabIndex = 33;
            this.btnBackUpPathBrowser.Text = "<>";
            this.btnBackUpPathBrowser.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "Backup";
            // 
            // tbxTARPath
            // 
            this.tbxTARPath.Location = new System.Drawing.Point(125, 136);
            this.tbxTARPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxTARPath.Name = "tbxTARPath";
            this.tbxTARPath.Size = new System.Drawing.Size(316, 26);
            this.tbxTARPath.TabIndex = 31;
            this.tbxTARPath.TextChanged += new System.EventHandler(this.tbxTARPath_TextChanged);
            // 
            // tbxXMLPath
            // 
            this.tbxXMLPath.Location = new System.Drawing.Point(127, 48);
            this.tbxXMLPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxXMLPath.Name = "tbxXMLPath";
            this.tbxXMLPath.Size = new System.Drawing.Size(316, 26);
            this.tbxXMLPath.TabIndex = 30;
            this.tbxXMLPath.TextChanged += new System.EventHandler(this.tbxXMLPath_TextChanged);
            // 
            // btnTarPathBrowser
            // 
            this.btnTarPathBrowser.Location = new System.Drawing.Point(448, 132);
            this.btnTarPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTarPathBrowser.Name = "btnTarPathBrowser";
            this.btnTarPathBrowser.Size = new System.Drawing.Size(46, 35);
            this.btnTarPathBrowser.TabIndex = 29;
            this.btnTarPathBrowser.Text = "<>";
            this.btnTarPathBrowser.UseVisualStyleBackColor = true;
            this.btnTarPathBrowser.Click += new System.EventHandler(this.btnTarPathBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "TAR file";
            // 
            // btnXMLPathBrowser
            // 
            this.btnXMLPathBrowser.Location = new System.Drawing.Point(450, 46);
            this.btnXMLPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXMLPathBrowser.Name = "btnXMLPathBrowser";
            this.btnXMLPathBrowser.Size = new System.Drawing.Size(45, 35);
            this.btnXMLPathBrowser.TabIndex = 27;
            this.btnXMLPathBrowser.Text = "<>";
            this.btnXMLPathBrowser.UseVisualStyleBackColor = true;
            this.btnXMLPathBrowser.Click += new System.EventHandler(this.btnXMLPathBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "XML file";
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.BackColor = System.Drawing.Color.PowderBlue;
            this.lblProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblProgressBar.Location = new System.Drawing.Point(42, 440);
            this.lblProgressBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(148, 29);
            this.lblProgressBar.TabIndex = 38;
            this.lblProgressBar.Text = "ProgressBar";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(32, 383);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(462, 35);
            this.progressBar.Step = 3;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(275, 294);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 61);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmrAutoRun
            // 
            this.tmrAutoRun.Tick += new System.EventHandler(this.tmrAutoRun_Tick);
            // 
            // btnAutoRun
            // 
            this.btnAutoRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoRun.Location = new System.Drawing.Point(47, 294);
            this.btnAutoRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAutoRun.Name = "btnAutoRun";
            this.btnAutoRun.Size = new System.Drawing.Size(186, 61);
            this.btnAutoRun.TabIndex = 36;
            this.btnAutoRun.Text = "AutoRun";
            this.btnAutoRun.UseVisualStyleBackColor = true;
            this.btnAutoRun.Click += new System.EventHandler(this.btnAutoRun_Click);
            // 
            // tmrCleanFile
            // 
            this.tmrCleanFile.Tick += new System.EventHandler(this.tmrCleanFile_Tick);
            // 
            // frmConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(850, 535);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnAutoRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxBackUpPath);
            this.Controls.Add(this.btnBackUpPathBrowser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTARPath);
            this.Controls.Add(this.tbxXMLPath);
            this.Controls.Add(this.btnTarPathBrowser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXMLPathBrowser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CustName);
            this.Name = "frmConverter";
            this.Text = "Converter";
            this.Load += new System.EventHandler(this.frmConverter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_CustName;
        private System.Windows.Forms.TextBox tbxBackUpPath;
        public System.Windows.Forms.Button btnBackUpPathBrowser;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTARPath;
        private System.Windows.Forms.TextBox tbxXMLPath;
        public System.Windows.Forms.Button btnTarPathBrowser;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnXMLPathBrowser;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer tmrAutoRun;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Button btnAutoRun;
        private System.Windows.Forms.Timer tmrCleanFile;
    }
}

