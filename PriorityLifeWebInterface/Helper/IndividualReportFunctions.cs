using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class IndividualReportFunctions
    {
        private IndividualReportFunctions()
        {

        }

        internal static List<IndividualCustomReportModel> SortReport(List<IndividualCustomReportModel> reports, string sidx, string sord, int startIndex, int row)
        {
            if (sord == "desc")
            {
                switch (sidx)
                {
                    case "Id":
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "WritingAgent":
                        return reports.OrderByDescending(s => s.WritingAgent).Skip(startIndex).Take(row).ToList();
                    case "Upline1":
                        return reports.OrderByDescending(s => s.Upline1).Skip(startIndex).Take(row).ToList();
                    case "Upline2":
                        return reports.OrderByDescending(s => s.Upline2).Skip(startIndex).Take(row).ToList();
                    case "Upline3":
                        return reports.OrderByDescending(s => s.Upline3).Skip(startIndex).Take(row).ToList();
                    case "Upline4":
                        return reports.OrderByDescending(s => s.Upline4).Skip(startIndex).Take(row).ToList();
                    case "Upline5":
                        return reports.OrderByDescending(s => s.Upline5).Skip(startIndex).Take(row).ToList();
                    case "Upline6":
                        return reports.OrderByDescending(s => s.Upline6).Skip(startIndex).Take(row).ToList();
                    case "Upline7":
                        return reports.OrderByDescending(s => s.Upline7).Skip(startIndex).Take(row).ToList();
                    case "Upline8":
                        return reports.OrderByDescending(s => s.Upline8).Skip(startIndex).Take(row).ToList();
                    case "Upline9":
                        return reports.OrderByDescending(s => s.Upline9).Skip(startIndex).Take(row).ToList();
                    case "Upline10":
                        return reports.OrderByDescending(s => s.Upline10).Skip(startIndex).Take(row).ToList();
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
                    case "TRANS":
                        return reports.OrderByDescending(s => s.TRANS).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderByDescending(s => s.Id).Skip(startIndex).Take(row).ToList();
                }
            }
            else
            {
                switch (sidx)
                {
                    case "Id":
                        return reports.OrderBy(s => s.Id).Skip(startIndex).Take(row).ToList();
                    case "WritingAgent":
                        return reports.OrderBy(s => s.WritingAgent).Skip(startIndex).Take(row).ToList();
                    case "Upline1":
                        return reports.OrderBy(s => s.Upline1).Skip(startIndex).Take(row).ToList();
                    case "Upline2":
                        return reports.OrderBy(s => s.Upline2).Skip(startIndex).Take(row).ToList();
                    case "Upline3":
                        return reports.OrderBy(s => s.Upline3).Skip(startIndex).Take(row).ToList();
                    case "Upline4":
                        return reports.OrderBy(s => s.Upline4).Skip(startIndex).Take(row).ToList();
                    case "Upline5":
                        return reports.OrderBy(s => s.Upline5).Skip(startIndex).Take(row).ToList();
                    case "Upline6":
                        return reports.OrderBy(s => s.Upline6).Skip(startIndex).Take(row).ToList();
                    case "Upline7":
                        return reports.OrderBy(s => s.Upline7).Skip(startIndex).Take(row).ToList();
                    case "Upline8":
                        return reports.OrderBy(s => s.Upline8).Skip(startIndex).Take(row).ToList();
                    case "Upline9":
                        return reports.OrderBy(s => s.Upline9).Skip(startIndex).Take(row).ToList();
                    case "Upline10":
                        return reports.OrderBy(s => s.Upline10).Skip(startIndex).Take(row).ToList();
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
                    case "TRANS":
                        return reports.OrderBy(s => s.TRANS).Skip(startIndex).Take(row).ToList();
                    case "Amount":
                        return reports.OrderBy(s => s.Amount).Skip(startIndex).Take(row).ToList();
                    default:
                        return reports.OrderBy(s => s.Id).Skip(startIndex).Take(row).ToList();
                }
            }


        }

        internal static List<IndividualCustomReportModel> GetReport(List<Commissions> objCommissionsCol)
        {
            List<IndividualReport> IndiReport = new List<IndividualReport>();
            foreach (var com in objCommissionsCol)
            {
                //var carrier = com.CarrierIdNavigation;
                //var salesperson = com.SalespersonIdNavigation;
                if (com.CarrierIdNavigation != null && com.SalespersonIdNavigation != null)
                {
                    var agentCom = IndiReport.Where(i => i.WritingAgent == com.SalespersonIdNavigation.FirstName + " " + com.SalespersonIdNavigation.LastName[0] && i.Carrier == com.CarrierIdNavigation.ShortName).FirstOrDefault();
                    if (agentCom != null)
                    {
                        agentCom.Amount += com.Amount;
                    }
                    else
                    {
                        IndiReport.Add(new IndividualReport
                        {
                            WritingAgent = com.SalespersonIdNavigation.FirstName + " " + com.SalespersonIdNavigation.LastName[0],
                            Upline1 = com.Upline1 != null ? com.Upline1.FirstName[0].ToString() + com.Upline1.LastName[0].ToString() : "",
                            Upline2 = com.Upline2 != null ? com.Upline2.FirstName[0].ToString() + com.Upline2.LastName[0].ToString() : "",
                            Upline3 = com.Upline3 != null ? com.Upline3.FirstName[0].ToString() + com.Upline3.LastName[0].ToString() : "",
                            Upline4 = com.Upline4 != null ? com.Upline4.FirstName[0].ToString() + com.Upline4.LastName[0].ToString() : "",
                            Upline5 = com.Upline5 != null ? com.Upline5.FirstName[0].ToString() + com.Upline5.LastName[0].ToString() : "",
                            Upline6 = com.Upline6 != null ? com.Upline6.FirstName[0].ToString() + com.Upline6.LastName[0].ToString() : "",
                            Upline7 = com.Upline7 != null ? com.Upline7.FirstName[0].ToString() + com.Upline7.LastName[0].ToString() : "",
                            Upline8 = com.Upline8 != null ? com.Upline8.FirstName[0].ToString() + com.Upline8.LastName[0].ToString() : "",
                            Upline9 = com.Upline9 != null ? com.Upline9.FirstName[0].ToString() + com.Upline9.LastName[0].ToString() : "",
                            Upline10 = com.Upline10 != null ? com.Upline10.FirstName[0].ToString() + com.Upline10.LastName[0].ToString() : "",
                            CommissionsDate = com.CommissionDate,
                            Carrier = com.CarrierIdNavigation.ShortName,
                            Amount = com.Amount
                        });
                    }
                }
            }

            IndiReport = IndiReport.OrderBy(c => c.WritingAgent).ToList();
            //int count = 0;
            //foreach (IndividualReport indi in IndiReport)
            //{
            //    indi.Id = ++count;
            //}

            List<IndividualCustomReportModel> customModel = new List<IndividualCustomReportModel>();
            foreach (var list in IndiReport)
            {
                var agentCommission = customModel.Where(c => c.WritingAgent == list.WritingAgent);
                if (agentCommission.Count() > 0)
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
                    customModel.Add(new IndividualCustomReportModel
                    {

                        Id = list.Id,
                        WritingAgent = list.WritingAgent,
                        Amount = list.Amount,
                        Upline1 = list.Upline1,
                        Upline2 = list.Upline2,
                        Upline3 = list.Upline3,
                        Upline4 = list.Upline4,
                        Upline5 = list.Upline5,
                        Upline6 = list.Upline6,
                        Upline7 = list.Upline7,
                        Upline8 = list.Upline8,
                        Upline9 = list.Upline9,
                        Upline10 = list.Upline10,
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
