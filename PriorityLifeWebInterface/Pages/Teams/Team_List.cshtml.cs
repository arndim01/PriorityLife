using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;

namespace PriorityLifeWebInterface.Pages.Teams
{
    [Authorize]
    public class Team_ListModel : PageModel
    {
        /// <summary>
         /// Handler, deletes a record.
         /// </summary>
         public IActionResult OnGetRemove(int id)
         {
            try
            {
                Team.Delete(id);
                return new JsonResult(true);
            }
            catch
            {
                return new BadRequestObjectResult("Remove the members first before deleting the team.");
            }
         }

        /// <summary>
        /// Handler, deletes a record.
        /// </summary>
        public IActionResult OnGetRemoveTeamDetail(int id)
        {
            TeamDetails.Delete(id);
            return new JsonResult(true);
        }


        /// <summary>
        /// Gets the list of data for use by the jqgrid plug-in
        /// </summary>
        public IActionResult OnGetGridData(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
         {


             int totalRecords = Team.GetRecordCount();
             int startRowIndex = ((_page * rows) - rows);
             List<Team> objTeamCol = Team.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
             int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

             if (objTeamCol is null)
                 return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

             var jsonData = new
             {
                 total = totalPages,
                 _page,
                 records = totalRecords,
                 rows = (
                     from objTeam in objTeamCol
                     select new
                     {
                         id = objTeam.Id,
                         teamname = objTeam.TeamName,
                         active = objTeam.Active
                     }).ToArray()
             };

             return new JsonResult(jsonData);
         }

        public IActionResult OnGetGridDataById(int Id, string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            int totalRecords = TeamDetails.GetRecordCountByTeamId(Id);
            int startRowIndex = ((_page * rows) - rows);
            List<TeamDetails> objTeamDetailsCol = TeamDetails.SelectSkipAndTakeByTeamId(rows, startRowIndex, sidx + " " + sord, Id);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);



            if (objTeamDetailsCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objTeamDetails in objTeamDetailsCol
                    select new
                    {
                        id = objTeamDetails.Id,
                        team_member  = objTeamDetails.TeamMemberIdNavigation.FirstName + " " + objTeamDetails.TeamMemberIdNavigation.LastName,
                        position =  objTeamDetails.TeamIdNavigation.TeamManager == objTeamDetails.TeamMemberId ? "Manager": "Member",

                    }).ToArray()
            };

            return new JsonResult(jsonData);
        }

        public IActionResult OnGetGridMembers(string sidx, string sord, int _page, int rows, int Id, bool isforJqGrid = true)
        {

            List<TeamDetails> objTeamDetailsCol = TeamDetails.SelectTeamDetailsCollectionByTeamId(Id);

            if (objTeamDetailsCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");



            var jsonData = new
            {
                rows = (
                    from objTeamDetails in objTeamDetailsCol
                    select new
                    {
                        id = objTeamDetails.Id,
                        cell = new string[] {
                             objTeamDetails.Id.ToString(),
                             objTeamDetails.TeamMemberId.ToString(),
                             objTeamDetails.Activate.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);

        }
        public IActionResult OnGetGridDataTeamDetails(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            int totalRecords = TeamDetails.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);
            List<TeamDetails> objTeamDetailsCol = TeamDetails.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objTeamDetailsCol is null)
                return new JsonResult("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objTeamDetails in objTeamDetailsCol
                    select new
                    {
                        id = objTeamDetails.Id,
                        cell = new string[] {
                             objTeamDetails.Id.ToString(),
                             objTeamDetails.TeamIdNavigation.TeamName.ToString(),
                             objTeamDetails.TeamMemberIdNavigation.FirstName + " " + objTeamDetails.TeamMemberIdNavigation.LastName[0],
                             objTeamDetails.Activate.ToString()
                        }
                    }).ToArray()
            };

            return new JsonResult(jsonData);
        }
    }
}