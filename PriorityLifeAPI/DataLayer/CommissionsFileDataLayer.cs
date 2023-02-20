using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using PriorityLifeAPI.DataLayer.Base;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer
{
     /// <summary>

     /// This file will not be overwritten.  You can put
     /// additional CommissionsFile DataLayer code in this class
     /// </summary>

     internal class CommissionsFileDataLayer : CommissionsFileDataLayerBase
     {
         // constructor
         internal CommissionsFileDataLayer()
         {
         }
        /// <summary>
        /// Get All Xlsx Files By Date 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static List<CommissionsFile> GetAllCFileByDate(DateTime date)
        {
            PriorityLifeContext context = new PriorityLifeContext();

            return context.CommissionsFile.Where(c => c.ExtractedDate.Year == date.Year && c.ExtractedDate.Month == date.Month && c.ExtractedDate.Day == date.Day && c.Extension == ".xlsx").ToList();

        }
    }
}
