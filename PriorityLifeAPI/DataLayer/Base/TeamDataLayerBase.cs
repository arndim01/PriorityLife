using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for TeamDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the TeamDataLayer class
     /// </summary>
     internal class TeamDataLayerBase
     {
         // constructor
         internal TeamDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static Team SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Team.Where(t => t.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the Team table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Team.Count();
         }

         /// <summary>
         /// Gets the total number of records in the Team table by TeamManager
         /// </summary>
         internal static int GetRecordCountByTeamManager(int teamManager)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Team.Where(t => t.TeamManager == teamManager).Count();
         }

         /// <summary>
         /// Gets the total number of records in the Team table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamManagerValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (teamManager != null)
                teamManagerValue = teamManager.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Team
                 .Where(t =>
                           (id != null ? t.Id == idValue : 1 == 1) &&
                           (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                           (active != null ? t.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects Team records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<Team> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "TeamManager desc":
                             return context.Team.OrderByDescending(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamName desc":
                             return context.Team.OrderByDescending(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Team.OrderByDescending(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Team.OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Team.OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Team.OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Team.OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Team.OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "TeamManager":
                             return context.Team.OrderBy(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamName":
                             return context.Team.OrderBy(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Team.OrderBy(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Team.OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Team.OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Team.OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Team.OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Team.OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "TeamManager desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamName desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                         case "Active desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "TeamManager":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamName":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                         case "Active":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.Team.Include(t => t.TeamManagerNavigation).Include(tm => tm.TeamDetails).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by TeamManager as a collection (List) of Team sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<Team> SelectSkipAndTakeByTeamManager(string sortByExpression, int startRowIndex, int rows, int teamManager)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "TeamManager desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamName desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                     case "Active desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "TeamManager":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamName":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();
                     case "Active":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.Active).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.Team.Where(t => t.TeamManager == teamManager).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects Team records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<Team> SelectSkipAndTakeDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamManagerValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (teamManager != null)
                teamManagerValue = teamManager.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "TeamManager desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();

                     case "TeamName desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();

                     case "Active desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "TeamManager":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.TeamManager).Skip(startRowIndex).Take(rows).ToList();

                     case "TeamName":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.TeamName).Skip(startRowIndex).Take(rows).ToList();

                     case "Active":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.Active).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.Team
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                                       (active != null ? t.Active == activeValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all Team
         /// </summary>
         internal static List<Team> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Team.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of Team.
         /// </summary>
         internal static List<Team> SelectAllDynamicWhere(int? id, int? teamManager, string teamName, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamManagerValue = int.MinValue;
             bool activeValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (teamManager != null)
                teamManagerValue = teamManager.Value;

             if (active != null)
                activeValue = active.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.Team
                 .Where(t =>
                           (id != null ? t.Id == idValue : 1 == 1) &&
                           (teamManager != null ? t.TeamManager == teamManagerValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(teamName) ? t.TeamName.Contains(teamName) : 1 == 1) &&
                           (active != null ? t.Active == activeValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all Team by Salesperson, related to column TeamManager
         /// </summary>
         internal static List<Team> SelectTeamCollectionByTeamManager(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.Team.Where(t => t.TeamManager == id).ToList();
         }
         /// <summary>
         /// Selects Id and TeamName columns for use with a DropDownList web control
         /// </summary>
         internal static List<Team> SelectTeamDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from t in context.Team
                     select new Team { Id = t.Id, TeamName = t.TeamName }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(Team objTeam)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Team entTeam = new Team();

             entTeam.TeamManager = objTeam.TeamManager;
             entTeam.TeamName = objTeam.TeamName;
             entTeam.Active = objTeam.Active;
             entTeam.AddedBy = objTeam.AddedBy;
             entTeam.AddedDate = objTeam.AddedDate;
             entTeam.UpdatedBy = objTeam.UpdatedBy;
             entTeam.UpdatedDate = objTeam.UpdatedDate;

             context.Team.Add(entTeam);
             context.SaveChanges();

             return entTeam.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(Team objTeam)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             Team entTeam = context.Team.Where(t => t.Id == objTeam.Id).FirstOrDefault();

             if (entTeam != null)
             {
                 entTeam.TeamManager = objTeam.TeamManager;
                 entTeam.TeamName = objTeam.TeamName;
                 entTeam.Active = objTeam.Active;
                 entTeam.AddedBy = objTeam.AddedBy;
                 entTeam.AddedDate = objTeam.AddedDate;
                 entTeam.UpdatedBy = objTeam.UpdatedBy;
                 entTeam.UpdatedDate = objTeam.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objTeam = context.Team.Where(t => t.Id == id).FirstOrDefault();

             if (objTeam != null)
             {
                 context.Team.Remove(objTeam);
                 context.SaveChanges();
             }
         }
     }
}
