using System;
using PriorityLifeAPI.DataLayer.Base;
using System.Linq;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional CommissionsExtracted DataLayer code in this class
     /// </summary>

     internal class CommissionsExtractedDataLayer : CommissionsExtractedDataLayerBase
     {
         // constructor
         internal CommissionsExtractedDataLayer()
         {
         }
        /// <summary>
        /// Check if Extracted Commissions Data Exist
        /// </summary>
        /// <param name="Carrier"></param>
        /// <param name="PlNumber"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        internal static bool CommissionsExist(string Carrier, string PlNumber, string FirstName, string LastName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.CommissionsExtracted.Where(c => c.Carrier == Carrier && c.UCode == PlNumber && c.FirstName == FirstName && c.LastName == LastName && c.DownloadType == "BULK").ToList().Count > 0;
        }
     }
}
