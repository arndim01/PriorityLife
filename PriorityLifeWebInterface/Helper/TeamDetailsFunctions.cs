using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class TeamDetailsFunctions
    {
        private TeamDetailsFunctions()
        {
        }


        /// <summary>
        /// Used when adding or updating a record.
        /// </summary>
        internal static void AddOrEdit(TeamDetails model, CrudOperation operation, bool isForListInline = false)
        {
            TeamDetails objTeamDetails;

            if (operation == CrudOperation.Add)
                objTeamDetails = new TeamDetails();
            else
                objTeamDetails = TeamDetails.SelectByPrimaryKey(model.Id);

            objTeamDetails.Id = model.Id;
            objTeamDetails.TeamId = model.TeamId;
            objTeamDetails.TeamMemberId = model.TeamMemberId;
            objTeamDetails.Activate = model.Activate;
            if (operation == CrudOperation.Add)
            {
                objTeamDetails.AddedBy = model.AddedBy;
                objTeamDetails.AddedDate = model.AddedDate;
            }
            else
            {
                objTeamDetails.UpdatedBy = model.UpdatedBy;
                objTeamDetails.UpdatedDate = model.UpdatedDate;
            }

            if (operation == CrudOperation.Add)
                objTeamDetails.Insert();
            else
                objTeamDetails.Update();
        }
    }
}
