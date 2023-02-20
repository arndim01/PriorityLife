
using OfficeOpenXml;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class ReportFunctions
    {
        private ReportFunctions()
        {

        }
        internal static bool AreFallingInSameWeek(DateTime date1, DateTime date2)
        {
            return date1.AddDays(-(int)date1.DayOfWeek) == date2.AddDays(-(int)date2.DayOfWeek);
        }
        internal static bool AreFallingInSameDay(DateTime date1, DateTime date2)
        {
            return date2.Year == date1.Year && date2.Month == date1.Month && date2.Day == date1.Day;
        }
        internal static bool AreFallingInSameMonth(DateTime date1, DateTime date2)
        {
            return date2.Year == date1.Year && date2.Month == date1.Month;
        }
        internal static bool AreFallingInSameYear(DateTime date1, DateTime date2)
        {
            return date2.Year == date1.Year;
        }

        internal static DateTime FirstDayOfWeek( DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }

        internal static DateTime LastDayOfWeek( DateTime dt) =>
            FirstDayOfWeek(dt).AddDays(6);

        internal static DateTime FirstDayOfMonth( DateTime dt) =>
       new DateTime(dt.Year, dt.Month, 1);

        internal static List<PriorityLifeAPI.Models.AgentTeamReport> SortTeamManagerReport(List<PriorityLifeAPI.Models.AgentTeamReport> reports, string sidx, string sord, int startIndex, int row)
        {
            if (sord == "desc")
            {
                switch (sidx)
                {
                    case "TeamName":
                        return reports.OrderByDescending(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                    case "TeamManager":
                        return reports.OrderByDescending(s => s.TeamManagerLastName).OrderByDescending(s => s.TeamManagerFirstName).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderByDescending(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderByDescending(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderByDescending(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                }
            }
            else
            {
                switch (sidx)
                {
                    case "TeamName":
                        return reports.OrderBy(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                    case "TeamManager":
                        return reports.OrderBy(s => s.TeamManagerLastName).OrderBy(s => s.TeamManagerFirstName).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderBy(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderBy(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderBy(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                }
            }
        }

        internal static List<PriorityLifeAPI.Models.TeamReport> SortTeamReport(List<PriorityLifeAPI.Models.TeamReport> reports, string sidx, string sord, int startIndex, int row)
        {
            if (sord == "desc")
            {
                switch (sidx)
                {
                    case "TeamName":
                        return reports.OrderByDescending(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                        
                    case "Amount":
                        return reports.OrderByDescending(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderByDescending(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderByDescending(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                }
            }
            else
            {
                switch (sidx)
                {
                    case "TeamName":
                        return reports.OrderBy(s => s.TeamName).Skip(startIndex).Take(row).ToList();

                    case "Amount":
                        return reports.OrderBy(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderBy(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderBy(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                }
            }
        }
       
        internal static List<IndividualReport> SortReport(List<IndividualReport> reports, string sidx, string sord, int startIndex, int row)
        {

            if( sord == "desc")
            {
                switch (sidx)
                {
                    case "Id":
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "WritingAgent":
                        return reports.OrderByDescending(s => s.WritingAgent).Skip(startIndex).Take(row).ToList();
                    case "CommissionsDate":
                        return reports.OrderByDescending(s => s.CommissionsDate).Skip(startIndex).Take(row).ToList();
                    case "Upline1":
                        return reports.OrderByDescending(s => s.Upline1).Skip(startIndex).Take(row).ToList();
                    case "Upline2":
                        return reports.OrderByDescending(s => s.Upline2).Skip(startIndex).Take(row).ToList();
                    case "Upline3":
                        return reports.OrderByDescending(s => s.Upline3).Skip(startIndex).Take(row).ToList();
                    case "Upline4":
                        return reports.OrderByDescending(s => s.Upline4).Skip(startIndex).Take(row).ToList();
                    case "Upline5":
                        return reports.OrderByDescending(s => s.Upline5).Skip(startIndex).Take(row).ToList();
                    case "Upline6":
                        return reports.OrderByDescending(s => s.Upline6).Skip(startIndex).Take(row).ToList();
                    case "Upline7":
                        return reports.OrderByDescending(s => s.Upline7).Skip(startIndex).Take(row).ToList();
                    case "Upline8":
                        return reports.OrderByDescending(s => s.Upline8).Skip(startIndex).Take(row).ToList();
                    case "Upline9":
                        return reports.OrderByDescending(s => s.Upline9).Skip(startIndex).Take(row).ToList();
                    case "Upline10":
                        return reports.OrderByDescending(s => s.Upline10).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderByDescending(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderByDescending(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                }
            }
            else
            {
                switch (sidx)
                {
                    case "Id":
                        return reports.OrderBy(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "WritingAgent":
                        return reports.OrderBy(s => s.WritingAgent).Skip(startIndex).Take(row).ToList();
                    case "CommissionsDate":
                        return reports.OrderBy(s => s.CommissionsDate).Skip(startIndex).Take(row).ToList();
                    case "Upline1":
                        return reports.OrderBy(s => s.Upline1).Skip(startIndex).Take(row).ToList();
                    case "Upline2":
                        return reports.OrderBy(s => s.Upline2).Skip(startIndex).Take(row).ToList();
                    case "Upline3":
                        return reports.OrderBy(s => s.Upline3).Skip(startIndex).Take(row).ToList();
                    case "Upline4":
                        return reports.OrderBy(s => s.Upline4).Skip(startIndex).Take(row).ToList();
                    case "Upline5":
                        return reports.OrderBy(s => s.Upline5).Skip(startIndex).Take(row).ToList();
                    case "Upline6":
                        return reports.OrderBy(s => s.Upline6).Skip(startIndex).Take(row).ToList();
                    case "Upline7":
                        return reports.OrderBy(s => s.Upline7).Skip(startIndex).Take(row).ToList();
                    case "Upline8":
                        return reports.OrderBy(s => s.Upline8).Skip(startIndex).Take(row).ToList();
                    case "Upline9":
                        return reports.OrderBy(s => s.Upline9).Skip(startIndex).Take(row).ToList();
                    case "Upline10":
                        return reports.OrderBy(s => s.Upline10).Skip(startIndex).Take(row).ToList();
                    case "Carrier":
                        return reports.OrderBy(s => s.Carrier).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderBy(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderBy(s => s.Id).Skip(startIndex).Take(row).ToList();
                }
            }


        }
        internal static string GenerateColumnText(int num)
        {
            string str = "";
            char achar;
            int mod;
            while (true)
            {
                mod = (num % 26) + 65;
                num = (int)(num / 26);
                achar = (char)mod;
                str = achar + str;
                if (num > 0) num--;
                else if (num == 0) break;
            }
            return str;
        }
        
        internal static List<IndividualReport> GetReport(List<Commissions> objCommissionsCol)
        {
            List<IndividualReport> IndiReport = new List<IndividualReport>();
            foreach (var com in objCommissionsCol)
            {
                //var carrier = com.CarrierIdNavigation;
                //var salesperson = com.SalespersonIdNavigation;
                if (com.CarrierIdNavigation != null && com.SalespersonIdNavigation != null)
                {
                    var agentCom = IndiReport.Where(i => i.WritingAgent == com.SalespersonIdNavigation.FirstName + " " + com.SalespersonIdNavigation.LastName[0] && i.Carrier == com.CarrierIdNavigation.ShortName).FirstOrDefault();
                    if (agentCom != null)
                    {
                        agentCom.Amount += com.Amount;
                    }
                    else
                    {
                        IndiReport.Add(new IndividualReport
                        {
                            WritingAgent = com.SalespersonIdNavigation.FirstName + " " + com.SalespersonIdNavigation.LastName[0],
                            Upline1 = com.Upline1 != null ? com.Upline1.FirstName[0].ToString() + com.Upline1.LastName[0].ToString() : "",
                            Upline2 = com.Upline2 != null ? com.Upline2.FirstName[0].ToString() + com.Upline2.LastName[0].ToString() : "",
                            Upline3 = com.Upline3 != null ? com.Upline3.FirstName[0].ToString() + com.Upline3.LastName[0].ToString() : "",
                            Upline4 = com.Upline4 != null ? com.Upline4.FirstName[0].ToString() + com.Upline4.LastName[0].ToString() : "",
                            Upline5 = com.Upline5 != null ? com.Upline5.FirstName[0].ToString() + com.Upline5.LastName[0].ToString() : "",
                            Upline6 = com.Upline6 != null ? com.Upline6.FirstName[0].ToString() + com.Upline6.LastName[0].ToString() : "",
                            Upline7 = com.Upline7 != null ? com.Upline7.FirstName[0].ToString() + com.Upline7.LastName[0].ToString() : "",
                            Upline8 = com.Upline8 != null ? com.Upline8.FirstName[0].ToString() + com.Upline8.LastName[0].ToString() : "",
                            Upline9 = com.Upline9 != null ? com.Upline9.FirstName[0].ToString() + com.Upline9.LastName[0].ToString() : "",
                            Upline10 = com.Upline10 != null ? com.Upline10.FirstName[0].ToString() + com.Upline10.LastName[0].ToString() : "",
                            CommissionsDate = com.CommissionDate,
                            Carrier = com.CarrierIdNavigation.ShortName,
                            Amount = com.Amount
                        });
                    }
                }
            }

            IndiReport = IndiReport.OrderBy(c => c.WritingAgent).ToList();
            int count = 0;
            foreach (IndividualReport indi in IndiReport)
            {
                indi.Id = ++count;
            }

            return IndiReport;
        }
        internal static byte[] GenerateStreamExcelReportTeamManager(List<PriorityLifeAPI.Models.AgentTeamReport> reports, string ReportType)
        {
            string amountHeader = "";


            reports = reports.OrderBy(c => c.TeamName).ToList();



            switch (ReportType)
            {
                case "DAILY":
                    amountHeader = DateTime.Now.ToString("MM/dd/yyyy");
                    break;
                case "WEEKLY":
                    amountHeader = FirstDayOfWeek(DateTime.Now).ToString("MMM") + " " + FirstDayOfWeek(DateTime.Now).Day + " to " + LastDayOfWeek(DateTime.Now).Day + " " + LastDayOfWeek(DateTime.Now).Year;
                    break;
                case "MTD":
                    amountHeader = FirstDayOfMonth(DateTime.Now).ToString("MMM") + " " + FirstDayOfMonth(DateTime.Now).Year;
                    break;
                case "YTD":
                    amountHeader = "Jan to " + DateTime.Now.ToString("MMM") + "-" + DateTime.Now.AddDays(-1).Day;
                    break;
                case "SEARCH":
                    break;
                default:
                    break;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("TeamName", typeof(string));
            table.Columns.Add("TeamManager", typeof(string));
            table.Columns.Add(amountHeader, typeof(decimal));
            table.Columns.Add("AIG", typeof(decimal)); //E
            table.Columns.Add("AMERICO", typeof(decimal)); //F
            table.Columns.Add("MOO", typeof(decimal)); //G
            table.Columns.Add("GLOBAL", typeof(decimal)); //H
            table.Columns.Add("ROYAL", typeof(decimal)); //I

            table.Columns.Add("TRANS", typeof(decimal)); //J
            table.Columns.Add("ATHENE", typeof(decimal)); //K
            table.Columns.Add("AMAM", typeof(decimal)); //L
            table.Columns.Add("PROSPERITY", typeof(decimal)); //M
            table.Columns.Add("RSHIELD", typeof(decimal)); //N

            foreach (var list in reports)
            {
                var team = table.Select("TeamName ='" + list.TeamName + "'");
                if (team.Length > 0)
                {
                    decimal getAmount = String.IsNullOrEmpty(table.Rows[table.Rows.Count - 1][3].ToString()) ? 0 : Convert.ToDecimal(table.Rows[table.Rows.Count - 1][3]);
                    decimal totalAmount = getAmount + list.Amount;
                    table.Rows[table.Rows.Count - 1][3] = totalAmount;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
                else
                {
                    table.Rows.Add();
                    table.Rows[table.Rows.Count - 1]["Rank"] = list.Rank;
                    table.Rows[table.Rows.Count - 1]["TeamName"] = list.TeamName;
                    table.Rows[table.Rows.Count - 1]["TeamManager"] = list.TeamManagerFirstName + " " + list.TeamManagerLastName[0];
                    table.Rows[table.Rows.Count - 1][3] = list.Amount;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
            }
            table.DefaultView.Sort = table.Columns[3].ColumnName + " desc";
            table = table.DefaultView.ToTable();
            int count = 0;
            foreach (DataRow row in table.Rows)
            {
                row[0] = ++count;
            }
            MemoryStream memoryStream = new MemoryStream();
            using (var package = new ExcelPackage(memoryStream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Generated " + ReportType + " Report");
                foreach (DataColumn col in table.Columns)
                {
                    string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal) + 1;
                    worksheet.Cells[columnIndex].Value = col.ColumnName;
                }
                decimal total = 0;
                decimal aigtotal = 0;
                decimal americototal = 0;
                decimal globaltotal = 0;
                decimal moototal = 0;
                decimal royaltotal = 0;

                decimal transtotal = 0;
                decimal amamtotal = 0;
                decimal athenetotal = 0;
                decimal prospertotal = 0;
                decimal rshieldtotal = 0;


                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        int rowIndex = table.Rows.IndexOf(row) + 2;
                        string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal);
                        if (columnIndex == "D" || columnIndex == "E" || columnIndex == "F" || columnIndex == "G" || columnIndex == "H" || columnIndex == "I" || columnIndex == "J" || columnIndex == "K" || columnIndex == "L" || columnIndex == "M" || columnIndex == "N")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Style.Numberformat.Format = "$###,###,##0.00";
                            worksheet.Cells[columnIndex + rowIndex].Value = string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                            switch (columnIndex)
                            {
                                case "D":
                                    total += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "E":
                                    aigtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "F":
                                    americototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "G":
                                    moototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "H":
                                    globaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "I":
                                    royaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "J":
                                    transtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "K":
                                    athenetotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "L":
                                    amamtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "M":
                                    prospertotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "N":
                                    rshieldtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;

                            }

                        }
                        else if (columnIndex == "A")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = Convert.ToInt32(row[col]);
                        }
                        else
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = row[col].ToString();
                        }
                    }
                }
                worksheet.Cells["C" + (table.Rows.Count + 3)].Value = "TOTAL";
                worksheet.Cells["D" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["D" + (table.Rows.Count + 3)].Value = total;
                worksheet.Cells["E" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["E" + (table.Rows.Count + 3)].Value = aigtotal;
                worksheet.Cells["F" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["F" + (table.Rows.Count + 3)].Value = americototal;
                worksheet.Cells["G" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["G" + (table.Rows.Count + 3)].Value = moototal;
                worksheet.Cells["H" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["H" + (table.Rows.Count + 3)].Value = globaltotal;
                worksheet.Cells["I" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["I" + (table.Rows.Count + 3)].Value = royaltotal;

                worksheet.Cells["J" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["J" + (table.Rows.Count + 3)].Value = transtotal;

                worksheet.Cells["K" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["K" + (table.Rows.Count + 3)].Value = athenetotal;

                worksheet.Cells["L" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["L" + (table.Rows.Count + 3)].Value = amamtotal;

                worksheet.Cells["M" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["M" + (table.Rows.Count + 3)].Value = prospertotal;

                worksheet.Cells["N" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["N" + (table.Rows.Count + 3)].Value = rshieldtotal;

                package.Save();
                return memoryStream.ToArray();
            }
        }
        internal static byte[] GenerateStreamExcelReportTeam(List<PriorityLifeAPI.Models.TeamReport> reports , string ReportType)
        {
            string amountHeader = "";
            reports = reports.OrderBy(c => c.TeamName).ToList();
            switch (ReportType)
            {
                case "DAILY":
                    amountHeader = DateTime.Now.ToString("MM/dd/yyyy");
                    break;
                case "WEEKLY":
                    amountHeader = FirstDayOfWeek(DateTime.Now).ToString("MMM") + " " + FirstDayOfWeek(DateTime.Now).Day + " to " + LastDayOfWeek(DateTime.Now).Day + " " + LastDayOfWeek(DateTime.Now).Year;
                    break;
                case "MTD":
                    amountHeader = FirstDayOfMonth(DateTime.Now).ToString("MMM") + " " + FirstDayOfMonth(DateTime.Now).Year;
                    break;
                case "YTD":
                    amountHeader = "Jan to " + DateTime.Now.ToString("MMM") + "-" + DateTime.Now.AddDays(-1).Day;
                    break;
                case "SEARCH":
                    break;
                default:
                    break;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("TeamName", typeof(string));
            table.Columns.Add(amountHeader, typeof(decimal));
            table.Columns.Add("AIG", typeof(decimal)); //D
            table.Columns.Add("AMERICO", typeof(decimal)); //E
            table.Columns.Add("MOO", typeof(decimal)); //F
            table.Columns.Add("GLOBAL", typeof(decimal)); //G
            table.Columns.Add("ROYAL", typeof(decimal)); //H

            foreach(var list in reports)
            {
                var team = table.Select("TeamName ='" + list.TeamName + "'");
                if( team.Length > 0)
                {
                    decimal getAmount = String.IsNullOrEmpty(table.Rows[table.Rows.Count - 1][2].ToString()) ? 0 : Convert.ToDecimal(table.Rows[table.Rows.Count - 1][2]);
                    decimal totalAmount = getAmount + list.Amount;
                    table.Rows[table.Rows.Count - 1][2] = totalAmount;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
                else
                {
                    table.Rows.Add();
                    table.Rows[table.Rows.Count - 1]["Rank"] = list.Rank;
                    table.Rows[table.Rows.Count - 1]["TeamName"] = list.TeamName;
                    table.Rows[table.Rows.Count - 1][2] = list.Amount;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
            }
            table.DefaultView.Sort = table.Columns[2].ColumnName + " desc";
            table = table.DefaultView.ToTable();
            int count = 0;
            foreach(DataRow row in table.Rows)
            {
                row[0] = ++count;
            }

            MemoryStream memoryStream = new MemoryStream();
            using(var package = new ExcelPackage(memoryStream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Generated " + ReportType + " Report");
                foreach(DataColumn col in table.Columns)
                {
                    string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal) + 1;
                    worksheet.Cells[columnIndex].Value = col.ColumnName;
                }
                decimal total = 0;
                decimal aigtotal = 0;
                decimal americototal = 0;
                decimal globaltotal = 0;
                decimal moototal = 0;
                decimal royaltotal = 0;

                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn col in table.Columns)
                    {
                        int rowIndex = table.Rows.IndexOf(row) + 2;
                        string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal);
                        if (columnIndex == "C" || columnIndex == "D" || columnIndex == "E" || columnIndex == "F" || columnIndex == "G" || columnIndex == "H")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Style.Numberformat.Format = "$###,###,##0.00";
                            worksheet.Cells[columnIndex + rowIndex].Value = string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                            switch (columnIndex)
                            {
                                case "C":
                                    total += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "D":
                                    aigtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "E":
                                    americototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "F":
                                    moototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "G":
                                    globaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "H":
                                    royaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                            }

                        }
                        else if( columnIndex == "A")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = Convert.ToInt32(row[col]);
                        }
                        else
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = row[col].ToString();
                        }
                    }
                }
                worksheet.Cells["B" + (table.Rows.Count + 3)].Value = "TOTAL";
                worksheet.Cells["C" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["C" + (table.Rows.Count + 3)].Value = total;
                worksheet.Cells["D" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["D" + (table.Rows.Count + 3)].Value = aigtotal;
                worksheet.Cells["E" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["E" + (table.Rows.Count + 3)].Value = americototal;
                worksheet.Cells["F" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["F" + (table.Rows.Count + 3)].Value = moototal;
                worksheet.Cells["G" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["G" + (table.Rows.Count + 3)].Value = globaltotal;
                worksheet.Cells["H" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["H" + (table.Rows.Count + 3)].Value = royaltotal;
                package.Save();
                return memoryStream.ToArray();
            }
        }
        internal static byte[] GenerateStreamExcelReport(List<Commissions> commissions, string ReportType, DateTime date1 = new DateTime(), DateTime date2 = new DateTime())
        {
            List<IndividualReport> IndiReport = GetReport(commissions);
            string amountHeader = "";
            switch (ReportType)
            {
                case "DAILY":
                    amountHeader = DateTime.Now.ToString("MM/dd/yyyy");
                    break;
                case "WEEKLY":
                    amountHeader = FirstDayOfWeek(DateTime.Now).ToString("MMM") + " " + FirstDayOfWeek(DateTime.Now).Day + " to " + LastDayOfWeek(DateTime.Now).Day + " " + LastDayOfWeek(DateTime.Now).Year;
                    break;
                case "MTD":
                    amountHeader = FirstDayOfMonth(DateTime.Now).ToString("MMM") + " " + FirstDayOfMonth(DateTime.Now).Year;
                    break;
                case "YTD":
                    amountHeader = "Jan to " + DateTime.Now.ToString("MMM") + "-" + DateTime.Now.AddDays(-1).Day;
                    break;
                case "SEARCH":

                    if( date1.Date == date2.Date)
                    {

                        amountHeader = date1.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        if( date1.Year == date2.Year)
                        {
                            if( date1.Month == date2.Month)
                            {
                                amountHeader = date1.ToString("MMM") + " " + date1.Day + " to " + date2.Day + " " + date2.Year;
                            }
                            else
                            {
                                amountHeader = date1.ToString("MMM") + " " + date1.Day + " to " + date2.ToString("MMM") + " " + date2.Day + " " + date2.Year;
                            }
                        }
                        else
                        {
                            amountHeader = date1.ToString("MMM") + " " + date1.Day + " " + date1.Year  + " to " + date2.ToString("MMM") + " " + date2.Day + " " + date2.Year;
                        }
                    }

                    break;
                default:
                    IndiReport = new List<IndividualReport>();
                    break;
            }

            //CONVERT IndiReportObject to DataTable
            DataTable table = new DataTable();
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("WritingAgent");
            table.Columns.Add(amountHeader, typeof(decimal));
            table.Columns.Add("Upline1", typeof(string));
            table.Columns.Add("Upline2", typeof(string));
            table.Columns.Add("Upline3", typeof(string));
            table.Columns.Add("Upline4", typeof(string));
            table.Columns.Add("Upline5", typeof(string));
            table.Columns.Add("Upline6", typeof(string));
            table.Columns.Add("Upline7", typeof(string));
            table.Columns.Add("Upline8", typeof(string));
            table.Columns.Add("Upline9", typeof(string));
            table.Columns.Add("Upline10", typeof(string));
            
            //CARRIER CONSTANT DATA NEED TO UPDATE ONCE NEW CARRIER ADDED
            table.Columns.Add("AIG", typeof(decimal)); //N
            table.Columns.Add("AMERICO", typeof(decimal)); //O
            table.Columns.Add("MOO", typeof(decimal)); //P
            table.Columns.Add("GLOBAL", typeof(decimal)); //Q
            table.Columns.Add("ROYAL", typeof(decimal)); //R
            table.Columns.Add("TRANS", typeof(decimal)); //S
            table.Columns.Add("ATHENE", typeof(decimal)); //T
            table.Columns.Add("AMAM", typeof(decimal)); //U
            table.Columns.Add("PROSPERITY", typeof(decimal)); //V
            table.Columns.Add("RSHIELD", typeof(decimal)); //W

            foreach (var list in IndiReport)
            {
                var agentCommission = table.Select("WritingAgent ='" + list.WritingAgent + "'");
                if (agentCommission.Length > 0)
                {
                    decimal getAmount = String.IsNullOrEmpty(table.Rows[table.Rows.Count - 1][2].ToString()) ? 0 : Convert.ToDecimal(table.Rows[table.Rows.Count - 1][2]);
                    decimal totalAmount = getAmount + list.Amount;
                    table.Rows[table.Rows.Count - 1][2] = totalAmount;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
                else
                {
                    //NEWW DATA
                    table.Rows.Add();
                    table.Rows[table.Rows.Count - 1]["Rank"] = 0;
                    table.Rows[table.Rows.Count - 1]["WritingAgent"] = list.WritingAgent;
                    table.Rows[table.Rows.Count - 1][2] = list.Amount;
                    table.Rows[table.Rows.Count - 1]["Upline1"] = list.Upline1;
                    table.Rows[table.Rows.Count - 1]["Upline2"] = list.Upline2;
                    table.Rows[table.Rows.Count - 1]["Upline3"] = list.Upline3;
                    table.Rows[table.Rows.Count - 1]["Upline4"] = list.Upline4;
                    table.Rows[table.Rows.Count - 1]["Upline5"] = list.Upline5;
                    table.Rows[table.Rows.Count - 1]["Upline6"] = list.Upline6;
                    table.Rows[table.Rows.Count - 1]["Upline7"] = list.Upline7;
                    table.Rows[table.Rows.Count - 1]["Upline8"] = list.Upline8;
                    table.Rows[table.Rows.Count - 1]["Upline9"] = list.Upline9;
                    table.Rows[table.Rows.Count - 1]["Upline10"] = list.Upline10;
                    table.Rows[table.Rows.Count - 1][list.Carrier] = list.Amount;
                }
            }
            //Sort Commissions Amount 
            table.DefaultView.Sort = table.Columns[2].ColumnName + " desc";
            table = table.DefaultView.ToTable();
            //Add Ranking
            int count = 0;
            foreach (DataRow row in table.Rows)
            {
                row[0] = ++count;
            }
            //WRITE EXCEL FILE IN MEMORY STREAM
            MemoryStream newFile = new MemoryStream();
            using (var package = new ExcelPackage(newFile))
            {
                var worksheet = package.Workbook.Worksheets.Add("Generated " + ReportType + " Report");
                //Column
                foreach (DataColumn col in table.Columns)
                {
                    string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal) + 1;
                    worksheet.Cells[columnIndex].Value = col.ColumnName;
                }

                decimal total = 0;
                decimal aigtotal = 0;
                decimal americototal = 0;
                decimal globaltotal = 0;
                decimal moototal = 0;
                decimal royaltotal = 0;
                decimal transtotal = 0;
                decimal amamtotal = 0;
                decimal athenetotal = 0;
                decimal prospertotal = 0;
                decimal rshieldtotal = 0;


                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        int rowIndex = table.Rows.IndexOf(row) + 2;
                        string columnIndex = ReportFunctions.GenerateColumnText(col.Ordinal);
                        if (columnIndex == "C" || columnIndex == "N" || columnIndex == "O" || columnIndex == "P" || columnIndex == "Q" || columnIndex == "R" || columnIndex == "S" || columnIndex == "T" || columnIndex == "U" || columnIndex == "V" || columnIndex == "W")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Style.Numberformat.Format = "$###,###,##0.00";
                            worksheet.Cells[columnIndex + rowIndex].Value = string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                            switch (columnIndex)
                            {
                                case "C":
                                    total += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "N":
                                    aigtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "O":
                                    americototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "P":
                                    moototal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "Q":
                                    globaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "R":
                                    royaltotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "S":
                                    transtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "T":
                                    athenetotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "U":
                                    amamtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "V":
                                    prospertotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                                case "W":
                                    rshieldtotal += string.IsNullOrEmpty(row[col].ToString()) ? 0 : Convert.ToDecimal(row[col]);
                                    break;
                            }
                        }
                        else if (columnIndex == "A")
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = Convert.ToInt32(row[col]);
                        }
                        else
                        {
                            worksheet.Cells[columnIndex + rowIndex].Value = row[col].ToString();
                        }
                        //Tsest
                    }
                }

                //DISPLAY TOTAL AMOUNT 
                worksheet.Cells["B" + (table.Rows.Count + 3)].Value = "TOTAL";
                worksheet.Cells["C" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["C" + (table.Rows.Count + 3)].Value = total;
                worksheet.Cells["N" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["N" + (table.Rows.Count + 3)].Value = aigtotal;
                worksheet.Cells["O" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["O" + (table.Rows.Count + 3)].Value = americototal;
                worksheet.Cells["P" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["P" + (table.Rows.Count + 3)].Value = moototal;
                worksheet.Cells["Q" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["Q" + (table.Rows.Count + 3)].Value = globaltotal;
                worksheet.Cells["R" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["R" + (table.Rows.Count + 3)].Value = royaltotal;
                worksheet.Cells["S" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["S" + (table.Rows.Count + 3)].Value = transtotal;
                worksheet.Cells["T" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["T" + (table.Rows.Count + 3)].Value = athenetotal;
                worksheet.Cells["U" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["U" + (table.Rows.Count + 3)].Value = amamtotal;
                worksheet.Cells["V" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["V" + (table.Rows.Count + 3)].Value = prospertotal;
                worksheet.Cells["W" + (table.Rows.Count + 3)].Style.Numberformat.Format = "$###,###,##0.00";
                worksheet.Cells["W" + (table.Rows.Count + 3)].Value = rshieldtotal;
                package.Save();
                return newFile.ToArray();
            }

        }

    }
}
