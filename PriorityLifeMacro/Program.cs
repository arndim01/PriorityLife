using ClosedXML.Excel;
using OfficeOpenXml;
using PriorityLifeMacro.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityLifeMacro
{
    class Program
    {

        
        static async Task Main(string[] args)
        {

                using (var macro = new Macro(new Uri(ConfigurationManager.AppSettings["BaseUri"])))
                {
                    await macro.GetCarrierInfo(ConfigurationManager.AppSettings["ApiKey"]);
                    await macro.PlayMacro();
                }
            

            //try
            //{

            //    Helper.Convert.XlsToExcel(@"C:\Users\bituinadmin\Downloads\IAMExportExcel.xls", @"C:\Projects\PriorityLifeMacro\MacroSaver\Downloads\MOO\IAMExportExcel.xlsx");
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine();
            //}

            //Console.WriteLine("Press any key");
            //Console.ReadLine();
            //Thread.Sleep(5000);
        }
    }
}
