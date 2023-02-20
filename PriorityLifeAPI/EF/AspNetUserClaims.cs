using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class AspNetUserClaims
    {
        public AspNetUserClaims()
        {
        }

        public virtual AspNetUsers UserIdNavigation { get; set; }
    }
}
