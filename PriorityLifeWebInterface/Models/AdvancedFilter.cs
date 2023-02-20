using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Models
{
    public class AdvancedFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AdvancedFilter()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }
}
