using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetUserClaimsDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserClaimsDataLayer class
     /// </summary>
     internal class AspNetUserClaimsDataLayerBase
     {
         // constructor
         internal AspNetUserClaimsDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetUserClaims SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserClaims.Where(a => a.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserClaims.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table by UserId
         /// </summary>
         internal static int GetRecordCountByUserId(string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserClaims.Where(a => a.UserId == userId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, string userId, string claimType, string claimValue)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             return context.AspNetUserClaims
                 .Where(a =>
                           (id != null ? a.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetUserClaims records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetUserClaims> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "UserId desc":
                             return context.AspNetUserClaims.OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType desc":
                             return context.AspNetUserClaims.OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue desc":
                             return context.AspNetUserClaims.OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserClaims.OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "UserId":
                             return context.AspNetUserClaims.OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType":
                             return context.AspNetUserClaims.OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue":
                             return context.AspNetUserClaims.OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserClaims.OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "UserId desc":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType desc":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue desc":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "UserId":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue":
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUserClaims.Include(a => a.UserIdNavigation).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserClaims sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<AspNetUserClaims> SelectSkipAndTakeByUserId(string sortByExpression, int startRowIndex, int rows, string userId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "UserId desc":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimType desc":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimValue desc":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "UserId":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimType":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimValue":
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetUserClaims.Where(a => a.UserId == userId).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects AspNetUserClaims records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetUserClaims> SelectSkipAndTakeDynamicWhere(int? id, string userId, string claimType, string claimValue, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "UserId desc":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimType desc":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimValue desc":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "UserId":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.UserId).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimType":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimValue":
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUserClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetUserClaims
         /// </summary>
         internal static List<AspNetUserClaims> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserClaims.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserClaims.
         /// </summary>
         internal static List<AspNetUserClaims> SelectAllDynamicWhere(int? id, string userId, string claimType, string claimValue)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             return context.AspNetUserClaims
                 .Where(a =>
                           (id != null ? a.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(userId) ? a.UserId.Contains(userId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all AspNetUserClaims by AspNetUsers, related to column UserId
         /// </summary>
         internal static List<AspNetUserClaims> SelectAspNetUserClaimsCollectionByUserId(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUserClaims.Where(a => a.UserId == id).ToList();
         }
         /// <summary>
         /// Selects Id and ClaimType columns for use with a DropDownList web control
         /// </summary>
         internal static List<AspNetUserClaims> SelectAspNetUserClaimsDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from a in context.AspNetUserClaims
                     select new AspNetUserClaims { Id = a.Id, ClaimType = a.ClaimType }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(AspNetUserClaims objAspNetUserClaims)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserClaims entAspNetUserClaims = new AspNetUserClaims();

             entAspNetUserClaims.UserId = objAspNetUserClaims.UserId;
             entAspNetUserClaims.ClaimType = objAspNetUserClaims.ClaimType;
             entAspNetUserClaims.ClaimValue = objAspNetUserClaims.ClaimValue;

             context.AspNetUserClaims.Add(entAspNetUserClaims);
             context.SaveChanges();

             return entAspNetUserClaims.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetUserClaims objAspNetUserClaims)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUserClaims entAspNetUserClaims = context.AspNetUserClaims.Where(a => a.Id == objAspNetUserClaims.Id).FirstOrDefault();

             if (entAspNetUserClaims != null)
             {
                 entAspNetUserClaims.UserId = objAspNetUserClaims.UserId;
                 entAspNetUserClaims.ClaimType = objAspNetUserClaims.ClaimType;
                 entAspNetUserClaims.ClaimValue = objAspNetUserClaims.ClaimValue;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetUserClaims = context.AspNetUserClaims.Where(a => a.Id == id).FirstOrDefault();

             if (objAspNetUserClaims != null)
             {
                 context.AspNetUserClaims.Remove(objAspNetUserClaims);
                 context.SaveChanges();
             }
         }
     }
}
