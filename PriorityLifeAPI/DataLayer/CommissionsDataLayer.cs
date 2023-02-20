using System;
using System.Collections.Generic;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.DataLayer.Base;
using System.Linq;
using PriorityLifeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional Commissions DataLayer code in this class
     /// </summary>

     internal class CommissionsDataLayer : CommissionsDataLayerBase
     {
         // constructor
         internal CommissionsDataLayer()
         {
         }


        internal static bool DeleteSpecificLayer(int Id)
        {
            Delete(Id);
            return true;

        }

        /// <summary>
        /// Get Individual IP Reports
        /// </summary>
        /// <returns></returns>
        internal static List<IndividualReport> GetCommissionsReport()
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return (from com in context.Commissions
                    join car in context.Carriers
                       on com.CarrierId equals car.Id
                    join sa in context.Salesperson
                      on com.SalespersonId equals sa.Id
                    select new IndividualReport
                    {
                        WritingAgent = sa.Initials,
                        CommissionsDate = com.CommissionDate.ToString("dd/MM/yyyy"),
                        Upline1 = "",
                        Upline2 = "",
                        Upline3 = "",
                        Upline4 = "",
                        Upline5 = "",
                        Upline6 = "",
                        Upline7 = "",
                        Upline8 = "",
                        Upline9 = "",
                        Upline10 = "",
                        Carrier = car.ShortName,
                        Amount = com.Amount
                    }).GroupBy(x => new { x.WritingAgent, x.CommissionsDate, x.Amount, x.Carrier }).Select(g => new IndividualReport {
                        WritingAgent = g.Key.WritingAgent,
                        CommissionsDate = g.Key.CommissionsDate,
                        Upline1 = "",
                        Upline2 = "",
                        Upline3 = "",
                        Upline4 = "",
                        Upline5 = "",
                        Upline6 = "",
                        Upline7 = "",
                        Upline8 = "",
                        Upline9 = "",
                        Upline10 = "",
                        Carrier = g.Key.Carrier,
                        Amount = g.Sum(t => t.Amount) }
                    ).ToList();
        }
        /// <summary>
        /// Get Report By Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static List<Commissions> GetReportByDate(DateTime date)
        {
            PriorityLifeContext context = new PriorityLifeContext();


            return (from c in context.Commissions
                    join cr in context.Carriers 
                        on c.CarrierId equals cr.Id
                    join s in context.Salesperson 
                        on c.SalespersonId equals s.Id
                    where (date.Date >= c.CommissionStartDate.Date && date.Date <= c.CommissionEndDate.Date)
                    select new Commissions {
                        Id = c.Id,
                        CommissionDate = c.CommissionDate,
                        Amount = c.Amount,
                        CarrierIdNavigation = cr,
                        SalespersonIdNavigation = s
                    }).ToList();


            //return context.Commissions.Where(c => c.CommissionDate.Year == date.Year && c.CommissionDate.Month == date.Month && c.CommissionDate.Day == date.Day).ToList();
        }
        /// <summary>
        /// Get Report Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        internal static List<Commissions> GetIPReportByRange(DateTime start, DateTime end)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return (from c in context.Commissions
                    join cr in context.Carriers
                        on c.CarrierId equals cr.Id
                    join s in context.Salesperson
                        on c.SalespersonId equals s.Id
                    join h in context.Hierarchy
                        on s.Id equals h.SalesPersonId into hie from h in hie.DefaultIfEmpty()  
                    where (c.CommissionStartDate.Date >= start.Date && c.CommissionEndDate.Date <= start.Date) || 
                          (c.CommissionStartDate.Date <= end.Date && c.CommissionEndDate.Date >= start.Date  && c.CommissionStartDate.Date >= start.Date ) ||
                          (start.Date >= c.CommissionStartDate.Date && end.Date <= c.CommissionEndDate.Date)
                    select new Commissions
                    {
                        Id = c.Id,
                        CommissionDate = c.CommissionDate,
                        Amount = c.Amount,
                        CarrierIdNavigation = cr,
                        SalespersonIdNavigation = s,
                        Upline1 = h.Upline1IdNavigation,
                        Upline2 = h.Upline2IdNavigation,
                        Upline3 = h.Upline3IdNavigation,
                        Upline4 = h.Upline4IdNavigation,
                        Upline5 = h.Upline5IdNavigation,
                        Upline6 = h.Upline6IdNavigation,
                        Upline7 = h.Upline7IdNavigation,
                        Upline8 = h.Upline8IdNavigation,
                        Upline9 = h.Upline9IdNavigation,
                        Upline10 = h.Upline10IdNavigation
                        
                    }).ToList();
        }
        /// <summary>
        /// Get Report By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        internal static List<Commissions> GetReportByYear(int year)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Commissions.Where(c => c.CommissionDate.Year == year).ToList();
        }

        /// <summary>
        /// Get Team Report By Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        internal static List<TeamReport> GetTeamsReportByDateRange(DateTime start, DateTime end)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return  (from c in context.Commissions
                          join s in context.Salesperson
                              on c.SalespersonId equals s.Id
                          join cr in context.Carriers
                              on c.CarrierId equals cr.Id
                          join td in context.TeamDetails
                              on s.Id equals td.TeamMemberId
                          join t in context.Team
                              on td.TeamId equals t.Id
                            where (c.CommissionStartDate.Date >= start.Date && c.CommissionEndDate.Date <= start.Date) ||
                                  (c.CommissionStartDate.Date <= end.Date && c.CommissionEndDate.Date >= start.Date && c.CommissionStartDate.Date >= start.Date) ||
                          (start.Date >= c.CommissionStartDate.Date && end.Date <= c.CommissionEndDate.Date)

                     select new TeamReport
                          {
                              Amount = c.Amount,
                              Carrier = cr.ShortName,
                              Rank = 0,
                              TeamName = t.TeamName
                        }).GroupBy(x => new { x.TeamName, x.Carrier }).Select(g => new TeamReport
                        {
                            Rank = g.First().Rank,
                            TeamName = g.First().TeamName,
                            Carrier = g.First().Carrier,
                            Amount = g.Sum(c => c.Amount)
                        }).OrderByDescending(c =>c.Amount).ToList();
            
        }
        /// <summary>
        /// Get Team Report By Date
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        internal static List<TeamReport> GetTeamsReportByDate(DateTime date)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return (from c in context.Commissions
                    join s in context.Salesperson
                        on c.SalespersonId equals s.Id
                    join cr in context.Carriers
                        on c.CarrierId equals cr.Id
                    join td in context.TeamDetails
                        on s.Id equals td.TeamMemberId
                    join t in context.Team
                        on td.TeamId equals t.Id
                    where (date >= c.CommissionStartDate.Date && date <= c.CommissionEndDate.Date)
                    select new TeamReport
                    {
                        Amount = c.Amount,
                        Carrier = cr.ShortName,
                        Rank = 0,
                        TeamName = t.TeamName
                    }).GroupBy(x => new { x.TeamName, x.Carrier }).Select(g => new TeamReport
                    {
                        Rank = g.First().Rank,
                        TeamName = g.First().TeamName,
                        Carrier = g.First().Carrier,
                        Amount = g.Sum(c => c.Amount)
                    }).OrderByDescending(c => c.Amount).ToList();

        }
        /// <summary>
        /// Get Team Manager Report By Date Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        internal static List<AgentTeamReport> GetTeamManagerReportByDateRange(DateTime start, DateTime end)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return (from c in context.Commissions
                    join s in context.Salesperson
                        on c.SalespersonId equals s.Id
                    join cr in context.Carriers
                        on c.CarrierId equals cr.Id
                    join t in context.Team
                        on c.SalespersonId equals t.TeamManager
                    where (c.CommissionStartDate.Date >= start.Date && c.CommissionEndDate.Date <= start.Date) ||
                          (c.CommissionStartDate.Date <= end.Date && c.CommissionEndDate.Date >= start.Date && c.CommissionStartDate.Date >= start.Date) ||
                          (start.Date >= c.CommissionStartDate.Date && end.Date <= c.CommissionEndDate.Date)
                    select new AgentTeamReport
                    {
                        TeamManagerFirstName = s.FirstName,
                        TeamManagerLastName = s.LastName,
                        Amount = c.Amount,
                        Carrier = cr.ShortName,
                        Rank = 0,
                        TeamName = t.TeamName
                    }).GroupBy(x => new { x.TeamName, x.TeamManagerFirstName, x.TeamManagerLastName, x.Carrier }).Select(g => new AgentTeamReport
                    {
                        TeamManagerFirstName = g.First().TeamManagerFirstName,
                        TeamManagerLastName = g.First().TeamManagerLastName,
                        Rank = g.First().Rank,
                        TeamName = g.First().TeamName,
                        Carrier = g.First().Carrier,
                        Amount = g.Sum(c => c.Amount)
                    }).OrderByDescending(c => c.Amount).ToList();

        }
        /// <summary>
        /// Get Team Manager Report By Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static List<AgentTeamReport> GetTeamManagerReportByDate(DateTime date)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return (from c in context.Commissions
                    join s in context.Salesperson
                        on c.SalespersonId equals s.Id
                    join cr in context.Carriers
                        on c.CarrierId equals cr.Id
                    join t in context.Team
                        on s.Id equals t.TeamManager
                    where (date >= c.CommissionStartDate.Date && date <= c.CommissionEndDate.Date)
                    select new AgentTeamReport
                    {
                        TeamManagerFirstName = s.FirstName,
                        TeamManagerLastName = s.LastName,
                        Amount = c.Amount,
                        Carrier = cr.ShortName,
                        Rank = 0,
                        TeamName = t.TeamName
                    }).GroupBy(x => new { x.TeamName, x.TeamManagerFirstName, x.TeamManagerLastName, x.Carrier }).Select(g => new AgentTeamReport
                    {
                        TeamManagerFirstName = g.First().TeamManagerFirstName,
                        TeamManagerLastName = g.First().TeamManagerLastName,
                        Rank = g.First().Rank,
                        TeamName = g.First().TeamName,
                        Carrier = g.First().Carrier,
                        Amount = g.Sum(c => c.Amount)
                    }).OrderByDescending(c => c.Amount).ToList();

        }
    }
}
