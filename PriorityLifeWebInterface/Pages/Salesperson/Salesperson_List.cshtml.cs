using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.Domain;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace PriorityLifeWebInterface.Pages.Salesperson
{
    [Authorize]
    public class Salesperson_ListModel : PageModel
    {
        public IActionResult OnGetRemove(int id)
        {
            PriorityLifeAPI.BusinessObject.Salesperson.Delete(id);
            return new JsonResult(true);
        }

        /// <summary>
        /// Gets the list of data for use by the jqgrid plug-in
        /// </summary>
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            int totalRecords = PriorityLifeAPI.BusinessObject.Salesperson.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);
            List<PriorityLifeAPI.BusinessObject.Salesperson> objSalespersonCol = PriorityLifeAPI.BusinessObject.Salesperson.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objSalespersonCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objSalesperson in objSalespersonCol
                    select new
                    {
                        id = objSalesperson.Id,
                        cell = new string[] {
                             objSalesperson.FirstName,
                             objSalesperson.MiddleName,
                             objSalesperson.LastName,
                             objSalesperson.Initials,
                             objSalesperson.Email,
                             objSalesperson.Phone,
                             objSalesperson.Active.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);
        }
    }
}