using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityLifeAPI.Models
{
    public class TeamReport
    {
        public int Rank { get; set; }
        public string TeamName { get; set; }
        public decimal Amount { get; set; }
        public string Carrier { get; set; }
    }
}
