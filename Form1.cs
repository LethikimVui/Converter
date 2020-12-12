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
    public partial class frmConverter : Form
    {
        Function function = new Function();
        WebReference.MES_TIS tis = new WebReference.MES_TIS();

        public string filePath = @"Config.txt";
        public string BackUpPath = "";
        public frmConverter()
        {
            InitializeComponent();
        }
        private void btn_CustName_Click(object sender, EventArgs e)
        {
            //string testHistory = tis.GetTestHistory(serialNumber, CustomerName, Devision);
            //string stepOrTestName = Regex.Split((Regex.Split(testHistory, "<StepOrTestName>")[1]), "</StepOrTestName>")[0];
            //string testResult = Regex.Split((Regex.Split(testHistory, "<TestStatus>")[1]), "</TestStatus>")[0];
            //string custAssy = tis.LookupCustAssy(serialNumber, CustomerName, Devision);
            //string assembly = Regex.Split((Regex.Split(custAssy, "<Number>")[1]), "</Number>")[0];
        }
        private void frmConverter_Load(object sender, EventArgs e)
        {
            btnAutoRun.PerformClick();
            btnSave.PerformClick();
            btnAutoRun.Visible = false;
            BackUpPath = tbxBackUpPath.Text;
            tmrProgress.Enabled = true;
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
            BackUpPath = backupPath;
            string logFile = @"Log\\log.txt";
            string[] XMLFiles = Directory.GetFiles(XMLPath, "*.xml");
            var countFile = XMLFiles.Count();

            if (countFile > 0)
            {
                var logFileContent = "";
                var XMLfile = XMLFiles[0];
                var tarContent = function.GetTarContent(XMLfile);

                if (!tarContent.StartsWith("Fail"))
                {
                    string XMLFileName = function.serialNumber + "#" + function.ProgramName + "#" + function.testerName + "#" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";
                    string TarFileName = function.serialNumber + "_" + function.ProgramName + "_" + function.stationName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".tar";
                    string fileTAR = TarPath + "\\" + TarFileName;

                    function.MoveFile(XMLfile, function.BackUpfolder(backupPath, "Pass"), XMLFileName);
                    function.WriteFile(tarContent, fileTAR);

                    logFileContent += DateTime.Now.ToString("dddd, dd MMMM yyyy") + " : Moved XML file to " + function.BackUpfolder(backupPath, "Pass") + "\r\n";
                    logFileContent += DateTime.Now.ToString("dddd, dd MMMM yyyy") + " : Written TAR file " + fileTAR + "\r\n";
                }
                else
                {
                    var temp = DateTime.Now.ToString("dddd, dd MMMM yyyy. ") +  tarContent;
                    logFileContent =  temp;
                    function.MoveFile(XMLfile, function.BackUpfolder(backupPath, "Fail"), "Failed " + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                }
                function.WriteFile(logFileContent, logFile, 1);
            }
        }
        private void tmrCleanFile_Tick(object sender, EventArgs e)
        {
            foreach (var item in Directory.GetDirectories(BackUpPath))
            {
                foreach (var item1 in Directory.GetDirectories(item))
                {
                    foreach (var item2 in Directory.GetDirectories(item1))
                    {
                        foreach (var item3 in Directory.GetDirectories(item2))
                        {
                            foreach (FileInfo file in new DirectoryInfo(item3).GetFiles().Where(p => p.CreationTime < DateTime.Now.AddMinutes(-5)).ToArray())
                                File.Delete(file.FullName);
                        }
                    }
                }
            }
        }
        private void tmrProgress_Tick(object sender, EventArgs e)
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
    }
}
