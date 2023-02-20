    using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro.Helper
{
    public static class Convert
    {



        /// <summary>
        /// Convert Csv to Xlsx
        /// </summary>
        /// <param name="FileInput"></param>
        /// <param name="FileOutput"></param>
        public static void CsvToExcel(string FileInput, string FileOutput, Carrier carrier)
        {
            if (!File.Exists(FileOutput))
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(FileOutput)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromText(new FileInfo(FileInput), carrier.ExcelFormatByCarrier());
                    package.Save();
                }
            }   
        }


        private static ExcelTextFormat ExcelFormatByCarrier(this Carrier carrier)
        {
            var format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.TextQualifier = '"';
            if (carrier == Carrier.AMERICO)
            {
                format.EOL = "\r";

            }
            else if (carrier == Carrier.GLOBAL)
            {
                format.EOL = "\n";
            }

            return format;
        }


        /// <summary>
        /// Convert Xls File to Xlsx
        /// </summary>
        /// <param name="FileInput"></param>
        /// <param name="FileOutput"></param>
        public static void XlsToExcel(string FileInput, string FileOutput)
        {
            if (!File.Exists(FileOutput))
            {
                using (ExcelPackage epackage = new ExcelPackage())
                {
                    ExcelWorksheet excel = epackage.Workbook.Worksheets.Add("ExcelTabName");
                    DataSet ds = ReadExcelFile(FileInput);
                    DataTable dtbl = ds.Tables[0];
                    excel.Cells["A1"].LoadFromDataTable(dtbl, true);
                    FileInfo file = new System.IO.FileInfo(FileOutput);
                    epackage.SaveAs(file);
                }
            }
        }

        



        private static string GetConnectionString(string FileInput)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0";
            props["Extended Properties"] = @"""Excel 12.0 XML;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text""";
            props["Data Source"] = FileInput;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }
        
        private static DataSet ReadExcelFile(string FileInput)
        {
            DataSet ds = new DataSet();

            string connectionString = GetConnectionString(FileInput);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                // Get all Sheets in Excel File
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                // Loop through all Sheets to get data
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    //if (!sheetName.EndsWith("$"))
                    //    continue;

                    // Get all rows from the Sheet
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    DataTable dt = new DataTable();
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    ds.Tables.Add(dt);
                }

                cmd = null;
                conn.Close();
            }

            return ds;
        }


        //private static DataSet ReadCSVFile(string FileInput)
        //{
        //    DataSet ds = new DataSet();

        //    string connectionString = GetCSVConnectionString(FileInput);
        //    Console.WriteLine(connectionString);
        //    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //    {
        //        conn.Open();
        //        OleDbCommand cmd = new OleDbCommand();
        //        cmd.Connection = conn;

        //        // Get all Sheets in Excel File
        //        DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        //        // Loop through all Sheets to get data
        //        foreach (DataRow dr in dtSheet.Rows)
        //        {
        //            string sheetName = dr["TABLE_NAME"].ToString();

        //            //if (!sheetName.EndsWith("$"))
        //            //    continue;

        //            // Get all rows from the Sheet
        //            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

        //            DataTable dt = new DataTable();
        //            dt.TableName = sheetName;

        //            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //            da.Fill(dt);

        //            ds.Tables.Add(dt);
        //        }

        //        cmd = null;
        //        conn.Close();
        //    }

        //    return ds;
        //}

        //public static void Csv2ToExcel(string FileInput, string FileOutput)
        //{
        //    if (!File.Exists(FileOutput))
        //    {
        //        using (ExcelPackage epackage = new ExcelPackage())
        //        {
        //            ExcelWorksheet excel = epackage.Workbook.Worksheets.Add("ExcelTabName");
        //            DataSet ds = ReadCSVFile(FileInput);
        //            DataTable dtbl = ds.Tables[0];
        //            excel.Cells["A1"].LoadFromDataTable(dtbl, true);
        //            FileInfo file = new FileInfo(FileOutput);
        //            epackage.SaveAs(file);
        //        }
        //    }
        //}


        //private static string GetCSVConnectionString(string FileInput)
        //{
        //    Dictionary<string, string> props = new Dictionary<string, string>();

        //    // XLSX - Excel 2007, 2010, 2012, 2013
        //    props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
        //    props["Extended Properties"] = @"text;HDR=Yes;FMT=Delimited;";
        //    props["Data Source"] = FileInput;

        //    // XLS - Excel 2003 and Older
        //    //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
        //    //props["Extended Properties"] = "Excel 8.0";
        //    //props["Data Source"] = "C:\\MyExcel.xls";

        //    StringBuilder sb = new StringBuilder();

        //    foreach (KeyValuePair<string, string> prop in props)
        //    {
        //        sb.Append(prop.Key);
        //        sb.Append('=');
        //        sb.Append(prop.Value);
        //        sb.Append(';');
        //    }

        //    return sb.ToString();
        //}

    }
}
