using PriorityLifeWebInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class TeamAgentReportFunctions
    {
        private TeamAgentReportFunctions() { }
        internal static List<TeamAgentCustomReportModel> SortReport(List<TeamAgentCustomReportModel> reports, string sidx, string sord, int startIndex, int row)
        {
            if (sord == "desc")
            {
                switch (sidx)
                {
                    case "Num":
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "TeamName":
                        return reports.OrderByDescending(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                    case "TeamManager":
                        return reports.OrderByDescending(s => s.TeamManager).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderByDescending(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "AIG":
                        return reports.OrderByDescending(s => s.AIG).Skip(startIndex).Take(row).ToList();
                    case "AMERICO":
                        return reports.OrderByDescending(s => s.AMERICO).Skip(startIndex).Take(row).ToList();
                    case "MOO":
                        return reports.OrderByDescending(s => s.MOO).Skip(startIndex).Take(row).ToList();
                    case "GLOBAL":
                        return reports.OrderByDescending(s => s.GLOBAL).Skip(startIndex).Take(row).ToList();
                    case "ROYAL":
                        return reports.OrderByDescending(s => s.ROYAL).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                }
            }
            else
            {
                switch (sidx)
                {
                    case "Num":
                        return reports.OrderBy(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "TeamName":
                        return reports.OrderBy(s => s.TeamName).Skip(startIndex).Take(row).ToList();
                    case "TeamManager":
                        return reports.OrderBy(s => s.TeamManager).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderBy(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    case "AIG":
                        return reports.OrderBy(s => s.AIG).Skip(startIndex).Take(row).ToList();
                    case "AMERICO":
                        return reports.OrderBy(s => s.AMERICO).Skip(startIndex).Take(row).ToList();
                    case "MOO":
                        return reports.OrderBy(s => s.MOO).Skip(startIndex).Take(row).ToList();
                    case "GLOBAL":
                        return reports.OrderBy(s => s.GLOBAL).Skip(startIndex).Take(row).ToList();
                    case "ROYAL":
                        return reports.OrderBy(s => s.ROYAL).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderBy(s => s.Id    ).Skip(startIndex).Take(row).ToList();
                }
            }
        }

        internal static List<TeamAgentCustomReportModel> GetReport(List<PriorityLifeAPI.Models.AgentTeamReport> reports)
        {

            reports = reports.OrderBy(c => c.TeamName).ToList();

            List<TeamAgentCustomReportModel> customModel = new List<TeamAgentCustomReportModel>();


            foreach (var list in reports)
            {
                var team = customModel.Where(c => c.TeamName == list.TeamName);
                if (team.Count() > 0)
                {
                    decimal getAmount = String.IsNullOrEmpty(customModel[customModel.Count - 1].Amount.ToString()) ? 0 : Convert.ToDecimal(customModel[customModel.Count - 1].Amount);
                    decimal totalAmount = getAmount + list.Amount;
                    customModel[customModel.Count - 1].Amount = totalAmount;
                    if (list.Carrier == "AIG")
                    {
                        customModel[customModel.Count - 1].AIG = list.Amount;

                    }
                    else if (list.Carrier == "AMERICO")
                    {
                        customModel[customModel.Count - 1].AMERICO = list.Amount;

                    }
                    else if (list.Carrier == "MOO")
                    {
                        customModel[customModel.Count - 1].MOO = list.Amount;

                    }
                    else if (list.Carrier == "GLOBAL")
                    {
                        customModel[customModel.Count - 1].GLOBAL = list.Amount;

                    }
                    else if (list.Carrier == "ROYAL")
                    {
                        customModel[customModel.Count - 1].ROYAL = list.Amount;
                    }
                    else if (list.Carrier == "TRANS")
                    {
                        customModel[customModel.Count - 1].TRANS = list.Amount;
                    }
                    else if (list.Carrier == "ATHENE")
                    {
                        customModel[customModel.Count - 1].ATHENE = list.Amount;
                    }
                    else if (list.Carrier == "AMAM")
                    {
                        customModel[customModel.Count - 1].AMAM = list.Amount;
                    }
                    else if (list.Carrier == "PROSPERITY")
                    {
                        customModel[customModel.Count - 1].PROSPERITY = list.Amount;
                    }
                    else if (list.Carrier == "RSHIELD")
                    {
                        customModel[customModel.Count - 1].RSHIELD = list.Amount;
                    }

                }
                else
                {

                    customModel.Add(new TeamAgentCustomReportModel
                    {
                        Id = list.Rank,
                        TeamName = list.TeamName,
                        TeamManager = list.TeamManagerFirstName + " " + list.TeamManagerLastName,
                        Amount = list.Amount
                    });

                    if (list.Carrier == "AIG")
                    {
                        customModel[customModel.Count - 1].AIG = list.Amount;

                    }
                    else if (list.Carrier == "AMERICO")
                    {
                        customModel[customModel.Count - 1].AMERICO = list.Amount;

                    }
                    else if (list.Carrier == "MOO")
                    {
                        customModel[customModel.Count - 1].MOO = list.Amount;

                    }
                    else if (list.Carrier == "GLOBAL")
                    {
                        customModel[customModel.Count - 1].GLOBAL = list.Amount;

                    }
                    else if (list.Carrier == "ROYAL")
                    {
                        customModel[customModel.Count - 1].ROYAL = list.Amount;
                    }
                    else if (list.Carrier == "TRANS")
                    {
                        customModel[customModel.Count - 1].TRANS = list.Amount;
                    }
                    else if (list.Carrier == "ATHENE")
                    {
                        customModel[customModel.Count - 1].ATHENE = list.Amount;
                    }
                    else if (list.Carrier == "AMAM")
                    {
                        customModel[customModel.Count - 1].AMAM = list.Amount;
                    }
                    else if (list.Carrier == "PROSPERITY")
                    {
                        customModel[customModel.Count - 1].PROSPERITY = list.Amount;
                    }
                    else if (list.Carrier == "RSHIELD")
                    {
                        customModel[customModel.Count - 1].RSHIELD = list.Amount;
                    }
                }
            }

            var SortReport = customModel.OrderByDescending(c => c.Amount).ToList();
            int count = 0;
            foreach (var report in SortReport)
            {
                report.Id = ++count;
            }

            return SortReport;
        }
    }
}
