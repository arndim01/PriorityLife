using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class AspNetUserLogins
    {
        public AspNetUserLogins()
        {
        }

        public virtual AspNetUsers UserIdNavigation { get; set; }
    }
}
