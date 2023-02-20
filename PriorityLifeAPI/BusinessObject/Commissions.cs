using System;
using System.Collections.Generic;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;
using PriorityLifeAPI.Models;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional Commissions Business Layer code in this class.
     /// </summary>
     public partial class Commissions : CommissionsBase
     {



        public static bool DeleteLater(int Id)
        {
            return CommissionsDataLayer.DeleteSpecificLayer(Id);
        }

        /// <summary>
        /// Get Individual IP Reports
        /// </summary>
        /// <returns></returns>
        public static List<IndividualReport> GetCommissionsReport()
        {
            return CommissionsDataLayer.GetCommissionsReport();
        }

        /// <summary>
        /// Get Report By Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Commissions> GetReportByDate(DateTime date)
        {

            return CommissionsDataLayer.GetReportByDate(date);
        }
        /// <summary>
        /// Get Report Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Commissions> GetIPReportByRange(DateTime start, DateTime end)
        {
            return CommissionsDataLayer.GetIPReportByRange(start, end);
        }
        /// <summary>
        /// Get Report By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<Commissions> GetReportByYear(int year)
        {
            return CommissionsDataLayer.GetReportByYear(year);
        }


        /// <summary>
        /// Get Team Report By Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<TeamReport> GetTeamsReportByDateRange(DateTime start, DateTime end)
        {
            return CommissionsDataLayer.GetTeamsReportByDateRange(start, end);
        }

        /// <summary>
        /// Get Team Report By Date
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<TeamReport> GetTeamsReportByDate(DateTime date)
        {
            return CommissionsDataLayer.GetTeamsReportByDate(date);

        }

        /// <summary>
        /// Get Team Manager Report By Date Range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<AgentTeamReport> GetTeamManagerReportByDateRange(DateTime start, DateTime end)
        {
            return CommissionsDataLayer.GetTeamManagerReportByDateRange(start, end);
        }
        /// <summary>
        /// Get Team Manager Report By Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<AgentTeamReport> GetTeamManagerReportByDate(DateTime date)
        {
            return CommissionsDataLayer.GetTeamManagerReportByDate(date);
        }
    }

   
}
