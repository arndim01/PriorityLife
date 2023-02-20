using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for Salesperson.  Do not make changes to this class,
     /// instead, put additional code in the Salesperson class
     /// </summary>
     public class SalespersonBase : PriorityLifeAPI.Models.SalespersonModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public SalespersonBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static Salesperson SelectByPrimaryKey(int id)
         {
             return SalespersonDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the Salesperson table
         /// </summary>
         public static int GetRecordCount()
         {
             return SalespersonDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the Salesperson table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return SalespersonDataLayer.GetRecordCountDynamicWhere(id, firstName, middleName, lastName, initials, email, phone, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of Salesperson sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<Salesperson> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return SalespersonDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects records as a collection (List) of Salesperson sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<Salesperson> SelectSkipAndTakeDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return SalespersonDataLayer.SelectSkipAndTakeDynamicWhere(id, firstName, middleName, lastName, initials, email, phone, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of Salesperson
         /// </summary>
         public static List<Salesperson> SelectAll()
         {
             return SalespersonDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of Salesperson sorted by the sort expression
         /// </summary>
         public static List<Salesperson> SelectAll(string sortByExpression)
         {
             List<Salesperson> objSalespersonCol = SalespersonDataLayer.SelectAll();
             return SortByExpression(objSalespersonCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Salesperson.
         /// </summary>
         public static List<Salesperson> SelectAllDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return SalespersonDataLayer.SelectAllDynamicWhere(id, firstName, middleName, lastName, initials, email, phone, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Salesperson sorted by the sort expression.
         /// </summary>
         public static List<Salesperson> SelectAllDynamicWhere(int? id, string firstName, string middleName, string lastName, string initials, string email, string phone, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<Salesperson> objSalespersonCol = SalespersonDataLayer.SelectAllDynamicWhere(id, firstName, middleName, lastName, initials, email, phone, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objSalespersonCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and FirstName columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<Salesperson> SelectSalespersonDropDownListData()
         {
             return SalespersonDataLayer.SelectSalespersonDropDownListData();
         }

         /// <summary>
         /// Sorts the List<Salesperson >by sort expression
         /// </summary>
         public static List<Salesperson> SortByExpression(List<Salesperson> objSalespersonCol, string sortExpression)
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
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ById);
                     break;
                 case "FirstName":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByFirstName);
                     break;
                 case "MiddleName":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByMiddleName);
                     break;
                 case "LastName":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByLastName);
                     break;
                 case "Initials":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByInitials);
                     break;
                 case "Email":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByEmail);
                     break;
                 case "Phone":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByPhone);
                     break;
                 case "Active":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByActive);
                     break;
                 case "AddedBy":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByAddedBy);
                     break;
                 case "AddedDate":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objSalespersonCol.Sort(PriorityLifeAPI.BusinessObject.Salesperson.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objSalespersonCol.Reverse();

             return objSalespersonCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             Salesperson objSalesperson = (Salesperson)this;
             return SalespersonDataLayer.Insert(objSalesperson);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             Salesperson objSalesperson = (Salesperson)this;
             SalespersonDataLayer.Update(objSalesperson);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             SalespersonDataLayer.Delete(id);
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
         public static Comparison<Salesperson> ById = delegate(Salesperson x, Salesperson y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares FirstName used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByFirstName = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.FirstName ?? String.Empty;
             string value2 = y.FirstName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares MiddleName used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByMiddleName = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.MiddleName ?? String.Empty;
             string value2 = y.MiddleName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares LastName used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByLastName = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.LastName ?? String.Empty;
             string value2 = y.LastName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Initials used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByInitials = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.Initials ?? String.Empty;
             string value2 = y.Initials ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Email used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByEmail = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.Email ?? String.Empty;
             string value2 = y.Email ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Phone used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByPhone = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.Phone ?? String.Empty;
             string value2 = y.Phone ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByActive = delegate(Salesperson x, Salesperson y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByAddedBy = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByAddedDate = delegate(Salesperson x, Salesperson y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByUpdatedBy = delegate(Salesperson x, Salesperson y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<Salesperson> ByUpdatedDate = delegate(Salesperson x, Salesperson y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
