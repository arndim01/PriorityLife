using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.Models;

namespace PriorityLifeWebInterface.Pages.Report
{
    public class Individual_Advance_ReportModel : PageModel
    {
        [BindProperty]
        public AdvancedFilter AdvancedFilter { get; set; } = new AdvancedFilter();

        public IActionResult OnGetCreateDocument(string startDate, string endDate)
        {
            //Write Excel
            try
            {
                string[] startDateSplit = startDate.Split('-');
                string[] endDateSplit = endDate.Split('-');
                DateTime start = new DateTime(Convert.ToInt32(startDateSplit[0]), Convert.ToInt32(startDateSplit[1]), Convert.ToInt32(startDateSplit[2]));
                DateTime end = new DateTime(Convert.ToInt32(endDateSplit[0]), Convert.ToInt32(endDateSplit[1]), Convert.ToInt32(endDateSplit[2]));
                List<Commissions> objCommissionsCol;
                if (start.Date == end.Date)
                {
                    objCommissionsCol = Commissions.GetReportByDate(start);

                }
                else
                {
                    objCommissionsCol = Commissions.GetIPReportByRange(start, end);
                }

                byte[] fileContents = ReportFunctions.GenerateStreamExcelReport(objCommissionsCol, "SEARCH", start, end);

                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "IndividualReport.xlsx"
                );
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        
        public IActionResult OnGetGridDataTest(string startDate, string endDate, int _page, int rows)
        {
            string[] startDateSplit = startDate.Split('-');
            string[] endDateSplit = endDate.Split('-');
            DateTime start = new DateTime(Convert.ToInt32(startDateSplit[0]), Convert.ToInt32(startDateSplit[1]), Convert.ToInt32(startDateSplit[2]));
            DateTime end = new DateTime(Convert.ToInt32(endDateSplit[0]), Convert.ToInt32(endDateSplit[1]), Convert.ToInt32(endDateSplit[2]));
            List<Commissions> objCommissionsCol;
            if ( start.Date == end.Date)
            {
                objCommissionsCol = Commissions.GetReportByDate(start);

            }
            else
            {
                objCommissionsCol = Commissions.GetIPReportByRange(start, end);
            }
          
            var IndiReport = IndividualReportFunctions.GetReport(objCommissionsCol);
            int totalRecords = IndiReport.Count;
            int startRowIndex = ((_page * rows) - rows);
            var IndiReportFiltered = IndiReport.Skip(startRowIndex).Take(rows).ToList();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (objCommissionsCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                   from indiReport in IndiReportFiltered
                   select new
                   {
                       id = indiReport.Id,
                       cell = new string[] {
                            indiReport.Id.ToString(),
                            indiReport.WritingAgent.ToString(),
                            indiReport.Amount.ToString(),
                            indiReport.Upline1.ToString(),
                            indiReport.Upline2.ToString(),
                            indiReport.Upline3.ToString(),
                            indiReport.Upline4.ToString(),
                            indiReport.Upline5.ToString(),
                            indiReport.Upline6.ToString(),
                            indiReport.Upline7.ToString(),
                            indiReport.Upline8.ToString(),
                            indiReport.Upline9.ToString(),
                            indiReport.Upline10.ToString(),
                            indiReport.AIG.ToString(),
                            indiReport.AMERICO.ToString(),
                            indiReport.MOO.ToString(),
                            indiReport.GLOBAL.ToString(),
                            indiReport.ROYAL.ToString(),
                            indiReport.TRANS.ToString(),
                            indiReport.ATHENE.ToString(),
                            indiReport.AMAM.ToString(),
                            indiReport.PROSPERITY.ToString(),
                            indiReport.RSHIELD.ToString()
                       }
                   }).ToArray()
            };

            return new JsonResult(jsonData);
        }
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            List<Commissions> objCommissionsCol = Commissions.GetReportByDate(DateTime.Now);
            // Commissions.DeleteLater(1);
            var IndiReport = IndividualReportFunctions.GetReport(objCommissionsCol);
            int totalRecords = IndiReport.Count;
            int startRowIndex = ((_page * rows) - rows);
            var IndiReportFiltered = IndividualReportFunctions.SortReport(IndiReport, sidx, sord, startRowIndex, rows);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (objCommissionsCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from indiReport in IndiReportFiltered
                    select new
                    {
                        id = indiReport.Id,
                        cell = new string[] {
                             indiReport.Id.ToString(),
                            indiReport.WritingAgent.ToString(),
                            indiReport.Amount.ToString(),
                            indiReport.Upline1.ToString(),
                            indiReport.Upline2.ToString(),
                            indiReport.Upline3.ToString(),
                            indiReport.Upline4.ToString(),
                            indiReport.Upline5.ToString(),
                            indiReport.Upline6.ToString(),
                            indiReport.Upline7.ToString(),
                            indiReport.Upline8.ToString(),
                            indiReport.Upline9.ToString(),
                            indiReport.Upline10.ToString(),
                            indiReport.AIG.ToString(),
                            indiReport.AMERICO.ToString(),
                            indiReport.MOO.ToString(),
                            indiReport.GLOBAL.ToString(),
                            indiReport.ROYAL.ToString(),
                            indiReport.TRANS.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);

        }



    }
}