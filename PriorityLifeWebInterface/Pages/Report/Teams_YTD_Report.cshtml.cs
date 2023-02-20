﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Helper;

namespace PriorityLifeWebInterface.Pages.Report
{
    public class Teams_YTD_ReportModel : PageModel
    {
        public IActionResult OnPostCreateDocument()
        {
            //Write Excel
            try
            {
                List<PriorityLifeAPI.Models.TeamReport> objCommissionsCol = Commissions.GetTeamsReportByDateRange(new DateTime(DateTime.Now.Year, 1, 1), DateTime.Now.AddDays(-1));
                byte[] fileContents = ReportFunctions.GenerateStreamExcelReportTeam(objCommissionsCol, "YTD");

                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "YTD_TeamReport.xlsx"
                );
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            List<PriorityLifeAPI.Models.TeamReport> reports = Commissions.GetTeamsReportByDateRange(new DateTime(DateTime.Now.Year, 1, 1), DateTime.Now.AddDays(-1));
            var CusReport = TeamReportFunctions.GetReport(reports);
            int totalRecords = reports.Count;
            int startRowIndex = ((_page * rows) - rows);
            var reportFiltered = TeamReportFunctions.SortReport(CusReport, sidx, sord, startRowIndex, rows);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (reports is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from report in reportFiltered
                    select new
                    {
                        id = report.TeamName,
                        cell = new string[] {
                            report.Id.ToString(),
                            report.TeamName.ToString(),
                            report.Amount.ToString(),
                            report.AIG.ToString(),
                            report.AMERICO.ToString(),
                            report.MOO.ToString(),
                            report.GLOBAL.ToString(),
                            report.ROYAL.ToString(),
                            report.TRANS.ToString(),
                            report.ATHENE.ToString(),
                            report.AMAM.ToString(),
                            report.PROSPERITY.ToString(),
                            report.RSHIELD.ToString()
                        }
                    }).ToArray()
            };
            return new JsonResult(jsonData);

        }
    }
}