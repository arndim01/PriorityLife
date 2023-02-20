using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class Hierarchy
    {
        public Hierarchy()
        {
        }

        public virtual Salesperson SalesPersonIdNavigation { get; set; }
        public virtual Salesperson Upline1IdNavigation { get; set; }
        public virtual Salesperson Upline2IdNavigation { get; set; }
        public virtual Salesperson Upline3IdNavigation { get; set; }
        public virtual Salesperson Upline4IdNavigation { get; set; }
        public virtual Salesperson Upline5IdNavigation { get; set; }
        public virtual Salesperson Upline6IdNavigation { get; set; }
        public virtual Salesperson Upline7IdNavigation { get; set; }
        public virtual Salesperson Upline8IdNavigation { get; set; }
        public virtual Salesperson Upline9IdNavigation { get; set; }
        public virtual Salesperson Upline10IdNavigation { get; set; }
    }
}
