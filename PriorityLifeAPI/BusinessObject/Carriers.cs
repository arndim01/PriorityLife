using System;
using System.Collections.Generic;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional Carriers Business Layer code in this class.
     /// </summary>
     public partial class Carriers : CarriersBase
     {

        /// <summary>
        /// Get Carriers By Shortname
        /// </summary>
        /// <param name="ShortName"></param>
        /// <returns></returns>
        public static Carriers GetCarriersByShortName(string shortName)
        {
            return CarriersDataLayer.GetCarriersByShortName(shortName);
        }
    }
}
