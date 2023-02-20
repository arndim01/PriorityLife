using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using PriorityLifeDataLoader;
using PriorityLifeDataLoader.Helper;

namespace PriorityLifeLoader.AzureFunction
{
    public static class MacroLoaderFunction
    {
        [FunctionName("MacroLoaderFunction")]
        public static async Task RunAsync([BlobTrigger("azure-prioritylife/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            if( Path.GetExtension(name) == ".xlsx")
            {
                using (ExtractedProperties extractedProperties = new ExtractedProperties())
                {
                    string[] CarrierSplit = Path.GetFileName(name).Split('_');
                    bool validFile = true;
                    if( CarrierSplit.Length > 0)
                    {

                        log.Info($"Captured the carrier template: { CarrierSplit[0] }");
                        switch (CarrierSplit[0])
                        {
                            case "AMERICO":
                                extractedProperties.ConvertToExtractedObject(Carrier.AMERICO, myBlob);
                                break;
                            case "AIG":
                                extractedProperties.ConvertToExtractedObject(Carrier.AIG, myBlob);
                                break;
                            case "MOO":
                                extractedProperties.ConvertToExtractedObject(Carrier.MOO, myBlob);
                                break;
                            case "GLOBAL":
                                extractedProperties.ConvertToExtractedObject(Carrier.GLOBAL, myBlob);
                                break;
                            case "ROYAL":
                                extractedProperties.ConvertToExtractedObject(Carrier.ROYAL, myBlob);
                                break;
                            default:
                                validFile = false;
                                break;
                        }
                        if( validFile)
                        {
                            try
                            {
                                string stringJSON = extractedProperties.GetJson();
                                await PostCommissionsJSONAsync(CarrierSplit[0], stringJSON, log);
                                log.Info($"Total table rows \n Rows:{extractedProperties.GetTotalRows()}, Carrier : { CarrierSplit[0] }");
                            }
                            catch
                            {
                                log.Info("Failed Load.");
                            }
                        }
                    }
                }
            }
        }
        public static async Task PostCommissionsJSONAsync(string Carrier, string JSON, TraceWriter log)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://prioritylife.azurewebsites.net");
                client.DefaultRequestHeaders.Add("ApiKey", "PriorityLifeV1");
                client.DefaultRequestHeaders.Add("Carrier", Carrier);
                HttpResponseMessage response = null;
                if( Carrier == "AMERICO" || Carrier == "ROYAL")
                {
                    response = await client.PostAsync("api/CommissionsApi/uploadbydate", new StringContent(JSON, Encoding.UTF8, "application/json"));
                }
                else
                {
                    response = await client.PostAsync("api/CommissionsApi/upload", new StringContent(JSON, Encoding.UTF8, "application/json"));
                }

                if (response.IsSuccessStatusCode)
                {
                    log.Info("Successfully upload data...");
                }else
                {
                    log.Info("Failed upload data...");
                }

            }
        }
    }
}
