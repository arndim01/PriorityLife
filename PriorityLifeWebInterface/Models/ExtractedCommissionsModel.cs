using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Models
{
    public class ExtractedCommissionsModel
    {
        public string agent_surname { get; set; }
        public string agent_givenname { get; set; }
        public string amount { get; set; }
        public DateTime date { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string pl_number { get; set; }
    }
}
