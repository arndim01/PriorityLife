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
    public class Team_UpdateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Team_UpdateModel(UserManager<IdentityUser> userManager)
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
        public void OnGet(int id, string returnUrl)
        {
            LoadPage(id, returnUrl);
        }

        public PageResult LoadPage(int id, string returnUrl)
        {
            // select a record by primary key(s)
            PriorityLifeAPI.BusinessObject.Team objTeam = PriorityLifeAPI.BusinessObject.Team.SelectByPrimaryKey(id);

            // create the model used by the partial page
            AddEditTeamPartialModel model = new AddEditTeamPartialModel();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Update;
            model.ReturnUrl = returnUrl;
            model.Team = objTeam;

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
                    Team.UpdatedBy = username;
                    Team.UpdatedDate = DateTime.Now;
                    // update record
                    TeamFunctions.AddOrEdit(Team, CrudOperation.Update);
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
            return LoadPage(Team.Id, ReturnUrl);
        }
    }
}