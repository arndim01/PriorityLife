using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class TeamDetails
    {
        public TeamDetails()
        {
        }

        public virtual Team TeamIdNavigation { get; set; }
        public virtual Salesperson TeamMemberIdNavigation { get; set; }
    }
}
