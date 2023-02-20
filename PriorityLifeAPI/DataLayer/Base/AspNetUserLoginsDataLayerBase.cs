using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetUserLoginsDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserLoginsDataLayer class
     /// </summary>
     internal class AspNetUserLoginsDataLayerBase
     {
         // constructor
         internal AspNetUserLoginsDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetUserLogins SelectByPrimaryKey(string loginProvider, string providerKey)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserLogins.Where(a => a.LoginProvider == loginProvider &&a.ProviderKey == providerKey).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserLogins.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table by UserId
         /// </summary>
         internal static int GetRecordCountByUserId(string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserLogins.Where(a => a.UserId == userId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetUserLogins
                 .Where(a =>
                           (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                           (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                           (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetUserLogins records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetUserLogins> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "ProviderKey desc":
                             return context.AspNetUserLogins.OrderByDescending(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                         case "ProviderDisplayName desc":
                             return context.AspNetUserLogins.OrderByDescending(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                         case "UserId desc":
                             return context.AspNetUserLogins.OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserLogins.OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "ProviderKey":
                             return context.AspNetUserLogins.OrderBy(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                         case "ProviderDisplayName":
                             return context.AspNetUserLogins.OrderBy(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                         case "UserId":
                             return context.AspNetUserLogins.OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserLogins.OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "ProviderKey desc":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderByDescending(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                         case "ProviderDisplayName desc":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderByDescending(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                         case "UserId desc":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "ProviderKey":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderBy(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                         case "ProviderDisplayName":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderBy(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                         case "UserId":
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserLogins.Include(a => a.UserIdNavigation).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserLogins sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<AspNetUserLogins> SelectSkipAndTakeByUserId(string sortByExpression, int startRowIndex, int rows, string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "ProviderKey desc":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderByDescending(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                     case "ProviderDisplayName desc":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderByDescending(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                     case "UserId desc":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "ProviderKey":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderBy(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();
                     case "ProviderDisplayName":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderBy(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();
                     case "UserId":
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserLogins.Where(a => a.UserId == userId).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects AspNetUserLogins records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetUserLogins> SelectSkipAndTakeDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "ProviderKey desc":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderByDescending(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();

                     case "ProviderDisplayName desc":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderByDescending(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();

                     case "UserId desc":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "ProviderKey":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderBy(a => a.ProviderKey).Skip(startRowIndex).Take(rows).ToList();

                     case "ProviderDisplayName":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderBy(a => a.ProviderDisplayName).Skip(startRowIndex).Take(rows).ToList();

                     case "UserId":
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserLogins
                             .Where(a =>
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                                   ).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetUserLogins
         /// </summary>
         internal static List<AspNetUserLogins> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserLogins.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserLogins.
         /// </summary>
         internal static List<AspNetUserLogins> SelectAllDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetUserLogins
                 .Where(a =>
                           (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                           (!String.IsNullOrEmpty(providerKey) ? a.ProviderKey.Contains(providerKey) : 1 == 1) &&
                           (!String.IsNullOrEmpty(providerDisplayName) ? a.ProviderDisplayName.Contains(providerDisplayName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all AspNetUserLogins by AspNetUsers, related to column UserId
         /// </summary>
         internal static List<AspNetUserLogins> SelectAspNetUserLoginsCollectionByUserId(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserLogins.Where(a => a.UserId == id).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static void Insert(AspNetUserLogins objAspNetUserLogins)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserLogins entAspNetUserLogins = new AspNetUserLogins();

             entAspNetUserLogins.LoginProvider = objAspNetUserLogins.LoginProvider;
             entAspNetUserLogins.ProviderKey = objAspNetUserLogins.ProviderKey;
             entAspNetUserLogins.ProviderDisplayName = objAspNetUserLogins.ProviderDisplayName;
             entAspNetUserLogins.UserId = objAspNetUserLogins.UserId;

             context.AspNetUserLogins.Add(entAspNetUserLogins);
             context.SaveChanges();
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetUserLogins objAspNetUserLogins)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserLogins entAspNetUserLogins = context.AspNetUserLogins.Where(a => a.LoginProvider == objAspNetUserLogins.LoginProvider &&a.ProviderKey == objAspNetUserLogins.ProviderKey).FirstOrDefault();

             if (entAspNetUserLogins != null)
             {
                 entAspNetUserLogins.ProviderDisplayName = objAspNetUserLogins.ProviderDisplayName;
                 entAspNetUserLogins.UserId = objAspNetUserLogins.UserId;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(string loginProvider, string providerKey)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetUserLogins = context.AspNetUserLogins.Where(a => a.LoginProvider == loginProvider).FirstOrDefault();

             if (objAspNetUserLogins != null)
             {
                 context.AspNetUserLogins.Remove(objAspNetUserLogins);
                 context.SaveChanges();
             }
         }
     }
}
