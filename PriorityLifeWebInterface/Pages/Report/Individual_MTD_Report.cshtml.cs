using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.Models;

namespace PriorityLifeWebInterface.Pages.Report
{
    [Authorize]
    public class Individual_MTD_ReportModel : PageModel
    {
        public IActionResult OnPostCreateDocument()
        {
            //Write Excel
            try
            {
                List<Commissions> objCommissionsCol = Commissions.GetIPReportByRange(ReportFunctions.FirstDayOfMonth(DateTime.Now), DateTime.Now.AddDays(-1));
                byte[] fileContents = ReportFunctions.GenerateStreamExcelReport(objCommissionsCol, "MTD");

                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "MTD_IndividualReport.xlsx"
                );
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {

            List<Commissions> objCommissionsCol = Commissions.GetIPReportByRange(ReportFunctions.FirstDayOfMonth(DateTime.Now), DateTime.Now.AddDays(-1));
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
    }
}