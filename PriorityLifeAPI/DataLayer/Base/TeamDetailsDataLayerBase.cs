using PriorityLifeAPI.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PriorityLifeAPI.DataLayer.Base
{
     /// <summary>
     /// Base class for TeamDetailsDataLayer.  Do not make changes to this class,
     /// instead, put additional code in the TeamDetailsDataLayer class
     /// </summary>
     internal class TeamDetailsDataLayerBase
     {
         // constructor
         internal TeamDetailsDataLayerBase()
         {
         }

         /// <summary>
         /// Selects a record by primary key(s)
         /// </summary>
         internal static TeamDetails SelectByPrimaryKey(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Where(t => t.Id == id).FirstOrDefault();
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table
         /// </summary>
         internal static int GetRecordCount()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Count();
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table by TeamId
         /// </summary>
         internal static int GetRecordCountByTeamId(int teamId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Where(t => t.TeamId == teamId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table by TeamMemberId
         /// </summary>
         internal static int GetRecordCountByTeamMemberId(int teamMemberId)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).Count();
         }

         /// <summary>
         /// Gets the total number of records in the TeamDetails table based on search parameters
         /// </summary>
         internal static int GetRecordCountDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamIdValue = int.MinValue;
             int teamMemberIdValue = int.MinValue;
             bool activateValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (teamId != null)
                teamIdValue = teamId.Value;

             if (teamMemberId != null)
                teamMemberIdValue = teamMemberId.Value;

             if (activate != null)
                activateValue = activate.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.TeamDetails
                 .Where(t =>
                           (id != null ? t.Id == idValue : 1 == 1) &&
                           (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                           (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                           (activate != null ? t.Activate == activateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).Count();
         }

         /// <summary>
         /// Selects TeamDetails records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of rows)
         /// </summary>
         internal static List<TeamDetails> SelectSkipAndTake(string sortByExpression, int startRowIndex, int rows, bool isIncludeRelatedProperties = true)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (!isIncludeRelatedProperties)
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "TeamId desc":
                             return context.TeamDetails.OrderByDescending(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamMemberId desc":
                             return context.TeamDetails.OrderByDescending(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                         case "Activate desc":
                             return context.TeamDetails.OrderByDescending(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.TeamDetails.OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.TeamDetails.OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.TeamDetails.OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.TeamDetails.OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.TeamDetails.OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "TeamId":
                             return context.TeamDetails.OrderBy(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamMemberId":
                             return context.TeamDetails.OrderBy(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                         case "Activate":
                             return context.TeamDetails.OrderBy(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.TeamDetails.OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.TeamDetails.OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.TeamDetails.OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.TeamDetails.OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.TeamDetails.OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
             else
             {
                 if (sortByExpression.Contains(" desc"))
                 {
                     switch (sortByExpression)
                     {
                         case "TeamId desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamMemberId desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                         case "Activate desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate desc":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
                 else
                 {
                     switch (sortByExpression)
                     {
                         case "TeamId":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                         case "TeamMemberId":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                         case "Activate":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedBy":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "AddedDate":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedBy":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                         case "UpdatedDate":
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                         default:
                             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                     }
                 }
             }
         }

         /// <summary>
         /// Selects records by TeamId as a collection (List) of TeamDetails sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<TeamDetails> SelectSkipAndTakeByTeamId(string sortByExpression, int startRowIndex, int rows, int teamId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "TeamId desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamMemberId desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                     case "Activate desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "TeamId":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamMemberId":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                     case "Activate":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == teamId).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects records by TeamMemberId as a collection (List) of TeamDetails sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
         /// </summary>
         internal static List<TeamDetails> SelectSkipAndTakeByTeamMemberId(string sortByExpression, int startRowIndex, int rows, int teamMemberId)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "TeamId desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamMemberId desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                     case "Activate desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate desc":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderByDescending(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
             else
             {
                 switch (sortByExpression)
                 {
                     case "TeamId":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();
                     case "TeamMemberId":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();
                     case "Activate":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedBy":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "AddedDate":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedBy":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();
                     case "UpdatedDate":
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();
                     default:
                         return context.TeamDetails.Where(t => t.TeamMemberId == teamMemberId).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects TeamDetails records sorted by the sortByExpression and returns records from the startRowIndex with rows (# of records) based on search parameters
         /// </summary>
         internal static List<TeamDetails> SelectSkipAndTakeDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sortByExpression, int startRowIndex, int rows)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamIdValue = int.MinValue;
             int teamMemberIdValue = int.MinValue;
             bool activateValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime? updatedDateValue = null;

             if (id != null)
                idValue = id.Value;

             if (teamId != null)
                teamIdValue = teamId.Value;

             if (teamMemberId != null)
                teamMemberIdValue = teamMemberId.Value;

             if (activate != null)
                activateValue = activate.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             if (sortByExpression.Contains(" desc"))
             {
                 switch (sortByExpression)
                 {
                     case "TeamId desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();

                     case "TeamMemberId desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();

                     case "Activate desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate desc":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderByDescending(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
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
                     case "TeamId":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.TeamId).Skip(startRowIndex).Take(rows).ToList();

                     case "TeamMemberId":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.TeamMemberId).Skip(startRowIndex).Take(rows).ToList();

                     case "Activate":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.Activate).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedBy":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.AddedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "AddedDate":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.AddedDate).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedBy":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.UpdatedBy).Skip(startRowIndex).Take(rows).ToList();

                     case "UpdatedDate":
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.UpdatedDate).Skip(startRowIndex).Take(rows).ToList();

                     default:
                         return context.TeamDetails
                             .Where(t =>
                                       (id != null ? t.Id == idValue : 1 == 1) &&
                                       (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                                       (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                                       (activate != null ? t.Activate == activateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                                       (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                                       (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                                       (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                                   ).OrderBy(t => t.Id).Skip(startRowIndex).Take(rows).ToList();
                 }
             }
         }

         /// <summary>
         /// Selects all TeamDetails
         /// </summary>
         internal static List<TeamDetails> SelectAll()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.ToList();
         }

         /// <summary>
         /// Selects records based on the passed filters as a collection (List) of TeamDetails.
         /// </summary>
         internal static List<TeamDetails> SelectAllDynamicWhere(int? id, int? teamId, int? teamMemberId, bool? activate, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
         {
             PriorityLifeContext context = new PriorityLifeContext();

             int idValue = int.MinValue;
             int teamIdValue = int.MinValue;
             int teamMemberIdValue = int.MinValue;
             bool activateValue = false;
             DateTime addedDateValue = DateTime.MinValue;
             DateTime updatedDateValue = DateTime.MinValue;

             if (id != null)
                idValue = id.Value;

             if (teamId != null)
                teamIdValue = teamId.Value;

             if (teamMemberId != null)
                teamMemberIdValue = teamMemberId.Value;

             if (activate != null)
                activateValue = activate.Value;

             if (addedDate != null)
                addedDateValue = addedDate.Value;

             if (updatedDate != null)
                updatedDateValue = updatedDate.Value;

             return context.TeamDetails
                 .Where(t =>
                           (id != null ? t.Id == idValue : 1 == 1) &&
                           (teamId != null ? t.TeamId == teamIdValue : 1 == 1) &&
                           (teamMemberId != null ? t.TeamMemberId == teamMemberIdValue : 1 == 1) &&
                           (activate != null ? t.Activate == activateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(addedBy) ? t.AddedBy.Contains(addedBy) : 1 == 1) &&
                           (addedDate != null ? t.AddedDate == addedDateValue : 1 == 1) &&
                           (!String.IsNullOrEmpty(updatedBy) ? t.UpdatedBy.Contains(updatedBy) : 1 == 1) &&
                           (updatedDate != null ? t.UpdatedDate == updatedDateValue : 1 == 1) 
                       ).ToList();
         }

         /// <summary>
         /// Selects all TeamDetails by Team, related to column TeamId
         /// </summary>
         internal static List<TeamDetails> SelectTeamDetailsCollectionByTeamId(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Include(t => t.TeamIdNavigation).Include(t => t.TeamMemberIdNavigation).Where(t => t.TeamId == id).ToList();
         }

         /// <summary>
         /// Selects all TeamDetails by Salesperson, related to column TeamMemberId
         /// </summary>
         internal static List<TeamDetails> SelectTeamDetailsCollectionByTeamMemberId(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return context.TeamDetails.Where(t => t.TeamMemberId == id).ToList();
         }
         /// <summary>
         /// Selects Id and AddedBy columns for use with a DropDownList web control
         /// </summary>
         internal static List<TeamDetails> SelectTeamDetailsDropDownListData()
         {
             PriorityLifeContext context = new PriorityLifeContext();
             return (from t in context.TeamDetails
                     select new TeamDetails { Id = t.Id, AddedBy = t.AddedBy }).ToList();
         }
         /// <summary>
         /// Inserts a record
         /// </summary>
         internal static int Insert(TeamDetails objTeamDetails)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             TeamDetails entTeamDetails = new TeamDetails();

             entTeamDetails.TeamId = objTeamDetails.TeamId;
             entTeamDetails.TeamMemberId = objTeamDetails.TeamMemberId;
             entTeamDetails.Activate = objTeamDetails.Activate;
             entTeamDetails.AddedBy = objTeamDetails.AddedBy;
             entTeamDetails.AddedDate = objTeamDetails.AddedDate;
             entTeamDetails.UpdatedBy = objTeamDetails.UpdatedBy;
             entTeamDetails.UpdatedDate = objTeamDetails.UpdatedDate;

             context.TeamDetails.Add(entTeamDetails);
             context.SaveChanges();

             return entTeamDetails.Id;
         }

         /// <summary>
         /// Updates a record
         /// </summary>
         internal static void Update(TeamDetails objTeamDetails)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             TeamDetails entTeamDetails = context.TeamDetails.Where(t => t.Id == objTeamDetails.Id).FirstOrDefault();

             if (entTeamDetails != null)
             {
                 entTeamDetails.TeamId = objTeamDetails.TeamId;
                 entTeamDetails.TeamMemberId = objTeamDetails.TeamMemberId;
                 entTeamDetails.Activate = objTeamDetails.Activate;
                 entTeamDetails.AddedBy = objTeamDetails.AddedBy;
                 entTeamDetails.AddedDate = objTeamDetails.AddedDate;
                 entTeamDetails.UpdatedBy = objTeamDetails.UpdatedBy;
                 entTeamDetails.UpdatedDate = objTeamDetails.UpdatedDate;

                 context.SaveChanges();
             }
         }

         /// <summary>
         /// Deletes a record based on primary key(s)
         /// </summary>
         internal static void Delete(int id)
         {
             PriorityLifeContext context = new PriorityLifeContext();
             var objTeamDetails = context.TeamDetails.Where(t => t.Id == id).FirstOrDefault();

             if (objTeamDetails != null)
             {
                 context.TeamDetails.Remove(objTeamDetails);
                 context.SaveChanges();
             }
         }
     }
}
