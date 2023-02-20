using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for TeamDetails.  Do not make changes to this class,
     /// instead, put additional code in the TeamDetails class
     /// </summary>
     public class TeamDetailsBase : PriorityLifeAPI.Models.TeamDetailsModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public TeamDetailsBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static TeamDetails SelectByPrimaryKey(int id)
         {
             return TeamDetailsDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table
         /// </summary>
         public static int GetRecordCount()
         {
             return TeamDetailsDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table by TeamId
         /// </summary>
         public static int GetRecordCountByTeamId(int teamId)
         {
             return TeamDetailsDataLayer.GetRecordCountByTeamId(teamId);
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table by TeamMemberId
         /// </summary>
         public static int GetRecordCountByTeamMemberId(int teamMemberId)
         {
             return TeamDetailsDataLayer.GetRecordCountByTeamMemberId(teamMemberId);
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return TeamDetailsDataLayer.GetRecordCountDynamicWhere(id, teamId, teamMemberId, activate, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of TeamDetails sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<TeamDetails> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDetailsDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by TeamId as a collection (List) of TeamDetails sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<TeamDetails> SelectSkipAndTakeByTeamId(int rows, int startRowIndex, string sortByExpression, int teamId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDetailsDataLayer.SelectSkipAndTakeByTeamId(sortByExpression, startRowIndex, rows, teamId);
         }

         /// <summary>
         /// Selects records by TeamMemberId as a collection (List) of TeamDetails sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<TeamDetails> SelectSkipAndTakeByTeamMemberId(int rows, int startRowIndex, string sortByExpression, int teamMemberId)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDetailsDataLayer.SelectSkipAndTakeByTeamMemberId(sortByExpression, startRowIndex, rows, teamMemberId);
         }

         /// <summary>
         /// Selects records as a collection (List) of TeamDetails sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<TeamDetails> SelectSkipAndTakeDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDetailsDataLayer.SelectSkipAndTakeDynamicWhere(id, teamId, teamMemberId, activate, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of TeamDetails
         /// </summary>
         public static List<TeamDetails> SelectAll()
         {
             return TeamDetailsDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of TeamDetails sorted by the sort expression
         /// </summary>
         public static List<TeamDetails> SelectAll(string sortByExpression)
         {
             List<TeamDetails> objTeamDetailsCol = TeamDetailsDataLayer.SelectAll();
             return SortByExpression(objTeamDetailsCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of TeamDetails.
         /// </summary>
         public static List<TeamDetails> SelectAllDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return TeamDetailsDataLayer.SelectAllDynamicWhere(id, teamId, teamMemberId, activate, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of TeamDetails sorted by the sort expression.
         /// </summary>
         public static List<TeamDetails> SelectAllDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<TeamDetails> objTeamDetailsCol = TeamDetailsDataLayer.SelectAllDynamicWhere(id, teamId, teamMemberId, activate, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objTeamDetailsCol, sortByExpression);
         }

         /// <summary>
         /// Selects all TeamDetails by Team, related to column TeamId
         /// </summary>
         public static List<TeamDetails> SelectTeamDetailsCollectionByTeamId(int id)
         {
             return TeamDetailsDataLayer.SelectTeamDetailsCollectionByTeamId(id);
         }

         /// <summary>
         /// Selects all TeamDetails by Team, related to column TeamId, sorted by the sort expression
         /// </summary>
         public static List<TeamDetails> SelectTeamDetailsCollectionByTeamId(int id, string sortByExpression)
         {
             List<TeamDetails> objTeamDetailsCol = TeamDetailsDataLayer.SelectTeamDetailsCollectionByTeamId(id);
             return SortByExpression(objTeamDetailsCol, sortByExpression);
         }

         /// <summary>
         /// Selects all TeamDetails by Salesperson, related to column TeamMemberId
         /// </summary>
         public static List<TeamDetails> SelectTeamDetailsCollectionByTeamMemberId(int id)
         {
             return TeamDetailsDataLayer.SelectTeamDetailsCollectionByTeamMemberId(id);
         }

         /// <summary>
         /// Selects all TeamDetails by Salesperson, related to column TeamMemberId, sorted by the sort expression
         /// </summary>
         public static List<TeamDetails> SelectTeamDetailsCollectionByTeamMemberId(int id, string sortByExpression)
         {
             List<TeamDetails> objTeamDetailsCol = TeamDetailsDataLayer.SelectTeamDetailsCollectionByTeamMemberId(id);
             return SortByExpression(objTeamDetailsCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<TeamDetails> SelectTeamDetailsDropDownListData()
         {
             return TeamDetailsDataLayer.SelectTeamDetailsDropDownListData();
         }

         /// <summary>
         /// Sorts the List<TeamDetails >by sort expression
         /// </summary>
         public static List<TeamDetails> SortByExpression(List<TeamDetails> objTeamDetailsCol, string sortExpression)
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
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ById);
                     break;
                 case "TeamId":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByTeamId);
                     break;
                 case "TeamMemberId":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByTeamMemberId);
                     break;
                 case "Activate":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByActivate);
                     break;
                 case "AddedBy":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByAddedBy);
                     break;
                 case "AddedDate":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objTeamDetailsCol.Sort(PriorityLifeAPI.BusinessObject.TeamDetails.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objTeamDetailsCol.Reverse();

             return objTeamDetailsCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             TeamDetails objTeamDetails = (TeamDetails)this;
             return TeamDetailsDataLayer.Insert(objTeamDetails);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             TeamDetails objTeamDetails = (TeamDetails)this;
             TeamDetailsDataLayer.Update(objTeamDetails);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             TeamDetailsDataLayer.Delete(id);
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
         public static Comparison<TeamDetails> ById = delegate(TeamDetails x, TeamDetails y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares TeamId used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByTeamId = delegate(TeamDetails x, TeamDetails y)
         {
             return x.TeamId.CompareTo(y.TeamId);
         };

         /// <summary>
         /// Compares TeamMemberId used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByTeamMemberId = delegate(TeamDetails x, TeamDetails y)
         {
             return x.TeamMemberId.CompareTo(y.TeamMemberId);
         };

         /// <summary>
         /// Compares Activate used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByActivate = delegate(TeamDetails x, TeamDetails y)
         {
             return x.Activate.CompareTo(y.Activate);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByAddedBy = delegate(TeamDetails x, TeamDetails y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByAddedDate = delegate(TeamDetails x, TeamDetails y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByUpdatedBy = delegate(TeamDetails x, TeamDetails y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<TeamDetails> ByUpdatedDate = delegate(TeamDetails x, TeamDetails y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
