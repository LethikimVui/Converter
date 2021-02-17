using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Converter
{
    public class Function
    {
        TIS.MES_TIS tis = new TIS.MES_TIS();
        public string ConfigPath = @"Config.txt";
        public string serialNumber = "";
        public string programName = "";
        public string testerName = "";
        public string stationName = "";
        public string customer = "";
        public string division = "";
        public string operatorName = "";
        public string assemblyNumber = "";
        public string side = "";

        public Dictionary<string, string> dicCustomer =
              new Dictionary<string, string>(){
                                {"LG","CHCM_L&G"},
                                {"ADT","CADTRAN"},
                                {"ACL","CHCM_ACLARA"},
                                {"DD","CHCM_DISPLAYDATA"},
                                {"ING","CHCM_INGENICO"},
                                {"KR","CHCM_KGM"},
                                {"SND","CHCM_SCHNEIDER"},
                                {"SWI","CHCM_SWI"},
                                {"GE","CHCM_GE"},
                                {"SES","CHCM_SES"},
                                {"ZBR","CHCM_ZEBRA"},
                                {"SLE","CHCM_SOLAREDGE"}};


        public bool IsCorrectStation(string customer, string assy, string side, string process, string routeStep)
        {
            if (!File.Exists(ConfigPath))
            {
                MessageBox.Show(ConfigPath + " not found! Please contact TE for support");
                //Send email to notify.
            }
            else
            {
                using (StreamReader reader = new StreamReader(ConfigPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var arrLine = line.Split('-');
                        if ((arrLine[0] == customer) && (arrLine[1] == assy) && (arrLine[2] == side) && (arrLine[3] == process) && (arrLine[4] == routeStep))
                        {
                            return true;
                        }
                    }
                    reader.Close();
                }
            }
            return false;
        }        
      
        public List<string> ReadFile(string filePath)
        {
            List<string> fileContent = new List<string>();
            if (!File.Exists(filePath))
            {
                MessageBox.Show(filePath + " not found! Please contact TE for support");
                //Send email to notify.
            }
            else
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileContent.Add(line);
                    }
                    reader.Close();
                }
            }
            return fileContent;
        }
        public void WriteFile(string content, string filePath, int mode = 0)
        {
            if (mode == 1)
            {
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            else
            {
                File.WriteAllText(filePath, content);
            }
        }
        public string GetTarContent(string XMLFile)
        {
            string tarContent = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFile);
            XmlNodeList tagnameBoardXML = doc.GetElementsByTagName("ns1:BoardXML");

            serialNumber = tagnameBoardXML[0].Attributes["serialNumber"].Value.ToString();
            string currentRouteStep = tis.GetCurrentRouteStep(serialNumber);

            var ProgramName = tagnameBoardXML[0].Attributes["boardType"].Value; //boardType="SND-C125807J-03-T";
            var arrProgramName = ProgramName.Split('-');
            string strCustomerPrefix = arrProgramName.FirstOrDefault();
            if (strCustomerPrefix == "SWI")
            {
                if (serialNumber.Contains('_'))
                {
                    string tempBoardNumber;
                    var arrSerialNumber = serialNumber.Split('_');
                    if (int.Parse(arrSerialNumber[1]) < 10)
                    {
                        tempBoardNumber = "0" + arrSerialNumber[1];
                    }
                    else
                    {
                        tempBoardNumber = arrSerialNumber[1];
                    }
                    if (arrSerialNumber[0].Length == 17)
                    {
                        serialNumber = arrSerialNumber[0].Substring(0, arrSerialNumber[0].Length - 7) + tempBoardNumber + arrSerialNumber[0].Substring(arrSerialNumber[0].Length - 5);
                    }
                    else
                    {
                        serialNumber = arrSerialNumber[0].Substring(0, arrSerialNumber[0].Length - 9) + tempBoardNumber + arrSerialNumber[0].Substring(arrSerialNumber[0].Length - 7);
                    }
                }
            }
            //string customer = "";
            foreach (var item in dicCustomer)
            {
                if (item.Key == strCustomerPrefix)
                    customer = item.Value;
            }
            // Side
            side = arrProgramName.LastOrDefault();
            XmlNodeList tagnameStationXML = doc.GetElementsByTagName("ns1:StationXML");
            string stage = tagnameStationXML[0].Attributes["stage"].Value;
            if (stage == "V510")
            {
                stationName = "AOI";
            }
            else
            {
                stationName = "AXI";
            }
            testerName = tagnameStationXML[0].Attributes["testerName"].Value.ToString();
            var testerNameSide = testerName + "_" + side;

            string custAssy = tis.LookupCustAssy(serialNumber, customer.Substring(1), customer.Substring(1));
            string assemblyNumber = Regex.Split((Regex.Split(custAssy, "<Number>")[1]), "</Number>")[0];
            var revision = Regex.Split((Regex.Split(custAssy, "<Revision>")[1]), "</Revision>")[0];


            // OperatorName
            XmlNodeList tagnameRepairEventXML = doc.GetElementsByTagName("ns1:RepairEventXML");
            operatorName = tagnameRepairEventXML[0].Attributes["repairOperator"].Value.ToString();

            XmlNodeList BoardTestXMLExport = doc.GetElementsByTagName("ns1:BoardTestXMLExport");

            var testerTestStartTime = BoardTestXMLExport[0].Attributes["testerTestStartTime"].Value.ToString().Replace("T", " ").Split('.')[0];
            var testerTestEndTime = BoardTestXMLExport[0].Attributes["testerTestEndTime"].Value.ToString().Replace("T", " ").Split('.')[0];

            var defectDetail = "";
            if (BoardTestXMLExport[0].Attributes["repairStatus"].Value.ToString() == "Repaired")
            {
                defectDetail = "TF\r\n";
                XmlNodeList listRepairAction = doc.GetElementsByTagName("ns1:RepairActionXML");
                XmlNodeList listComponent = doc.GetElementsByTagName("ns1:ComponentXML");

                string CRDs = "F";
                string strDefectName = "";

                for (int i = 0; i < listRepairAction.Count; i++)
                {
                    if (listRepairAction[i].Attributes["repairStatus"].Value.ToString() == "Repaired")
                    {
                        string strCRD;
                        string DefectName;
                        string RepairTime;
                        strCRD = listComponent[i].Attributes["designator"].Value.ToString().Split(':')[1];
                        CRDs += strCRD;
                        CRDs += ",";
                        DefectName = listRepairAction[i].Attributes["indictmentType"].Value.ToString();
                        RepairTime = listRepairAction[i].Attributes["repairTime"].Value.ToString().Replace("T", " ").Split('.')[0]; ;

                        strDefectName += "~\r\nc" + strCRD + "\r\nA" + DefectName + "\r\n(" + RepairTime + ")\r\n~\r\n";
                    }
                }
                CRDs = CRDs.Remove(CRDs.Trim().Length - 1);
                defectDetail += CRDs;
                defectDetail += "\r\n>Failed\r\n";
                defectDetail += strDefectName;
            }
            else
                defectDetail = "TP";

            tarContent += "S" + serialNumber + "\r\n"; // SN
            tarContent += customer + "\r\n"; // Customer Name
            tarContent += "N" + testerNameSide + "\r\n";  // Tester Name
            tarContent += "PQC\r\n";
            tarContent += "n" + assemblyNumber + "\r\n"; // Assy #
            tarContent += "r" + revision + "\r\n"; // Revision
            tarContent += "O" + operatorName + "\r\n"; // OperatorName
            tarContent += "L4\r\n";
            tarContent += "p1\r\n";
            tarContent += "[" + testerTestStartTime + "\r\n";
            tarContent += "]" + testerTestEndTime + "\r\n";
            tarContent += defectDetail + "\r\n";

            return tarContent;
        }
        public void MoveFile(string sourcePath, string desPath, string fileName)
        {
            if (File.Exists(desPath))
            {
                using (FileStream sw = File.Create(desPath)) { }
            }
            string destFileName = desPath + "\\" + fileName;
            File.Move(sourcePath, destFileName);
        }
        public string BackUpfolder(string backupPath, string stationName, string categoryName)
        {
            DateTime currentDateTime = DateTime.Now;
            int currentDay = currentDateTime.Day;

            string CategoryFolder = backupPath + "/" + stationName + "/" + categoryName + "/";
            DirectoryInfo dirCategory = Directory.CreateDirectory(CategoryFolder);

            string currentYearPath = CategoryFolder + currentDateTime.Year.ToString() + "/";
            DirectoryInfo dirYear = Directory.CreateDirectory(currentYearPath);
            int currentMonth = currentDateTime.Month;

            string weekInMonth = null;
            if (currentDay <= 7)
                weekInMonth = "1";
            else if ((currentDay > 7) && (currentDay <= 14))
                weekInMonth = "2";
            else if ((currentDay > 14) && (currentDay <= 24))
                weekInMonth = "3";
            else
                weekInMonth = "4";

            string weekInMonthFolder = null;
            if (currentMonth < 10)
            {
                weekInMonthFolder = "0" + currentMonth.ToString() + "_WW_0" + weekInMonth;
            }
            else
            {
                weekInMonthFolder = currentMonth.ToString() + "_WW_0" + weekInMonth;
            }

            string weekInMonthPath = currentYearPath + weekInMonthFolder + "/";
            DirectoryInfo dirWeekinMonth = Directory.CreateDirectory(weekInMonthPath);

            string dayPath = weekInMonthPath + currentDay.ToString() + "/";
            DirectoryInfo dirDay = Directory.CreateDirectory(dayPath);
            return dayPath;
        }
        public void SendEmail(string subject, string emailContent, string xmlFile = "0")
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient("corimc04.corp.JABIL.ORG");
                message.From = new MailAddress("test@Jabil.com");
                message.To.Add(new MailAddress("vui_le@jabil.com"));

                message.Subject = subject;
                message.Body = emailContent;
                if (xmlFile != "0")
                {
                    message.Attachments.Add(new Attachment(xmlFile));

                }
                smtp.Send(message);
                foreach (Attachment attachment in message.Attachments)
                {
                    attachment.Dispose();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}