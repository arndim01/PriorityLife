using Newtonsoft.Json;
using PriorityLifeDataLoader.Build;
using PriorityLifeDataLoader.Interface;
using PriorityLifeDataLoader.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Helper
{
    public static class ReadingData
    {

        
        public static Dictionary<string, int> GetColumnsPosition(this ITemplateSheet templateSheet)
        {
            Dictionary<string, int> ColumnsAddress = new Dictionary<string, int>();
            if( templateSheet != null)
            {
                var HeaderColumnList = templateSheet.Ws.Row(templateSheet.ReadLine).AsRange().CellsUsed();

                foreach( var cl in HeaderColumnList)
                {
                    int ColAddress = cl.Address.ColumnNumber;
                    foreach (var column in templateSheet.TemplateProperties.XMLProperties.Columns)
                    {

                        //Console.WriteLine(cl.Value.ToString().ToLowerInvariant().Trim());
                        //Console.WriteLine(column.Key.ToLowerInvariant());

                        if ( cl.Value.ToString().ToLowerInvariant().Trim() == column.Key.ToLowerInvariant())
                        {
                            ColumnsAddress.Add(cl.Value.ToString().ToLowerInvariant().Trim(), ColAddress);
                        }
                    }
                }

                return ColumnsAddress;

            }
            else
            {
                throw new Exception("TemplateSheeet is null.");
            }
        }
        /// <summary>
        /// Convert All Excel Data to DataTable
        /// </summary>
        /// <param name="templateSheet"></param>
        /// <param name="ColumnsHeaderPosition"></param>
        /// <returns></returns>
        public static DataTable ConstructData(this ITemplateSheet templateSheet, Dictionary<string, int> ColumnsHeaderPosition)
        {
            
            if( ColumnsHeaderPosition != null && templateSheet != null )
            {
                templateSheet.NextLine();
                using (DataTable dataTable = new DataTable())
                {
                    //foreach (var column in ColumnsHeaderPosition)
                    //{
                    dataTable.Columns.Add(new DataColumn("agent_surname", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("agent_givenname", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("amount", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("date", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("year", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("month", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("day", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("pl_number", typeof(string)));
                    //dataTable.Columns.Add(new DataColumn)

                    //}
                    bool FoundIssue = false;
                    string CustomdDate = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
                    for (; templateSheet.ReadLine <= templateSheet.GetTotalRowsUsed; templateSheet.NextLine())
                    {
                        //if( !FoundIssue )
                        //{
                            dataTable.Rows.Add();
                        //}

                        FoundIssue = false;

                        foreach (var column in ColumnsHeaderPosition)
                        {
                            foreach(var columnPolicy in templateSheet.TemplateProperties.XMLProperties.Columns)
                            {
                                if(columnPolicy.Key.ToLowerInvariant() == column.Key)
                                {

                                    string extractedCellValue = templateSheet.Ws.Cell(templateSheet.ReadLine, column.Value).Value.ToString().Trim();

                                    if (columnPolicy.Value.Dont.Count > 0)
                                    {
                                        if( columnPolicy.Value.Dont.Any(extractedCellValue.Contains) || FindSpecialCode(columnPolicy.Value.Dont, extractedCellValue))
                                        {
                                            FoundIssue = true;
                                            break;
                                        }
                                        else
                                        {
                                            if( columnPolicy.Value.ExtractedColumn == "agent_name")
                                            {

                                                if( extractedCellValue.Contains(','))
                                                {
                                                    string[] split = extractedCellValue.Split(',');


                                                    if (split.Length > 1)
                                                    {
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();

                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                    }
                                                    else
                                                    {
                                                        FoundIssue = true;
                                                        break;
                                                    }

                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }



                                            }
                                            else if(columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if(columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if( columnPolicy.Value.ExtractedColumn == "amount")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                            }
                                            else if( columnPolicy.Value.ExtractedColumn == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;

                                                var dateExtract = extractedCellValue.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;

                                            }
                                            else if( columnPolicy.Value.ExtractedColumn == "pl_number")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                            }

                                            if( templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;
                                                var dateExtract = CustomdDate.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                            }
                                        }
                                    }else if(columnPolicy.Value.Dos.Count > 0)
                                    {
                                        if( !columnPolicy.Value.Dos.Any(extractedCellValue.Contains))
                                        {
                                            FoundIssue = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (columnPolicy.Value.ExtractedColumn == "agent_name")
                                            {
                                                if (extractedCellValue.Contains(','))
                                                {
                                                    string[] split = extractedCellValue.Split(',');


                                                    if (split.Length > 1)
                                                    {
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                    }
                                                    else
                                                    {
                                                        FoundIssue = true;
                                                        break;
                                                    }

                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "amount")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;
                                                var dateExtract = extractedCellValue.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "pl_number")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                            }

                                            if (templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;

                                                var dateExtract = CustomdDate.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;

                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (columnPolicy.Value.ExtractedColumn == "agent_name")
                                        {
                                            if (extractedCellValue.Contains(','))
                                            {
                                                string[] split = extractedCellValue.Split(',');


                                                if (split.Length > 1)
                                                {
                                                    dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();
                                                    dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                FoundIssue = true;
                                                break;
                                            }
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "amount")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "date")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;
                                            var dateExtract = extractedCellValue.CleanDateString();
                                            dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "pl_number")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                        }

                                        if (templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;
                                            var dateExtract = CustomdDate.CleanDateString();
                                            dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                        }
                                    }
                                }
                            }
                            if (FoundIssue) {
                                dataTable.Rows.RemoveAt(dataTable.Rows.Count - 1);
                                break;
                            } 
                            
                        }
                        
                    }



                        return dataTable;

                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Convert All Excel Data to DataTable
        /// </summary>
        /// <param name="templateSheet"></param>
        /// <param name="ColumnsHeaderPosition"></param>
        /// <returns></returns>
        public static DataTable ConstructData(this ITemplateSheet templateSheet, Dictionary<string, int> ColumnsHeaderPosition, string Date)
        {

            if (ColumnsHeaderPosition != null && templateSheet != null)
            {
                templateSheet.NextLine();
                using (DataTable dataTable = new DataTable())
                {
                    //foreach (var column in ColumnsHeaderPosition)
                    //{
                    dataTable.Columns.Add(new DataColumn("agent_surname", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("agent_givenname", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("amount", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("date", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("year", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("month", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("day", typeof(string)));
                    dataTable.Columns.Add(new DataColumn("pl_number", typeof(string)));

                    //}
                    bool FoundIssue = false;
                    string CustomdDate = Date;
                    for (; templateSheet.ReadLine <= templateSheet.GetTotalRowsUsed; templateSheet.NextLine())
                    {
                        //if( !FoundIssue )
                        //{
                        dataTable.Rows.Add();
                        //}

                        FoundIssue = false;

                        foreach (var column in ColumnsHeaderPosition)
                        {
                            foreach (var columnPolicy in templateSheet.TemplateProperties.XMLProperties.Columns)
                            {
                                if (columnPolicy.Key.ToLowerInvariant() == column.Key)
                                {

                                    string extractedCellValue = templateSheet.Ws.Cell(templateSheet.ReadLine, column.Value).Value.ToString().Trim();

                                    if (columnPolicy.Value.Dont.Count > 0)
                                    {
                                        if (columnPolicy.Value.Dont.Any(extractedCellValue.Contains) || FindSpecialCode(columnPolicy.Value.Dont, extractedCellValue))
                                        {
                                            FoundIssue = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (columnPolicy.Value.ExtractedColumn == "agent_name")
                                            {

                                                if (extractedCellValue.Contains(','))
                                                {
                                                    string[] split = extractedCellValue.Split(',');


                                                    if (split.Length > 1)
                                                    {
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();

                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                    }
                                                    else
                                                    {
                                                        FoundIssue = true;
                                                        break;
                                                    }

                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }



                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "amount")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;

                                                var dateExtract = extractedCellValue.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;

                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "pl_number")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                            }

                                            if (templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;
                                                var dateExtract = CustomdDate.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                            }
                                        }
                                    }
                                    else if (columnPolicy.Value.Dos.Count > 0)
                                    {
                                        if (!columnPolicy.Value.Dos.Any(extractedCellValue.Contains))
                                        {
                                            FoundIssue = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (columnPolicy.Value.ExtractedColumn == "agent_name")
                                            {
                                                if (extractedCellValue.Contains(','))
                                                {
                                                    string[] split = extractedCellValue.Split(',');


                                                    if (split.Length > 1)
                                                    {
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();
                                                        dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                    }
                                                    else
                                                    {
                                                        FoundIssue = true;
                                                        break;
                                                    }

                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "amount")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;
                                                var dateExtract = extractedCellValue.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                            }
                                            else if (columnPolicy.Value.ExtractedColumn == "pl_number")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                            }

                                            if (templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                            {
                                                dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;

                                                var dateExtract = CustomdDate.CleanDateString();
                                                dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                                dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;

                                                dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (columnPolicy.Value.ExtractedColumn == "agent_name")
                                        {
                                            if (extractedCellValue.Contains(','))
                                            {
                                                string[] split = extractedCellValue.Split(',');


                                                if (split.Length > 1)
                                                {
                                                    dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = split[0].CleanUnessaryString();
                                                    dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = split[1].CleanUnessaryString();
                                                }
                                                else
                                                {
                                                    FoundIssue = true;
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                FoundIssue = true;
                                                break;
                                            }
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "agent_first_name")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["agent_givenname"] = extractedCellValue.CleanUnessaryString();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "agent_last_name")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["agent_surname"] = extractedCellValue.CleanUnessaryString();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "amount")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["amount"] = extractedCellValue.ParseCurrency();
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "date")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["date"] = extractedCellValue;
                                            var dateExtract = extractedCellValue.CleanDateString();
                                            dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                        }
                                        else if (columnPolicy.Value.ExtractedColumn == "pl_number")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = extractedCellValue;
                                        }

                                        if (templateSheet.TemplateProperties.XMLProperties.DlType == "date")
                                        {
                                            dataTable.Rows[dataTable.Rows.Count - 1]["date"] = CustomdDate;
                                            var dateExtract = CustomdDate.CleanDateString();
                                            dataTable.Rows[dataTable.Rows.Count - 1]["year"] = dateExtract.Year;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["month"] = dateExtract.Month;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["day"] = dateExtract.Day;
                                            dataTable.Rows[dataTable.Rows.Count - 1]["pl_number"] = "NON";
                                        }
                                    }
                                }
                            }
                            if (FoundIssue)
                            {
                                dataTable.Rows.RemoveAt(dataTable.Rows.Count - 1);
                                break;
                            }

                        }

                    }

                    Console.WriteLine(dataTable);

                    return dataTable;

                }
            }
            else
            {
                throw new Exception();
            }
        }

        private static bool FindSpecialCode(List<string> Policy, string Value)
        {
            if(Policy.Any("_blank".Contains))
            {
                if(String.IsNullOrEmpty(Value.Trim()))
                {
                    return true;
                }
                return false;
            }

            return false;
        }
        private static string CleanUnessaryString(this string Value)
        {
            if( Value.IndexOf('(') != -1)
            {
                return getFirstString(Value.Trim(), "(");
            }
            return Value.Trim();
        }
        private static DateExtract CleanDateString(this string Value)
        {
            try
            {
                var date = DateTime.Parse(Value);
                var format = String.Format("{0:MM/dd/yyyy}", Value);

                var splitspace = format.Split(' ');
                var correctedDate = "";
                if(splitspace.Length == 1)
                {
                    correctedDate = format;
                }
                else
                {
                    correctedDate = splitspace[0];
                }

                string[] split = correctedDate.Split('/');
                return new DateExtract { Year = split[2], Day = split[1], Month = split[0] };
            }
            catch
            {
                string[] split = Value.Split('/');
                return new DateExtract { Year = split[2], Day = split[1], Month = split[0] };
            }
        }
        private static string getFirstString(string strSource, string strEnd)
        {
            int end;
            if (strSource.Contains(strEnd))
            {
                end = strSource.IndexOf(strEnd, 0);
                return strSource.Substring(0, end);
            }
            else
            {
                return "";
            }
        }
        private static string ParseCurrency(this string amount)
        {
            string NewAmount = "";
            if( !String.IsNullOrEmpty(amount))
            {

                NewAmount = Decimal.Parse(amount.Replace("$", ""), NumberStyles.Currency).ToString();
            }
            return NewAmount;
        }
        public static string ToJson(this DataTable table)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
            foreach (DataRow row in table.Rows)
            {
                item = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));
                }
                lst.Add(item);
            }
            return JsonConvert.SerializeObject(lst);
        }
    }
}
