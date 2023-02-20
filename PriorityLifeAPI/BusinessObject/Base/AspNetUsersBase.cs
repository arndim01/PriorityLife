using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetUsers.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUsers class
     /// </summary>
     public class AspNetUsersBase : PriorityLifeAPI.Models.AspNetUsersModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetUsersBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetUsers SelectByPrimaryKey(string id)
         {
             return AspNetUsersDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUsers table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetUsersDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUsers table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName)
         {
             return AspNetUsersDataLayer.GetRecordCountDynamicWhere(id, userName, normalizedUserName, email, normalizedEmail, emailConfirmed, passwordHash, securityStamp, concurrencyStamp, phoneNumber, phoneNumberConfirmed, twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount, firstName, lastName);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUsers sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetUsers> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUsersDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUsers sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetUsers> SelectSkipAndTakeDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUsersDataLayer.SelectSkipAndTakeDynamicWhere(id, userName, normalizedUserName, email, normalizedEmail, emailConfirmed, passwordHash, securityStamp, concurrencyStamp, phoneNumber, phoneNumberConfirmed, twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount, firstName, lastName, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUsers
         /// </summary>
         public static List<AspNetUsers> SelectAll()
         {
             return AspNetUsersDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUsers sorted by the sort expression
         /// </summary>
         public static List<AspNetUsers> SelectAll(string sortByExpression)
         {
             List<AspNetUsers> objAspNetUsersCol = AspNetUsersDataLayer.SelectAll();
             return SortByExpression(objAspNetUsersCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUsers.
         /// </summary>
         public static List<AspNetUsers> SelectAllDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName)
         {
             return AspNetUsersDataLayer.SelectAllDynamicWhere(id, userName, normalizedUserName, email, normalizedEmail, emailConfirmed, passwordHash, securityStamp, concurrencyStamp, phoneNumber, phoneNumberConfirmed, twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount, firstName, lastName);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUsers sorted by the sort expression.
         /// </summary>
         public static List<AspNetUsers> SelectAllDynamicWhere(string id, string userName, string normalizedUserName, string email, string normalizedEmail, bool? emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool? phoneNumberConfirmed, bool? twoFactorEnabled, DateTimeOffset? lockoutEnd, bool? lockoutEnabled, int? accessFailedCount, string firstName, string lastName, string sortByExpression)
         {
             List<AspNetUsers> objAspNetUsersCol = AspNetUsersDataLayer.SelectAllDynamicWhere(id, userName, normalizedUserName, email, normalizedEmail, emailConfirmed, passwordHash, securityStamp, concurrencyStamp, phoneNumber, phoneNumberConfirmed, twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount, firstName, lastName);
             return SortByExpression(objAspNetUsersCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and UserName columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<AspNetUsers> SelectAspNetUsersDropDownListData()
         {
             return AspNetUsersDataLayer.SelectAspNetUsersDropDownListData();
         }

         /// <summary>
         /// Sorts the List<AspNetUsers >by sort expression
         /// </summary>
         public static List<AspNetUsers> SortByExpression(List<AspNetUsers> objAspNetUsersCol, string sortExpression)
         {
             bool isSortDescending = sortExpression.ToLower().Contains(" desc");

             if (isSortDescending)
             {
                 sortExpression = sortExpression.Replace(" DESC", "");
                 sortExpression = sortExpression.Replace(" desc", "");
             }
             else
             {
                 sortExpression = sortExpression.Replace(" ASC", "");
                 sortExpression = sortExpression.Replace(" asc", "");
             }

             switch (sortExpression)
             {
                 case "Id":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ById);
                     break;
                 case "UserName":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByUserName);
                     break;
                 case "NormalizedUserName":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByNormalizedUserName);
                     break;
                 case "Email":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByEmail);
                     break;
                 case "NormalizedEmail":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByNormalizedEmail);
                     break;
                 case "EmailConfirmed":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByEmailConfirmed);
                     break;
                 case "PasswordHash":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByPasswordHash);
                     break;
                 case "SecurityStamp":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.BySecurityStamp);
                     break;
                 case "ConcurrencyStamp":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByConcurrencyStamp);
                     break;
                 case "PhoneNumber":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByPhoneNumber);
                     break;
                 case "PhoneNumberConfirmed":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByPhoneNumberConfirmed);
                     break;
                 case "TwoFactorEnabled":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByTwoFactorEnabled);
                     break;
                 case "LockoutEnd":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByLockoutEnd);
                     break;
                 case "LockoutEnabled":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByLockoutEnabled);
                     break;
                 case "AccessFailedCount":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByAccessFailedCount);
                     break;
                 case "FirstName":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByFirstName);
                     break;
                 case "LastName":
                     objAspNetUsersCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUsers.ByLastName);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetUsersCol.Reverse();

             return objAspNetUsersCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public string Insert()
         {
             AspNetUsers objAspNetUsers = (AspNetUsers)this;
             return AspNetUsersDataLayer.Insert(objAspNetUsers);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetUsers objAspNetUsers = (AspNetUsers)this;
             AspNetUsersDataLayer.Update(objAspNetUsers);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(string id)
         {
             AspNetUsersDataLayer.Delete(id);
         }

         private static string GetSortExpression(string sortByExpression)
         {
             if (String.IsNullOrEmpty(sortByExpression) || sortByExpression == " asc")
                 sortByExpression = "Id";
             else if (sortByExpression.Contains(" asc"))
                 sortByExpression = sortByExpression.Replace(" asc", "");

             return sortByExpression;
         }

         /// <summary>
         /// Compares Id used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ById = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.Id ?? String.Empty;
             string value2 = y.Id ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UserName used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByUserName = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.UserName ?? String.Empty;
             string value2 = y.UserName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares NormalizedUserName used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByNormalizedUserName = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.NormalizedUserName ?? String.Empty;
             string value2 = y.NormalizedUserName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Email used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByEmail = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.Email ?? String.Empty;
             string value2 = y.Email ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares NormalizedEmail used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByNormalizedEmail = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.NormalizedEmail ?? String.Empty;
             string value2 = y.NormalizedEmail ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares EmailConfirmed used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByEmailConfirmed = delegate(AspNetUsers x, AspNetUsers y)
         {
             return x.EmailConfirmed.CompareTo(y.EmailConfirmed);
         };

         /// <summary>
         /// Compares PasswordHash used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByPasswordHash = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.PasswordHash ?? String.Empty;
             string value2 = y.PasswordHash ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares SecurityStamp used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> BySecurityStamp = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.SecurityStamp ?? String.Empty;
             string value2 = y.SecurityStamp ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ConcurrencyStamp used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByConcurrencyStamp = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.ConcurrencyStamp ?? String.Empty;
             string value2 = y.ConcurrencyStamp ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares PhoneNumber used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByPhoneNumber = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.PhoneNumber ?? String.Empty;
             string value2 = y.PhoneNumber ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares PhoneNumberConfirmed used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByPhoneNumberConfirmed = delegate(AspNetUsers x, AspNetUsers y)
         {
             return x.PhoneNumberConfirmed.CompareTo(y.PhoneNumberConfirmed);
         };

         /// <summary>
         /// Compares TwoFactorEnabled used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByTwoFactorEnabled = delegate(AspNetUsers x, AspNetUsers y)
         {
             return x.TwoFactorEnabled.CompareTo(y.TwoFactorEnabled);
         };

         /// <summary>
         /// Compares LockoutEnd used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByLockoutEnd = delegate(AspNetUsers x, AspNetUsers y)
         {
             return Nullable.Compare(x.LockoutEnd, y.LockoutEnd);
         };

         /// <summary>
         /// Compares LockoutEnabled used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByLockoutEnabled = delegate(AspNetUsers x, AspNetUsers y)
         {
             return x.LockoutEnabled.CompareTo(y.LockoutEnabled);
         };

         /// <summary>
         /// Compares AccessFailedCount used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByAccessFailedCount = delegate(AspNetUsers x, AspNetUsers y)
         {
             return x.AccessFailedCount.CompareTo(y.AccessFailedCount);
         };

         /// <summary>
         /// Compares FirstName used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByFirstName = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.FirstName ?? String.Empty;
             string value2 = y.FirstName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares LastName used for sorting
         /// </summary>
         public static Comparison<AspNetUsers> ByLastName = delegate(AspNetUsers x, AspNetUsers y)
         {
             string value1 = x.LastName ?? String.Empty;
             string value2 = y.LastName ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
