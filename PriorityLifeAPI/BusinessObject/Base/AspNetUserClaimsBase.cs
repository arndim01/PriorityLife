using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetUserClaims.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserClaims class
     /// </summary>
     public class AspNetUserClaimsBase : PriorityLifeAPI.Models.AspNetUserClaimsModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetUserClaimsBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetUserClaims SelectByPrimaryKey(int id)
         {
             return AspNetUserClaimsDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetUserClaimsDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table by UserId
         /// </summary>
         public static int GetRecordCountByUserId(string userId)
         {
             return AspNetUserClaimsDataLayer.GetRecordCountByUserId(userId);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetUserClaims table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, string userId, string claimType, string claimValue)
         {
             return AspNetUserClaimsDataLayer.GetRecordCountDynamicWhere(id, userId, claimType, claimValue);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserClaims sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserClaims> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserClaimsDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by UserId as a collection (List) of AspNetUserClaims sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<AspNetUserClaims> SelectSkipAndTakeByUserId(int rows, int startRowIndex, string sortByExpression, string userId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserClaimsDataLayer.SelectSkipAndTakeByUserId(sortByExpression, startRowIndex, rows, userId);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetUserClaims sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetUserClaims> SelectSkipAndTakeDynamicWhere(int? id, string userId, string claimType, string claimValue, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetUserClaimsDataLayer.SelectSkipAndTakeDynamicWhere(id, userId, claimType, claimValue, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserClaims
         /// </summary>
         public static List<AspNetUserClaims> SelectAll()
         {
             return AspNetUserClaimsDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetUserClaims sorted by the sort expression
         /// </summary>
         public static List<AspNetUserClaims> SelectAll(string sortByExpression)
         {
             List<AspNetUserClaims> objAspNetUserClaimsCol = AspNetUserClaimsDataLayer.SelectAll();
             return SortByExpression(objAspNetUserClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserClaims.
         /// </summary>
         public static List<AspNetUserClaims> SelectAllDynamicWhere(int? id, string userId, string claimType, string claimValue)
         {
             return AspNetUserClaimsDataLayer.SelectAllDynamicWhere(id, userId, claimType, claimValue);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetUserClaims sorted by the sort expression.
         /// </summary>
         public static List<AspNetUserClaims> SelectAllDynamicWhere(int? id, string userId, string claimType, string claimValue, string sortByExpression)
         {
             List<AspNetUserClaims> objAspNetUserClaimsCol = AspNetUserClaimsDataLayer.SelectAllDynamicWhere(id, userId, claimType, claimValue);
             return SortByExpression(objAspNetUserClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects all AspNetUserClaims by AspNetUsers, related to column UserId
         /// </summary>
         public static List<AspNetUserClaims> SelectAspNetUserClaimsCollectionByUserId(string id)
         {
             return AspNetUserClaimsDataLayer.SelectAspNetUserClaimsCollectionByUserId(id);
         }

         /// <summary>
         /// Selects all AspNetUserClaims by AspNetUsers, related to column UserId, sorted by the sort expression
         /// </summary>
         public static List<AspNetUserClaims> SelectAspNetUserClaimsCollectionByUserId(string id, string sortByExpression)
         {
             List<AspNetUserClaims> objAspNetUserClaimsCol = AspNetUserClaimsDataLayer.SelectAspNetUserClaimsCollectionByUserId(id);
             return SortByExpression(objAspNetUserClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and ClaimType columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<AspNetUserClaims> SelectAspNetUserClaimsDropDownListData()
         {
             return AspNetUserClaimsDataLayer.SelectAspNetUserClaimsDropDownListData();
         }

         /// <summary>
         /// Sorts the List<AspNetUserClaims >by sort expression
         /// </summary>
         public static List<AspNetUserClaims> SortByExpression(List<AspNetUserClaims> objAspNetUserClaimsCol, string sortExpression)
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
                     objAspNetUserClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserClaims.ById);
                     break;
                 case "UserId":
                     objAspNetUserClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserClaims.ByUserId);
                     break;
                 case "ClaimType":
                     objAspNetUserClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserClaims.ByClaimType);
                     break;
                 case "ClaimValue":
                     objAspNetUserClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetUserClaims.ByClaimValue);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetUserClaimsCol.Reverse();

             return objAspNetUserClaimsCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             AspNetUserClaims objAspNetUserClaims = (AspNetUserClaims)this;
             return AspNetUserClaimsDataLayer.Insert(objAspNetUserClaims);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetUserClaims objAspNetUserClaims = (AspNetUserClaims)this;
             AspNetUserClaimsDataLayer.Update(objAspNetUserClaims);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             AspNetUserClaimsDataLayer.Delete(id);
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
         public static Comparison<AspNetUserClaims> ById = delegate(AspNetUserClaims x, AspNetUserClaims y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares UserId used for sorting
         /// </summary>
         public static Comparison<AspNetUserClaims> ByUserId = delegate(AspNetUserClaims x, AspNetUserClaims y)
         {
             string value1 = x.UserId ?? String.Empty;
             string value2 = y.UserId ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ClaimType used for sorting
         /// </summary>
         public static Comparison<AspNetUserClaims> ByClaimType = delegate(AspNetUserClaims x, AspNetUserClaims y)
         {
             string value1 = x.ClaimType ?? String.Empty;
             string value2 = y.ClaimType ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ClaimValue used for sorting
         /// </summary>
         public static Comparison<AspNetUserClaims> ByClaimValue = delegate(AspNetUserClaims x, AspNetUserClaims y)
         {
             string value1 = x.ClaimValue ?? String.Empty;
             string value2 = y.ClaimValue ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
