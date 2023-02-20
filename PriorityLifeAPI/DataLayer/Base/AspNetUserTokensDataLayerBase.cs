using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetUserTokensDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserTokensDataLayer class
     /// </summary>
     internal class AspNetUserTokensDataLayerBase
     {
         // constructor
         internal AspNetUserTokensDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetUserTokens SelectByPrimaryKey(string userId, string loginProvider, string name)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserTokens.Where(a => a.UserId == userId &&a.LoginProvider == loginProvider &&a.Name == name).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserTokens.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table by UserId
         /// </summary>
         internal static int GetRecordCountByUserId(string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserTokens.Where(a => a.UserId == userId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(string userId, string loginProvider, string name, string value)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetUserTokens
                 .Where(a =>
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetUserTokens records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetUserTokens> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "LoginProvider desc":
                             return context.AspNetUserTokens.OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                         case "Name desc":
                             return context.AspNetUserTokens.OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "Value desc":
                             return context.AspNetUserTokens.OrderByDescending(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserTokens.OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "LoginProvider":
                             return context.AspNetUserTokens.OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                         case "Name":
                             return context.AspNetUserTokens.OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "Value":
                             return context.AspNetUserTokens.OrderBy(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserTokens.OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "LoginProvider desc":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                         case "Name desc":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "Value desc":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderByDescending(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "LoginProvider":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                         case "Name":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "Value":
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderBy(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserTokens.Include(a => a.UserIdNavigation).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserTokens sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<AspNetUserTokens> SelectSkipAndTakeByUserId(string sortByExpression, int startRowIndex, int rows, string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "LoginProvider desc":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     case "Name desc":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                     case "Value desc":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderByDescending(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "LoginProvider":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();
                     case "Name":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                     case "Value":
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderBy(a => a.Value).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserTokens.Where(a => a.UserId == userId).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects AspNetUserTokens records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetUserTokens> SelectSkipAndTakeDynamicWhere(string userId, string loginProvider, string name, string value, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "LoginProvider desc":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderByDescending(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();

                     case "Name desc":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "Value desc":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderByDescending(a => a.Value).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "LoginProvider":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderBy(a => a.LoginProvider).Skip(startRowIndex).Take(rows).ToList();

                     case "Name":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "Value":
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderBy(a => a.Value).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserTokens
                             .Where(a =>
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                                   ).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetUserTokens
         /// </summary>
         internal static List<AspNetUserTokens> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserTokens.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserTokens.
         /// </summary>
         internal static List<AspNetUserTokens> SelectAllDynamicWhere(string userId, string loginProvider, string name, string value)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetUserTokens
                 .Where(a =>
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(loginProvider) ? a.LoginProvider.Contains(loginProvider) : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(value) ? a.Value.Contains(value) : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all AspNetUserTokens by AspNetUsers, related to column UserId
         /// </summary>
         internal static List<AspNetUserTokens> SelectAspNetUserTokensCollectionByUserId(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserTokens.Where(a => a.UserId == id).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static void Insert(AspNetUserTokens objAspNetUserTokens)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserTokens entAspNetUserTokens = new AspNetUserTokens();

             entAspNetUserTokens.UserId = objAspNetUserTokens.UserId;
             entAspNetUserTokens.LoginProvider = objAspNetUserTokens.LoginProvider;
             entAspNetUserTokens.Name = objAspNetUserTokens.Name;
             entAspNetUserTokens.Value = objAspNetUserTokens.Value;

             context.AspNetUserTokens.Add(entAspNetUserTokens);
             context.SaveChanges();
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetUserTokens objAspNetUserTokens)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserTokens entAspNetUserTokens = context.AspNetUserTokens.Where(a => a.UserId == objAspNetUserTokens.UserId &&a.LoginProvider == objAspNetUserTokens.LoginProvider &&a.Name == objAspNetUserTokens.Name).FirstOrDefault();

             if (entAspNetUserTokens != null)
             {
                 entAspNetUserTokens.Value = objAspNetUserTokens.Value;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(string userId, string loginProvider, string name)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetUserTokens = context.AspNetUserTokens.Where(a => a.UserId == userId).FirstOrDefault();

             if (objAspNetUserTokens != null)
             {
                 context.AspNetUserTokens.Remove(objAspNetUserTokens);
                 context.SaveChanges();
             }
         }
     }
}
