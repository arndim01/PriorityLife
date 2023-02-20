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
    public class TeamDetails_UpdateModel : PageModel
    {
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.TeamDetails TeamDetails { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public AddEditTeamDetailsPartialModel PartialModel { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        public TeamDetails_UpdateModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// Initial handler the razor page encounters.
        /// </summary>
        public void OnGet(int id, string returnUrl)
        {
            LoadPage(id, returnUrl);
        }

        public PageResult LoadPage(int id, string returnUrl)
        {
            // select a record by primary key(s)
            PriorityLifeAPI.BusinessObject.TeamDetails objTeamDetails = PriorityLifeAPI.BusinessObject.TeamDetails.SelectByPrimaryKey(id);

            // create the model used by the partial page
            AddEditTeamDetailsPartialModel model = new AddEditTeamDetailsPartialModel();
            model.TeamDropDownListData = Team.SelectTeamDropDownListData();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Update;
            model.ReturnUrl = returnUrl;
            model.TeamDetails = objTeamDetails;

            // assign values to the model used by this page
            PartialModel = model;

            // assign the return url
            ReturnUrl = returnUrl;

            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string username = _userManager.GetUserName(HttpContext.User);
                    TeamDetails.UpdatedBy = username;
                    TeamDetails.UpdatedDate = DateTime.Now;
                    // update record
                    TeamDetailsFunctions.AddOrEdit(TeamDetails, CrudOperation.Update);
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
            return LoadPage(TeamDetails.Id, ReturnUrl);
        }
    }
}