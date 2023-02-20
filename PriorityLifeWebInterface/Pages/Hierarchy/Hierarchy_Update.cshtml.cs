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

namespace PriorityLifeWebInterface.Pages.Hierarchy
{
    [Authorize]
    public class Hierarchy_UpdateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Hierarchy_UpdateModel(UserManager<IdentityUser> userManager)
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
        public void OnGet(int id, string returnUrl)
        {
            LoadPage(id, returnUrl);
        }

        public PageResult LoadPage(int id, string returnUrl)
        {
            // select a record by primary key(s)
            PriorityLifeAPI.BusinessObject.Hierarchy objHierarchy = PriorityLifeAPI.BusinessObject.Hierarchy.SelectByPrimaryKey(id);

            // create the model used by the partial page
            AddEditHierarchyPartialModel model = new AddEditHierarchyPartialModel();
            model.SalespersonDropDownListData = PriorityLifeAPI.BusinessObject.Salesperson.SelectSalespersonDropDownListData();
            model.Operation = CrudOperation.Update;
            model.ReturnUrl = returnUrl;
            model.Hierarchy = objHierarchy;

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
                    string username = _userManager.GetUserName(HttpContext.User);
                    Hierarchy.UpdatedBy = username;
                    Hierarchy.UpdatedDate = DateTime.Now;

                    HierarchyFunctions.AddOrEdit(Hierarchy, CrudOperation.Update);
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
            return LoadPage(Hierarchy.Id, ReturnUrl);
        }
    }
}
