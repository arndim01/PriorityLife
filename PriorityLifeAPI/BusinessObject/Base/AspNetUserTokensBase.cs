using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetUserTokens.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserTokens class
     /// </summary>
     public class AspNetUserTokensBase : PriorityLifeAPI.Models.AspNetUserTokensModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetUserTokensBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetUserTokens SelectByPrimaryKey(string userId, string loginProvider, string name)
         {
             return AspNetUserTokensDataLayer.SelectByPrimaryKey(userId, loginProvider, name);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetUserTokensDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table by UserId
         /// </summary>
         public static int GetRecordCountByUserId(string userId)
         {
             return AspNetUserTokensDataLayer.GetRecordCountByUserId(userId);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserTokens table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(string userId, string loginProvider, string name, string value)
         {
             return AspNetUserTokensDataLayer.GetRecordCountDynamicWhere(userId, loginProvider, name, value);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserTokens sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserTokens> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserTokensDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserTokens sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserTokens> SelectSkipAndTakeByUserId(int rows, int startRowIndex, string sortByExpression, string userId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserTokensDataLayer.SelectSkipAndTakeByUserId(sortByExpression, startRowIndex, rows, userId);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserTokens sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetUserTokens> SelectSkipAndTakeDynamicWhere(string userId, string loginProvider, string name, string value, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserTokensDataLayer.SelectSkipAndTakeDynamicWhere(userId, loginProvider, name, value, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserTokens
         /// </summary>
         public static List<AspNetUserTokens> SelectAll()
         {
             return AspNetUserTokensDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserTokens sorted by the sort expression
         /// </summary>
         public static List<AspNetUserTokens> SelectAll(string sortByExpression)
         {
             List<AspNetUserTokens> objAspNetUserTokensCol = AspNetUserTokensDataLayer.SelectAll();
             return SortByExpression(objAspNetUserTokensCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserTokens.
         /// </summary>
         public static List<AspNetUserTokens> SelectAllDynamicWhere(string userId, string loginProvider, string name, string value)
         {
             return AspNetUserTokensDataLayer.SelectAllDynamicWhere(userId, loginProvider, name, value);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserTokens sorted by the sort expression.
         /// </summary>
         public static List<AspNetUserTokens> SelectAllDynamicWhere(string userId, string loginProvider, string name, string value, string sortByExpression)
         {
             List<AspNetUserTokens> objAspNetUserTokensCol = AspNetUserTokensDataLayer.SelectAllDynamicWhere(userId, loginProvider, name, value);
             return SortByExpression(objAspNetUserTokensCol, sortByExpression);
         }

         /// <summary>
         /// Selects all AspNetUserTokens by AspNetUsers, related to column UserId
         /// </summary>
         public static List<AspNetUserTokens> SelectAspNetUserTokensCollectionByUserId(string id)
         {
             return AspNetUserTokensDataLayer.SelectAspNetUserTokensCollectionByUserId(id);
         }

         /// <summary>
         /// Selects all AspNetUserTokens by AspNetUsers, related to column UserId, sorted by the sort expression
         /// </summary>
         public static List<AspNetUserTokens> SelectAspNetUserTokensCollectionByUserId(string id, string sortByExpression)
         {
             List<AspNetUserTokens> objAspNetUserTokensCol = AspNetUserTokensDataLayer.SelectAspNetUserTokensCollectionByUserId(id);
             return SortByExpression(objAspNetUserTokensCol, sortByExpression);
         }

         /// <summary>
         /// Sorts the List<AspNetUserTokens >by sort expression
         /// </summary>
         public static List<AspNetUserTokens> SortByExpression(List<AspNetUserTokens> objAspNetUserTokensCol, string sortExpression)
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
                 case "UserId":
                     objAspNetUserTokensCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserTokens.ByUserId);
                     break;
                 case "LoginProvider":
                     objAspNetUserTokensCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserTokens.ByLoginProvider);
                     break;
                 case "Name":
                     objAspNetUserTokensCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserTokens.ByName);
                     break;
                 case "Value":
                     objAspNetUserTokensCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserTokens.ByValue);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetUserTokensCol.Reverse();

             return objAspNetUserTokensCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public void Insert()
         {
             AspNetUserTokens objAspNetUserTokens = (AspNetUserTokens)this;
             AspNetUserTokensDataLayer.Insert(objAspNetUserTokens);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetUserTokens objAspNetUserTokens = (AspNetUserTokens)this;
             AspNetUserTokensDataLayer.Update(objAspNetUserTokens);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(string userId, string loginProvider, string name)
         {
             AspNetUserTokensDataLayer.Delete(userId, loginProvider, name);
         }

         private static string GetSortExpression(string sortByExpression)
         {
             if (String.IsNullOrEmpty(sortByExpression) || sortByExpression == " asc")
                 sortByExpression = "UserId";
             else if (sortByExpression.Contains(" asc"))
                 sortByExpression = sortByExpression.Replace(" asc", "");

             return sortByExpression;
         }

         /// <summary>
         /// Compares UserId used for sorting
         /// </summary>
         public static Comparison<AspNetUserTokens> ByUserId = delegate(AspNetUserTokens x, AspNetUserTokens y)
         {
             string value1 = x.UserId ?? String.Empty;
             string value2 = y.UserId ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares LoginProvider used for sorting
         /// </summary>
         public static Comparison<AspNetUserTokens> ByLoginProvider = delegate(AspNetUserTokens x, AspNetUserTokens y)
         {
             string value1 = x.LoginProvider ?? String.Empty;
             string value2 = y.LoginProvider ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Name used for sorting
         /// </summary>
         public static Comparison<AspNetUserTokens> ByName = delegate(AspNetUserTokens x, AspNetUserTokens y)
         {
             string value1 = x.Name ?? String.Empty;
             string value2 = y.Name ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Value used for sorting
         /// </summary>
         public static Comparison<AspNetUserTokens> ByValue = delegate(AspNetUserTokens x, AspNetUserTokens y)
         {
             string value1 = x.Value ?? String.Empty;
             string value2 = y.Value ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
