using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp2
{
    public class Function
    {
        public string filePath = @"Config.txt";
        public string StationConfigFilePath = @"StationConfig.txt";
        public string serialNumber = "";
        public string ProgramName = "";
        public string testerName = "";
        public string stationName = "";
        public string CustomerName = "";
        public string Devision = "";
        public string AssemblyNumber = "";
        WebReference.MES_TIS tis = new WebReference.MES_TIS();

        public List<string> ReadConfigFile(string filePath)
        {
            List<string> configContents = new List<string>();

            if (!File.Exists(filePath))
            {
                List<string> custNames = new List<string> { "XMLPath=C:\\Users\\1099969\\Desktop\\AOIConverterTest\\AOILogFile", "TARPath =C:\\Users\\1099969\\Desktop\\AOIConverterTest\\AOITarFile", "BackUpAOI=C:\\Users\\1099969\\Desktop\\AOIConverterTest\\AOIBackup", "custName:LG-CHCM_L&G", "custName:ADT-CADTRAN", "custName:ACL-CHCM_ACLARA", "custName:DD-CHCM_DISPLAYDATA", "custName:ING-CHCM_INGENICO", "custName:KR-CHCM_KGM", "custName:SND-CHCM_SCHNEIDER", "custName:SWI-CHCM_SWI" };

                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in custNames)
                {
                    sw.WriteLine(item);
                    configContents.Add(item);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            else
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string ln;
                    while ((ln = reader.ReadLine()) != null)
                    {
                        configContents.Add(ln);
                    }
                    reader.Close();
                }
            }
            return configContents;
        }
        public List<string> CheckStationConfigFile()
        {
            List<string> stepConfig = new List<string>();
            if (!File.Exists(StationConfigFilePath))
            {                
                MessageBox.Show("Config file not found! Please contact TE for support");
                //Send email to notify.
            }
            else
            {
                using (StreamReader reader = new StreamReader(StationConfigFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Split('=')[0] == AssemblyNumber)
                        {
                            stepConfig.Add(line.Split('=')[1]);
                        }
                    }
                    if (stepConfig is null)
                    {
                        return null;
                    }
                    reader.Close();
                }
            }
            return stepConfig;
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
      
        public string LoadFirstXMLFile(string XMLPath)
        {
            string[] file = Directory.GetFiles(XMLPath, "*.xml");
            return file[0];
        }
        public string GetTarContent(string XMLFile)
        {
            string tarContent = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFile);
            XmlNodeList tagnameBoardXML = doc.GetElementsByTagName("ns1:BoardXML");

            serialNumber = tagnameBoardXML[0].Attributes["serialNumber"].Value.ToString();
            string currentRouteStep = tis.GetCurrentRouteStep(serialNumber);
            if (!currentRouteStep.StartsWith("No"))
            {


            }




                ProgramName = tagnameBoardXML[0].Attributes["boardType"].Value; //boardType="SND-C125807J-03-T";
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
            string customer = "";
            var customerList = ReadConfigFile(filePath);
            foreach (var item in customerList)
            {
                if (item.StartsWith("custName"))
                {
                    if ((item.Split(':')[1]).Split('-')[0] == strCustomerPrefix)
                    {
                        customer = (item.Split(':')[1]).Split('-')[1];
                    }
                }
            }
            // Side
            string side = arrProgramName.LastOrDefault();
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

            //var revision = arrProgramName[2];
            //if (strCustomerPrefix == "KR")
            //{
            //    if (arrProgramName[2].ToString().Contains('_'))
            //    {
            //        revision = revision.Replace("_", ".");
            //    }
            //}

            // OperatorName
            XmlNodeList tagnameRepairEventXML = doc.GetElementsByTagName("ns1:RepairEventXML");
            var operatorName = tagnameRepairEventXML[0].Attributes["repairOperator"].Value.ToString();

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

            CustomerName = customer;
            Devision = customer;
            AssemblyNumber = assemblyNumber;
            tarContent += "S" + serialNumber + "\r\n"; // SN
            tarContent += customer + "\r\n"; // Customer Name
            tarContent += "N" + testerNameSide + "\r\n";  // Tester Name
            tarContent += "PQC\r\n";
            tarContent += "n" + assemblyNumber + "\r\n"; // Assy #
            //tarContent += "n" + arrProgramName[1] + "\r\n"; // Assy #
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
    }
}
