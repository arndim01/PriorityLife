using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.Domain;
using Newtonsoft.Json;
using PriorityLifeWebInterface.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace PriorityLifeWebInterface.Pages.Hierarchy
{
    [Authorize]
    public class Hierarchy_ListModel : PageModel
    {
        /// <summary>
        /// Handler, deletes a record.
        /// </summary>
        public IActionResult OnGetRemove(int id)
        {
            PriorityLifeAPI.BusinessObject.Hierarchy.Delete(id);
            return new JsonResult(true);
        }
        /// <summary>
        /// Gets the list of data for use by the jqgrid plug-in
        /// </summary>
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {

            string s = null;

            int totalRecords = PriorityLifeAPI.BusinessObject.Hierarchy.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);
            List<PriorityLifeAPI.BusinessObject.Hierarchy> objHierarchyCol = PriorityLifeAPI.BusinessObject.Hierarchy.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objHierarchyCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objHierarchy in objHierarchyCol
                    select new
                    {
                        id = objHierarchy.Id,
                        cell = new string[] {   
                             objHierarchy.SalesPersonIdNavigation.FirstName + " " + objHierarchy.SalesPersonIdNavigation.LastName[0],
                             objHierarchy.Upline1Id.HasValue ? objHierarchy.Upline1IdNavigation.FirstName[0].ToString() + objHierarchy.Upline1IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline2Id.HasValue ? objHierarchy.Upline2IdNavigation.FirstName[0].ToString() + objHierarchy.Upline2IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline3Id.HasValue ? objHierarchy.Upline3IdNavigation.FirstName[0].ToString() + objHierarchy.Upline3IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline4Id.HasValue ? objHierarchy.Upline4IdNavigation.FirstName[0].ToString() + objHierarchy.Upline4IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline5Id.HasValue ? objHierarchy.Upline5IdNavigation.FirstName[0].ToString() + objHierarchy.Upline5IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline6Id.HasValue ? objHierarchy.Upline6IdNavigation.FirstName[0].ToString() + objHierarchy.Upline6IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline7Id.HasValue ? objHierarchy.Upline7IdNavigation.FirstName[0].ToString() + objHierarchy.Upline7IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline8Id.HasValue ? objHierarchy.Upline8IdNavigation.FirstName[0].ToString() + objHierarchy.Upline8IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline9Id.HasValue ? objHierarchy.Upline9IdNavigation.FirstName[0].ToString() + objHierarchy.Upline9IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Upline10Id.HasValue ? objHierarchy.Upline10IdNavigation.FirstName[0].ToString() + objHierarchy.Upline10IdNavigation.LastName[0].ToString() : "",
                             objHierarchy.Active.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);
        }
    }
}