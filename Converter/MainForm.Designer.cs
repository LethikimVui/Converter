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
            this.tbxTARPath = new System.Windows.Forms.TextBox();
            this.tbxXMLPath = new System.Windows.Forms.TextBox();
            this.btnTarPathBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXMLPathBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrAutoRun = new System.Windows.Forms.Timer(this.components);
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.tmrCleanFile = new System.Windows.Forms.Timer(this.components);
            this.nicSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailRecipientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.BackColor = System.Drawing.Color.PowderBlue;
            this.lblProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblProgressBar.Location = new System.Drawing.Point(30, 309);
            this.lblProgressBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(148, 29);
            this.lblProgressBar.TabIndex = 51;
            this.lblProgressBar.Text = "ProgressBar";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(206, 309);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(432, 35);
            this.progressBar.Step = 3;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 50;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(257, 238);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 61);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbxBackUpPath
            // 
            this.tbxBackUpPath.Location = new System.Drawing.Point(136, 192);
            this.tbxBackUpPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxBackUpPath.Name = "tbxBackUpPath";
            this.tbxBackUpPath.Size = new System.Drawing.Size(441, 26);
            this.tbxBackUpPath.TabIndex = 48;
            this.tbxBackUpPath.TextChanged += new System.EventHandler(this.TbxBackUpPath_TextChanged);
            // 
            // btnBackUpPathBrowser
            // 
            this.btnBackUpPathBrowser.Location = new System.Drawing.Point(593, 188);
            this.btnBackUpPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackUpPathBrowser.Name = "btnBackUpPathBrowser";
            this.btnBackUpPathBrowser.Size = new System.Drawing.Size(45, 35);
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
            this.label4.Location = new System.Drawing.Point(28, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "Backup";
            // 
            // tbxTARPath
            // 
            this.tbxTARPath.Location = new System.Drawing.Point(136, 130);
            this.tbxTARPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxTARPath.Name = "tbxTARPath";
            this.tbxTARPath.Size = new System.Drawing.Size(441, 26);
            this.tbxTARPath.TabIndex = 45;
            this.tbxTARPath.TextChanged += new System.EventHandler(this.TbxTARPath_TextChanged);
            // 
            // tbxXMLPath
            // 
            this.tbxXMLPath.Location = new System.Drawing.Point(136, 75);
            this.tbxXMLPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxXMLPath.Name = "tbxXMLPath";
            this.tbxXMLPath.Size = new System.Drawing.Size(441, 26);
            this.tbxXMLPath.TabIndex = 44;
            this.tbxXMLPath.TextChanged += new System.EventHandler(this.TbxXMLPath_TextChanged);
            // 
            // btnTarPathBrowser
            // 
            this.btnTarPathBrowser.Location = new System.Drawing.Point(593, 126);
            this.btnTarPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTarPathBrowser.Name = "btnTarPathBrowser";
            this.btnTarPathBrowser.Size = new System.Drawing.Size(45, 35);
            this.btnTarPathBrowser.TabIndex = 43;
            this.btnTarPathBrowser.Text = "<>";
            this.btnTarPathBrowser.UseVisualStyleBackColor = true;
            this.btnTarPathBrowser.Click += new System.EventHandler(this.BtnTarPathBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "TAR file";
            // 
            // btnXMLPathBrowser
            // 
            this.btnXMLPathBrowser.Location = new System.Drawing.Point(593, 73);
            this.btnXMLPathBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXMLPathBrowser.Name = "btnXMLPathBrowser";
            this.btnXMLPathBrowser.Size = new System.Drawing.Size(45, 35);
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
            this.label1.Location = new System.Drawing.Point(28, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
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
            this.nicSystemTray.BalloonTipText = "This is Balloon Tip";
            this.nicSystemTray.BalloonTipTitle = "This is Balloon Title";
            this.nicSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("nicSystemTray.Icon")));
            this.nicSystemTray.Text = "sdsfsdfsdfsdf";
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
            this.menuStrip1.Size = new System.Drawing.Size(804, 33);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stationConfigurationToolStripMenuItem,
            this.emailRecipientToolStripMenuItem});
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.administratorToolStripMenuItem.Text = "Administrator";
            // 
            // stationConfigurationToolStripMenuItem
            // 
            this.stationConfigurationToolStripMenuItem.Name = "stationConfigurationToolStripMenuItem";
            this.stationConfigurationToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
            this.stationConfigurationToolStripMenuItem.Text = "Station Configuration";
            this.stationConfigurationToolStripMenuItem.Click += new System.EventHandler(this.StationConfigurationToolStripMenuItem_Click);
            // 
            // emailRecipientToolStripMenuItem
            // 
            this.emailRecipientToolStripMenuItem.Name = "emailRecipientToolStripMenuItem";
            this.emailRecipientToolStripMenuItem.Size = new System.Drawing.Size(265, 30);
            this.emailRecipientToolStripMenuItem.Text = "Email Recipient";
            this.emailRecipientToolStripMenuItem.Click += new System.EventHandler(this.EmailRecipientToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 61);
            this.button1.TabIndex = 53;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(804, 392);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.progressBar);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainForm";
            this.Text = "Converter";
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
        private System.Windows.Forms.TextBox tbxTARPath;
        private System.Windows.Forms.TextBox tbxXMLPath;
        public System.Windows.Forms.Button btnTarPathBrowser;
        public System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ToolStripMenuItem emailRecipientToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

