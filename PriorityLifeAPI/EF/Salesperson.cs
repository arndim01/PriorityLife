using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class Salesperson
    {
        public Salesperson()
        {
            HierarchySalesPersonIdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline1IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline2IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline3IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline4IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline5IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline6IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline7IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline8IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline9IdNavigation = new HashSet<Hierarchy>();
            HierarchyUpline10IdNavigation = new HashSet<Hierarchy>();
            Team = new HashSet<Team>();
            TeamDetails = new HashSet<TeamDetails>();
        }

        public virtual ICollection<Hierarchy> HierarchySalesPersonIdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline1IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline2IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline3IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline4IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline5IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline6IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline7IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline8IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline9IdNavigation { get; set; }
        public virtual ICollection<Hierarchy> HierarchyUpline10IdNavigation { get; set; }
        public virtual ICollection<Team> Team { get; set; }
        public virtual ICollection<TeamDetails> TeamDetails { get; set; }
        public virtual ICollection<Commissions> Commissions { get; set; }
    }
}
