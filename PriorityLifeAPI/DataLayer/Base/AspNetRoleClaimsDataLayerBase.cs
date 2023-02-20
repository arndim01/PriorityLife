using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetRoleClaimsDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRoleClaimsDataLayer class
     /// </summary>
     internal class AspNetRoleClaimsDataLayerBase
     {
         // constructor
         internal AspNetRoleClaimsDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetRoleClaims SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoleClaims.Where(a => a.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoleClaims.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table by RoleId
         /// </summary>
         internal static int GetRecordCountByRoleId(string roleId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, string roleId, string claimType, string claimValue)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             return context.AspNetRoleClaims
                 .Where(a =>
                           (id != null ? a.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetRoleClaims records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetRoleClaims> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "RoleId desc":
                             return context.AspNetRoleClaims.OrderByDescending(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType desc":
                             return context.AspNetRoleClaims.OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue desc":
                             return context.AspNetRoleClaims.OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoleClaims.OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "RoleId":
                             return context.AspNetRoleClaims.OrderBy(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType":
                             return context.AspNetRoleClaims.OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue":
                             return context.AspNetRoleClaims.OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoleClaims.OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "RoleId desc":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderByDescending(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType desc":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue desc":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "RoleId":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderBy(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimType":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                         case "ClaimValue":
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoleClaims.Include(a => a.RoleIdNavigation).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by RoleId as a collection (List) of AspNetRoleClaims sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<AspNetRoleClaims> SelectSkipAndTakeByRoleId(string sortByExpression, int startRowIndex, int rows, string roleId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "RoleId desc":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderByDescending(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimType desc":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimValue desc":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "RoleId":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderBy(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimType":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();
                     case "ClaimValue":
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.AspNetRoleClaims.Where(a => a.RoleId == roleId).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects AspNetRoleClaims records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetRoleClaims> SelectSkipAndTakeDynamicWhere(int? id, string roleId, string claimType, string claimValue, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "RoleId desc":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimType desc":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimValue desc":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "RoleId":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.RoleId).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimType":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.ClaimType).Skip(startRowIndex).Take(rows).ToList();

                     case "ClaimValue":
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.ClaimValue).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetRoleClaims
                             .Where(a =>
                                       (id != null ? a.Id == idValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                                   ).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetRoleClaims
         /// </summary>
         internal static List<AspNetRoleClaims> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoleClaims.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoleClaims.
         /// </summary>
         internal static List<AspNetRoleClaims> SelectAllDynamicWhere(int? id, string roleId, string claimType, string claimValue)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;

             if (id != null)
                idValue = id.Value;

             return context.AspNetRoleClaims
                 .Where(a =>
                           (id != null ? a.Id == idValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(roleId) ? a.RoleId.Contains(roleId) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimType) ? a.ClaimType.Contains(claimType) : 1 == 1) &&
                           (!String.IsNullOrEmpty(claimValue) ? a.ClaimValue.Contains(claimValue) : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all AspNetRoleClaims by AspNetRoles, related to column RoleId
         /// </summary>
         internal static List<AspNetRoleClaims> SelectAspNetRoleClaimsCollectionByRoleId(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoleClaims.Where(a => a.RoleId == id).ToList();
         }
         /// <summary>
         /// Selects Id and ClaimType columns for use with a DropDownList web control
         /// </summary>
         internal static List<AspNetRoleClaims> SelectAspNetRoleClaimsDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from a in context.AspNetRoleClaims
                     select new AspNetRoleClaims { Id = a.Id, ClaimType = a.ClaimType }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(AspNetRoleClaims objAspNetRoleClaims)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetRoleClaims entAspNetRoleClaims = new AspNetRoleClaims();

             entAspNetRoleClaims.RoleId = objAspNetRoleClaims.RoleId;
             entAspNetRoleClaims.ClaimType = objAspNetRoleClaims.ClaimType;
             entAspNetRoleClaims.ClaimValue = objAspNetRoleClaims.ClaimValue;

             context.AspNetRoleClaims.Add(entAspNetRoleClaims);
             context.SaveChanges();

             return entAspNetRoleClaims.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetRoleClaims objAspNetRoleClaims)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetRoleClaims entAspNetRoleClaims = context.AspNetRoleClaims.Where(a => a.Id == objAspNetRoleClaims.Id).FirstOrDefault();

             if (entAspNetRoleClaims != null)
             {
                 entAspNetRoleClaims.RoleId = objAspNetRoleClaims.RoleId;
                 entAspNetRoleClaims.ClaimType = objAspNetRoleClaims.ClaimType;
                 entAspNetRoleClaims.ClaimValue = objAspNetRoleClaims.ClaimValue;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetRoleClaims = context.AspNetRoleClaims.Where(a => a.Id == id).FirstOrDefault();

             if (objAspNetRoleClaims != null)
             {
                 context.AspNetRoleClaims.Remove(objAspNetRoleClaims);
                 context.SaveChanges();
             }
         }
     }
}
