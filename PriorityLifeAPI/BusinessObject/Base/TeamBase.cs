using System;
using PriorityLifeAPI.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriorityLifeAPI.BusinessObject.Base
{
     /// <summary>
     /// Base class for Team.  Do not make changes to this class,
     /// instead, put additional code in the Team class
     /// </summary>
     public class TeamBase : PriorityLifeAPI.Models.TeamModel
     {

         /// <summary>
         /// Constructor
         /// </summary>
         public TeamBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         public static Team SelectByPrimaryKey(int id)
         {
             return TeamDataLayer.SelectByPrimaryKey(id);
         }

         /// <summary>
         /// Gets the total number of records in the Team table
         /// </summary>
         public static int GetRecordCount()
         {
             return TeamDataLayer.GetRecordCount();
         }

         /// <summary>
         /// Gets the total number of records in the Team table by TeamManager
         /// </summary>
         public static int GetRecordCountByTeamManager(int teamManager)
         {
             return TeamDataLayer.GetRecordCountByTeamManager(teamManager);
         }

         /// <summary>
         /// Gets the total number of records in the Team table based on search parameters
         /// </summary>
         public static int GetRecordCountDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return TeamDataLayer.GetRecordCountDynamicWhere(id, teamManager, teamName, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records as a collection (List) of Team sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         public static List<Team> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDataLayer.SelectSkipAndTake(sortByExpression, startRowIndex, rows, isIncludeRelatedProperties);
         }

         /// <summary>
         /// Selects records by TeamManager as a collection (List) of Team sorted by the sortByExpression starting from the startRowIndex
         /// </summary>
         public static List<Team> SelectSkipAndTakeByTeamManager(int rows, int startRowIndex, string sortByExpression, int teamManager)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDataLayer.SelectSkipAndTakeByTeamManager(sortByExpression, startRowIndex, rows, teamManager);
         }

         /// <summary>
         /// Selects records as a collection (List) of Team sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
         /// </summary>
         public static List<Team> SelectSkipAndTakeDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression)
         {
             sortByExpression = GetSortExpression(sortByExpression);
             return TeamDataLayer.SelectSkipAndTakeDynamicWhere(id, teamManager, teamName, active, addedBy, addedDate, updatedBy, updatedDate, sortByExpression, startRowIndex, rows);
         }

         /// <summary>
         /// Selects all records as a collection (List) of Team
         /// </summary>
         public static List<Team> SelectAll()
         {
             return TeamDataLayer.SelectAll();
         }

         /// <summary>
         /// Selects all records as a collection (List) of Team sorted by the sort expression
         /// </summary>
         public static List<Team> SelectAll(string sortByExpression)
         {
             List<Team> objTeamCol = TeamDataLayer.SelectAll();
             return SortByExpression(objTeamCol, sortByExpression);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Team.
         /// </summary>
         public static List<Team> SelectAllDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             return TeamDataLayer.SelectAllDynamicWhere(id, teamManager, teamName, active, addedBy, addedDate, updatedBy, updatedDate);
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Team sorted by the sort expression.
         /// </summary>
         public static List<Team> SelectAllDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression)
         {
             List<Team> objTeamCol = TeamDataLayer.SelectAllDynamicWhere(id, teamManager, teamName, active, addedBy, addedDate, updatedBy, updatedDate);
             return SortByExpression(objTeamCol, sortByExpression);
         }

         /// <summary>
         /// Selects all Team by Salesperson, related to column TeamManager
         /// </summary>
         public static List<Team> SelectTeamCollectionByTeamManager(int id)
         {
             return TeamDataLayer.SelectTeamCollectionByTeamManager(id);
         }

         /// <summary>
         /// Selects all Team by Salesperson, related to column TeamManager, sorted by the sort expression
         /// </summary>
         public static List<Team> SelectTeamCollectionByTeamManager(int id, string sortByExpression)
         {
             List<Team> objTeamCol = TeamDataLayer.SelectTeamCollectionByTeamManager(id);
             return SortByExpression(objTeamCol, sortByExpression);
         }

         /// <summary>
         /// Selects Id and TeamName columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
         /// </summary>
         public static List<Team> SelectTeamDropDownListData()
         {
             return TeamDataLayer.SelectTeamDropDownListData();
         }

         /// <summary>
         /// Sorts the List<Team >by sort expression
         /// </summary>
         public static List<Team> SortByExpression(List<Team> objTeamCol, string sortExpression)
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
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ById);
                     break;
                 case "TeamManager":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByTeamManager);
                     break;
                 case "TeamName":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByTeamName);
                     break;
                 case "Active":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByActive);
                     break;
                 case "AddedBy":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByAddedBy);
                     break;
                 case "AddedDate":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByAddedDate);
                     break;
                 case "UpdatedBy":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByUpdatedBy);
                     break;
                 case "UpdatedDate":
                     objTeamCol.Sort(PriorityLifeAPI.BusinessObject.Team.ByUpdatedDate);
                     break;
                 default:
                     break;
             }

             if (isSortDescending)
                 objTeamCol.Reverse();

             return objTeamCol;
         }

         /// <summary>
         /// Inserts a record
         /// </summary>
         public int Insert()
         {
             Team objTeam = (Team)this;
             return TeamDataLayer.Insert(objTeam);
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         public void Update()
         {
             Team objTeam = (Team)this;
             TeamDataLayer.Update(objTeam);
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         public static void Delete(int id)
         {
             TeamDataLayer.Delete(id);
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
         public static Comparison<Team> ById = delegate(Team x, Team y)
         {
             return x.Id.CompareTo(y.Id);
         };

         /// <summary>
         /// Compares TeamManager used for sorting
         /// </summary>
         public static Comparison<Team> ByTeamManager = delegate(Team x, Team y)
         {
             return x.TeamManager.CompareTo(y.TeamManager);
         };

         /// <summary>
         /// Compares TeamName used for sorting
         /// </summary>
         public static Comparison<Team> ByTeamName = delegate(Team x, Team y)
         {
             string value1 = x.TeamName ?? String.Empty;
             string value2 = y.TeamName ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares Active used for sorting
         /// </summary>
         public static Comparison<Team> ByActive = delegate(Team x, Team y)
         {
             return x.Active.CompareTo(y.Active);
         };

         /// <summary>
         /// Compares AddedBy used for sorting
         /// </summary>
         public static Comparison<Team> ByAddedBy = delegate(Team x, Team y)
         {
             string value1 = x.AddedBy ?? String.Empty;
             string value2 = y.AddedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares AddedDate used for sorting
         /// </summary>
         public static Comparison<Team> ByAddedDate = delegate(Team x, Team y)
         {
             return x.AddedDate.CompareTo(y.AddedDate);
         };

         /// <summary>
         /// Compares UpdatedBy used for sorting
         /// </summary>
         public static Comparison<Team> ByUpdatedBy = delegate(Team x, Team y)
         {
             string value1 = x.UpdatedBy ?? String.Empty;
             string value2 = y.UpdatedBy ?? String.Empty;
             return value1.CompareTo(value2);
         };

         /// <summary>
         /// Compares UpdatedDate used for sorting
         /// </summary>
         public static Comparison<Team> ByUpdatedDate = delegate(Team x, Team y)
         {
             return Nullable.Compare(x.UpdatedDate, y.UpdatedDate);
         };

     }
}
