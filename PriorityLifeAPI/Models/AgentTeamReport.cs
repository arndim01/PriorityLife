using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityLifeAPI.Models
{
    public class AgentTeamReport
    {
        public int Rank { get; set; }
        public string TeamName { get; set; }
        public string TeamManagerFirstName { get; set; }
        public string TeamManagerLastName { get; set; }
        public decimal Amount { get; set; }
        public string Carrier { get; set; }
    }
}
