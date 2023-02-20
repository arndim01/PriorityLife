using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for CommissionsFileDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the CommissionsFileDataLayer class
     /// </summary>
     internal class CommissionsFileDataLayerBase
     {
         // constructor
         internal CommissionsFileDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static CommissionsFile SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsFile.Where(c => c.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsFile.Count();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table by CarrierId
         /// </summary>
         internal static int GetRecordCountByCarrierId(int carrierId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsFile.Where(c => c.CarrierId == carrierId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime extractedDateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (extractedDate != null)
                extractedDateValue = extractedDate.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.CommissionsFile
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                           (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                           (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects CommissionsFile records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<CommissionsFile> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "CarrierId desc":
                             return context.CommissionsFile.OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "ExtractedDate desc":
                             return context.CommissionsFile.OrderByDescending(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "FileUrl desc":
                             return context.CommissionsFile.OrderByDescending(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                         case "Extension desc":
                             return context.CommissionsFile.OrderByDescending(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.CommissionsFile.OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.CommissionsFile.OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.CommissionsFile.OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.CommissionsFile.OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.CommissionsFile.OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsFile.OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "CarrierId":
                             return context.CommissionsFile.OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "ExtractedDate":
                             return context.CommissionsFile.OrderBy(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "FileUrl":
                             return context.CommissionsFile.OrderBy(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                         case "Extension":
                             return context.CommissionsFile.OrderBy(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.CommissionsFile.OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.CommissionsFile.OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.CommissionsFile.OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.CommissionsFile.OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.CommissionsFile.OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsFile.OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "CarrierId desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "ExtractedDate desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "FileUrl desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                         case "Extension desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "CarrierId":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "ExtractedDate":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "FileUrl":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                         case "Extension":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsFile.Include(c => c.CarrierIdNavigation).OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by CarrierId as a collection (List) of CommissionsFile sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<CommissionsFile> SelectSkipAndTakeByCarrierId(string sortByExpression, int startRowIndex, int rows, int carrierId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "CarrierId desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                     case "ExtractedDate desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "FileUrl desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                     case "Extension desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "CarrierId":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                     case "ExtractedDate":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "FileUrl":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();
                     case "Extension":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.CommissionsFile.Where(c => c.CarrierId == carrierId).OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects CommissionsFile records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<CommissionsFile> SelectSkipAndTakeDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime extractedDateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (extractedDate != null)
                extractedDateValue = extractedDate.Value;

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
                     case "CarrierId desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();

                     case "ExtractedDate desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "FileUrl desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();

                     case "Extension desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "CarrierId":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();

                     case "ExtractedDate":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.ExtractedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "FileUrl":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.FileUrl).Skip(startRowIndex).Take(rows).ToList();

                     case "Extension":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Extension).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.CommissionsFile
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all CommissionsFile
         /// </summary>
         internal static List<CommissionsFile> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsFile.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsFile.
         /// </summary>
         internal static List<CommissionsFile> SelectAllDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime extractedDateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (extractedDate != null)
                extractedDateValue = extractedDate.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.CommissionsFile
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                           (extractedDate != null ? c.ExtractedDate == extractedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(fileUrl) ? c.FileUrl.Contains(fileUrl) : 1 == 1) &&
                           (!String.IsNullOrEmpty(extension) ? c.Extension.Contains(extension) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all CommissionsFile by Carriers, related to column CarrierId
         /// </summary>
         internal static List<CommissionsFile> SelectCommissionsFileCollectionByCarrierId(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsFile.Where(c => c.CarrierId == id).ToList();
         }
         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control
         /// </summary>
         internal static List<CommissionsFile> SelectCommissionsFileDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from c in context.CommissionsFile
                     select new CommissionsFile { Id = c.Id, AddedBy = c.AddedBy }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(CommissionsFile objCommissionsFile)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             CommissionsFile entCommissionsFile = new CommissionsFile();

             entCommissionsFile.CarrierId = objCommissionsFile.CarrierId;
             entCommissionsFile.ExtractedDate = objCommissionsFile.ExtractedDate;
             entCommissionsFile.FileUrl = objCommissionsFile.FileUrl;
             entCommissionsFile.Extension = objCommissionsFile.Extension;
             entCommissionsFile.Active = objCommissionsFile.Active;
             entCommissionsFile.AddedBy = objCommissionsFile.AddedBy;
             entCommissionsFile.AddedDate = objCommissionsFile.AddedDate;
             entCommissionsFile.UpdatedBy = objCommissionsFile.UpdatedBy;
             entCommissionsFile.UpdatedDate = objCommissionsFile.UpdatedDate;

             context.CommissionsFile.Add(entCommissionsFile);
             context.SaveChanges();

             return entCommissionsFile.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(CommissionsFile objCommissionsFile)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             CommissionsFile entCommissionsFile = context.CommissionsFile.Where(c => c.Id == objCommissionsFile.Id).FirstOrDefault();

             if (entCommissionsFile != null)
             {
                 entCommissionsFile.CarrierId = objCommissionsFile.CarrierId;
                 entCommissionsFile.ExtractedDate = objCommissionsFile.ExtractedDate;
                 entCommissionsFile.FileUrl = objCommissionsFile.FileUrl;
                 entCommissionsFile.Extension = objCommissionsFile.Extension;
                 entCommissionsFile.Active = objCommissionsFile.Active;
                 entCommissionsFile.AddedBy = objCommissionsFile.AddedBy;
                 entCommissionsFile.AddedDate = objCommissionsFile.AddedDate;
                 entCommissionsFile.UpdatedBy = objCommissionsFile.UpdatedBy;
                 entCommissionsFile.UpdatedDate = objCommissionsFile.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objCommissionsFile = context.CommissionsFile.Where(c => c.Id == id).FirstOrDefault();

             if (objCommissionsFile != null)
             {
                 context.CommissionsFile.Remove(objCommissionsFile);
                 context.SaveChanges();
             }
         }
     }
}
