using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            tmrCleanFile.Enabled = false;
        }
        private void TbxBackUpPath_TextChanged(object sender, EventArgs e)
        {
            tmrAutoRun.Enabled = false;
            tmrProgress.Enabled = false;
            tmrCleanFile.Enabled = false;
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
                tmrAutoRun.Enabled = true;
                tmrProgress.Enabled = true;
                tmrCleanFile.Enabled = true;
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
            lblProgressBar.Text = "Loading " + progressBar.Value.ToString() + " %";
        }
        private void TmrAutoRun_Tick_1(object sender, EventArgs e)
        {
            string logFile = @"log.txt";
            string[] XMLFiles = Directory.GetFiles(XMLPath, "*.xml");
            var countFile = XMLFiles.Count();

            if (countFile > 0)
            {                
                Task.Delay(5000); // delay 3s (time wait for logfile)

                var logFileContent = "";
                var XMLfile = XMLFiles[0];
                var tarContent = function.GetTarContent(XMLfile);
                string currentRouteStep = "";
                string getTestHistory = "";

                try
                {
                    currentRouteStep = tis.GetCurrentRouteStep(function.serialNumber);
                    getTestHistory = tis.GetTestHistory(function.serialNumber, function.customer.Substring(1), function.customer.Substring(1));
                }
                catch (Exception ex)
                {
                    //logFileContent = ex.Message;
                    //function.SendEmail("TIS Failed", logFileContent);
                    //MessageBox.Show("vui lòng liên hệ TE: ", "Converter bị lỗi TIS, không kết nối được TIS");
                }

                if (!currentRouteStep.StartsWith("No"))
                {
                    var NewDataSet = Regex.Split(getTestHistory, "</NewDataSet>");
                    var TestHistory = Regex.Split(NewDataSet.FirstOrDefault(), "<TestHistory>");
                    var latestStepOrTestName = Regex.Split((Regex.Split(TestHistory.LastOrDefault(), "<StepOrTestName>")).LastOrDefault(), "</StepOrTestName>").FirstOrDefault();
                    string stepText = Regex.Split((Regex.Split(currentRouteStep, "<StepText>")[1]), "</StepText>")[0]; //QC, SMT
                    bool check = false;
                    if (stepText.ToLower() == "QC" || stepText.ToLower() == "REWORK")
                    {
                        check = function.IsCorrectStation(function.customer.Substring(1), function.assemblyNumber, stepText, latestStepOrTestName, ConfigContent);
                    }

                    if ((stepText.ToLower() == "smt") || check)
                    {
                        string XMLFileName = function.serialNumber + "#" + function.programName + "#" + function.testerName + "#" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";
                        string TarFileName = function.serialNumber + "_" + function.programName + "_" + function.stationName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".tar";
                        //string fileTAR = TARPath + "\\" + TarFileName;
                        //var result = tis.ProcessTestData(tarContent, "Generic");
                        var result = "Pass";
                        if (result == "Pass")
                        {
                            function.MoveFile(XMLfile, function.BackUpfolder(BackUpPath, function.stationName, "Pass"), XMLFileName);
                            logFileContent += DateTime.Now.ToString("dddd, dd MMMM yyyy") + " : Moved XML file to " + function.BackUpfolder(BackUpPath, function.stationName, "Pass") + "\r\n";                            
                        }
                        else
                        {
                            MessageBox.Show("Fail ProcessTestData tis function", "Please contact TE");
                            function.SendEmail("Fail ProcessTestData tis function", tarContent);
                        }
                    }
                    else
                    {                       
                        string XMLFileName = function.serialNumber + "#" + function.programName + "#" + function.testerName + "#" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";
                        function.SendEmail("Board Sai Qui Trình", XMLFileName, XMLfile);
                        //function.MoveFile(XMLfile, function.BackUpfolder(BackUpPath, function.stationName, "Fail"), XMLFileName);
                        File.Delete(XMLfile);
                        tmrAutoRun.Enabled = false;
                        DialogResult result = MessageBox.Show("Board chưa được config. Vui lòng liên hệ TE");
                        if (result == DialogResult.OK)
                        {
                            tmrAutoRun.Enabled = true;
                        }
                    }
                }
                else // startwith No
                {                                  
                    var temp = DateTime.Now.ToString("dddd, dd MMMM yyyy. ") + "Fail at " + Environment.MachineName + ". SN: " + function.serialNumber + ". Operator: " + function.operatorName + "\r\n";
                    logFileContent = temp;

                    var emailSubject = "[" + function.customer.Substring(1) + "] " + "Failed at " + Environment.MachineName;
                    function.SendEmail(emailSubject, temp, XMLfile);
                    //function.MoveFile(XMLfile, function.BackUpfolder(BackUpPath, function.stationName, "Fail"), "Failed " + DateTime.Now.ToString("yyyyMMddHHmmssfff"));                   
                    File.Delete(XMLfile);
                    tmrAutoRun.Enabled = false;
                    tmrProgress.Enabled = false;
                    if (string.IsNullOrEmpty(function.assemblyNumber))
                    {
                        tmrAutoRun.Enabled = true;
                        tmrProgress.Enabled = true;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(function.serialNumber + " Board đã được Packout", "Vui lòng kiểm tra lại");
                        if (result == DialogResult.OK)
                        {
                            tmrAutoRun.Enabled = true;
                            tmrProgress.Enabled = true;
                        }
                    }
                  
                }
                function.WriteFile(logFileContent, logFile, 1);
               
            }
            else
            {
                tmrAutoRun.Enabled = false;
            }
            
            tmrAutoRun.Enabled = true;
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
        }}
}


