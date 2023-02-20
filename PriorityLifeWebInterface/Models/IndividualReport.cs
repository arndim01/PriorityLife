using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Models
{
    public class IndividualReport
    {
        public int Id { get; set; }
        public string WritingAgent { get; set; }
        public DateTime CommissionsDate { get; set; }
        public string Upline1 { get; set; }
        public string Upline2 { get; set; }
        public string Upline3 { get; set; }
        public string Upline4 { get; set; }
        public string Upline5 { get; set; }
        public string Upline6 { get; set; }
        public string Upline7 { get; set; }
        public string Upline8 { get; set; }
        public string Upline9 { get; set; }
        public string Upline10 { get; set; }
        public string Carrier { get; set; }
        public decimal Amount { get; set; }
    }

    public class IndividualCustomReportModel
    {
        public int Id { get; set; }
        public string WritingAgent { get; set; }
        public decimal Amount { get; set; }
        public string Upline1 { get; set; }
        public string Upline2 { get; set; }
        public string Upline3 { get; set; }
        public string Upline4 { get; set; }
        public string Upline5 { get; set; }
        public string Upline6 { get; set; }
        public string Upline7 { get; set; }
        public string Upline8 { get; set; }
        public string Upline9 { get; set; }
        public string Upline10 { get; set; }
        public decimal AIG { get; set; }
        public decimal AMERICO { get; set; }
        public decimal MOO { get; set; }
        public decimal GLOBAL { get; set; }
        public decimal ROYAL { get; set; }
        public decimal TRANS { get; set; }
        public decimal ATHENE { get; set; }
        public decimal AMAM { get; set; }
        public decimal PROSPERITY { get; set; }
        public decimal RSHIELD { get; set; }

    }
    public class TeamAgentCustomReportModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamManager { get; set; }
        public decimal Amount { get; set; }
        public decimal AIG { get; set; }
        public decimal AMERICO { get; set; }
        public decimal MOO { get; set; }
        public decimal GLOBAL { get; set; }
        public decimal ROYAL { get; set; }
        public decimal TRANS { get; set; }
        public decimal ATHENE { get; set; }
        public decimal AMAM { get; set; }
        public decimal PROSPERITY { get; set; }
        public decimal RSHIELD { get; set; }

    }

    public class TeamCustomReportModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public decimal Amount { get; set; }
        public decimal AIG { get; set; }
        public decimal AMERICO { get; set; }
        public decimal MOO { get; set; }
        public decimal GLOBAL { get; set; }
        public decimal ROYAL { get; set; }
        public decimal TRANS { get; set; }
        public decimal ATHENE { get; set; }
        public decimal AMAM { get; set; }
        public decimal PROSPERITY { get; set; }
        public decimal RSHIELD { get; set; }

    }
}
