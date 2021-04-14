namespace Converter
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxBackUpPath = new System.Windows.Forms.TextBox();
            this.btnBackUpPathBrowser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxXMLPath = new System.Windows.Forms.TextBox();
            this.btnXMLPathBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrAutoRun = new System.Windows.Forms.Timer(this.components);
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.tmrCleanFile = new System.Windows.Forms.Timer(this.components);
            this.nicSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.BackColor = System.Drawing.Color.PowderBlue;
            this.lblProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblProgressBar.Location = new System.Drawing.Point(21, 144);
            this.lblProgressBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(97, 20);
            this.lblProgressBar.TabIndex = 51;
            this.lblProgressBar.Text = "ProgressBar";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(152, 144);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(271, 20);
            this.progressBar.Step = 3;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 50;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(196, 174);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbxBackUpPath
            // 
            this.tbxBackUpPath.AllowDrop = true;
            this.tbxBackUpPath.Location = new System.Drawing.Point(99, 97);
            this.tbxBackUpPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxBackUpPath.Name = "tbxBackUpPath";
            this.tbxBackUpPath.Size = new System.Drawing.Size(270, 20);
            this.tbxBackUpPath.TabIndex = 2;
            this.tbxBackUpPath.TextChanged += new System.EventHandler(this.TbxBackUpPath_TextChanged);
            // 
            // btnBackUpPathBrowser
            // 
            this.btnBackUpPathBrowser.AutoSize = true;
            this.btnBackUpPathBrowser.Location = new System.Drawing.Point(377, 91);
            this.btnBackUpPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackUpPathBrowser.Name = "btnBackUpPathBrowser";
            this.btnBackUpPathBrowser.Size = new System.Drawing.Size(46, 30);
            this.btnBackUpPathBrowser.TabIndex = 47;
            this.btnBackUpPathBrowser.Text = "<>";
            this.btnBackUpPathBrowser.UseVisualStyleBackColor = true;
            this.btnBackUpPathBrowser.Click += new System.EventHandler(this.BtnBackUpPathBrowser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 46;
            this.label4.Text = "Backup";
            // 
            // tbxXMLPath
            // 
            this.tbxXMLPath.AllowDrop = true;
            this.tbxXMLPath.Location = new System.Drawing.Point(99, 50);
            this.tbxXMLPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxXMLPath.Name = "tbxXMLPath";
            this.tbxXMLPath.Size = new System.Drawing.Size(270, 20);
            this.tbxXMLPath.TabIndex = 1;
            this.tbxXMLPath.TextChanged += new System.EventHandler(this.TbxXMLPath_TextChanged);
            // 
            // btnXMLPathBrowser
            // 
            this.btnXMLPathBrowser.AutoSize = true;
            this.btnXMLPathBrowser.Location = new System.Drawing.Point(377, 46);
            this.btnXMLPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXMLPathBrowser.Name = "btnXMLPathBrowser";
            this.btnXMLPathBrowser.Size = new System.Drawing.Size(46, 29);
            this.btnXMLPathBrowser.TabIndex = 41;
            this.btnXMLPathBrowser.Text = "<>";
            this.btnXMLPathBrowser.UseVisualStyleBackColor = true;
            this.btnXMLPathBrowser.Click += new System.EventHandler(this.BtnXMLPathBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "XML file";
            // 
            // tmrAutoRun
            // 
            this.tmrAutoRun.Tick += new System.EventHandler(this.TmrAutoRun_Tick_1);
            // 
            // tmrProgress
            // 
            this.tmrProgress.Tick += new System.EventHandler(this.TmrProgress_Tick);
            // 
            // nicSystemTray
            // 
            this.nicSystemTray.BalloonTipText = "Application is running in background";
            this.nicSystemTray.BalloonTipTitle = "Converter";
            this.nicSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("nicSystemTray.Icon")));
            this.nicSystemTray.Text = "Converter";
            this.nicSystemTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NicSystemTray_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administratorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stationConfigurationToolStripMenuItem});
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.administratorToolStripMenuItem.Text = "Administrator";
            // 
            // stationConfigurationToolStripMenuItem
            // 
            this.stationConfigurationToolStripMenuItem.Name = "stationConfigurationToolStripMenuItem";
            this.stationConfigurationToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.stationConfigurationToolStripMenuItem.Text = "Station Configuration";
            this.stationConfigurationToolStripMenuItem.Click += new System.EventHandler(this.StationConfigurationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(449, 219);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxBackUpPath);
            this.Controls.Add(this.btnBackUpPathBrowser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxXMLPath);
            this.Controls.Add(this.btnXMLPathBrowser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainForm";
            this.Text = "Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.FrmMainForm_Load);
            this.Resize += new System.EventHandler(this.FrmMainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxBackUpPath;
        public System.Windows.Forms.Button btnBackUpPathBrowser;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxXMLPath;
        public System.Windows.Forms.Button btnXMLPathBrowser;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrAutoRun;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.Timer tmrCleanFile;
        private System.Windows.Forms.NotifyIcon nicSystemTray;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stationConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

