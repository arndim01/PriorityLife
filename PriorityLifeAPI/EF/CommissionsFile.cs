using System;
using System.Collections.Generic;

namespace PriorityLifeAPI.BusinessObject
{
    public partial class CommissionsFile
    {
        public CommissionsFile()
        {
        }

        public virtual Carriers CarrierIdNavigation { get; set; }
    }
}
