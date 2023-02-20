using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.Models;

namespace PriorityLifeWebInterface.Pages
{
    [Authorize]
    public class Report_ListModel : PageModel
    {
        public IActionResult OnPostCreateDocument()
        {
            List<Commissions> objCommissionsCol = Commissions.SelectAll();
            //Write Excel
            try
            {
                byte[] fileContents = ReportFunctions.GenerateStreamExcelReport(objCommissionsCol, "MTD");

                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }
                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "test.xlsx"
                );
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Gets the list of data for use by the jqgrid plug-in
        /// </summary>
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {

            List<PriorityLifeAPI.Models.IndividualReport> reports = Commissions.GetCommissionsReport();
            List<Commissions> objCommissionsCol = Commissions.SelectAll();
            List<IndividualReport> IndiReport = new List<IndividualReport>();
            int count = 0;
            foreach( var com in objCommissionsCol)
            {
                var carrier = Carriers.SelectByPrimaryKey(com.CarrierId);
                var salesperson = PriorityLifeAPI.BusinessObject.Salesperson.SelectByPrimaryKey(com.SalespersonId);


                if( carrier != null && salesperson != null)
                {
                    var agentCom = IndiReport.Where(i => i.CommissionsDate.Year == com.CommissionDate.Year && i.CommissionsDate.Month == com.CommissionDate.Month && i.CommissionsDate.Day == com.CommissionDate.Day &&
                    i.WritingAgent == salesperson.FirstName + " " + salesperson.LastName[0] && i.Carrier == carrier.ShortName).FirstOrDefault();
                    if ( agentCom != null )
                    {
                        agentCom.Amount += com.Amount;
                    }
                    else
                    {
                        IndiReport.Add(new IndividualReport
                        {
                            Id = ++count,
                            WritingAgent = salesperson.FirstName + " " + salesperson.LastName[0],
                            CommissionsDate = com.CommissionDate,
                            Upline1 = "",
                            Upline2 = "",
                            Upline3 = "",
                            Upline4 = "",
                            Upline5 = "",
                            Upline6 = "",
                            Upline7 = "",
                            Upline8 = "",
                            Upline9 = "",
                            Upline10 = "",
                            Carrier = carrier.ShortName,
                            Amount = com.Amount
                        });
                    }
                }

                
            }

            IndiReport = IndiReport.OrderBy(c => c.WritingAgent).ToList();


            int totalRecords = IndiReport.Count;
            int startRowIndex = ((_page * rows) - rows);
            List<IndividualReport> IndiReportFiltered = ReportFunctions.SortReport(IndiReport, sidx, sord, startRowIndex, rows);

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
                            indiReport.CommissionsDate.ToString("d"),
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
                            indiReport.Carrier.ToString(),
                            indiReport.Amount.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);
        }
    }
}