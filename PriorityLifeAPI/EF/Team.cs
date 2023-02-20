using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class Team
    {
        public Team()
        {
            TeamDetails = new HashSet<TeamDetails>();
        }

        public virtual ICollection<TeamDetails> TeamDetails { get; set; }
        public virtual Salesperson TeamManagerNavigation { get; set; }
    }
}
