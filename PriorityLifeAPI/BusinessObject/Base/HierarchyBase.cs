using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for Hierarchy.  Do not make changes to this class,
     /// instead, put additional code in the Hierarchy class
     /// </summary>
     public class HierarchyBase : PriorityLifeAPI.Models.HierarchyModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public HierarchyBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static Hierarchy SelectByPrimaryKey(int id)
         {
             return HierarchyDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table
         /// </summary>
         public static int GetRecordCount()
         {
             return HierarchyDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by SalesPersonId
         /// </summary>
         public static int GetRecordCountBySalesPersonId(int salesPersonId)
         {
             return HierarchyDataLayer.GetRecordCountBySalesPersonId(salesPersonId);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline1Id
         /// </summary>
         public static int GetRecordCountByUpline1Id(int upline1Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline1Id(upline1Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline2Id
         /// </summary>
         public static int GetRecordCountByUpline2Id(int upline2Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline2Id(upline2Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline3Id
         /// </summary>
         public static int GetRecordCountByUpline3Id(int upline3Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline3Id(upline3Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline4Id
         /// </summary>
         public static int GetRecordCountByUpline4Id(int upline4Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline4Id(upline4Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline5Id
         /// </summary>
         public static int GetRecordCountByUpline5Id(int upline5Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline5Id(upline5Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline6Id
         /// </summary>
         public static int GetRecordCountByUpline6Id(int upline6Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline6Id(upline6Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline7Id
         /// </summary>
         public static int GetRecordCountByUpline7Id(int upline7Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline7Id(upline7Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline8Id
         /// </summary>
         public static int GetRecordCountByUpline8Id(int upline8Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline8Id(upline8Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline9Id
         /// </summary>
         public static int GetRecordCountByUpline9Id(int upline9Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline9Id(upline9Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table by Upline10Id
         /// </summary>
         public static int GetRecordCountByUpline10Id(int upline10Id)
         {
             return HierarchyDataLayer.GetRecordCountByUpline10Id(upline10Id);
         }

         /// <summary>
         /// Gets the total number of records in the Hierarchy table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return HierarchyDataLayer.GetRecordCountDynamicWhere(id, salesPersonId, upline1Id, upline2Id, upline3Id, upline4Id, upline5Id, upline6Id, upline7Id, upline8Id, upline9Id, upline10Id, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of Hierarchy sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by SalesPersonId as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeBySalesPersonId(int rows, int startRowIndex, string sortByExpression, int salesPersonId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeBySalesPersonId(sortByExpression, startRowIndex, rows, salesPersonId);
         }

         /// <summary>
         /// Selects records by Upline1Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline1Id(int rows, int startRowIndex, string sortByExpression, int upline1Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline1Id(sortByExpression, startRowIndex, rows, upline1Id);
         }

         /// <summary>
         /// Selects records by Upline2Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline2Id(int rows, int startRowIndex, string sortByExpression, int upline2Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline2Id(sortByExpression, startRowIndex, rows, upline2Id);
         }

         /// <summary>
         /// Selects records by Upline3Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline3Id(int rows, int startRowIndex, string sortByExpression, int upline3Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline3Id(sortByExpression, startRowIndex, rows, upline3Id);
         }

         /// <summary>
         /// Selects records by Upline4Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline4Id(int rows, int startRowIndex, string sortByExpression, int upline4Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline4Id(sortByExpression, startRowIndex, rows, upline4Id);
         }

         /// <summary>
         /// Selects records by Upline5Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline5Id(int rows, int startRowIndex, string sortByExpression, int upline5Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline5Id(sortByExpression, startRowIndex, rows, upline5Id);
         }

         /// <summary>
         /// Selects records by Upline6Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline6Id(int rows, int startRowIndex, string sortByExpression, int upline6Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline6Id(sortByExpression, startRowIndex, rows, upline6Id);
         }

         /// <summary>
         /// Selects records by Upline7Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline7Id(int rows, int startRowIndex, string sortByExpression, int upline7Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline7Id(sortByExpression, startRowIndex, rows, upline7Id);
         }

         /// <summary>
         /// Selects records by Upline8Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline8Id(int rows, int startRowIndex, string sortByExpression, int upline8Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline8Id(sortByExpression, startRowIndex, rows, upline8Id);
         }

         /// <summary>
         /// Selects records by Upline9Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline9Id(int rows, int startRowIndex, string sortByExpression, int upline9Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline9Id(sortByExpression, startRowIndex, rows, upline9Id);
         }

         /// <summary>
         /// Selects records by Upline10Id as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeByUpline10Id(int rows, int startRowIndex, string sortByExpression, int upline10Id)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeByUpline10Id(sortByExpression, startRowIndex, rows, upline10Id);
         }

         /// <summary>
         /// Selects records as a collection (List) of Hierarchy sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<Hierarchy> SelectSkipAndTakeDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return HierarchyDataLayer.SelectSkipAndTakeDynamicWhere(id, salesPersonId, upline1Id, upline2Id, upline3Id, upline4Id, upline5Id, upline6Id, upline7Id, upline8Id, upline9Id, upline10Id, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of Hierarchy
         /// </summary>
         public static List<Hierarchy> SelectAll()
         {
             return HierarchyDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of Hierarchy sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectAll(string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectAll();
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Hierarchy.
         /// </summary>
         public static List<Hierarchy> SelectAllDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return HierarchyDataLayer.SelectAllDynamicWhere(id, salesPersonId, upline1Id, upline2Id, upline3Id, upline4Id, upline5Id, upline6Id, upline7Id, upline8Id, upline9Id, upline10Id, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Hierarchy sorted by the sort expression.
         /// </summary>
         public static List<Hierarchy> SelectAllDynamicWhere(int? id, int? salesPersonId, int? upline1Id, int? upline2Id, int? upline3Id, int? upline4Id, int? upline5Id, int? upline6Id, int? upline7Id, int? upline8Id, int? upline9Id, int? upline10Id, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectAllDynamicWhere(id, salesPersonId, upline1Id, upline2Id, upline3Id, upline4Id, upline5Id, upline6Id, upline7Id, upline8Id, upline9Id, upline10Id, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column SalesPersonId
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionBySalesPersonId(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionBySalesPersonId(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column SalesPersonId, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionBySalesPersonId(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionBySalesPersonId(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline1Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline1Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline1Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline1Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline1Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline1Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline2Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline2Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline2Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline2Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline2Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline2Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline3Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline3Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline3Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline3Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline3Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline3Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline4Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline4Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline4Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline4Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline4Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline4Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline5Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline5Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline5Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline5Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline5Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline5Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline6Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline6Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline6Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline6Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline6Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline6Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline7Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline7Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline7Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline7Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline7Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline7Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline8Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline8Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline8Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline8Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline8Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline8Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline9Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline9Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline9Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline9Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline9Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline9Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline10Id
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline10Id(int id)
         {
             return HierarchyDataLayer.SelectHierarchyCollectionByUpline10Id(id);
         }

         /// <summary>
         /// Selects all Hierarchy by Salesperson, related to column Upline10Id, sorted by the sort expression
         /// </summary>
         public static List<Hierarchy> SelectHierarchyCollectionByUpline10Id(int id, string sortByExpression)
         {
             List<Hierarchy> objHierarchyCol = HierarchyDataLayer.SelectHierarchyCollectionByUpline10Id(id);
             return SortByExpression(objHierarchyCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<Hierarchy> SelectHierarchyDropDownListData()
         {
             return HierarchyDataLayer.SelectHierarchyDropDownListData();
         }

         /// <summary>
         /// Sorts the List<Hierarchy >by sort expression
         /// </summary>
         public static List<Hierarchy> SortByExpression(List<Hierarchy> objHierarchyCol, string sortExpression)
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
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ById);
                     break;
                 case "SalesPersonId":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.BySalesPersonId);
                     break;
                 case "Upline1Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline1Id);
                     break;
                 case "Upline2Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline2Id);
                     break;
                 case "Upline3Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline3Id);
                     break;
                 case "Upline4Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline4Id);
                     break;
                 case "Upline5Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline5Id);
                     break;
                 case "Upline6Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline6Id);
                     break;
                 case "Upline7Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline7Id);
                     break;
                 case "Upline8Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline8Id);
                     break;
                 case "Upline9Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline9Id);
                     break;
                 case "Upline10Id":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpline10Id);
                     break;
                 case "Active":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByActive);
                     break;
                 case "AddedBy":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByAddedBy);
                     break;
                 case "AddedDate":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objHierarchyCol.Sort(PriorityLifeAPI.BusinessObject.Hierarchy.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objHierarchyCol.Reverse();

             return objHierarchyCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             Hierarchy objHierarchy = (Hierarchy)this;
             return HierarchyDataLayer.Insert(objHierarchy);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             Hierarchy objHierarchy = (Hierarchy)this;
             HierarchyDataLayer.Update(objHierarchy);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             HierarchyDataLayer.Delete(id);
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
         public static Comparison<Hierarchy> ById = delegate(Hierarchy x, Hierarchy y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares SalesPersonId used for sorting
         /// </summary>
         public static Comparison<Hierarchy> BySalesPersonId = delegate(Hierarchy x, Hierarchy y)
         {
             return x.SalesPersonId.CompareTo(y.SalesPersonId);
         };

         /// <summary>
         /// Compares Upline1Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline1Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline1Id, y.Upline1Id);
         };

         /// <summary>
         /// Compares Upline2Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline2Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline2Id, y.Upline2Id);
         };

         /// <summary>
         /// Compares Upline3Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline3Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline3Id, y.Upline3Id);
         };

         /// <summary>
         /// Compares Upline4Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline4Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline4Id, y.Upline4Id);
         };

         /// <summary>
         /// Compares Upline5Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline5Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline5Id, y.Upline5Id);
         };

         /// <summary>
         /// Compares Upline6Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline6Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline6Id, y.Upline6Id);
         };

         /// <summary>
         /// Compares Upline7Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline7Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline7Id, y.Upline7Id);
         };

         /// <summary>
         /// Compares Upline8Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline8Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline8Id, y.Upline8Id);
         };

         /// <summary>
         /// Compares Upline9Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline9Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline9Id, y.Upline9Id);
         };

         /// <summary>
         /// Compares Upline10Id used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpline10Id = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.Upline10Id, y.Upline10Id);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByActive = delegate(Hierarchy x, Hierarchy y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByAddedBy = delegate(Hierarchy x, Hierarchy y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByAddedDate = delegate(Hierarchy x, Hierarchy y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpdatedBy = delegate(Hierarchy x, Hierarchy y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<Hierarchy> ByUpdatedDate = delegate(Hierarchy x, Hierarchy y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
