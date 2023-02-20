using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public class HierarchyFunctions
    {
        private HierarchyFunctions()
        {
        }


        /// <summary>
        /// Used when adding or updating a record.
        /// </summary>
        internal static void AddOrEdit(Hierarchy model, CrudOperation operation, bool isForListInline = false)
        {
            Hierarchy objHierarchy;

            if (operation == CrudOperation.Add)
                objHierarchy = new Hierarchy();
            else
                objHierarchy = Hierarchy.SelectByPrimaryKey(model.Id);

            objHierarchy.Id = model.Id;
            objHierarchy.SalesPersonId = model.SalesPersonId;
            objHierarchy.Upline1Id = model.Upline1Id;
            objHierarchy.Upline2Id = model.Upline2Id;
            objHierarchy.Upline3Id = model.Upline3Id;
            objHierarchy.Upline4Id = model.Upline4Id;
            objHierarchy.Upline5Id = model.Upline5Id;
            objHierarchy.Upline6Id = model.Upline6Id;
            objHierarchy.Upline7Id = model.Upline7Id;
            objHierarchy.Upline8Id = model.Upline8Id;
            objHierarchy.Upline9Id = model.Upline9Id;
            objHierarchy.Upline10Id = model.Upline10Id;
            objHierarchy.Active = model.Active;

            if( operation == CrudOperation.Add)
            {
                objHierarchy.AddedBy = model.AddedBy;
                objHierarchy.AddedDate = model.AddedDate;
            }
            else
            {
                objHierarchy.UpdatedBy = model.UpdatedBy;
                objHierarchy.UpdatedDate = model.UpdatedDate;
            }



            if (operation == CrudOperation.Add)
                objHierarchy.Insert();
            else
                objHierarchy.Update();
        }
    }
}
