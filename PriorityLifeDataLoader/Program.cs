using Newtonsoft.Json;
using PriorityLifeDataLoader.Build;
using PriorityLifeDataLoader.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

//                ExecuteExcel(args[0], args[1], args[2], args[3]);
                ExecuteExcel("ConvertToJson", "RSHIELD", "Downloads/export.xlsx", "");
            }
            catch
            {
                Console.WriteLine("Please enter by order [Method] [Carrier Short Name] [File Path] [Date(MM/dd/yyyy)]");
                Console.WriteLine("Available Method:");
                Console.WriteLine("Convert Json");
            }

            Console.ReadLine();
            Console.WriteLine("fsfasfa");
        }
        public static void ExecuteExcel(string method, string carrier, string path, string date)
        {
            using (ExtractedProperties extracted = new ExtractedProperties())
            {

                Carrier carrierType = Carrier.AIG;
                switch (carrier)
                {
                    case "AIG":
                        carrierType = Carrier.AIG;
                        break;
                    case "AMERICO":
                        carrierType = Carrier.AMERICO;
                        break;
                    case "MOO":
                        carrierType = Carrier.MOO;
                        break;
                    case "GLOBAL":
                        carrierType = Carrier.GLOBAL;
                        break;
                    case "ROYAL":
                        carrierType = Carrier.ROYAL;
                        break;
                    case "AMAM":
                        carrierType = Carrier.AMAM;
                        break;
                    case "ATHENE":
                        carrierType = Carrier.ATHENE;
                        break;
                    case "TRANS":
                        carrierType = Carrier.TRANS;
                        break;
                    case "PROSPERITY":
                        carrierType = Carrier.PROSPERITY;
                        break;
                    case "RSHIELD":
                        carrierType = Carrier.RSHIELD;
                        break;
                }

                switch (method)
                {
                    case "ConvertToJsonDate":
                        extracted.ConvertToExtractedObject(carrierType, path, date);
                        Console.WriteLine(extracted.GetJson());
                        break;
                    case "ConvertToJson":
                        extracted.ConvertToExtractedObject(carrierType, path);
                        Console.WriteLine(extracted.GetJson());
                        break;
                    default:
                        Console.WriteLine("Please enter by order [Method] [Carrier Short Name] [File Path] [Date(MM/dd/yyyy)]");
                        Console.WriteLine("Available Method:");
                        Console.WriteLine("Convert Json");
                        break;
                }

                
            }
        }

    }
}
