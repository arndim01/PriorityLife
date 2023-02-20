using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class AspNetRoleClaims
    {
        public AspNetRoleClaims()
        {
        }

        public virtual AspNetRoles RoleIdNavigation { get; set; }
    }
}
