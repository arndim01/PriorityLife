using System;
using System.Linq;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.DataLayer.Base;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional Salesperson DataLayer code in this class
     /// </summary>

     internal class SalespersonDataLayer : SalespersonDataLayerBase
     {
         // constructor
         internal SalespersonDataLayer()
         {
         }

        /// <summary>
        /// Get Salesperson With Initials
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Initials"></param>
        /// <returns></returns>
        internal static Salesperson GetSalespersonWithInitials(string FirstName, string LastName, string Initials)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Salesperson.Where(c => c.LastName == LastName && c.FirstName == FirstName && c.Initials == Initials).FirstOrDefault();
        }
        /// <summary>
        /// Get Salesperson By Initials
        /// </summary>
        /// <param name="FirstNameInitial"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        internal static Salesperson GetSalespersonByInitials(string FirstNameInitial, string LastName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Salesperson.Where(c => c.Initials == LastName + " " + FirstNameInitial[0]).FirstOrDefault();
        }

        /// <summary>
        /// Check if Salesperson Exist
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        internal static bool SalespersonExist(string FirstName, string LastName, string Initials)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Salesperson.Where(c => c.LastName == LastName && c.FirstName == FirstName && c.Initials == Initials).ToList().Count > 0;
        }
        /// <summary>
        /// Check If Salesperson Exist By Initials
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        internal static bool SalespersonExistByInitials(string FirstNameInitial, string LastName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Salesperson.Where(c => c.Initials == LastName + " " + FirstNameInitial[0]).ToList().Count > 0;
        }
    }
}
