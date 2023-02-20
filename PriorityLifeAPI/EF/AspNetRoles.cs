using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
        }

        public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
    }
}
