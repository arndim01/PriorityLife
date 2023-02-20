using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class Commissions
    {
        public Commissions()
        {
        }
        public virtual Salesperson SalespersonIdNavigation { get; set; }
        public virtual Carriers CarrierIdNavigation { get; set; }
        [NotMapped]
        public virtual Salesperson Upline1 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline2 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline3 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline4 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline5 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline6 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline7 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline8 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline9 { get; set; }
        [NotMapped]
        public virtual Salesperson Upline10 { get; set; }
    }
}
