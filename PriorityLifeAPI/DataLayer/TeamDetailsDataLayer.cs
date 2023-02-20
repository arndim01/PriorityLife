using System;
using PriorityLifeAPI.DataLayer.Base;
using System.Linq;
using PriorityLifeAPI.BusinessObject;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional TeamDetails DataLayer code in this class
     /// </summary>

     internal class TeamDetailsDataLayer : TeamDetailsDataLayerBase
     {
         // constructor
         internal TeamDetailsDataLayer()
         {

         }
        /// <summary>
        /// Check if Member Exist in the team.
        /// </summary>
        /// <param name="SalespersonId"></param>
        /// <param name="TeamId"></param>
        /// <returns></returns>
        internal static bool CheckTeamMemberExistInTeamById(int SalespersonId, int TeamId)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.TeamDetails.Where(c => c.TeamId == TeamId && c.TeamMemberId == SalespersonId).ToList().Count > 0;
        }

        //internal static TeamDetails Get
     }
}
