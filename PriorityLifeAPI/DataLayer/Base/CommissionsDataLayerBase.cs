using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for CommissionsDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the CommissionsDataLayer class
     /// </summary>
     internal class CommissionsDataLayerBase
     {
         // constructor
         internal CommissionsDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static Commissions SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Commissions.Where(c => c.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the Commissions table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Commissions.Count();
         }

         /// <summary>
         /// Gets the total number of records in the Commissions table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salespersonIdValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime commissionDateValue = DateTime.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (salespersonId != null)
                salespersonIdValue = salespersonId.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (commissionDate != null)
                commissionDateValue = commissionDate.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Commissions
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                           (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                           (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                           (amount != null ? c.Amount == amountValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects Commissions records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<Commissions> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "SalespersonId desc":
                             return context.Commissions.OrderByDescending(c => c.SalespersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "CarrierId desc":
                             return context.Commissions.OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "CommissionDate desc":
                             return context.Commissions.OrderByDescending(c => c.CommissionDate).Skip(startRowIndex).Take(rows).ToList();
                         case "Amount desc":
                             return context.Commissions.OrderByDescending(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Commissions.OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Commissions.OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Commissions.OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Commissions.OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Commissions.OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "SalespersonId":
                             return context.Commissions.OrderBy(c => c.SalespersonId).Skip(startRowIndex).Take(rows).ToList();
                         case "CarrierId":
                             return context.Commissions.OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();
                         case "CommissionDate":
                             return context.Commissions.OrderBy(c => c.CommissionDate).Skip(startRowIndex).Take(rows).ToList();
                         case "Amount":
                             return context.Commissions.OrderBy(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Commissions.OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Commissions.OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Commissions.OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Commissions.OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Commissions.OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects Commissions records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<Commissions> SelectSkipAndTakeDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salespersonIdValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime commissionDateValue = DateTime.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (salespersonId != null)
                salespersonIdValue = salespersonId.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (commissionDate != null)
                commissionDateValue = commissionDate.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "SalespersonId desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.SalespersonId).Skip(startRowIndex).Take(rows).ToList();

                     case "CarrierId desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();

                     case "CommissionDate desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.CommissionDate).Skip(startRowIndex).Take(rows).ToList();

                     case "Amount desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
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
                     case "SalespersonId":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.SalespersonId).Skip(startRowIndex).Take(rows).ToList();

                     case "CarrierId":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.CarrierId).Skip(startRowIndex).Take(rows).ToList();

                     case "CommissionDate":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.CommissionDate).Skip(startRowIndex).Take(rows).ToList();

                     case "Amount":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Amount).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Commissions
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                                       (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                                       (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                                       (amount != null ? c.Amount == amountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all Commissions
         /// </summary>
         internal static List<Commissions> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Commissions.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Commissions.
         /// </summary>
         internal static List<Commissions> SelectAllDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int salespersonIdValue = int.MinValue;
             int carrierIdValue = int.MinValue;
             DateTime commissionDateValue = DateTime.MinValue;
             decimal amountValue = decimal.MinValue;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (salespersonId != null)
                salespersonIdValue = salespersonId.Value;

             if (carrierId != null)
                carrierIdValue = carrierId.Value;

             if (commissionDate != null)
                commissionDateValue = commissionDate.Value;

             if (amount != null)
                amountValue = amount.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Commissions
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (salespersonId != null ? c.SalespersonId == salespersonIdValue : 1 == 1) &&
                           (carrierId != null ? c.CarrierId == carrierIdValue : 1 == 1) &&
                           (commissionDate != null ? c.CommissionDate == commissionDateValue : 1 == 1) &&
                           (amount != null ? c.Amount == amountValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control
         /// </summary>
         internal static List<Commissions> SelectCommissionsDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from c in context.Commissions
                     select new Commissions { Id = c.Id, AddedBy = c.AddedBy }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(Commissions objCommissions)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Commissions entCommissions = new Commissions();

             entCommissions.SalespersonId = objCommissions.SalespersonId;
             entCommissions.CarrierId = objCommissions.CarrierId;
             entCommissions.CommissionDate = objCommissions.CommissionDate;
             entCommissions.CommissionStartDate = objCommissions.CommissionStartDate;
             entCommissions.CommissionEndDate = objCommissions.CommissionEndDate;
             entCommissions.Amount = objCommissions.Amount;
             entCommissions.AddedBy = objCommissions.AddedBy;
             entCommissions.AddedDate = objCommissions.AddedDate;
             entCommissions.UpdatedBy = objCommissions.UpdatedBy;
             entCommissions.UpdatedDate = objCommissions.UpdatedDate;

             context.Commissions.Add(entCommissions);
             context.SaveChanges();

             return entCommissions.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(Commissions objCommissions)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Commissions entCommissions = context.Commissions.Where(c => c.Id == objCommissions.Id).FirstOrDefault();

             if (entCommissions != null)
             {
                 entCommissions.SalespersonId = objCommissions.SalespersonId;
                 entCommissions.CarrierId = objCommissions.CarrierId;
                 entCommissions.CommissionDate = objCommissions.CommissionDate;
                 entCommissions.Amount = objCommissions.Amount;
                 entCommissions.AddedBy = objCommissions.AddedBy;
                 entCommissions.AddedDate = objCommissions.AddedDate;
                 entCommissions.UpdatedBy = objCommissions.UpdatedBy;
                 entCommissions.UpdatedDate = objCommissions.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objCommissions = context.Commissions.Where(c => c.Id == id).FirstOrDefault();

             if (objCommissions != null)
             {
                 context.Commissions.Remove(objCommissions);
                 context.SaveChanges();
             }
         }
     }
}
