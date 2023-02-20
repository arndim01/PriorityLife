using System;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional CommissionsExtracted Business Layer code in this class.
     /// </summary>
     public partial class CommissionsExtracted : CommissionsExtractedBase
     {

        /// <summary>
        /// Check if Extracted Commissions Data Exist
        /// </summary>
        /// <param name="Carrier"></param>
        /// <param name="PlNumber"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        public static bool CommissionsExist(string Carrier, string PlNumber, string FirstName, string LastName)
        {
            return CommissionsExtractedDataLayer.CommissionsExist(Carrier, PlNumber, FirstName, LastName);
        }
    }
}
