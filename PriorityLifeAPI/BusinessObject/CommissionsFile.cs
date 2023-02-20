using System;
using System.Collections.Generic;
using PriorityLifeAPI.BusinessObject.Base;
using PriorityLifeAPI.DataLayer;

namespace PriorityLifeAPI.BusinessObject
{
     /// <summary>
     /// This file will not be overwritten.  You can put
     /// additional CommissionsFile Business Layer code in this class.
     /// </summary>
     public partial class CommissionsFile : CommissionsFileBase
     {

        /// <summary>
        /// Get All Xlsx Files By Date 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>>
        public static List<CommissionsFile> GetAllCFileByDate(DateTime date)
        {
            return CommissionsFileDataLayer.GetAllCFileByDate(date);
        }
    }
}
