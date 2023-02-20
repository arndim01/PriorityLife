using PriorityLifeAPI.Domain;
using PriorityLifeAPI.BusinessObject;
using System;

namespace PriorityLifeWebInterface
{
    public class SalespersonFunctions
    {
        private SalespersonFunctions()
        {
        }


        /// <summary>
        /// Used when adding or updating a record.
        /// </summary>
        internal static void AddOrEdit(Salesperson model, CrudOperation operation, bool isForListInline = false)
        {
            Salesperson objSalesperson;

            if (operation == CrudOperation.Add)
                objSalesperson = new Salesperson();
            else
                objSalesperson = Salesperson.SelectByPrimaryKey(model.Id);

            objSalesperson.Id = model.Id;
            objSalesperson.FirstName = model.FirstName.ToUpper();
            objSalesperson.MiddleName = model.MiddleName == null ? "": model.MiddleName.ToUpper() ;
            objSalesperson.LastName = model.LastName.ToUpper();
            objSalesperson.Initials = model.Initials.ToUpper();
            objSalesperson.Email = model.Email;
            objSalesperson.Phone = model.Phone;
            objSalesperson.Active = model.Active;

            if ( operation == CrudOperation.Add)
            {
                objSalesperson.AddedBy = model.AddedBy;
                objSalesperson.AddedDate = model.AddedDate;
            }
            else
            {
                objSalesperson.UpdatedBy = model.UpdatedBy;
                objSalesperson.UpdatedDate = model.UpdatedDate;
            }



            if (operation == CrudOperation.Add)
                objSalesperson.Insert();
            else
                objSalesperson.Update();
        }
    }
}
