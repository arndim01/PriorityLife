using PriorityLifeMacro.Helper;
using PriorityLifeMacro.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PriorityLifeMacro
{
    public class MacroChrome : IMacroCR
    {

        private iMacros.AppClass app;
        private iMacros.Status status;
        private int TimeOut;
        private bool OpenBrowser;
        private string Command;

        public CarrierInfo Carrier { get; private set; }

        public ErrorLogs ErrorLogs { get; private set; }

        public MacroChrome(bool openBrowser = true, int timeOut = 60) 
        {
            TimeOut = timeOut;
            OpenBrowser = openBrowser;
            app = new iMacros.AppClass();
        }

        public void SetCarrier(CarrierInfo carrier)
        {
            Carrier = carrier;
            ErrorLogs = new ErrorLogs();
        }

        public void Play()
        {
            //REFACTOR LATER
            var worker = new Thread(() => {
                Console.WriteLine("Start Timer");
                Thread.Sleep(Carrier.GetEstimateTimeout() * 2);
                Console.WriteLine("End Timer");
            })
            { Name = "Worker" };
            Console.WriteLine("Starting worker thread...");
            worker.Start();
            // watchdog thread
            ThreadPool.QueueUserWorkItem((o) => {
                if (!worker.Join(Carrier.GetEstimateTimeout()))
                {
                    worker.Abort();
                    ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "macro_force_close_error", Message = "Force close imacro" });
                    this.Stop();
                }
            });

            CreateStringMacro();
            CreateVbs();
            Process proc = null;
            try
            {
                string batDir = string.Format(Constant.GENERATEDMACRO_DIR);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = "mac.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();

                worker.Abort();
                this.Stop();
            }
            catch (Exception ex)
            {
                worker.Abort();
                this.Stop();
                Console.WriteLine(ex.StackTrace.ToString());
            }

            if (ErrorLogs.ErrorDetails.Count == 0)
                ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "success", Message = "No Error found" });
        }

        public void CleanFiles()
        {
            DirectoryInfo di = new DirectoryInfo(Constant.DESKTOP_DOWNLOAD_DIR);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
        public void CreateLogs()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ErrorLogs.GetType());
            string XmlString = "";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, ErrorLogs);
                memoryStream.Position = 0;
                XmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            XElement xElement = XElement.Parse(XmlString);
            var dateNow = DateTime.Now;

            xElement.Save(Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") + "/logs.xml");
        }
        private void CreateStringMacro()
        {
            using (StreamReader sr = new StreamReader(Constant.MACRO_DIR +  Carrier.GetPath()))
            {
                Command = sr.ReadToEnd();
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("usn", Carrier.Username);
            dic.Add("pwd", Carrier.Password);
            if (Carrier.DownloadType == DownloadType.InputDate)
            {
                var dateNow = DateTime.Now.AddDays(-1);
                dic.Add("eff", dateNow.ToString("MM/dd/yyyy"));
                dic.Add("exp", dateNow.ToString("MM/dd/yyyy"));
            }
            foreach (KeyValuePair<string, string> entry in dic)
            {
                Command = Command.Replace("{" + entry.Key + "}", entry.Value);
            }
        }
        public void CreateVbs()
        {

            //HTML PATH AND CREATION
            string htmPath = @Constant.GENERATEDMACRO_DIR + @"\TPS.htm";
            if( !File.Exists( htmPath ))
            {
                File.Create(htmPath).Dispose();

                using(TextWriter tw = new StreamWriter(htmPath))
                {
                    tw.WriteLine(Constant.CHROME_MACRO_HTM(Command));
                }

            }else if( File.Exists(htmPath))
            {
                using(TextWriter tw = new StreamWriter(htmPath))
                {
                    tw.WriteLine(Constant.CHROME_MACRO_HTM(Command));
                }
            }

            //BATCH FILE PATH AND CREATION
            string batchPath = @Constant.GENERATEDMACRO_DIR + @"\mac.bat";
            if(!File.Exists(batchPath))
            {
                File.Create(batchPath).Dispose();
                using(TextWriter tw = new StreamWriter(batchPath))
                {
                    tw.WriteLine(Constant.CHROME_BATCH_RUNNER(htmPath));
                }

            }else if (File.Exists(batchPath))
            {
                using (TextWriter tw = new StreamWriter(batchPath))
                {
                    tw.WriteLine(Constant.CHROME_BATCH_RUNNER(htmPath));
                }
            }

        }
        public void TransferFiles()
        {
            var dateNow = DateTime.Now;
            string path = Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd");
            Directory.CreateDirectory(path);
            DirectoryInfo di = new DirectoryInfo(Constant.DESKTOP_DOWNLOAD_DIR);
            foreach (FileInfo file in di.GetFiles())
            {
                //if (!File.Exists( path + "/" + file.Name + ".xlsx"))
                //{
                    if (file.Extension == Carrier.GetExtension())
                    {
                        if (file.Extension == ".csv")
                        {
                            Helper.Convert.CsvToExcel(file.FullName, path + "/" + Path.GetFileNameWithoutExtension( file.Name) + ".xlsx", Carrier.Carrier);
                        }
                        else if (file.Extension == ".xls")
                        {
                            Helper.Convert.XlsToExcel(file.FullName, path + "/" + Path.GetFileNameWithoutExtension(file.Name) + ".xlsx");
                        }
                        else
                        {
                            if (!File.Exists(path + "/" + file.Name)) File.Copy(file.FullName, path + "/" + file.Name);
                        }
                    }
                Thread.Sleep(10000);
                //}
            }
        }

        public void Stop()
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (Process p in chromeInstances)
            {
                if( !p.HasExited)
                {
                    p.Kill();

                }
            }
            

            Thread.Sleep(10000);

        }

        public async Task UploadToBlobStorage()
        {
            Console.WriteLine("Upload Blob");
            var dateNow = DateTime.Now;
            string path = Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd");
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {

                using (BlobStore blob = new BlobStore())
                {
                    if (!await blob.UploadFile(Carrier, file.FullName, "Downloads/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd")))
                    {
                        Console.WriteLine("Error Storage Upload.");
                    }
                    else
                    {
                        Console.WriteLine("Upload successful.");
                    }
                }
            }
        }
    }
}
