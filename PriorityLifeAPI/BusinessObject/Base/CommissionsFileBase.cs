using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for CommissionsFile.  Do not make changes to this class,
     /// instead, put additional code in the CommissionsFile class
     /// </summary>
     public class CommissionsFileBase : PriorityLifeAPI.Models.CommissionsFileModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public CommissionsFileBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static CommissionsFile SelectByPrimaryKey(int id)
         {
             return CommissionsFileDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table
         /// </summary>
         public static int GetRecordCount()
         {
             return CommissionsFileDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table by CarrierId
         /// </summary>
         public static int GetRecordCountByCarrierId(int carrierId)
         {
             return CommissionsFileDataLayer.GetRecordCountByCarrierId(carrierId);
         }

         /// <summary>
         /// Gets the total number of records in the CommissionsFile table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsFileDataLayer.GetRecordCountDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<CommissionsFile> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsFileDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by CarrierId as a collection (List) of CommissionsFile sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<CommissionsFile> SelectSkipAndTakeByCarrierId(int rows, int startRowIndex, string sortByExpression, int carrierId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsFileDataLayer.SelectSkipAndTakeByCarrierId(sortByExpression, startRowIndex, rows, carrierId);
         }

         /// <summary>
         /// Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<CommissionsFile> SelectSkipAndTakeDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsFileDataLayer.SelectSkipAndTakeDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of CommissionsFile
         /// </summary>
         public static List<CommissionsFile> SelectAll()
         {
             return CommissionsFileDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of CommissionsFile sorted by the sort expression
         /// </summary>
         public static List<CommissionsFile> SelectAll(string sortByExpression)
         {
             List<CommissionsFile> objCommissionsFileCol = CommissionsFileDataLayer.SelectAll();
             return SortByExpression(objCommissionsFileCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsFile.
         /// </summary>
         public static List<CommissionsFile> SelectAllDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsFileDataLayer.SelectAllDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of CommissionsFile sorted by the sort expression.
         /// </summary>
         public static List<CommissionsFile> SelectAllDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<CommissionsFile> objCommissionsFileCol = CommissionsFileDataLayer.SelectAllDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objCommissionsFileCol, sortByExpression);
         }

         /// <summary>
         /// Selects all CommissionsFile by Carriers, related to column CarrierId
         /// </summary>
         public static List<CommissionsFile> SelectCommissionsFileCollectionByCarrierId(int id)
         {
             return CommissionsFileDataLayer.SelectCommissionsFileCollectionByCarrierId(id);
         }

         /// <summary>
         /// Selects all CommissionsFile by Carriers, related to column CarrierId, sorted by the sort expression
         /// </summary>
         public static List<CommissionsFile> SelectCommissionsFileCollectionByCarrierId(int id, string sortByExpression)
         {
             List<CommissionsFile> objCommissionsFileCol = CommissionsFileDataLayer.SelectCommissionsFileCollectionByCarrierId(id);
             return SortByExpression(objCommissionsFileCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<CommissionsFile> SelectCommissionsFileDropDownListData()
         {
             return CommissionsFileDataLayer.SelectCommissionsFileDropDownListData();
         }

         /// <summary>
         /// Sorts the List<CommissionsFile >by sort expression
         /// </summary>
         public static List<CommissionsFile> SortByExpression(List<CommissionsFile> objCommissionsFileCol, string sortExpression)
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
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ById);
                     break;
                 case "CarrierId":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByCarrierId);
                     break;
                 case "ExtractedDate":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByExtractedDate);
                     break;
                 case "FileUrl":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByFileUrl);
                     break;
                 case "Extension":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByExtension);
                     break;
                 case "Active":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByActive);
                     break;
                 case "AddedBy":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByAddedBy);
                     break;
                 case "AddedDate":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objCommissionsFileCol.Sort(PriorityLifeAPI.BusinessObject.CommissionsFile.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objCommissionsFileCol.Reverse();

             return objCommissionsFileCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             CommissionsFile objCommissionsFile = (CommissionsFile)this;
             return CommissionsFileDataLayer.Insert(objCommissionsFile);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             CommissionsFile objCommissionsFile = (CommissionsFile)this;
             CommissionsFileDataLayer.Update(objCommissionsFile);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             CommissionsFileDataLayer.Delete(id);
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
         public static Comparison<CommissionsFile> ById = delegate(CommissionsFile x, CommissionsFile y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares CarrierId used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByCarrierId = delegate(CommissionsFile x, CommissionsFile y)
         {
             return x.CarrierId.CompareTo(y.CarrierId);
         };

         /// <summary>
         /// Compares ExtractedDate used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByExtractedDate = delegate(CommissionsFile x, CommissionsFile y)
         {
             return x.ExtractedDate.CompareTo(y.ExtractedDate);
         };

         /// <summary>
         /// Compares FileUrl used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByFileUrl = delegate(CommissionsFile x, CommissionsFile y)
         {
             string value1 = x.FileUrl ?? String.Empty;
             string value2 = y.FileUrl ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Extension used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByExtension = delegate(CommissionsFile x, CommissionsFile y)
         {
             string value1 = x.Extension ?? String.Empty;
             string value2 = y.Extension ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByActive = delegate(CommissionsFile x, CommissionsFile y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByAddedBy = delegate(CommissionsFile x, CommissionsFile y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByAddedDate = delegate(CommissionsFile x, CommissionsFile y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByUpdatedBy = delegate(CommissionsFile x, CommissionsFile y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<CommissionsFile> ByUpdatedDate = delegate(CommissionsFile x, CommissionsFile y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
