using System;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional TeamDetails Business Layer code in this class.
     /// </summary>
     public partial class TeamDetails : TeamDetailsBase
     {
        /// <summary>
        /// Check if Member Exist in the team.
        /// </summary>
        /// <param name="SalespersonId"></param>
        /// <param name="TeamId"></param>
        /// <returns></returns>
        public static bool CheckTeamMemberExistInTeamById(int SalespersonId, int TeamId)
        {
            return TeamDetailsDataLayer.CheckTeamMemberExistInTeamById(SalespersonId, TeamId);
        }
    }
}
