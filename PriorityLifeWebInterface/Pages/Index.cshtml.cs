using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PriorityLifeWebInterface.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public string UserLogin;
        public IndexModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            //UserLogin = _userManager.GetUserName(User);
        }
        public void OnGet()
        {

        }
    }
}
