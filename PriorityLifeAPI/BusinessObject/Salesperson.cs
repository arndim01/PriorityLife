using System;
using System.Linq;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional Salesperson Business Layer code in this class.
     /// </summary>
     public partial class Salesperson : SalespersonBase
     {
        /// <summary>
        /// Get Salesperson By Lastname and Surname
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Initials"></param>
        /// <returns></returns>
        public static Salesperson GetSalespersonWithInitials(string FirstName, string LastName, string Initials)
        {
            return SalespersonDataLayer.GetSalespersonWithInitials(FirstName, LastName, Initials);
        }
        /// <summary>
        /// Get Salesperson By Initials
        /// </summary>
        /// <param name="FirstNameInitial"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        public static Salesperson GetSalespersonByInitials(string FirstNameInitial, string LastName)
        {
            return SalespersonDataLayer.GetSalespersonByInitials(FirstNameInitial, LastName);
        }
        /// <summary>
        /// Check if Salesperson Exist
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Initials"></param>
        /// <returns></returns>
        public static bool SalespersonExist(string FirstName, string LastName, string Initials)
        {   
            return SalespersonDataLayer.SalespersonExist(FirstName, LastName, Initials);
        }

        /// <summary>
        /// Check If Salesperson Exist By Initials
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        public static bool SalespersonExistByInitials(string FirstNameInitial, string LastName)
        {
            return SalespersonDataLayer.SalespersonExistByInitials(FirstNameInitial, LastName);
        }
    }
}
