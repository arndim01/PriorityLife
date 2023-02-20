using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.Domain;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.PartialModels;

namespace PriorityLifeWebInterface.Pages.Teams
{
    [Authorize]
    public class Team_AddModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Team_AddModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Team Team { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public AddEditTeamPartialModel PartialModel { get; set; }

        /// <summary>
        /// Initial handler the razor page encounters.
        /// </summary>
        public void OnGet(string returnUrl)
        {
            LoadPage(returnUrl);
        }

        private PageResult LoadPage(string returnUrl)
        {
            // create the model used by the partial page
            AddEditTeamPartialModel model = new AddEditTeamPartialModel();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Add;
            model.ReturnUrl = returnUrl;
            model.Team = new PriorityLifeAPI.BusinessObject.Team()
            {
                AddedBy = "user",
                AddedDate = DateTime.Now
            };
            // assign values to the model used by this page
            PartialModel = model;

            // assign the return url
            ReturnUrl = returnUrl;

            return Page();
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (PriorityLifeAPI.BusinessObject.Team.CheckTeamNameExist(Team.TeamName))
                    {
                        ModelState.AddModelError("", "Team name already exist.");
                        return LoadPage(ReturnUrl);
                    }

                    string username = _userManager.GetUserName(HttpContext.User);
                    Team.AddedBy = username;
                    Team.AddedDate = DateTime.Now;

                    TeamFunctions.AddOrEdit(Team, CrudOperation.Add);
                    //Add manager as member.
                    var teamR = PriorityLifeAPI.BusinessObject.Team.GetTeamByTeamName(Team.TeamName);
                    if( teamR != null)
                    {
                        if( !PriorityLifeAPI.BusinessObject.TeamDetails.CheckTeamMemberExistInTeamById(Team.TeamManager, teamR.Id))
                        {

                            var teamDetail = new PriorityLifeAPI.BusinessObject.TeamDetails()
                            {
                                TeamId = teamR.Id,
                                TeamMemberId = Team.TeamManager,
                                AddedBy = username,
                                AddedDate = DateTime.Now
                            };


                            TeamDetailsFunctions.AddOrEdit(teamDetail, CrudOperation.Add);
                        }
                    }


                    return RedirectToPage(ReturnUrl);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        ModelState.AddModelError("", ex.InnerException.Message);
                    else
                        ModelState.AddModelError("", ex.Message);
                }
            }

            // if we got this far, something failed, redisplay form
            return LoadPage(ReturnUrl);
        }
    }
}