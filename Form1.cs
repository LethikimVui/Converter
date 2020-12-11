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
using WindowsFormsApp2.WebReference;

namespace WindowsFormsApp2
{
    public partial class frmConverter : Form
    {
        Function function = new Function();
        WebReference.MES_TIS tis = new WebReference.MES_TIS();

        public string filePath = @"Config.txt";
        public frmConverter()
        {
            InitializeComponent();
        }


        private void btn_CustName_Click(object sender, EventArgs e)
        {
            //var serialNumber = "KGBJV22940092050021343"; //Packout
            //var serialNumber_SMT = "KGMJV33440212049043872"; //SMT

            //string GetCurrentRouteStep = tis.GetCurrentRouteStep(serialNumber_SMT);
            //string testHistory = tis.GetTestHistory(serialNumber, "HCM_KGM", "HCM_KGM");

            //string stepOrTestName = Regex.Split((Regex.Split(testHistory, "<StepOrTestName>")[1]), "</StepOrTestName>")[0];
            //MessageBox.Show(GetCurrentRouteStep);
            //MessageBox.Show(testHistory);



        }

        private void frmConverter_Load(object sender, EventArgs e)
        {
            btnAutoRun.PerformClick();
            btnSave.PerformClick();
            btnAutoRun.Visible = false;
            timer2.Enabled = true;
            tmrCleanFile.Enabled = true;
        }
        private void frmConverter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

        }
        private void btnAutoRun_Click(object sender, EventArgs e)
        {
            string filePath = @"Config.txt";
            var configContents = function.ReadConfigFile(filePath);
            foreach (var item in configContents)
            {
                if (item.StartsWith("XMLPath"))
                {
                    tbxXMLPath.Text = item.Split('=').LastOrDefault();
                }
                if (item.StartsWith("TARPath"))
                {
                    tbxTARPath.Text = item.Split('=').LastOrDefault();
                }
                if (item.StartsWith("BackUpAOI"))
                {
                    tbxBackUpPath.Text = item.Split('=').LastOrDefault();
                }
            }
            if ((string.IsNullOrEmpty(tbxXMLPath.Text)) || (string.IsNullOrEmpty(tbxTARPath.Text)))
            {
                MessageBox.Show("Chọn đường dẫn logfile hoặc tarfile", "", MessageBoxButtons.OK);
            }
            else
            {
                tmrAutoRun.Enabled = true;
            }
        }
        private void btnXMLPathBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog_XML = new FolderBrowserDialog();
            DialogResult result = openFileDialog_XML.ShowDialog();
            openFileDialog_XML.ShowNewFolderButton = true;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog_XML.SelectedPath))
            {
                tbxXMLPath.Text = openFileDialog_XML.SelectedPath;
            }
        }
        private void btnTarPathBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog_TAR = new FolderBrowserDialog();

            DialogResult result = openFileDialog_TAR.ShowDialog();
            openFileDialog_TAR.ShowNewFolderButton = true;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog_TAR.SelectedPath))
            {
                tbxTARPath.Text = openFileDialog_TAR.SelectedPath;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 3;
            progressBar.PerformStep();
            if (progressBar.Value == 100)
            {
                progressBar.Value = 0;

            }
            lblProgressBar.Text = "Loading " + progressBar.Value.ToString() + " %";
        }
        private void tbxXMLPath_TextChanged(object sender, EventArgs e)
        {
            tmrAutoRun.Enabled = false;
        }
        private void tbxTARPath_TextChanged(object sender, EventArgs e)
        {
            tmrAutoRun.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Write to source
            string contents = "";
            string XMLPath = tbxXMLPath.Text;
            string TARPath = tbxTARPath.Text;
            string BackUpAOI = tbxBackUpPath.Text;
            var configContents = function.ReadConfigFile(filePath);
            for (int i = 0; i < configContents.Count; i++)
            {
                if (configContents[i].StartsWith("XMLPath"))
                {
                    configContents[i] = "XMLPath=" + XMLPath;
                }
                if (configContents[i].StartsWith("TARPath"))
                {
                    configContents[i] = "TARPath=" + TARPath;
                }
                if (configContents[i].StartsWith("BackUpAOI"))
                {
                    configContents[i] = "BackUpAOI=" + BackUpAOI;
                }
                contents += configContents[i] + "\r\n";
            }
            function.WriteFile(contents, filePath);
            tmrAutoRun.Enabled = true;
        }

        private void tmrAutoRun_Tick(object sender, EventArgs e)
        {
            string XMLPath = tbxXMLPath.Text;
            string TarPath = tbxTARPath.Text;
            string backupPath = tbxBackUpPath.Text;
            string logFile = @"Log\\log.txt";
            string[] XMLFiles = Directory.GetFiles(XMLPath, "*.xml");
            var countFile = XMLFiles.Count();
            if (countFile > 0)
            {
                var logFileContent = "";
                var XMLfile = XMLFiles[0];
                var tarContent = function.GetTarContent(XMLfile);
                var serialNumber = function.serialNumber;
                var CustomerName = function.CustomerName.Substring(1);
                var Devision = function.Devision.Substring(1);
                var assemblyNumber = function.AssemblyNumber;

                string currentRouteStep = tis.GetCurrentRouteStep(serialNumber);
                if (!currentRouteStep.StartsWith("No"))
                {
                    var stepConfig = function.CheckStationConfigFile();
                    if (stepConfig == null)
                    {
                        Console.WriteLine("Assy is not configured");
                    }
                    else
                    {
                        string stepText = Regex.Split((Regex.Split(currentRouteStep, "<StepText>")[1]), "</StepText>")[0];
                        var element = stepConfig.Where(x => x.Contains(stepText.ToLower())).FirstOrDefault();
                        if (element != null)
                        {
                            //string testHistory = tis.GetTestHistory(serialNumber, CustomerName, Devision);
                            //string stepOrTestName = Regex.Split((Regex.Split(testHistory, "<StepOrTestName>")[1]), "</StepOrTestName>")[0];
                            //string testResult = Regex.Split((Regex.Split(testHistory, "<TestStatus>")[1]), "</TestStatus>")[0];
                            //string custAssy = tis.LookupCustAssy(serialNumber, CustomerName, Devision);
                            //string assembly = Regex.Split((Regex.Split(custAssy, "<Number>")[1]), "</Number>")[0];

                            string XMLFileName = function.serialNumber + "#" + function.ProgramName + "#" + function.testerName + "#" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";
                            string TarFileName = function.serialNumber + "_" + function.ProgramName + "_" + function.stationName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".tar";

                            function.MoveFile(XMLfile, function.BackUpfolder(backupPath, "AOI", "Pass"), XMLFileName);

                            string fileTAR = TarPath + "\\" + TarFileName;

                            logFileContent += DateTime.Now.ToString("dddd, dd MMMM yyyy") + " : Moved XML file to " + function.BackUpfolder(backupPath, "AOI", "Pass") + "\r\n";
                            logFileContent += DateTime.Now.ToString("dddd, dd MMMM yyyy") + " : Written TAR file " + fileTAR + "\r\n";

                        }
                        else
                        {
                            logFileContent += "Assy is not configured";
                        }
                    }
                    
                }
                else
                {
                    logFileContent += "Converted Failed " + function.serialNumber + " .Date: " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    function.MoveFile(XMLfile, function.BackUpfolder(backupPath, "AOI", "Fail"), "Failed" + DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                }
                function.WriteFile(logFileContent, logFile, 1);

            }

        }

        private void tmrCleanFile_Tick(object sender, EventArgs e)
        {

            foreach (FileInfo file in new DirectoryInfo(@"C:\\Users\\1099969\\Desktop\\Test").GetFiles().Where(p => p.CreationTime < DateTime.Now.AddMinutes(-1)).ToArray())
                File.Delete(file.FullName);
        }
    }
}
