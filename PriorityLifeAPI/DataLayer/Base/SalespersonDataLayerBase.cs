using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for SalespersonDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the SalespersonDataLayer class
     /// </summary>
     internal class SalespersonDataLayerBase
     {
         // constructor
         internal SalespersonDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static Salesperson SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Salesperson.Where(s => s.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the Salesperson table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Salesperson.Count();
         }

         /// <summary>
         /// Gets the total number of records in the Salesperson table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;
             return context.Salesperson
                 .Where(s =>
                           (id != null ? s.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                           (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                           (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                           (active != null ? s.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects Salesperson records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<Salesperson> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "FirstName desc":
                             return context.Salesperson.OrderByDescending(s => s.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "MiddleName desc":
                             return context.Salesperson.OrderByDescending(s => s.MiddleName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName desc":
                             return context.Salesperson.OrderByDescending(s => s.LastName).Skip(startRowIndex).Take(rows).ToList();
                         case "Initials desc":
                             return context.Salesperson.OrderByDescending(s => s.Initials).Skip(startRowIndex).Take(rows).ToList();
                         case "Email desc":
                             return context.Salesperson.OrderByDescending(s => s.Email).Skip(startRowIndex).Take(rows).ToList();
                         case "Phone desc":
                             return context.Salesperson.OrderByDescending(s => s.Phone).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Salesperson.OrderByDescending(s => s.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Salesperson.OrderByDescending(s => s.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Salesperson.OrderByDescending(s => s.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Salesperson.OrderByDescending(s => s.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Salesperson.OrderByDescending(s => s.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Salesperson.OrderByDescending(s => s.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "FirstName":
                             return context.Salesperson.OrderBy(s => s.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "MiddleName":
                             return context.Salesperson.OrderBy(s => s.MiddleName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName":
                             return context.Salesperson.OrderBy(s => s.LastName).Skip(startRowIndex).Take(rows).ToList();
                         case "Initials":
                             return context.Salesperson.OrderBy(s => s.Initials).Skip(startRowIndex).Take(rows).ToList();
                         case "Email":
                             return context.Salesperson.OrderBy(s => s.Email).Skip(startRowIndex).Take(rows).ToList();
                         case "Phone":
                             return context.Salesperson.OrderBy(s => s.Phone).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Salesperson.OrderBy(s => s.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Salesperson.OrderBy(s => s.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Salesperson.OrderBy(s => s.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Salesperson.OrderBy(s => s.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Salesperson.OrderBy(s => s.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Salesperson.OrderBy(s => s.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects Salesperson records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<Salesperson> SelectSkipAndTakeDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

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
                     case "FirstName desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "MiddleName desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.MiddleName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.LastName).Skip(startRowIndex).Take(rows).ToList();

                     case "Initials desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.Initials).Skip(startRowIndex).Take(rows).ToList();

                     case "Email desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.Email).Skip(startRowIndex).Take(rows).ToList();

                     case "Phone desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.Phone).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(s => s.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "FirstName":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "MiddleName":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.MiddleName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.LastName).Skip(startRowIndex).Take(rows).ToList();

                     case "Initials":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.Initials).Skip(startRowIndex).Take(rows).ToList();

                     case "Email":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.Email).Skip(startRowIndex).Take(rows).ToList();

                     case "Phone":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.Phone).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Salesperson
                             .Where(s =>
                                       (id != null ? s.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                                       (active != null ? s.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(s => s.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all Salesperson
         /// </summary>
         internal static List<Salesperson> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Salesperson.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Salesperson.
         /// </summary>
         internal static List<Salesperson> SelectAllDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Salesperson
                 .Where(s =>
                           (id != null ? s.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? s.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(middleName) ? s.MiddleName.Contains(middleName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? s.LastName.Contains(lastName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(initials) ? s.Initials.Contains(initials) : 1 == 1) &&
                           (!String.IsNullOrEmpty(email) ? s.Email.Contains(email) : 1 == 1) &&
                           (!String.IsNullOrEmpty(phone) ? s.Phone.Contains(phone) : 1 == 1) &&
                           (active != null ? s.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? s.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? s.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? s.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? s.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and FirstName columns for use with a DropDownList web control
         /// </summary>
         internal static List<Salesperson> SelectSalespersonDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from s in context.Salesperson
                     select new Salesperson { Id = s.Id, FirstName = s.FirstName + " " + s.LastName , }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(Salesperson objSalesperson)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Salesperson entSalesperson = new Salesperson();

             entSalesperson.FirstName = objSalesperson.FirstName;
             entSalesperson.MiddleName = objSalesperson.MiddleName;
             entSalesperson.LastName = objSalesperson.LastName;
             entSalesperson.Initials = objSalesperson.Initials;
             entSalesperson.Email = objSalesperson.Email;
             entSalesperson.Phone = objSalesperson.Phone;
             entSalesperson.Active = objSalesperson.Active;
             entSalesperson.AddedBy = objSalesperson.AddedBy;
             entSalesperson.AddedDate = objSalesperson.AddedDate;
             entSalesperson.UpdatedBy = objSalesperson.UpdatedBy;
             entSalesperson.UpdatedDate = objSalesperson.UpdatedDate;

             context.Salesperson.Add(entSalesperson);
             context.SaveChanges();

             return entSalesperson.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(Salesperson objSalesperson)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Salesperson entSalesperson = context.Salesperson.Where(s => s.Id == objSalesperson.Id).FirstOrDefault();

             if (entSalesperson != null)
             {
                 entSalesperson.FirstName = objSalesperson.FirstName;
                 entSalesperson.MiddleName = objSalesperson.MiddleName;
                 entSalesperson.LastName = objSalesperson.LastName;
                 entSalesperson.Initials = objSalesperson.Initials;
                 entSalesperson.Email = objSalesperson.Email;
                 entSalesperson.Phone = objSalesperson.Phone;
                 entSalesperson.Active = objSalesperson.Active;
                 entSalesperson.AddedBy = objSalesperson.AddedBy;
                 entSalesperson.AddedDate = objSalesperson.AddedDate;
                 entSalesperson.UpdatedBy = objSalesperson.UpdatedBy;
                 entSalesperson.UpdatedDate = objSalesperson.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objSalesperson = context.Salesperson.Where(s => s.Id == id).FirstOrDefault();

             if (objSalesperson != null)
             {
                 context.Salesperson.Remove(objSalesperson);
                 context.SaveChanges();
             }
         }
     }
}
