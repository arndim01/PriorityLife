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
    public class Salesperson_AddModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Salesperson_AddModel(UserManager<IdentityUser> userManager)
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
        public void OnGet(string returnUrl)
        {
            LoadPage(returnUrl);
        }

        private PageResult LoadPage(string returnUrl)
        {
            // create the model used by the partial page
            AddEditSalespersonPartialModel model = new AddEditSalespersonPartialModel();
            model.Operation = CrudOperation.Add;
            model.ReturnUrl = returnUrl;
            model.Salesperson = new PriorityLifeAPI.BusinessObject.Salesperson()
            {
                Initials = "initials",
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
                    // add new record
                    // automate update
                    if( PriorityLifeAPI.BusinessObject.Salesperson.SalespersonExist(Salesperson.LastName, Salesperson.FirstName, Salesperson.LastName + " " + Salesperson.FirstName[0]))
                    {
                        ModelState.AddModelError("", "Salesperson already exist.");
                        return LoadPage(ReturnUrl);
                    }


                    string username = _userManager.GetUserName(HttpContext.User);
                    Salesperson.Initials = Salesperson.LastName + " " + Salesperson.FirstName[0];
                    Salesperson.AddedBy = username;
                    Salesperson.AddedDate = DateTime.Now;

                    SalespersonFunctions.AddOrEdit(Salesperson, CrudOperation.Add);
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