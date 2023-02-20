using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetRolesDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRolesDataLayer class
     /// </summary>
     internal class AspNetRolesDataLayerBase
     {
         // constructor
         internal AspNetRolesDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetRoles SelectByPrimaryKey(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoles.Where(a => a.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoles table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoles.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoles table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetRoles
                 .Where(a =>
                           (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetRoles records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetRoles> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "Name desc":
                             return context.AspNetRoles.OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedName desc":
                             return context.AspNetRoles.OrderByDescending(a => a.NormalizedName).Skip(startRowIndex).Take(rows).ToList();
                         case "ConcurrencyStamp desc":
                             return context.AspNetRoles.OrderByDescending(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoles.OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "Name":
                             return context.AspNetRoles.OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedName":
                             return context.AspNetRoles.OrderBy(a => a.NormalizedName).Skip(startRowIndex).Take(rows).ToList();
                         case "ConcurrencyStamp":
                             return context.AspNetRoles.OrderBy(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetRoles.OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects AspNetRoles records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetRoles> SelectSkipAndTakeDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "Name desc":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderByDescending(a => a.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedName desc":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderByDescending(a => a.NormalizedName).Skip(startRowIndex).Take(rows).ToList();

                     case "ConcurrencyStamp desc":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderByDescending(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "Name":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderBy(a => a.Name).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedName":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderBy(a => a.NormalizedName).Skip(startRowIndex).Take(rows).ToList();

                     case "ConcurrencyStamp":
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderBy(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetRoles
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                                   ).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetRoles
         /// </summary>
         internal static List<AspNetRoles> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetRoles.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoles.
         /// </summary>
         internal static List<AspNetRoles> SelectAllDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp)
         {
             PriorityLifeContext context = new PriorityLifeContext();


             return context.AspNetRoles
                 .Where(a =>
                           (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                           (!String.IsNullOrEmpty(name) ? a.Name.Contains(name) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedName) ? a.NormalizedName.Contains(normalizedName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and Name columns for use with a DropDownList web control
         /// </summary>
         internal static List<AspNetRoles> SelectAspNetRolesDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from a in context.AspNetRoles
                     select new AspNetRoles { Id = a.Id, Name = a.Name }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static string Insert(AspNetRoles objAspNetRoles)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetRoles entAspNetRoles = new AspNetRoles();

             entAspNetRoles.Id = objAspNetRoles.Id;
             entAspNetRoles.Name = objAspNetRoles.Name;
             entAspNetRoles.NormalizedName = objAspNetRoles.NormalizedName;
             entAspNetRoles.ConcurrencyStamp = objAspNetRoles.ConcurrencyStamp;

             context.AspNetRoles.Add(entAspNetRoles);
             context.SaveChanges();

             return entAspNetRoles.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetRoles objAspNetRoles)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetRoles entAspNetRoles = context.AspNetRoles.Where(a => a.Id == objAspNetRoles.Id).FirstOrDefault();

             if (entAspNetRoles != null)
             {
                 entAspNetRoles.Name = objAspNetRoles.Name;
                 entAspNetRoles.NormalizedName = objAspNetRoles.NormalizedName;
                 entAspNetRoles.ConcurrencyStamp = objAspNetRoles.ConcurrencyStamp;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetRoles = context.AspNetRoles.Where(a => a.Id == id).FirstOrDefault();

             if (objAspNetRoles != null)
             {
                 context.AspNetRoles.Remove(objAspNetRoles);
                 context.SaveChanges();
             }
         }
     }
}
