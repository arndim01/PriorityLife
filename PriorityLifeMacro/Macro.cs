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
using System.Windows.Forms;

namespace PriorityLifeMacro
{
    public class Macro : IDisposable
    {
        public bool isAuthenticated { get; private set; } = false;
        public Uri BaseUri { get; private set; }
        public int ConnectionTimeout { get; set; } = 60000;
        public List<CarrierInfo> CarrierInfos { get; private set; }
        public Macro(Uri baseUri)
        {
            BaseUri = baseUri;
        }
        public async Task GetCarrierInfo(string API_KEY)
        {
            CarrierInfos = new List<CarrierInfo>()
            {
                 new CarrierInfo{ Id = 6, Carrier = Carrier.AIG, ShortName = "AIG", Username = "Test", Password = "Test", DownloadType = DownloadType.Bulk},
                 new CarrierInfo{ Carrier = Carrier.AMERICO, Username = "Test", Password = "Test", DownloadType = DownloadType.InputDate},
                 new CarrierInfo{ Id = 3, Carrier = Carrier.MOO, ShortName = "MOO", Username = "Test", Password = "Test", DownloadType = DownloadType.Bulk},
                 new CarrierInfo { Carrier = Carrier.AMAM, Username = "Test", Password = "Test", DownloadType = DownloadType.Bulk }
            };
            if ( CarrierInfos.Count == 0)
            {
                throw new Exception("No carrier result found from the server.");
            }
            this.isAuthenticated = true;
        }
        public async Task PlayMacro()
        {
            if( this.isAuthenticated)
            {
                IMacroBrowser macroIE = new MacroIE();
                IMacroBrowser macroCR = new MacroChrome();
                Thread.Sleep(5000);
                try
                {
                    foreach (CarrierInfo carrier in CarrierInfos)
                    {
                        string Browser = carrier.GetBrowser();
                        switch (Browser)
                        {
                            case "cr": // Chrome Browser
                                macroCR.SetCarrier(carrier);
                                 await RunPlayerAsync(macroCR);
                                break;
                            case "ie": // Internet Explorer Browser
                                macroIE.SetCarrier(carrier);
                                 await RunPlayerAsync(macroIE);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new Exception(e.Message);
                }
            }
            else
            {
                throw new Exception("Authenticate using your credentials");
            }
        }
        private async Task RunPlayerAsync(IMacroBrowser macro)
        {
            try
            {

                macro.Play();
                //Clean download file, transfer excel to the corresponding storage and create logs.
                macro.TransferFiles();
                macro.CreateLogs();
                await Task.Run(() => macro.UploadToBlobStorage());
                macro.CleanFiles();
            }
            catch(Exception e)
            {
                Error.CreateExceptionLog(e, Constant.LOGS_DIR);
            }

        }
        public void Dispose()
        {
            BaseUri = null;
            CarrierInfos = null;
        }
    }
}
