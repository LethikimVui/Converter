using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class frmMainForm : Form
    {
        Function function = new Function();
        KEUTIS.MES_TIS tis = new KEUTIS.MES_TIS();

        public string XMLPath;
        public string BackUpPath;
        public List<string> ConfigContent;
        static string FilePath = "Path.txt";
        public frmMainForm()
        {
            InitializeComponent();
        }
        private void NicSystemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            nicSystemTray.Visible = false;
        }
        private void FrmMainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                nicSystemTray.Visible = true;
                nicSystemTray.ShowBalloonTip(1000);
            }
        }
        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            ConfigContent = function.ReadFile(function.ConfigPath);
            var paths = function.ReadFile(FilePath);
            foreach (var item in paths)
            {
                if (item.Split('=')[0] == "XMLPath")
                {
                    tbxXMLPath.Text = item.Split('=')[1];
                }
                if (item.Split('=')[0] == "BackUpPath")
                {
                    tbxBackUpPath.Text = item.Split('=')[1];
                }
            }
        }
        private void BtnXMLPathBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog_XML = new FolderBrowserDialog();
            DialogResult result = openFileDialog_XML.ShowDialog();
            openFileDialog_XML.ShowNewFolderButton = true;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog_XML.SelectedPath))
            {
                tbxXMLPath.Text = openFileDialog_XML.SelectedPath;
            }
        }
        private void BtnBackUpPathBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog_BackUp = new FolderBrowserDialog();

            DialogResult result = openFileDialog_BackUp.ShowDialog();
            openFileDialog_BackUp.ShowNewFolderButton = true;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog_BackUp.SelectedPath))
            {
                tbxBackUpPath.Text = openFileDialog_BackUp.SelectedPath;
            }
        }
        private void TbxXMLPath_TextChanged(object sender, EventArgs e)
        {
            tmrAutoRun.Enabled = false;
            tmrProgress.Enabled = false;
        }
        private void TbxBackUpPath_TextChanged(object sender, EventArgs e)
        {
            tmrAutoRun.Enabled = false;
            tmrProgress.Enabled = false;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            XMLPath = tbxXMLPath.Text;
            BackUpPath = tbxBackUpPath.Text;

            if ((string.IsNullOrEmpty(XMLPath)) || (string.IsNullOrEmpty(BackUpPath)))
            {
                MessageBox.Show("Chọn đường dẫn logfile hoặc backup", "Folder Empty", MessageBoxButtons.OK);
            }
            else
            {
                string contents = "XMLPath=" + XMLPath + Environment.NewLine + "BackUpPath=" + BackUpPath;
                function.WriteFile(contents, FilePath);

                tmrAutoRun.Enabled = true;
                tmrProgress.Enabled = true;
            }
        }
        private void TmrProgress_Tick(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 1;
            progressBar.PerformStep();
            if (progressBar.Value == 100)
            {
                progressBar.Value = 0;
            }
            lblProgressBar.Text = "Running " + progressBar.Value.ToString() + " %";
        }
        private void TmrAutoRun_Tick_1(object sender, EventArgs e)
        {
            string[] XMLFiles = Directory.GetFiles(XMLPath, "*.xml");
            var countFile = XMLFiles.Count();

            if (countFile > 0)
            {
                var XMLfile = XMLFiles[0];
                var tarContent = "";
                function.serialNumber = "";

                //if (File.Exists(XMLfile))
                //{
                Thread.Sleep(500);
                    tarContent = function.GetTarContent(XMLfile);
                //}
                //else
                //    return;
                
                string currentRouteStep = "";
                string getTestHistory = "";
                try
                {
                    currentRouteStep = tis.GetCurrentRouteStep(function.serialNumber);
                    getTestHistory = tis.GetTestHistory(function.serialNumber, function.customer.Substring(1), function.customer.Substring(1));
                }
                catch
                {
                    //tmrAutoRun.Enabled = false;
                    //DialogResult result = MessageBox.Show(new Form() { TopMost = true }, "TIS không kết nối được. Vui lòng liên hệ TE");
                    //if (result == DialogResult.OK)
                    //{
                    //    tmrAutoRun.Enabled = true;
                    //}
                    MessageBox.Show(new Form() { TopMost = true }, "TIS không kết nối được. Vui lòng liên hệ TE");

                    File.Delete(XMLfile);
                    return;
                }
                if (!currentRouteStep.StartsWith("No"))
                {
                    var NewDataSet = Regex.Split(getTestHistory, "</NewDataSet>");
                    var TestHistory = Regex.Split(NewDataSet.FirstOrDefault(), "<TestHistory>");
                    var latestStepOrTestName = Regex.Split((Regex.Split(TestHistory.LastOrDefault(), "<StepOrTestName>")).LastOrDefault(), "</StepOrTestName>").FirstOrDefault();
                    string stepText = Regex.Split((Regex.Split(currentRouteStep, "<StepText>")[1]), "</StepText>")[0]; //QC, SMT
                    bool check = false;
                    if (stepText.ToLower() == "qc" || stepText.ToLower() == "rework")
                    {
                        check = function.IsCorrectStation(function.customer.Substring(1), function.assemblyNumber, stepText, latestStepOrTestName, ConfigContent);
                    }

                    if ((stepText.ToLower() == "smt") || check)
                    {
                        string XMLFileName = function.serialNumber + "#" + function.programName + "#" + function.testerName + "#" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";

                        var result = tis.ProcessTestData(tarContent, "Generic");
                        //var result = "Pass";

                        if (result.ToLower() == "pass")
                        {
                            function.MoveFile(XMLfile, function.BackUpfolder(BackUpPath, function.stationName, "Pass"), XMLFileName);
                        }
                        else
                        {
                            var retry_result = "";
                            bool isPass = false;
                            for (int i = 0; i < 2; i++)
                            {
                                retry_result = tis.ProcessTestData(tarContent, "Generic");
                                if (retry_result.ToLower() == "pass")
                                {
                                    isPass = true;
                                    function.MoveFile(XMLfile, function.BackUpfolder(BackUpPath, function.stationName, "Pass"), XMLFileName);
                                    break;
                                }
                            }
                            if (!isPass)
                            {
                                MessageBox.Show(new Form() { TopMost = true }, "Fail upload tar result to MES for SN " + function.serialNumber, "Vui lòng liên hệ TE");
                                function.SendEmail("Fail upload tar result to MES", tarContent);
                            }
                        }
                    }
                    else
                    {
                        File.Delete(XMLfile);
                        //tmrAutoRun.Enabled = false;
                        //DialogResult result = MessageBox.Show(new Form() { TopMost = true }, "SN " + function.serialNumber + " chưa được config. Vui lòng liên hệ TE");
                        //if (result == DialogResult.OK)
                        //{
                        //    tmrAutoRun.Enabled = true;
                        //}
                        MessageBox.Show(new Form() { TopMost = true }, "SN " + function.serialNumber + " chưa được config. Vui lòng liên hệ TE");

                    }
                }
                else // startwith No
                {      
                    File.Delete(XMLfile);
                    if (!string.IsNullOrEmpty(function.assemblyNumber))
                    {
                        //tmrAutoRun.Enabled = false;
                        //tmrProgress.Enabled = false;
                        //DialogResult result = MessageBox.Show(new Form() { TopMost = true }, function.serialNumber + " đã được Packout", "Vui lòng kiểm tra lại");
                        //if (result == DialogResult.OK)
                        //{
                        //    tmrAutoRun.Enabled = true;
                        //    tmrProgress.Enabled = true;
                        //}
                        MessageBox.Show(new Form() { TopMost = true }, function.serialNumber + " đã được Packout", "Vui lòng kiểm tra lại");
                    }
                }
            }
        }
        private void StationConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn f = new frmLogIn();
            f.ShowDialog();
        }
        private void FrmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }
        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn f = new frmLogIn();
            f.ShowDialog();
        }
    }
}


