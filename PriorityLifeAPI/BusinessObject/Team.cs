using System;
using System.Collections.Generic;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;
using PriorityLifeAPI.Models;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional Team Business Layer code in this class.
     /// </summary>
     public partial class Team : TeamBase
     {
        /// <summary>
        /// Check Team Name Exist
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public static bool CheckTeamNameExist(string teamName)
        {
            return TeamDataLayer.CheckTeamNameExist(teamName);
        }

        /// <summary>
        /// Get Team by Team Name
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public static Team GetTeamByTeamName(string teamName)
        {
            return TeamDataLayer.GetTeamByTeamName(teamName);
        }
    }
}
