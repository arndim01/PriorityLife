using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for CarriersDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the CarriersDataLayer class
     /// </summary>
     internal class CarriersDataLayerBase
     {
         // constructor
         internal CarriersDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static Carriers SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Carriers.Where(c => c.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the Carriers table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Carriers.Count();
         }

         /// <summary>
         /// Gets the total number of records in the Carriers table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
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

             return context.Carriers
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                           (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                           (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects Carriers records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<Carriers> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "Name desc":
                             return context.Carriers.OrderByDescending(c => c.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "ShortName desc":
                             return context.Carriers.OrderByDescending(c => c.ShortName).Skip(startRowIndex).Take(rows).ToList();
                         case "Url desc":
                             return context.Carriers.OrderByDescending(c => c.Url).Skip(startRowIndex).Take(rows).ToList();
                         case "Username desc":
                             return context.Carriers.OrderByDescending(c => c.Username).Skip(startRowIndex).Take(rows).ToList();
                         case "Password desc":
                             return context.Carriers.OrderByDescending(c => c.Password).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Carriers.OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Carriers.OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Carriers.OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Carriers.OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Carriers.OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Carriers.OrderByDescending(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "Name":
                             return context.Carriers.OrderBy(c => c.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "ShortName":
                             return context.Carriers.OrderBy(c => c.ShortName).Skip(startRowIndex).Take(rows).ToList();
                         case "Url":
                             return context.Carriers.OrderBy(c => c.Url).Skip(startRowIndex).Take(rows).ToList();
                         case "Username":
                             return context.Carriers.OrderBy(c => c.Username).Skip(startRowIndex).Take(rows).ToList();
                         case "Password":
                             return context.Carriers.OrderBy(c => c.Password).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Carriers.OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Carriers.OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Carriers.OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Carriers.OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Carriers.OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Carriers.OrderBy(c => c.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects Carriers records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<Carriers> SelectSkipAndTakeDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
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
                     case "Name desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "ShortName desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.ShortName).Skip(startRowIndex).Take(rows).ToList();

                     case "Url desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Url).Skip(startRowIndex).Take(rows).ToList();

                     case "Username desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Username).Skip(startRowIndex).Take(rows).ToList();

                     case "Password desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Password).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
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
                     case "Name":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "ShortName":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.ShortName).Skip(startRowIndex).Take(rows).ToList();

                     case "Url":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Url).Skip(startRowIndex).Take(rows).ToList();

                     case "Username":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Username).Skip(startRowIndex).Take(rows).ToList();

                     case "Password":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Password).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                                       (active != null ? c.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(c => c.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Carriers
                             .Where(c =>
                                       (id != null ? c.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
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
         /// Selects all Carriers
         /// </summary>
         internal static List<Carriers> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Carriers.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Carriers.
         /// </summary>
         internal static List<Carriers> SelectAllDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
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

             return context.Carriers
                 .Where(c =>
                           (id != null ? c.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? c.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(shortName) ? c.ShortName.Contains(shortName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(url) ? c.Url.Contains(url) : 1 == 1) &&
                           (!String.IsNullOrEmpty(username) ? c.Username.Contains(username) : 1 == 1) &&
                           (!String.IsNullOrEmpty(password) ? c.Password.Contains(password) : 1 == 1) &&
                           (active != null ? c.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? c.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? c.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? c.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? c.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and Name columns for use with a DropDownList web control
         /// </summary>
         internal static List<Carriers> SelectCarriersDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from c in context.Carriers
                     select new Carriers { Id = c.Id, Name = c.Name }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(Carriers objCarriers)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Carriers entCarriers = new Carriers();

             entCarriers.Name = objCarriers.Name;
             entCarriers.ShortName = objCarriers.ShortName;
             entCarriers.Url = objCarriers.Url;
             entCarriers.Username = objCarriers.Username;
             entCarriers.Password = objCarriers.Password;
             entCarriers.Active = objCarriers.Active;
             entCarriers.AddedBy = objCarriers.AddedBy;
             entCarriers.AddedDate = objCarriers.AddedDate;
             entCarriers.UpdatedBy = objCarriers.UpdatedBy;
             entCarriers.UpdatedDate = objCarriers.UpdatedDate;

             context.Carriers.Add(entCarriers);
             context.SaveChanges();

             return entCarriers.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(Carriers objCarriers)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Carriers entCarriers = context.Carriers.Where(c => c.Id == objCarriers.Id).FirstOrDefault();

             if (entCarriers != null)
             {
                 entCarriers.Name = objCarriers.Name;
                 entCarriers.ShortName = objCarriers.ShortName;
                 entCarriers.Url = objCarriers.Url;
                 entCarriers.Username = objCarriers.Username;
                 entCarriers.Password = objCarriers.Password;
                 entCarriers.Active = objCarriers.Active;
                 entCarriers.AddedBy = objCarriers.AddedBy;
                 entCarriers.AddedDate = objCarriers.AddedDate;
                 entCarriers.UpdatedBy = objCarriers.UpdatedBy;
                 entCarriers.UpdatedDate = objCarriers.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objCarriers = context.Carriers.Where(c => c.Id == id).FirstOrDefault();

             if (objCarriers != null)
             {
                 context.Carriers.Remove(objCarriers);
                 context.SaveChanges();
             }
         }
     }
}
