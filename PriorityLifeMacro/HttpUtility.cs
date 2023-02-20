using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriorityLifeMacro.Helper;
using PriorityLifeMacro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro
{
    internal static class HttpUtility
    {
        public static async Task UploadCommissionsFileInfo(CommissionsFile commissionsFile)
        {
            string serializedModel = JsonConvert.SerializeObject(commissionsFile);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUri"]);
                client.DefaultRequestHeaders.Add("ApiKey", ConfigurationManager.AppSettings["ApiKey"]);
                HttpResponseMessage response = await client.PostAsync("api/CommissionsFileApi/addfile", new StringContent(serializedModel, Encoding.UTF8, "application/json"));

                Console.WriteLine(response);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ToString());
                }
            }
        }
        public static async Task<List<CarrierInfo>> GetCarrierInfo()    
        {
            List<CarrierInfo> carrierInfos = new List<CarrierInfo>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUri"]);
                client.DefaultRequestHeaders.Add("ApiKey", ConfigurationManager.AppSettings["ApiKey"]);
                HttpResponseMessage response = await client.GetAsync("api/CarriersApi/list");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    dynamic instance = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                    var result = (JArray)instance["rows"];

                    foreach (JToken tk in result)
                    {

                        var cell = tk["cell"];
                        Carrier carrier = Carrier.NULL;
                        switch (cell[2].ToString())
                        {
                            case "AMERICO":
                                carrier = Carrier.AMERICO;
                                break;
                            case "MOO":
                                carrier = Carrier.MOO;
                                break;
                            case "ROYAL":
                                carrier = Carrier.ROYAL;
                                break;
                            case "AIG":
                                carrier = Carrier.AIG;
                                break;
                            case "GLOBAL":
                                carrier = Carrier.GLOBAL;
                                break;
                        }

                        DownloadType downloadType = DownloadType.Bulk;
                        if (cell[2].ToString() == "AMERICO" || cell[2].ToString() == "ROYAL")
                        {
                            downloadType = DownloadType.InputDate;
                        }


                        if (carrier != Carrier.NULL)
                            carrierInfos.Add(new CarrierInfo { Id = System.Convert.ToInt32(cell[0]),  Carrier = carrier, ShortName = cell[2].ToString(), Username = cell[4].ToString(), Password = cell[5].ToString(), DownloadType = downloadType });

                    }
                    return carrierInfos;
                }
                else
                {
                    return carrierInfos;
                }
            }
            
        }
    }
}
