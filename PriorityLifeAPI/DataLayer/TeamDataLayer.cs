using System;
using System.Collections.Generic;
using PriorityLifeAPI.DataLayer.Base;
using System.Linq;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Models;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional Team DataLayer code in this class
     /// </summary>

     internal class TeamDataLayer : TeamDataLayerBase
     {
         // constructor
         internal TeamDataLayer()
         {
         }
        
        /// <summary>
        /// Check Team Name Exist
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        internal static bool CheckTeamNameExist(string teamName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Team.Where(c => c.TeamName == teamName.ToUpper()).ToList().Count > 0;
        }
        /// <summary>
        /// Get Team by Team Name
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        internal static Team GetTeamByTeamName( string teamName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Team.Where(c => c.TeamName == teamName.ToUpper()).FirstOrDefault();
        }

     }
}
