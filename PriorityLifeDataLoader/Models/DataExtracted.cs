using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Models
{
    public class DataExtracted
    {
        public string Agent { get; set; }
        public string PremiumAmount { get; set; }
        public string CommissionDate { get; set; }
    }

    public class DateExtract
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }
}
