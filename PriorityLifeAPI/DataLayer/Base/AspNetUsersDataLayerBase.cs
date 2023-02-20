using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for AspNetUsersDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUsersDataLayer class
     /// </summary>
     internal class AspNetUsersDataLayerBase
     {
         // constructor
         internal AspNetUsersDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static AspNetUsers SelectByPrimaryKey(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUsers.Where(a => a.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUsers table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUsers.Count();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUsers table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             bool emailConfirmedValue = false;
             bool phoneNumberConfirmedValue = false;
             bool twoFactorEnabledValue = false;
             DateTimeOffset? lockoutEndValue = null;
             bool lockoutEnabledValue = false;
             int accessFailedCountValue = int.MinValue;

             if (emailConfirmed != null)
                emailConfirmedValue = emailConfirmed.Value;

             if (phoneNumberConfirmed != null)
                phoneNumberConfirmedValue = phoneNumberConfirmed.Value;

             if (twoFactorEnabled != null)
                twoFactorEnabledValue = twoFactorEnabled.Value;

             if (lockoutEnd != null)
                lockoutEndValue = lockoutEnd.Value;

             if (lockoutEnabled != null)
                lockoutEnabledValue = lockoutEnabled.Value;

             if (accessFailedCount != null)
                accessFailedCountValue = accessFailedCount.Value;

             return context.AspNetUsers
                 .Where(a =>
                           (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                           (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                           (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                           (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                           (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                           (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                           (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                           (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                           (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                           (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                           (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects AspNetUsers records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<AspNetUsers> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                     switch (sortByExpression)
                     {
                         case "UserName desc":
                             return context.AspNetUsers.OrderByDescending(a => a.UserName).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedUserName desc":
                             return context.AspNetUsers.OrderByDescending(a => a.NormalizedUserName).Skip(startRowIndex).Take(rows).ToList();
                         case "Email desc":
                             return context.AspNetUsers.OrderByDescending(a => a.Email).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedEmail desc":
                             return context.AspNetUsers.OrderByDescending(a => a.NormalizedEmail).Skip(startRowIndex).Take(rows).ToList();
                         case "EmailConfirmed desc":
                             return context.AspNetUsers.OrderByDescending(a => a.EmailConfirmed).Skip(startRowIndex).Take(rows).ToList();
                         case "PasswordHash desc":
                             return context.AspNetUsers.OrderByDescending(a => a.PasswordHash).Skip(startRowIndex).Take(rows).ToList();
                         case "SecurityStamp desc":
                             return context.AspNetUsers.OrderByDescending(a => a.SecurityStamp).Skip(startRowIndex).Take(rows).ToList();
                         case "ConcurrencyStamp desc":
                             return context.AspNetUsers.OrderByDescending(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();
                         case "PhoneNumber desc":
                             return context.AspNetUsers.OrderByDescending(a => a.PhoneNumber).Skip(startRowIndex).Take(rows).ToList();
                         case "PhoneNumberConfirmed desc":
                             return context.AspNetUsers.OrderByDescending(a => a.PhoneNumberConfirmed).Skip(startRowIndex).Take(rows).ToList();
                         case "TwoFactorEnabled desc":
                             return context.AspNetUsers.OrderByDescending(a => a.TwoFactorEnabled).Skip(startRowIndex).Take(rows).ToList();
                         case "LockoutEnd desc":
                             return context.AspNetUsers.OrderByDescending(a => a.LockoutEnd).Skip(startRowIndex).Take(rows).ToList();
                         case "LockoutEnabled desc":
                             return context.AspNetUsers.OrderByDescending(a => a.LockoutEnabled).Skip(startRowIndex).Take(rows).ToList();
                         case "AccessFailedCount desc":
                             return context.AspNetUsers.OrderByDescending(a => a.AccessFailedCount).Skip(startRowIndex).Take(rows).ToList();
                         case "FirstName desc":
                             return context.AspNetUsers.OrderByDescending(a => a.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName desc":
                             return context.AspNetUsers.OrderByDescending(a => a.LastName).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUsers.OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
             else
             {
                     switch (sortByExpression)
                     {
                         case "UserName":
                             return context.AspNetUsers.OrderBy(a => a.UserName).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedUserName":
                             return context.AspNetUsers.OrderBy(a => a.NormalizedUserName).Skip(startRowIndex).Take(rows).ToList();
                         case "Email":
                             return context.AspNetUsers.OrderBy(a => a.Email).Skip(startRowIndex).Take(rows).ToList();
                         case "NormalizedEmail":
                             return context.AspNetUsers.OrderBy(a => a.NormalizedEmail).Skip(startRowIndex).Take(rows).ToList();
                         case "EmailConfirmed":
                             return context.AspNetUsers.OrderBy(a => a.EmailConfirmed).Skip(startRowIndex).Take(rows).ToList();
                         case "PasswordHash":
                             return context.AspNetUsers.OrderBy(a => a.PasswordHash).Skip(startRowIndex).Take(rows).ToList();
                         case "SecurityStamp":
                             return context.AspNetUsers.OrderBy(a => a.SecurityStamp).Skip(startRowIndex).Take(rows).ToList();
                         case "ConcurrencyStamp":
                             return context.AspNetUsers.OrderBy(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();
                         case "PhoneNumber":
                             return context.AspNetUsers.OrderBy(a => a.PhoneNumber).Skip(startRowIndex).Take(rows).ToList();
                         case "PhoneNumberConfirmed":
                             return context.AspNetUsers.OrderBy(a => a.PhoneNumberConfirmed).Skip(startRowIndex).Take(rows).ToList();
                         case "TwoFactorEnabled":
                             return context.AspNetUsers.OrderBy(a => a.TwoFactorEnabled).Skip(startRowIndex).Take(rows).ToList();
                         case "LockoutEnd":
                             return context.AspNetUsers.OrderBy(a => a.LockoutEnd).Skip(startRowIndex).Take(rows).ToList();
                         case "LockoutEnabled":
                             return context.AspNetUsers.OrderBy(a => a.LockoutEnabled).Skip(startRowIndex).Take(rows).ToList();
                         case "AccessFailedCount":
                             return context.AspNetUsers.OrderBy(a => a.AccessFailedCount).Skip(startRowIndex).Take(rows).ToList();
                         case "FirstName":
                             return context.AspNetUsers.OrderBy(a => a.FirstName).Skip(startRowIndex).Take(rows).ToList();
                         case "LastName":
                             return context.AspNetUsers.OrderBy(a => a.LastName).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.AspNetUsers.OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
             }
         }

         /// <summary>
         /// Selects AspNetUsers records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<AspNetUsers> SelectSkipAndTakeDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             bool emailConfirmedValue = false;
             bool phoneNumberConfirmedValue = false;
             bool twoFactorEnabledValue = false;
             DateTimeOffset? lockoutEndValue = null;
             bool lockoutEnabledValue = false;
             int accessFailedCountValue = int.MinValue;

             if (emailConfirmed != null)
                emailConfirmedValue = emailConfirmed.Value;

             if (phoneNumberConfirmed != null)
                phoneNumberConfirmedValue = phoneNumberConfirmed.Value;

             if (twoFactorEnabled != null)
                twoFactorEnabledValue = twoFactorEnabled.Value;

             if (lockoutEnd != null)
                lockoutEndValue = lockoutEnd.Value;

             if (lockoutEnabled != null)
                lockoutEnabledValue = lockoutEnabled.Value;

             if (accessFailedCount != null)
                accessFailedCountValue = accessFailedCount.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "UserName desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.UserName).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedUserName desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.NormalizedUserName).Skip(startRowIndex).Take(rows).ToList();

                     case "Email desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.Email).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedEmail desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.NormalizedEmail).Skip(startRowIndex).Take(rows).ToList();

                     case "EmailConfirmed desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.EmailConfirmed).Skip(startRowIndex).Take(rows).ToList();

                     case "PasswordHash desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.PasswordHash).Skip(startRowIndex).Take(rows).ToList();

                     case "SecurityStamp desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.SecurityStamp).Skip(startRowIndex).Take(rows).ToList();

                     case "ConcurrencyStamp desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();

                     case "PhoneNumber desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.PhoneNumber).Skip(startRowIndex).Take(rows).ToList();

                     case "PhoneNumberConfirmed desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.PhoneNumberConfirmed).Skip(startRowIndex).Take(rows).ToList();

                     case "TwoFactorEnabled desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.TwoFactorEnabled).Skip(startRowIndex).Take(rows).ToList();

                     case "LockoutEnd desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.LockoutEnd).Skip(startRowIndex).Take(rows).ToList();

                     case "LockoutEnabled desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.LockoutEnabled).Skip(startRowIndex).Take(rows).ToList();

                     case "AccessFailedCount desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.AccessFailedCount).Skip(startRowIndex).Take(rows).ToList();

                     case "FirstName desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName desc":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.LastName).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderByDescending(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "UserName":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.UserName).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedUserName":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.NormalizedUserName).Skip(startRowIndex).Take(rows).ToList();

                     case "Email":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.Email).Skip(startRowIndex).Take(rows).ToList();

                     case "NormalizedEmail":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.NormalizedEmail).Skip(startRowIndex).Take(rows).ToList();

                     case "EmailConfirmed":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.EmailConfirmed).Skip(startRowIndex).Take(rows).ToList();

                     case "PasswordHash":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.PasswordHash).Skip(startRowIndex).Take(rows).ToList();

                     case "SecurityStamp":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.SecurityStamp).Skip(startRowIndex).Take(rows).ToList();

                     case "ConcurrencyStamp":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.ConcurrencyStamp).Skip(startRowIndex).Take(rows).ToList();

                     case "PhoneNumber":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.PhoneNumber).Skip(startRowIndex).Take(rows).ToList();

                     case "PhoneNumberConfirmed":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.PhoneNumberConfirmed).Skip(startRowIndex).Take(rows).ToList();

                     case "TwoFactorEnabled":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.TwoFactorEnabled).Skip(startRowIndex).Take(rows).ToList();

                     case "LockoutEnd":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.LockoutEnd).Skip(startRowIndex).Take(rows).ToList();

                     case "LockoutEnabled":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.LockoutEnabled).Skip(startRowIndex).Take(rows).ToList();

                     case "AccessFailedCount":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.AccessFailedCount).Skip(startRowIndex).Take(rows).ToList();

                     case "FirstName":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.FirstName).Skip(startRowIndex).Take(rows).ToList();

                     case "LastName":
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.LastName).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.AspNetUsers
                             .Where(a =>
                                       (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                                       (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                                       (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                                       (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                                       (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                                       (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                                       (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                                       (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                                   ).OrderBy(a => a.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all AspNetUsers
         /// </summary>
         internal static List<AspNetUsers> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.AspNetUsers.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUsers.
         /// </summary>
         internal static List<AspNetUsers> SelectAllDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             bool emailConfirmedValue = false;
             bool phoneNumberConfirmedValue = false;
             bool twoFactorEnabledValue = false;
             DateTimeOffset lockoutEndValue = DateTimeOffset.MinValue;
             bool lockoutEnabledValue = false;
             int accessFailedCountValue = int.MinValue;

             if (emailConfirmed != null)
                emailConfirmedValue = emailConfirmed.Value;

             if (phoneNumberConfirmed != null)
                phoneNumberConfirmedValue = phoneNumberConfirmed.Value;

             if (twoFactorEnabled != null)
                twoFactorEnabledValue = twoFactorEnabled.Value;

             if (lockoutEnd != null)
                lockoutEndValue = lockoutEnd.Value;

             if (lockoutEnabled != null)
                lockoutEnabledValue = lockoutEnabled.Value;

             if (accessFailedCount != null)
                accessFailedCountValue = accessFailedCount.Value;

             return context.AspNetUsers
                 .Where(a =>
                           (!String.IsNullOrEmpty(id) ? a.Id.Contains(id) : 1 == 1) &&
                           (!String.IsNullOrEmpty(userName) ? a.UserName.Contains(userName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedUserName) ? a.NormalizedUserName.Contains(normalizedUserName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(email) ? a.Email.Contains(email) : 1 == 1) &&
                           (!String.IsNullOrEmpty(normalizedEmail) ? a.NormalizedEmail.Contains(normalizedEmail) : 1 == 1) &&
                           (emailConfirmed != null ? a.EmailConfirmed == emailConfirmedValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(passwordHash) ? a.PasswordHash.Contains(passwordHash) : 1 == 1) &&
                           (!String.IsNullOrEmpty(securityStamp) ? a.SecurityStamp.Contains(securityStamp) : 1 == 1) &&
                           (!String.IsNullOrEmpty(concurrencyStamp) ? a.ConcurrencyStamp.Contains(concurrencyStamp) : 1 == 1) &&
                           (!String.IsNullOrEmpty(phoneNumber) ? a.PhoneNumber.Contains(phoneNumber) : 1 == 1) &&
                           (phoneNumberConfirmed != null ? a.PhoneNumberConfirmed == phoneNumberConfirmedValue : 1 == 1) &&
                           (twoFactorEnabled != null ? a.TwoFactorEnabled == twoFactorEnabledValue : 1 == 1) &&
                           (lockoutEnd != null ? a.LockoutEnd == lockoutEndValue : 1 == 1) &&
                           (lockoutEnabled != null ? a.LockoutEnabled == lockoutEnabledValue : 1 == 1) &&
                           (accessFailedCount != null ? a.AccessFailedCount == accessFailedCountValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(firstName) ? a.FirstName.Contains(firstName) : 1 == 1) &&
                           (!String.IsNullOrEmpty(lastName) ? a.LastName.Contains(lastName) : 1 == 1) 
                       ).ToList();
         }
         /// <summary>
         /// Selects Id and UserName columns for use with a DropDownList web control
         /// </summary>
         internal static List<AspNetUsers> SelectAspNetUsersDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from a in context.AspNetUsers
                     select new AspNetUsers { Id = a.Id, UserName = a.UserName }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static string Insert(AspNetUsers objAspNetUsers)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUsers entAspNetUsers = new AspNetUsers();

             entAspNetUsers.Id = objAspNetUsers.Id;
             entAspNetUsers.UserName = objAspNetUsers.UserName;
             entAspNetUsers.NormalizedUserName = objAspNetUsers.NormalizedUserName;
             entAspNetUsers.Email = objAspNetUsers.Email;
             entAspNetUsers.NormalizedEmail = objAspNetUsers.NormalizedEmail;
             entAspNetUsers.EmailConfirmed = objAspNetUsers.EmailConfirmed;
             entAspNetUsers.PasswordHash = objAspNetUsers.PasswordHash;
             entAspNetUsers.SecurityStamp = objAspNetUsers.SecurityStamp;
             entAspNetUsers.ConcurrencyStamp = objAspNetUsers.ConcurrencyStamp;
             entAspNetUsers.PhoneNumber = objAspNetUsers.PhoneNumber;
             entAspNetUsers.PhoneNumberConfirmed = objAspNetUsers.PhoneNumberConfirmed;
             entAspNetUsers.TwoFactorEnabled = objAspNetUsers.TwoFactorEnabled;
             entAspNetUsers.LockoutEnd = objAspNetUsers.LockoutEnd;
             entAspNetUsers.LockoutEnabled = objAspNetUsers.LockoutEnabled;
             entAspNetUsers.AccessFailedCount = objAspNetUsers.AccessFailedCount;
             entAspNetUsers.FirstName = objAspNetUsers.FirstName;
             entAspNetUsers.LastName = objAspNetUsers.LastName;

             context.AspNetUsers.Add(entAspNetUsers);
             context.SaveChanges();

             return entAspNetUsers.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(AspNetUsers objAspNetUsers)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             AspNetUsers entAspNetUsers = context.AspNetUsers.Where(a => a.Id == objAspNetUsers.Id).FirstOrDefault();

             if (entAspNetUsers != null)
             {
                 entAspNetUsers.UserName = objAspNetUsers.UserName;
                 entAspNetUsers.NormalizedUserName = objAspNetUsers.NormalizedUserName;
                 entAspNetUsers.Email = objAspNetUsers.Email;
                 entAspNetUsers.NormalizedEmail = objAspNetUsers.NormalizedEmail;
                 entAspNetUsers.EmailConfirmed = objAspNetUsers.EmailConfirmed;
                 entAspNetUsers.PasswordHash = objAspNetUsers.PasswordHash;
                 entAspNetUsers.SecurityStamp = objAspNetUsers.SecurityStamp;
                 entAspNetUsers.ConcurrencyStamp = objAspNetUsers.ConcurrencyStamp;
                 entAspNetUsers.PhoneNumber = objAspNetUsers.PhoneNumber;
                 entAspNetUsers.PhoneNumberConfirmed = objAspNetUsers.PhoneNumberConfirmed;
                 entAspNetUsers.TwoFactorEnabled = objAspNetUsers.TwoFactorEnabled;
                 entAspNetUsers.LockoutEnd = objAspNetUsers.LockoutEnd;
                 entAspNetUsers.LockoutEnabled = objAspNetUsers.LockoutEnabled;
                 entAspNetUsers.AccessFailedCount = objAspNetUsers.AccessFailedCount;
                 entAspNetUsers.FirstName = objAspNetUsers.FirstName;
                 entAspNetUsers.LastName = objAspNetUsers.LastName;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(string id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objAspNetUsers = context.AspNetUsers.Where(a => a.Id == id).FirstOrDefault();

             if (objAspNetUsers != null)
             {
                 context.AspNetUsers.Remove(objAspNetUsers);
                 context.SaveChanges();
             }
         }
     }
}
