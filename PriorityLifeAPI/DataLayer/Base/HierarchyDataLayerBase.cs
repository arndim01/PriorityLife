using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for HierarchyDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the HierarchyDataLayer class
     /// </summary>
     internal class HierarchyDataLayerBase
     {
         // constructor
         internal HierarchyDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static Hierarchy SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by SalesPersonId
         /// </summary>
         internal static int GetRecordCountBySalesPersonId(int salesPersonId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline1Id
         /// </summary>
         internal static int GetRecordCountByUpline1Id(int upline1Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline2Id
         /// </summary>
         internal static int GetRecordCountByUpline2Id(int upline2Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline3Id
         /// </summary>
         internal static int GetRecordCountByUpline3Id(int upline3Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline4Id
         /// </summary>
         internal static int GetRecordCountByUpline4Id(int upline4Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline5Id
         /// </summary>
         internal static int GetRecordCountByUpline5Id(int upline5Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline6Id
         /// </summary>
         internal static int GetRecordCountByUpline6Id(int upline6Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline7Id
         /// </summary>
         internal static int GetRecordCountByUpline7Id(int upline7Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline8Id
         /// </summary>
         internal static int GetRecordCountByUpline8Id(int upline8Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline9Id
         /// </summary>
         internal static int GetRecordCountByUpline9Id(int upline9Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline10Id
         /// </summary>
         internal static int GetRecordCountByUpline10Id(int upline10Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salesPersonIdValue = int.MinValue;
             int upline1IdValue = int.MinValue;
             int upline2IdValue = int.MinValue;
             int upline3IdValue = int.MinValue;
             int upline4IdValue = int.MinValue;
             int upline5IdValue = int.MinValue;
             int upline6IdValue = int.MinValue;
             int upline7IdValue = int.MinValue;
             int upline8IdValue = int.MinValue;
             int upline9IdValue = int.MinValue;
             int upline10IdValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (salesPersonId != null)
                salesPersonIdValue = salesPersonId.Value;

             if (upline1Id != null)
                upline1IdValue = upline1Id.Value;

             if (upline2Id != null)
                upline2IdValue = upline2Id.Value;

             if (upline3Id != null)
                upline3IdValue = upline3Id.Value;

             if (upline4Id != null)
                upline4IdValue = upline4Id.Value;

             if (upline5Id != null)
                upline5IdValue = upline5Id.Value;

             if (upline6Id != null)
                upline6IdValue = upline6Id.Value;

             if (upline7Id != null)
                upline7IdValue = upline7Id.Value;

             if (upline8Id != null)
                upline8IdValue = upline8Id.Value;

             if (upline9Id != null)
                upline9IdValue = upline9Id.Value;

             if (upline10Id != null)
                upline10IdValue = upline10Id.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Hierarchy
                 .Where(h =>
                           (id != null ? h.Id == idValue : 1 == 1) &&
                           (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                           (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                           (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                           (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                           (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                           (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                           (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                           (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                           (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                           (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                           (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                           (active != null ? h.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects Hierarchy records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "SalesPersonId desc":
                             return context.Hierarchy.OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline1Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline2Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline3Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline4Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline5Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline6Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline7Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline8Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline9Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline10Id desc":
                             return context.Hierarchy.OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Hierarchy.OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Hierarchy.OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Hierarchy.OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Hierarchy.OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Hierarchy.OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Hierarchy.OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "SalesPersonId":
                             return context.Hierarchy.OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline1Id":
                             return context.Hierarchy.OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline2Id":
                             return context.Hierarchy.OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline3Id":
                             return context.Hierarchy.OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline4Id":
                             return context.Hierarchy.OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline5Id":
                             return context.Hierarchy.OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline6Id":
                             return context.Hierarchy.OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline7Id":
                             return context.Hierarchy.OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline8Id":
                             return context.Hierarchy.OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline9Id":
                             return context.Hierarchy.OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline10Id":
                             return context.Hierarchy.OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Hierarchy.OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Hierarchy.OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Hierarchy.OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Hierarchy.OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Hierarchy.OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Hierarchy.OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "SalesPersonId desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline1Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline2Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline3Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline4Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline5Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline6Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline7Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline8Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline9Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline10Id desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "SalesPersonId":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline1Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline2Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline3Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline4Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline5Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline6Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline7Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline8Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline9Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Upline10Id":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Hierarchy.Include(h => h.SalesPersonIdNavigation).Include(h => h.Upline1IdNavigation).Include(h => h.Upline2IdNavigation).Include(h => h.Upline3IdNavigation).Include(h => h.Upline4IdNavigation).Include(h => h.Upline5IdNavigation).Include(h => h.Upline6IdNavigation).Include(h => h.Upline7IdNavigation).Include(h => h.Upline8IdNavigation).Include(h => h.Upline9IdNavigation).Include(h => h.Upline10IdNavigation).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by SalesPersonId as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeBySalesPersonId(string sortByExpression, int startRowIndex, int rows, int salesPersonId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.SalesPersonId == salesPersonId).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline1Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline1Id(string sortByExpression, int startRowIndex, int rows, int upline1Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline1Id == upline1Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline2Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline2Id(string sortByExpression, int startRowIndex, int rows, int upline2Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline2Id == upline2Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline3Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline3Id(string sortByExpression, int startRowIndex, int rows, int upline3Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline3Id == upline3Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline4Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline4Id(string sortByExpression, int startRowIndex, int rows, int upline4Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline4Id == upline4Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline5Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline5Id(string sortByExpression, int startRowIndex, int rows, int upline5Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline5Id == upline5Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline6Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline6Id(string sortByExpression, int startRowIndex, int rows, int upline6Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline6Id == upline6Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline7Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline7Id(string sortByExpression, int startRowIndex, int rows, int upline7Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline7Id == upline7Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline8Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline8Id(string sortByExpression, int startRowIndex, int rows, int upline8Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline8Id == upline8Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline9Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline9Id(string sortByExpression, int startRowIndex, int rows, int upline9Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline9Id == upline9Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by Upline10Id as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeByUpline10Id(string sortByExpression, int startRowIndex, int rows, int upline10Id)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline1Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline2Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline3Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline4Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline5Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline6Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline7Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline8Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline9Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Upline10Id":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Hierarchy.Where(h => h.Upline10Id == upline10Id).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects Hierarchy records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<Hierarchy> SelectSkipAndTakeDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salesPersonIdValue = int.MinValue;
             int upline1IdValue = int.MinValue;
             int upline2IdValue = int.MinValue;
             int upline3IdValue = int.MinValue;
             int upline4IdValue = int.MinValue;
             int upline5IdValue = int.MinValue;
             int upline6IdValue = int.MinValue;
             int upline7IdValue = int.MinValue;
             int upline8IdValue = int.MinValue;
             int upline9IdValue = int.MinValue;
             int upline10IdValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (salesPersonId != null)
                salesPersonIdValue = salesPersonId.Value;

             if (upline1Id != null)
                upline1IdValue = upline1Id.Value;

             if (upline2Id != null)
                upline2IdValue = upline2Id.Value;

             if (upline3Id != null)
                upline3IdValue = upline3Id.Value;

             if (upline4Id != null)
                upline4IdValue = upline4Id.Value;

             if (upline5Id != null)
                upline5IdValue = upline5Id.Value;

             if (upline6Id != null)
                upline6IdValue = upline6Id.Value;

             if (upline7Id != null)
                upline7IdValue = upline7Id.Value;

             if (upline8Id != null)
                upline8IdValue = upline8Id.Value;

             if (upline9Id != null)
                upline9IdValue = upline9Id.Value;

             if (upline10Id != null)
                upline10IdValue = upline10Id.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline1Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline2Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline3Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline4Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline5Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline6Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline7Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline8Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline9Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline10Id desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "SalesPersonId":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.SalesPersonId).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline1Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline1Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline2Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline2Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline3Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline3Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline4Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline4Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline5Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline5Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline6Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline6Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline7Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline7Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline8Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline8Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline9Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline9Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Upline10Id":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Upline10Id).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Hierarchy
                             .Where(h =>
                                       (id != null ? h.Id == idValue : 1 == 1) &&
                                       (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                                       (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                                       (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                                       (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                                       (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                                       (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                                       (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                                       (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                                       (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                                       (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                                       (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                                       (active != null ? h.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(h => h.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all Hierarchy
         /// </summary>
         internal static List<Hierarchy> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Hierarchy.
         /// </summary>
         internal static List<Hierarchy> SelectAllDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salesPersonIdValue = int.MinValue;
             int upline1IdValue = int.MinValue;
             int upline2IdValue = int.MinValue;
             int upline3IdValue = int.MinValue;
             int upline4IdValue = int.MinValue;
             int upline5IdValue = int.MinValue;
             int upline6IdValue = int.MinValue;
             int upline7IdValue = int.MinValue;
             int upline8IdValue = int.MinValue;
             int upline9IdValue = int.MinValue;
             int upline10IdValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (salesPersonId != null)
                salesPersonIdValue = salesPersonId.Value;

             if (upline1Id != null)
                upline1IdValue = upline1Id.Value;

             if (upline2Id != null)
                upline2IdValue = upline2Id.Value;

             if (upline3Id != null)
                upline3IdValue = upline3Id.Value;

             if (upline4Id != null)
                upline4IdValue = upline4Id.Value;

             if (upline5Id != null)
                upline5IdValue = upline5Id.Value;

             if (upline6Id != null)
                upline6IdValue = upline6Id.Value;

             if (upline7Id != null)
                upline7IdValue = upline7Id.Value;

             if (upline8Id != null)
                upline8IdValue = upline8Id.Value;

             if (upline9Id != null)
                upline9IdValue = upline9Id.Value;

             if (upline10Id != null)
                upline10IdValue = upline10Id.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Hierarchy
                 .Where(h =>
                           (id != null ? h.Id == idValue : 1 == 1) &&
                           (salesPersonId != null ? h.SalesPersonId == salesPersonIdValue : 1 == 1) &&
                           (upline1Id != null ? h.Upline1Id == upline1IdValue : 1 == 1) &&
                           (upline2Id != null ? h.Upline2Id == upline2IdValue : 1 == 1) &&
                           (upline3Id != null ? h.Upline3Id == upline3IdValue : 1 == 1) &&
                           (upline4Id != null ? h.Upline4Id == upline4IdValue : 1 == 1) &&
                           (upline5Id != null ? h.Upline5Id == upline5IdValue : 1 == 1) &&
                           (upline6Id != null ? h.Upline6Id == upline6IdValue : 1 == 1) &&
                           (upline7Id != null ? h.Upline7Id == upline7IdValue : 1 == 1) &&
                           (upline8Id != null ? h.Upline8Id == upline8IdValue : 1 == 1) &&
                           (upline9Id != null ? h.Upline9Id == upline9IdValue : 1 == 1) &&
                           (upline10Id != null ? h.Upline10Id == upline10IdValue : 1 == 1) &&
                           (active != null ? h.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? h.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? h.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? h.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? h.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column SalesPersonId
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionBySalesPersonId(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.SalesPersonId == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline1Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline1Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline1Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline2Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline2Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline2Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline3Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline3Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline3Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline4Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline4Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline4Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline5Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline5Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline5Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline6Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline6Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline6Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline7Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline7Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline7Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline8Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline8Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline8Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline9Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline9Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline9Id == id).ToList();
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline10Id
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyCollectionByUpline10Id(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Hierarchy.Where(h => h.Upline10Id == id).ToList();
         }
         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control
         /// </summary>
         internal static List<Hierarchy> SelectHierarchyDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from h in context.Hierarchy
                     select new Hierarchy { Id = h.Id, AddedBy = h.AddedBy }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(Hierarchy objHierarchy)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Hierarchy entHierarchy = new Hierarchy();

             entHierarchy.SalesPersonId = objHierarchy.SalesPersonId;
             entHierarchy.Upline1Id = objHierarchy.Upline1Id;
             entHierarchy.Upline2Id = objHierarchy.Upline2Id;
             entHierarchy.Upline3Id = objHierarchy.Upline3Id;
             entHierarchy.Upline4Id = objHierarchy.Upline4Id;
             entHierarchy.Upline5Id = objHierarchy.Upline5Id;
             entHierarchy.Upline6Id = objHierarchy.Upline6Id;
             entHierarchy.Upline7Id = objHierarchy.Upline7Id;
             entHierarchy.Upline8Id = objHierarchy.Upline8Id;
             entHierarchy.Upline9Id = objHierarchy.Upline9Id;
             entHierarchy.Upline10Id = objHierarchy.Upline10Id;
             entHierarchy.Active = objHierarchy.Active;
             entHierarchy.AddedBy = objHierarchy.AddedBy;
             entHierarchy.AddedDate = objHierarchy.AddedDate;
             entHierarchy.UpdatedBy = objHierarchy.UpdatedBy;
             entHierarchy.UpdatedDate = objHierarchy.UpdatedDate;

             context.Hierarchy.Add(entHierarchy);
             context.SaveChanges();

             return entHierarchy.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(Hierarchy objHierarchy)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Hierarchy entHierarchy = context.Hierarchy.Where(h => h.Id == objHierarchy.Id).FirstOrDefault();

             if (entHierarchy != null)
             {
                 entHierarchy.SalesPersonId = objHierarchy.SalesPersonId;
                 entHierarchy.Upline1Id = objHierarchy.Upline1Id;
                 entHierarchy.Upline2Id = objHierarchy.Upline2Id;
                 entHierarchy.Upline3Id = objHierarchy.Upline3Id;
                 entHierarchy.Upline4Id = objHierarchy.Upline4Id;
                 entHierarchy.Upline5Id = objHierarchy.Upline5Id;
                 entHierarchy.Upline6Id = objHierarchy.Upline6Id;
                 entHierarchy.Upline7Id = objHierarchy.Upline7Id;
                 entHierarchy.Upline8Id = objHierarchy.Upline8Id;
                 entHierarchy.Upline9Id = objHierarchy.Upline9Id;
                 entHierarchy.Upline10Id = objHierarchy.Upline10Id;
                 entHierarchy.Active = objHierarchy.Active;
                 entHierarchy.AddedBy = objHierarchy.AddedBy;
                 entHierarchy.AddedDate = objHierarchy.AddedDate;
                 entHierarchy.UpdatedBy = objHierarchy.UpdatedBy;
                 entHierarchy.UpdatedDate = objHierarchy.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objHierarchy = context.Hierarchy.Where(h => h.Id == id).FirstOrDefault();

             if (objHierarchy != null)
             {
                 context.Hierarchy.Remove(objHierarchy);
                 context.SaveChanges();
             }
         }
     }
}
