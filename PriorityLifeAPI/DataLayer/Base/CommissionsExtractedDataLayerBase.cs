using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for CommissionsExtractedDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the CommissionsExtractedDataLayer class
     /// </summary>
     internal class CommissionsExtractedDataLayerBase
     {
         // constructor
         internal CommissionsExtractedDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static CommissionsExtracted SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsExtracted.Where(c => c.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsExtracted table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsExtracted.Count();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsExtracted table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime dateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (date != null)
                dateValue = date.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.CommissionsExtracted
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                           (amount != null ? c.Amount == amountValue : 1 == 1) &&
                           (date != null ? c.Date == dateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                           (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects CommissionsExtracted records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<CommissionsExtracted> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "Carrier desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.Carrier).Skip(startRowIndex).Take(rows).ToList();
                         case "FirstName desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.LastName).Skip(startRowIndex).Take(rows).ToList();
                         case "Amount desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();
                         case "Date desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.Date).Skip(startRowIndex).Take(rows).ToList();
                         case "UCode desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.UCode).Skip(startRowIndex).Take(rows).ToList();
                         case "DownloadType desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.DownloadType).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.CommissionsExtracted.OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsExtracted.OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "Carrier":
                             return context.CommissionsExtracted.OrderBy(c => c.Carrier).Skip(startRowIndex).Take(rows).ToList();
                         case "FirstName":
                             return context.CommissionsExtracted.OrderBy(c => c.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName":
                             return context.CommissionsExtracted.OrderBy(c => c.LastName).Skip(startRowIndex).Take(rows).ToList();
                         case "Amount":
                             return context.CommissionsExtracted.OrderBy(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();
                         case "Date":
                             return context.CommissionsExtracted.OrderBy(c => c.Date).Skip(startRowIndex).Take(rows).ToList();
                         case "UCode":
                             return context.CommissionsExtracted.OrderBy(c => c.UCode).Skip(startRowIndex).Take(rows).ToList();
                         case "DownloadType":
                             return context.CommissionsExtracted.OrderBy(c => c.DownloadType).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.CommissionsExtracted.OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.CommissionsExtracted.OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.CommissionsExtracted.OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.CommissionsExtracted.OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.CommissionsExtracted.OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.CommissionsExtracted.OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects CommissionsExtracted records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<CommissionsExtracted> SelectSkipAndTakeDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime dateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (date != null)
                dateValue = date.Value;

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
                     case "Carrier desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Carrier).Skip(startRowIndex).Take(rows).ToList();

                     case "FirstName desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.LastName).Skip(startRowIndex).Take(rows).ToList();

                     case "Amount desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();

                     case "Date desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Date).Skip(startRowIndex).Take(rows).ToList();

                     case "UCode desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UCode).Skip(startRowIndex).Take(rows).ToList();

                     case "DownloadType desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.DownloadType).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
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
                     case "Carrier":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Carrier).Skip(startRowIndex).Take(rows).ToList();

                     case "FirstName":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.LastName).Skip(startRowIndex).Take(rows).ToList();

                     case "Amount":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();

                     case "Date":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Date).Skip(startRowIndex).Take(rows).ToList();

                     case "UCode":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UCode).Skip(startRowIndex).Take(rows).ToList();

                     case "DownloadType":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.DownloadType).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.CommissionsExtracted
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (date != null ? c.Date == dateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
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
         /// Selects all CommissionsExtracted
         /// </summary>
         internal static List<CommissionsExtracted> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.CommissionsExtracted.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsExtracted.
         /// </summary>
         internal static List<CommissionsExtracted> SelectAllDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime dateValue = DateTime.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (date != null)
                dateValue = date.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.CommissionsExtracted
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(carrier) ? c.Carrier.Contains(carrier) : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? c.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? c.LastName.Contains(lastName) : 1 == 1) &&
                           (amount != null ? c.Amount == amountValue : 1 == 1) &&
                           (date != null ? c.Date == dateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(uCode) ? c.UCode.Contains(uCode) : 1 == 1) &&
                           (!String.IsNullOrEmpty(downloadType) ? c.DownloadType.Contains(downloadType) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and Carrier columns for use with a DropDownList web control
         /// </summary>
         internal static List<CommissionsExtracted> SelectCommissionsExtractedDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from c in context.CommissionsExtracted
                     select new CommissionsExtracted { Id = c.Id, Carrier = c.Carrier }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(CommissionsExtracted objCommissionsExtracted)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             CommissionsExtracted entCommissionsExtracted = new CommissionsExtracted();

             entCommissionsExtracted.Carrier = objCommissionsExtracted.Carrier;
             entCommissionsExtracted.FirstName = objCommissionsExtracted.FirstName;
             entCommissionsExtracted.LastName = objCommissionsExtracted.LastName;
             entCommissionsExtracted.Amount = objCommissionsExtracted.Amount;
             entCommissionsExtracted.Date = objCommissionsExtracted.Date;
             entCommissionsExtracted.UCode = objCommissionsExtracted.UCode;
             entCommissionsExtracted.DownloadType = objCommissionsExtracted.DownloadType;
             entCommissionsExtracted.Active = objCommissionsExtracted.Active;
             entCommissionsExtracted.AddedBy = objCommissionsExtracted.AddedBy;
             entCommissionsExtracted.AddedDate = objCommissionsExtracted.AddedDate;
             entCommissionsExtracted.UpdatedBy = objCommissionsExtracted.UpdatedBy;
             entCommissionsExtracted.UpdatedDate = objCommissionsExtracted.UpdatedDate;

             context.CommissionsExtracted.Add(entCommissionsExtracted);
             context.SaveChanges();

             return entCommissionsExtracted.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(CommissionsExtracted objCommissionsExtracted)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             CommissionsExtracted entCommissionsExtracted = context.CommissionsExtracted.Where(c => c.Id == objCommissionsExtracted.Id).FirstOrDefault();

             if (entCommissionsExtracted != null)
             {
                 entCommissionsExtracted.Carrier = objCommissionsExtracted.Carrier;
                 entCommissionsExtracted.FirstName = objCommissionsExtracted.FirstName;
                 entCommissionsExtracted.LastName = objCommissionsExtracted.LastName;
                 entCommissionsExtracted.Amount = objCommissionsExtracted.Amount;
                 entCommissionsExtracted.Date = objCommissionsExtracted.Date;
                 entCommissionsExtracted.UCode = objCommissionsExtracted.UCode;
                 entCommissionsExtracted.DownloadType = objCommissionsExtracted.DownloadType;
                 entCommissionsExtracted.Active = objCommissionsExtracted.Active;
                 entCommissionsExtracted.AddedBy = objCommissionsExtracted.AddedBy;
                 entCommissionsExtracted.AddedDate = objCommissionsExtracted.AddedDate;
                 entCommissionsExtracted.UpdatedBy = objCommissionsExtracted.UpdatedBy;
                 entCommissionsExtracted.UpdatedDate = objCommissionsExtracted.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objCommissionsExtracted = context.CommissionsExtracted.Where(c => c.Id == id).FirstOrDefault();

             if (objCommissionsExtracted != null)
             {
                 context.CommissionsExtracted.Remove(objCommissionsExtracted);
                 context.SaveChanges();
             }
         }
     }
}
