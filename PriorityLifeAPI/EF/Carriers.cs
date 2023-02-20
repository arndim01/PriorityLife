using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class Carriers
    {
        public Carriers()
        {
            CommissionsFile = new HashSet<CommissionsFile>();
        }

        public virtual ICollection<CommissionsFile> CommissionsFile { get; set; }
        public virtual ICollection<Commissions> Commissions { get; set; }
    }
}
