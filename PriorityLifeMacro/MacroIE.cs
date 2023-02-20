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
    public class MacroIE : IMacroIE
    {

        private iMacros.AppClass app;
        private iMacros.Status status;
        private int TimeOut;
        private bool OpenBrowser;
        public CarrierInfo Carrier { get; private set; }
        public ErrorLogs ErrorLogs { get; private set; }
        public MacroIE( bool openBrowser = true, int timeOut = 60  ) 
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
                Thread.Sleep(Carrier.GetEstimateTimeout()*2);
                Console.WriteLine("End Timer");
            })
            { Name = "Worker" };
            Console.WriteLine("Starting worker thread...");
            worker.Start();
            // watchdog thread
            ThreadPool.QueueUserWorkItem((o) => {
                if (!worker.Join(Carrier.GetEstimateTimeout()))
                {
                    status = app.iimClose();
                    Console.WriteLine("Stop IMacro");
                    Thread.Sleep(5000);
                    worker.Abort();
                    ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "macro_force_close_error", Message = "Force close imacro"});
                    this.Stop();
                }
            });

            status = app.iimOpen("-ie", OpenBrowser, TimeOut);
            if (status != iMacros.Status.sOk) {

                ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "macro_open_error", Message = status.ToString() });
            }
            string macroPath = Constant.MACRO_DIR + Carrier.GetPath();
            app.iimSet("usn", Carrier.Username);
            app.iimSet("pwd", Carrier.Password);
            app.iimSet("downloadpath", Constant.DOWNLOAD_DIR);
            if (Carrier.DownloadType == DownloadType.InputDate)
            {
                var dateNow = DateTime.Now.AddDays(-1);
                app.iimSet("eff", dateNow.ToString("M/dd/yyyy"));
                app.iimSet("exp", dateNow.ToString("M/dd/yyyy"));
            }
            status = app.iimPlay(macroPath);
            if (status != iMacros.Status.sOk) {
                ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "macro_play_error", Message = status.ToString() });
            }
            status = app.iimClose();
            if (status != iMacros.Status.sOk) {
                ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "macro_close_error", Message = status.ToString() });
            }
            Thread.Sleep(5000);
            this.Stop();
            worker.Abort();
            if( ErrorLogs.ErrorDetails.Count == 0 )
                ErrorLogs.ErrorDetails.Add(new ErrorDetails { Type = "success", Message = "No Error found" });
        }
        public void CleanFiles()
        {
            DirectoryInfo di = new DirectoryInfo(Constant.DESKTOP_DOWNLOAD_DIR);
            foreach(FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public void CreateLogs()
        {
            var dateNow = DateTime.Now;
            XmlSerializer xmlSerializer = new XmlSerializer(ErrorLogs.GetType());
            string XmlString = "";
            using(MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, ErrorLogs);
                memoryStream.Position = 0;
                XmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            XElement xElement = XElement.Parse(XmlString);
            
            xElement.Save(Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") + "/logs.xml");
        }
        public void TransferFiles()
        {
            var dateNow = DateTime.Now;
            string path = Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd");
            Directory.CreateDirectory(path);
            ConvertFileToExpectedExtension(path);
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                //if (!File.Exists(Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") + "/" + file.Name + ".xlsx"))
                //{
                    if (file.Extension == Carrier.GetExtension())
                    {
                        if (file.Extension == ".csv")
                        {

                            Helper.Convert.CsvToExcel(file.FullName, Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") + "/" + Path.GetFileNameWithoutExtension(file.Name) + ".xlsx", Carrier.Carrier);
                        }
                        else if (file.Extension == ".xls")
                        {
                            Helper.Convert.XlsToExcel(file.FullName, Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") + "/" + Path.GetFileNameWithoutExtension(file.Name) + ".xlsx");
                        }
                    }
                //}
            }
        }

        /// <summary>
        /// Check if file dont have extension and change to expected extension.
        /// </summary>
        /// <param name="path"></param>
        private void ConvertFileToExpectedExtension(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Extension == "" && Carrier.ShortName == "MOO")
                {
                    File.Copy(file.FullName, file.FullName + Carrier.GetExtension());
                }
            }
        }

        public async Task UploadToBlobStorage()
        {
            var dateNow = DateTime.Now;
            string path = Constant.DOWNLOAD_DIR + "/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd");
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                if( file.Extension == ".xlsx" || file.Extension == ".xml")
                {
                    using (BlobStore blob = new BlobStore())
                    {
                        if (!await blob.UploadFile(Carrier, file.FullName, "Downloads/" + Carrier.GetDownloadPath() + dateNow.ToString("yyyyMMdd") ))
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

            Console.WriteLine("Upload Blob");

        }

        public void Stop()
        {
            Process[] ieInstances = Process.GetProcessesByName("IEXPLORE");
            foreach (Process p in ieInstances)
            {
                if(!p.HasExited)
                {

                    p.Kill();
                }
            }
        }

       
    }
}
