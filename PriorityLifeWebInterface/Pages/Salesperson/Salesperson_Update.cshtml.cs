using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.Domain;
using PriorityLifeWebInterface.PartialModels;

namespace PriorityLifeWebInterface.Pages.Salesperson
{
    [Authorize]
    public class Salesperson_UpdateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Salesperson_UpdateModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Salesperson Salesperson { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public AddEditSalespersonPartialModel PartialModel { get; set; }

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
            PriorityLifeAPI.BusinessObject.Salesperson objSalesperson = PriorityLifeAPI.BusinessObject.Salesperson.SelectByPrimaryKey(id);

            // create the model used by the partial page
            AddEditSalespersonPartialModel model = new AddEditSalespersonPartialModel();
            model.Operation = CrudOperation.Update;
            model.ReturnUrl = returnUrl;
            model.Salesperson = objSalesperson;
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
                    // update record

                    // automate update
                    string username = _userManager.GetUserName(HttpContext.User);
                    string Initials = Salesperson.LastName + " " + Salesperson.FirstName[0];

                    // update initials when firstname and lastname updated
                    if( Initials !=  Salesperson.Initials)
                    {
                        Salesperson.Initials = Salesperson.LastName + " " + Salesperson.FirstName[0];
                    }
                    Salesperson.UpdatedBy = username;
                    Salesperson.UpdatedDate = DateTime.Now;

                    SalespersonFunctions.AddOrEdit(Salesperson, CrudOperation.Update);
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
            return LoadPage(Salesperson.Id, ReturnUrl);
        }
    }
}