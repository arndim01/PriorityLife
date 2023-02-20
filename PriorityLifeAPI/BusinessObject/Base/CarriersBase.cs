using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for Carriers.  Do not make changes to this class,
     /// instead, put additional code in the Carriers class
     /// </summary>
     public class CarriersBase : PriorityLifeAPI.Models.CarriersModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public CarriersBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static Carriers SelectByPrimaryKey(int id)
         {
             return CarriersDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the Carriers table
         /// </summary>
         public static int GetRecordCount()
         {
             return CarriersDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the Carriers table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CarriersDataLayer.GetRecordCountDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of Carriers sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<Carriers> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CarriersDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of Carriers sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<Carriers> SelectSkipAndTakeDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CarriersDataLayer.SelectSkipAndTakeDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of Carriers
         /// </summary>
         public static List<Carriers> SelectAll()
         {
             return CarriersDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of Carriers sorted by the sort expression
         /// </summary>
         public static List<Carriers> SelectAll(string sortByExpression)
         {
             List<Carriers> objCarriersCol = CarriersDataLayer.SelectAll();
             return SortByExpression(objCarriersCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Carriers.
         /// </summary>
         public static List<Carriers> SelectAllDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CarriersDataLayer.SelectAllDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Carriers sorted by the sort expression.
         /// </summary>
         public static List<Carriers> SelectAllDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<Carriers> objCarriersCol = CarriersDataLayer.SelectAllDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objCarriersCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and Name columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<Carriers> SelectCarriersDropDownListData()
         {
             return CarriersDataLayer.SelectCarriersDropDownListData();
         }

         /// <summary>
         /// Sorts the List<Carriers >by sort expression
         /// </summary>
         public static List<Carriers> SortByExpression(List<Carriers> objCarriersCol, string sortExpression)
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
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ById);
                     break;
                 case "Name":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByName);
                     break;
                 case "ShortName":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByShortName);
                     break;
                 case "Url":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByUrl);
                     break;
                 case "Username":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByUsername);
                     break;
                 case "Password":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByPassword);
                     break;
                 case "Active":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByActive);
                     break;
                 case "AddedBy":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByAddedBy);
                     break;
                 case "AddedDate":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objCarriersCol.Sort(PriorityLifeAPI.BusinessObject.Carriers.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objCarriersCol.Reverse();

             return objCarriersCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             Carriers objCarriers = (Carriers)this;
             return CarriersDataLayer.Insert(objCarriers);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             Carriers objCarriers = (Carriers)this;
             CarriersDataLayer.Update(objCarriers);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             CarriersDataLayer.Delete(id);
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
         public static Comparison<Carriers> ById = delegate(Carriers x, Carriers y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares Name used for sorting
         /// </summary>
         public static Comparison<Carriers> ByName = delegate(Carriers x, Carriers y)
         {
             string value1 = x.Name ?? String.Empty;
             string value2 = y.Name ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares ShortName used for sorting
         /// </summary>
         public static Comparison<Carriers> ByShortName = delegate(Carriers x, Carriers y)
         {
             string value1 = x.ShortName ?? String.Empty;
             string value2 = y.ShortName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Url used for sorting
         /// </summary>
         public static Comparison<Carriers> ByUrl = delegate(Carriers x, Carriers y)
         {
             string value1 = x.Url ?? String.Empty;
             string value2 = y.Url ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Username used for sorting
         /// </summary>
         public static Comparison<Carriers> ByUsername = delegate(Carriers x, Carriers y)
         {
             string value1 = x.Username ?? String.Empty;
             string value2 = y.Username ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Password used for sorting
         /// </summary>
         public static Comparison<Carriers> ByPassword = delegate(Carriers x, Carriers y)
         {
             string value1 = x.Password ?? String.Empty;
             string value2 = y.Password ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<Carriers> ByActive = delegate(Carriers x, Carriers y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<Carriers> ByAddedBy = delegate(Carriers x, Carriers y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<Carriers> ByAddedDate = delegate(Carriers x, Carriers y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<Carriers> ByUpdatedBy = delegate(Carriers x, Carriers y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<Carriers> ByUpdatedDate = delegate(Carriers x, Carriers y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
