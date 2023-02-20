using System;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.DataLayer.Base;
using System.Linq;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional Carriers DataLayer code in this class
     /// </summary>

     internal class CarriersDataLayer : CarriersDataLayerBase
     {
         // constructor
         internal CarriersDataLayer()
         {
         }

        /// <summary>
        /// Get Carriers By Shortname
        /// </summary>
        /// <param name="ShortName"></param>
        /// <returns></returns>
        internal static Carriers GetCarriersByShortName(string ShortName)
        {
            PriorityLifeContext context = new PriorityLifeContext();
            return context.Carriers.Where(c => c.ShortName == ShortName).FirstOrDefault();
        }
    }
}
