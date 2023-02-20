using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class AspNetUserTokens
    {
        public AspNetUserTokens()
        {
        }

        public virtual AspNetUsers UserIdNavigation { get; set; }
    }
}
