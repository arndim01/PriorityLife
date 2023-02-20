using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetUserLogins.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserLogins class
     /// </summary>
     public class AspNetUserLoginsBase : PriorityLifeAPI.Models.AspNetUserLoginsModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetUserLoginsBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetUserLogins SelectByPrimaryKey(string loginProvider, string providerKey)
         {
             return AspNetUserLoginsDataLayer.SelectByPrimaryKey(loginProvider, providerKey);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetUserLoginsDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table by UserId
         /// </summary>
         public static int GetRecordCountByUserId(string userId)
         {
             return AspNetUserLoginsDataLayer.GetRecordCountByUserId(userId);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserLogins table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId)
         {
             return AspNetUserLoginsDataLayer.GetRecordCountDynamicWhere(loginProvider, providerKey, providerDisplayName, userId);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserLogins sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserLogins> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserLoginsDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserLogins sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserLogins> SelectSkipAndTakeByUserId(int rows, int startRowIndex, string sortByExpression, string userId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserLoginsDataLayer.SelectSkipAndTakeByUserId(sortByExpression, startRowIndex, rows, userId);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserLogins sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetUserLogins> SelectSkipAndTakeDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserLoginsDataLayer.SelectSkipAndTakeDynamicWhere(loginProvider, providerKey, providerDisplayName, userId, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserLogins
         /// </summary>
         public static List<AspNetUserLogins> SelectAll()
         {
             return AspNetUserLoginsDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserLogins sorted by the sort expression
         /// </summary>
         public static List<AspNetUserLogins> SelectAll(string sortByExpression)
         {
             List<AspNetUserLogins> objAspNetUserLoginsCol = AspNetUserLoginsDataLayer.SelectAll();
             return SortByExpression(objAspNetUserLoginsCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserLogins.
         /// </summary>
         public static List<AspNetUserLogins> SelectAllDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId)
         {
             return AspNetUserLoginsDataLayer.SelectAllDynamicWhere(loginProvider, providerKey, providerDisplayName, userId);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserLogins sorted by the sort expression.
         /// </summary>
         public static List<AspNetUserLogins> SelectAllDynamicWhere(string loginProvider, string providerKey, string providerDisplayName, string userId, string sortByExpression)
         {
             List<AspNetUserLogins> objAspNetUserLoginsCol = AspNetUserLoginsDataLayer.SelectAllDynamicWhere(loginProvider, providerKey, providerDisplayName, userId);
             return SortByExpression(objAspNetUserLoginsCol, sortByExpression);
         }

         /// <summary>
         /// Selects all AspNetUserLogins by AspNetUsers, related to column UserId
         /// </summary>
         public static List<AspNetUserLogins> SelectAspNetUserLoginsCollectionByUserId(string id)
         {
             return AspNetUserLoginsDataLayer.SelectAspNetUserLoginsCollectionByUserId(id);
         }

         /// <summary>
         /// Selects all AspNetUserLogins by AspNetUsers, related to column UserId, sorted by the sort expression
         /// </summary>
         public static List<AspNetUserLogins> SelectAspNetUserLoginsCollectionByUserId(string id, string sortByExpression)
         {
             List<AspNetUserLogins> objAspNetUserLoginsCol = AspNetUserLoginsDataLayer.SelectAspNetUserLoginsCollectionByUserId(id);
             return SortByExpression(objAspNetUserLoginsCol, sortByExpression);
         }

         /// <summary>
         /// Sorts the List<AspNetUserLogins >by sort expression
         /// </summary>
         public static List<AspNetUserLogins> SortByExpression(List<AspNetUserLogins> objAspNetUserLoginsCol, string sortExpression)
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
                 case "LoginProvider":
                     objAspNetUserLoginsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserLogins.ByLoginProvider);
                     break;
                 case "ProviderKey":
                     objAspNetUserLoginsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserLogins.ByProviderKey);
                     break;
                 case "ProviderDisplayName":
                     objAspNetUserLoginsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserLogins.ByProviderDisplayName);
                     break;
                 case "UserId":
                     objAspNetUserLoginsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserLogins.ByUserId);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetUserLoginsCol.Reverse();

             return objAspNetUserLoginsCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public void Insert()
         {
             AspNetUserLogins objAspNetUserLogins = (AspNetUserLogins)this;
             AspNetUserLoginsDataLayer.Insert(objAspNetUserLogins);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetUserLogins objAspNetUserLogins = (AspNetUserLogins)this;
             AspNetUserLoginsDataLayer.Update(objAspNetUserLogins);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(string loginProvider, string providerKey)
         {
             AspNetUserLoginsDataLayer.Delete(loginProvider, providerKey);
         }

         private static string GetSortExpression(string sortByExpression)
         {
             if (String.IsNullOrEmpty(sortByExpression) || sortByExpression == " asc")
                 sortByExpression = "LoginProvider";
             else if (sortByExpression.Contains(" asc"))
                 sortByExpression = sortByExpression.Replace(" asc", "");

             return sortByExpression;
         }

         /// <summary>
         /// Compares LoginProvider used for sorting
         /// </summary>
         public static Comparison<AspNetUserLogins> ByLoginProvider = delegate(AspNetUserLogins x, AspNetUserLogins y)
         {
             string value1 = x.LoginProvider ?? String.Empty;
             string value2 = y.LoginProvider ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ProviderKey used for sorting
         /// </summary>
         public static Comparison<AspNetUserLogins> ByProviderKey = delegate(AspNetUserLogins x, AspNetUserLogins y)
         {
             string value1 = x.ProviderKey ?? String.Empty;
             string value2 = y.ProviderKey ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ProviderDisplayName used for sorting
         /// </summary>
         public static Comparison<AspNetUserLogins> ByProviderDisplayName = delegate(AspNetUserLogins x, AspNetUserLogins y)
         {
             string value1 = x.ProviderDisplayName ?? String.Empty;
             string value2 = y.ProviderDisplayName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UserId used for sorting
         /// </summary>
         public static Comparison<AspNetUserLogins> ByUserId = delegate(AspNetUserLogins x, AspNetUserLogins y)
         {
             string value1 = x.UserId ?? String.Empty;
             string value2 = y.UserId ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
