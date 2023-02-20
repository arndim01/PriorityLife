using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetRoleClaims.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRoleClaims class
     /// </summary>
     public class AspNetRoleClaimsBase : PriorityLifeAPI.Models.AspNetRoleClaimsModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetRoleClaimsBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetRoleClaims SelectByPrimaryKey(int id)
         {
             return AspNetRoleClaimsDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetRoleClaimsDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table by RoleId
         /// </summary>
         public static int GetRecordCountByRoleId(string roleId)
         {
             return AspNetRoleClaimsDataLayer.GetRecordCountByRoleId(roleId);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoleClaims table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, string roleId, string claimType, string claimValue)
         {
             return AspNetRoleClaimsDataLayer.GetRecordCountDynamicWhere(id, roleId, claimType, claimValue);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetRoleClaims sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetRoleClaims> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetRoleClaimsDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by RoleId as a collection (List) of AspNetRoleClaims sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<AspNetRoleClaims> SelectSkipAndTakeByRoleId(int rows, int startRowIndex, string sortByExpression, string roleId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetRoleClaimsDataLayer.SelectSkipAndTakeByRoleId(sortByExpression, startRowIndex, rows, roleId);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetRoleClaims sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetRoleClaims> SelectSkipAndTakeDynamicWhere(int? id, string roleId, string claimType, string claimValue, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetRoleClaimsDataLayer.SelectSkipAndTakeDynamicWhere(id, roleId, claimType, claimValue, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetRoleClaims
         /// </summary>
         public static List<AspNetRoleClaims> SelectAll()
         {
             return AspNetRoleClaimsDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetRoleClaims sorted by the sort expression
         /// </summary>
         public static List<AspNetRoleClaims> SelectAll(string sortByExpression)
         {
             List<AspNetRoleClaims> objAspNetRoleClaimsCol = AspNetRoleClaimsDataLayer.SelectAll();
             return SortByExpression(objAspNetRoleClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoleClaims.
         /// </summary>
         public static List<AspNetRoleClaims> SelectAllDynamicWhere(int? id, string roleId, string claimType, string claimValue)
         {
             return AspNetRoleClaimsDataLayer.SelectAllDynamicWhere(id, roleId, claimType, claimValue);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoleClaims sorted by the sort expression.
         /// </summary>
         public static List<AspNetRoleClaims> SelectAllDynamicWhere(int? id, string roleId, string claimType, string claimValue, string sortByExpression)
         {
             List<AspNetRoleClaims> objAspNetRoleClaimsCol = AspNetRoleClaimsDataLayer.SelectAllDynamicWhere(id, roleId, claimType, claimValue);
             return SortByExpression(objAspNetRoleClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects all AspNetRoleClaims by AspNetRoles, related to column RoleId
         /// </summary>
         public static List<AspNetRoleClaims> SelectAspNetRoleClaimsCollectionByRoleId(string id)
         {
             return AspNetRoleClaimsDataLayer.SelectAspNetRoleClaimsCollectionByRoleId(id);
         }

         /// <summary>
         /// Selects all AspNetRoleClaims by AspNetRoles, related to column RoleId, sorted by the sort expression
         /// </summary>
         public static List<AspNetRoleClaims> SelectAspNetRoleClaimsCollectionByRoleId(string id, string sortByExpression)
         {
             List<AspNetRoleClaims> objAspNetRoleClaimsCol = AspNetRoleClaimsDataLayer.SelectAspNetRoleClaimsCollectionByRoleId(id);
             return SortByExpression(objAspNetRoleClaimsCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and ClaimType columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<AspNetRoleClaims> SelectAspNetRoleClaimsDropDownListData()
         {
             return AspNetRoleClaimsDataLayer.SelectAspNetRoleClaimsDropDownListData();
         }

         /// <summary>
         /// Sorts the List<AspNetRoleClaims >by sort expression
         /// </summary>
         public static List<AspNetRoleClaims> SortByExpression(List<AspNetRoleClaims> objAspNetRoleClaimsCol, string sortExpression)
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
                     objAspNetRoleClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoleClaims.ById);
                     break;
                 case "RoleId":
                     objAspNetRoleClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoleClaims.ByRoleId);
                     break;
                 case "ClaimType":
                     objAspNetRoleClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoleClaims.ByClaimType);
                     break;
                 case "ClaimValue":
                     objAspNetRoleClaimsCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoleClaims.ByClaimValue);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetRoleClaimsCol.Reverse();

             return objAspNetRoleClaimsCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             AspNetRoleClaims objAspNetRoleClaims = (AspNetRoleClaims)this;
             return AspNetRoleClaimsDataLayer.Insert(objAspNetRoleClaims);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetRoleClaims objAspNetRoleClaims = (AspNetRoleClaims)this;
             AspNetRoleClaimsDataLayer.Update(objAspNetRoleClaims);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             AspNetRoleClaimsDataLayer.Delete(id);
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
         public static Comparison<AspNetRoleClaims> ById = delegate(AspNetRoleClaims x, AspNetRoleClaims y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares RoleId used for sorting
         /// </summary>
         public static Comparison<AspNetRoleClaims> ByRoleId = delegate(AspNetRoleClaims x, AspNetRoleClaims y)
         {
             string value1 = x.RoleId ?? String.Empty;
             string value2 = y.RoleId ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ClaimType used for sorting
         /// </summary>
         public static Comparison<AspNetRoleClaims> ByClaimType = delegate(AspNetRoleClaims x, AspNetRoleClaims y)
         {
             string value1 = x.ClaimType ?? String.Empty;
             string value2 = y.ClaimType ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ClaimValue used for sorting
         /// </summary>
         public static Comparison<AspNetRoleClaims> ByClaimValue = delegate(AspNetRoleClaims x, AspNetRoleClaims y)
         {
             string value1 = x.ClaimValue ?? String.Empty;
             string value2 = y.ClaimValue ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
