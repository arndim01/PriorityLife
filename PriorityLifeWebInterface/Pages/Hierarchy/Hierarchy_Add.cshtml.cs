using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeAPI.Domain;
using PriorityLifeAPI.BusinessObject;
using Newtonsoft.Json;
using PriorityLifeWebInterface.PartialModels;
using PriorityLifeWebInterface.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PriorityLifeWebInterface.Pages.Hierarchy
{
 
    [Authorize]
    public class Hierarchy_AddModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Hierarchy_AddModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public PriorityLifeAPI.BusinessObject.Hierarchy Hierarchy { get; set; }

            [BindProperty]
            public string ReturnUrl { get; set; }

        public AddEditHierarchyPartialModel PartialModel { get; set; }

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
            AddEditHierarchyPartialModel model = new AddEditHierarchyPartialModel();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Add;
            model.ReturnUrl = returnUrl;
            model.Hierarchy = new PriorityLifeAPI.BusinessObject.Hierarchy()
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


                    string username = _userManager.GetUserName(HttpContext.User);
                    // add new record

                    // automate update

                    Hierarchy.AddedBy = username;
                    Hierarchy.AddedDate = DateTime.Now;

                    HierarchyFunctions.AddOrEdit(Hierarchy, CrudOperation.Add);
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