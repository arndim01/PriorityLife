using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for CommissionsExtracted.  Do not make changes to this class,
     /// instead, put additional code in the CommissionsExtracted class
     /// </summary>
     public class CommissionsExtractedBase : PriorityLifeAPI.Models.CommissionsExtractedModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public CommissionsExtractedBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static CommissionsExtracted SelectByPrimaryKey(int id)
         {
             return CommissionsExtractedDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsExtracted table
         /// </summary>
         public static int GetRecordCount()
         {
             return CommissionsExtractedDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsExtracted table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsExtractedDataLayer.GetRecordCountDynamicWhere(id, carrier, firstName, lastName, amount, date, uCode, downloadType, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of CommissionsExtracted sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<CommissionsExtracted> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsExtractedDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of CommissionsExtracted sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<CommissionsExtracted> SelectSkipAndTakeDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsExtractedDataLayer.SelectSkipAndTakeDynamicWhere(id, carrier, firstName, lastName, amount, date, uCode, downloadType, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of CommissionsExtracted
         /// </summary>
         public static List<CommissionsExtracted> SelectAll()
         {
             return CommissionsExtractedDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of CommissionsExtracted sorted by the sort expression
         /// </summary>
         public static List<CommissionsExtracted> SelectAll(string sortByExpression)
         {
             List<CommissionsExtracted> objCommissionsExtractedCol = CommissionsExtractedDataLayer.SelectAll();
             return SortByExpression(objCommissionsExtractedCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsExtracted.
         /// </summary>
         public static List<CommissionsExtracted> SelectAllDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsExtractedDataLayer.SelectAllDynamicWhere(id, carrier, firstName, lastName, amount, date, uCode, downloadType, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsExtracted sorted by the sort expression.
         /// </summary>
         public static List<CommissionsExtracted> SelectAllDynamicWhere(int? id, string carrier, string firstName, string lastName, decimal? amount, DateTime? date, string uCode, string downloadType, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<CommissionsExtracted> objCommissionsExtractedCol = CommissionsExtractedDataLayer.SelectAllDynamicWhere(id, carrier, firstName, lastName, amount, date, uCode, downloadType, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objCommissionsExtractedCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and Carrier columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<CommissionsExtracted> SelectCommissionsExtractedDropDownListData()
         {
             return CommissionsExtractedDataLayer.SelectCommissionsExtractedDropDownListData();
         }

         /// <summary>
         /// Sorts the List<CommissionsExtracted >by sort expression
         /// </summary>
         public static List<CommissionsExtracted> SortByExpression(List<CommissionsExtracted> objCommissionsExtractedCol, string sortExpression)
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
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ById);
                     break;
                 case "Carrier":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByCarrier);
                     break;
                 case "FirstName":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByFirstName);
                     break;
                 case "LastName":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByLastName);
                     break;
                 case "Amount":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByAmount);
                     break;
                 case "Date":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByDate);
                     break;
                 case "UCode":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByUCode);
                     break;
                 case "DownloadType":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByDownloadType);
                     break;
                 case "Active":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByActive);
                     break;
                 case "AddedBy":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByAddedBy);
                     break;
                 case "AddedDate":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objCommissionsExtractedCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsExtracted.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objCommissionsExtractedCol.Reverse();

             return objCommissionsExtractedCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             CommissionsExtracted objCommissionsExtracted = (CommissionsExtracted)this;
             return CommissionsExtractedDataLayer.Insert(objCommissionsExtracted);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             CommissionsExtracted objCommissionsExtracted = (CommissionsExtracted)this;
             CommissionsExtractedDataLayer.Update(objCommissionsExtracted);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             CommissionsExtractedDataLayer.Delete(id);
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
         public static Comparison<CommissionsExtracted> ById = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares Carrier used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByCarrier = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.Carrier ?? String.Empty;
             string value2 = y.Carrier ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares FirstName used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByFirstName = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.FirstName ?? String.Empty;
             string value2 = y.FirstName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares LastName used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByLastName = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.LastName ?? String.Empty;
             string value2 = y.LastName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Amount used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByAmount = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return x.Amount.CompareTo(y.Amount);
         };

         /// <summary>
         /// Compares Date used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByDate = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return x.Date.CompareTo(y.Date);
         };

         /// <summary>
         /// Compares UCode used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByUCode = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.UCode ?? String.Empty;
             string value2 = y.UCode ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares DownloadType used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByDownloadType = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.DownloadType ?? String.Empty;
             string value2 = y.DownloadType ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByActive = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByAddedBy = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByAddedDate = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByUpdatedBy = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<CommissionsExtracted> ByUpdatedDate = delegate(CommissionsExtracted x, CommissionsExtracted y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
