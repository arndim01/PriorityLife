using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class TeamFunctions
    {
        private TeamFunctions()
        {
        }


        /// <summary>
        /// Used when adding or updating a record.
        /// </summary>
        internal static void AddOrEdit(Team model, CrudOperation operation, bool isForListInline = false)
        {
            Team objTeam;

            if (operation == CrudOperation.Add)
                objTeam = new Team();
            else
                objTeam = Team.SelectByPrimaryKey(model.Id);

            objTeam.Id = model.Id;
            objTeam.TeamManager = model.TeamManager;
            objTeam.TeamName = model.TeamName.Trim().ToUpper();
            objTeam.Active = model.Active;

            if (operation == CrudOperation.Add)
            {
                objTeam.AddedBy = model.AddedBy;
                objTeam.AddedDate = model.AddedDate;
            }
            else
            {
                objTeam.UpdatedBy = model.UpdatedBy;
                objTeam.UpdatedDate = model.UpdatedDate;
            }




            if (operation == CrudOperation.Add)
            {
                

                objTeam.Insert();



            }
                
            else
                objTeam.Update();
        }
    }
}
