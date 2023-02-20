using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for Commissions.  Do not make changes to this class,
     /// instead, put additional code in the Commissions class
     /// </summary>
     public class CommissionsBase : PriorityLifeAPI.Models.CommissionsModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public CommissionsBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static Commissions SelectByPrimaryKey(int id)
         {
             return CommissionsDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the Commissions table
         /// </summary>
         public static int GetRecordCount()
         {
             return CommissionsDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the Commissions table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsDataLayer.GetRecordCountDynamicWhere(id, salespersonId, carrierId, commissionDate, amount, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of Commissions sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<Commissions> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of Commissions sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<Commissions> SelectSkipAndTakeDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return CommissionsDataLayer.SelectSkipAndTakeDynamicWhere(id, salespersonId, carrierId, commissionDate, amount, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of Commissions
         /// </summary>
         public static List<Commissions> SelectAll()
         {
             return CommissionsDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of Commissions sorted by the sort expression
         /// </summary>
         public static List<Commissions> SelectAll(string sortByExpression)
         {
             List<Commissions> objCommissionsCol = CommissionsDataLayer.SelectAll();
             return SortByExpression(objCommissionsCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Commissions.
         /// </summary>
         public static List<Commissions> SelectAllDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return CommissionsDataLayer.SelectAllDynamicWhere(id, salespersonId, carrierId, commissionDate, amount, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Commissions sorted by the sort expression.
         /// </summary>
         public static List<Commissions> SelectAllDynamicWhere(int? id, int? salespersonId, int? carrierId, DateTime? commissionDate, decimal? amount, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<Commissions> objCommissionsCol = CommissionsDataLayer.SelectAllDynamicWhere(id, salespersonId, carrierId, commissionDate, amount, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objCommissionsCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<Commissions> SelectCommissionsDropDownListData()
         {
             return CommissionsDataLayer.SelectCommissionsDropDownListData();
         }

         /// <summary>
         /// Sorts the List<Commissions >by sort expression
         /// </summary>
         public static List<Commissions> SortByExpression(List<Commissions> objCommissionsCol, string sortExpression)
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
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ById);
                     break;
                 case "SalespersonId":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.BySalespersonId);
                     break;
                 case "CarrierId":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByCarrierId);
                     break;
                 case "CommissionDate":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByCommissionDate);
                     break;
                 case "Amount":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByAmount);
                     break;
                 case "AddedBy":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByAddedBy);
                     break;
                 case "AddedDate":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objCommissionsCol.Sort(PriorityLifeAPI.BusinessObject.Commissions.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objCommissionsCol.Reverse();

             return objCommissionsCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             Commissions objCommissions = (Commissions)this;
             return CommissionsDataLayer.Insert(objCommissions);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             Commissions objCommissions = (Commissions)this;
             CommissionsDataLayer.Update(objCommissions);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             CommissionsDataLayer.Delete(id);
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
         public static Comparison<Commissions> ById = delegate(Commissions x, Commissions y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares SalespersonId used for sorting
         /// </summary>
         public static Comparison<Commissions> BySalespersonId = delegate(Commissions x, Commissions y)
         {
             return x.SalespersonId.CompareTo(y.SalespersonId);
         };

         /// <summary>
         /// Compares CarrierId used for sorting
         /// </summary>
         public static Comparison<Commissions> ByCarrierId = delegate(Commissions x, Commissions y)
         {
             return x.CarrierId.CompareTo(y.CarrierId);
         };

         /// <summary>
         /// Compares CommissionDate used for sorting
         /// </summary>
         public static Comparison<Commissions> ByCommissionDate = delegate(Commissions x, Commissions y)
         {
             return x.CommissionDate.CompareTo(y.CommissionDate);
         };

         /// <summary>
         /// Compares Amount used for sorting
         /// </summary>
         public static Comparison<Commissions> ByAmount = delegate(Commissions x, Commissions y)
         {
             return x.Amount.CompareTo(y.Amount);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<Commissions> ByAddedBy = delegate(Commissions x, Commissions y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<Commissions> ByAddedDate = delegate(Commissions x, Commissions y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<Commissions> ByUpdatedBy = delegate(Commissions x, Commissions y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<Commissions> ByUpdatedDate = delegate(Commissions x, Commissions y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
