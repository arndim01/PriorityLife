using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.PartialModels;

namespace PriorityLifeWebInterface.Pages.Teams
{
    public class TeamDetails_AddModel : PageModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.TeamDetails TeamDetails { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public AddEditTeamDetailsPartialModel PartialModel { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        public TeamDetails_AddModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
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
            AddEditTeamDetailsPartialModel model = new AddEditTeamDetailsPartialModel();
            model.TeamDropDownListData = Team.SelectTeamDropDownListData();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Add;
            model.ReturnUrl = returnUrl;
            model.TeamDetails = new PriorityLifeAPI.BusinessObject.TeamDetails()
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
                    if( PriorityLifeAPI.BusinessObject.TeamDetails.CheckTeamMemberExistInTeamById(TeamDetails.TeamMemberId, TeamDetails.TeamId))
                    {
                        ModelState.AddModelError("", "Team Member already exist in the team.");
                        return LoadPage(ReturnUrl);
                    }


                    string username = _userManager.GetUserName(HttpContext.User);
                    // add new record


                    TeamDetails.AddedBy = username;
                    TeamDetails.AddedDate = DateTime.Now;
                    TeamDetailsFunctions.AddOrEdit(TeamDetails, CrudOperation.Add);
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