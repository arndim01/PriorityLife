using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for AspNetRoles.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRoles class
     /// </summary>
     public class AspNetRolesBase : PriorityLifeAPI.Models.AspNetRolesModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public AspNetRolesBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static AspNetRoles SelectByPrimaryKey(string id)
         {
             return AspNetRolesDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoles table
         /// </summary>
         public static int GetRecordCount()
         {
             return AspNetRolesDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the AspNetRoles table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp)
         {
             return AspNetRolesDataLayer.GetRecordCountDynamicWhere(id, name, normalizedName, concurrencyStamp);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetRoles sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<AspNetRoles> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetRolesDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of AspNetRoles sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<AspNetRoles> SelectSkipAndTakeDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return AspNetRolesDataLayer.SelectSkipAndTakeDynamicWhere(id, name, normalizedName, concurrencyStamp, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetRoles
         /// </summary>
         public static List<AspNetRoles> SelectAll()
         {
             return AspNetRolesDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of AspNetRoles sorted by the sort expression
         /// </summary>
         public static List<AspNetRoles> SelectAll(string sortByExpression)
         {
             List<AspNetRoles> objAspNetRolesCol = AspNetRolesDataLayer.SelectAll();
             return SortByExpression(objAspNetRolesCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoles.
         /// </summary>
         public static List<AspNetRoles> SelectAllDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp)
         {
             return AspNetRolesDataLayer.SelectAllDynamicWhere(id, name, normalizedName, concurrencyStamp);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of AspNetRoles sorted by the sort expression.
         /// </summary>
         public static List<AspNetRoles> SelectAllDynamicWhere(string id, string name, string normalizedName, string concurrencyStamp, string sortByExpression)
         {
             List<AspNetRoles> objAspNetRolesCol = AspNetRolesDataLayer.SelectAllDynamicWhere(id, name, normalizedName, concurrencyStamp);
             return SortByExpression(objAspNetRolesCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and Name columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<AspNetRoles> SelectAspNetRolesDropDownListData()
         {
             return AspNetRolesDataLayer.SelectAspNetRolesDropDownListData();
         }

         /// <summary>
         /// Sorts the List<AspNetRoles >by sort expression
         /// </summary>
         public static List<AspNetRoles> SortByExpression(List<AspNetRoles> objAspNetRolesCol, string sortExpression)
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
                     objAspNetRolesCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoles.ById);
                     break;
                 case "Name":
                     objAspNetRolesCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoles.ByName);
                     break;
                 case "NormalizedName":
                     objAspNetRolesCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoles.ByNormalizedName);
                     break;
                 case "ConcurrencyStamp":
                     objAspNetRolesCol.Sort(PriorityLifeAPI.BusinessObject.AspNetRoles.ByConcurrencyStamp);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objAspNetRolesCol.Reverse();

             return objAspNetRolesCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public string Insert()
         {
             AspNetRoles objAspNetRoles = (AspNetRoles)this;
             return AspNetRolesDataLayer.Insert(objAspNetRoles);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             AspNetRoles objAspNetRoles = (AspNetRoles)this;
             AspNetRolesDataLayer.Update(objAspNetRoles);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(string id)
         {
             AspNetRolesDataLayer.Delete(id);
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
         public static Comparison<AspNetRoles> ById = delegate(AspNetRoles x, AspNetRoles y)
         {
             string value1 = x.Id ?? String.Empty;
             string value2 = y.Id ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Name used for sorting
         /// </summary>
         public static Comparison<AspNetRoles> ByName = delegate(AspNetRoles x, AspNetRoles y)
         {
             string value1 = x.Name ?? String.Empty;
             string value2 = y.Name ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares NormalizedName used for sorting
         /// </summary>
         public static Comparison<AspNetRoles> ByNormalizedName = delegate(AspNetRoles x, AspNetRoles y)
         {
             string value1 = x.NormalizedName ?? String.Empty;
             string value2 = y.NormalizedName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ConcurrencyStamp used for sorting
         /// </summary>
         public static Comparison<AspNetRoles> ByConcurrencyStamp = delegate(AspNetRoles x, AspNetRoles y)
         {
             string value1 = x.ConcurrencyStamp ?? String.Empty;
             string value2 = y.ConcurrencyStamp ?? String.Empty;
             return value1.CompareTo(value2);
         };

     }
}
