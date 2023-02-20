using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Domain;
using PriorityLifeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Controllers.Base
{
    public class CommissionsFileApiControllerBase : Controller
    {
        /// <summary>
        /// Inserts/Adds/Creates a new record in the database
        /// </summary>
        /// <param name="model">Pass the CommissionsFileModel here.  Arrives as CommissionsFileFields which automatically strips the data annotations from the CommissionsFileModel.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Insert([FromBody]CommissionsFileModel model, bool isForListInline = false)
        {
            return AddEditCommissionsFile(model, CrudOperation.Add, isForListInline);
        }

        /// <summary>
        /// Updates an existing record in the database by primary key.  Pass the primary key in the CommissionsFileModel
        /// </summary>
        /// <param name="model">Pass the CommissionsFileModel here.  Arrives as CommissionsFileFields which automatically strips the data annotations from the CommissionsFileModel.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Update([FromBody]CommissionsFileModel model, bool isForListInline = false)
        {
            return AddEditCommissionsFile(model, CrudOperation.Update, isForListInline);
        }

        /// <summary>
        /// Deletes an existing record by primary key
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>IActionResult</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                CommissionsFile.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private IActionResult AddEditCommissionsFile(CommissionsFileModel model, CrudOperation operation, bool isForListInline = false)
        {
            try
            {
                CommissionsFile objCommissionsFile;

                if (operation == CrudOperation.Add)
                    objCommissionsFile = new CommissionsFile();
                else
                    objCommissionsFile = CommissionsFile.SelectByPrimaryKey(model.Id);

                objCommissionsFile.Id = model.Id;
                objCommissionsFile.CarrierId = model.CarrierId;
                objCommissionsFile.ExtractedDate = model.ExtractedDate;
                objCommissionsFile.FileUrl = model.FileUrl;
                objCommissionsFile.Extension = model.Extension;
                objCommissionsFile.Active = model.Active;
                objCommissionsFile.AddedBy = model.AddedBy;
                objCommissionsFile.AddedDate = model.AddedDate;
                objCommissionsFile.UpdatedBy = model.UpdatedBy;
                objCommissionsFile.UpdatedDate = model.UpdatedDate;

                if (operation == CrudOperation.Add)
                    objCommissionsFile.Insert();
                else
                    objCommissionsFile.Update();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private List<CommissionsFile> GetFilteredData(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sidx, string sord, int rows, int startRowIndex, string sortExpression)
        {
            if (id != null || carrierId != null || extractedDate != null || !String.IsNullOrEmpty(fileUrl) || !String.IsNullOrEmpty(extension) || active != null || !String.IsNullOrEmpty(addedBy) || addedDate != null || !String.IsNullOrEmpty(updatedBy) || updatedDate != null)
                return CommissionsFile.SelectSkipAndTakeDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sortExpression);

            return CommissionsFile.SelectSkipAndTake(rows, startRowIndex, sortExpression);
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records.
        /// </summary>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="page">Current page</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="isforJqGrid">Optional isforJqGrid.  Default is true, returns json formatted string, otherwise, returns serialized List of CommissionsFile</param>
        /// <returns>Serialized CommissionsFile collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTake(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            int totalRecords = CommissionsFile.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);
            bool isIncludeRelatedProperties = true;

            if (!isforJqGrid)
                isIncludeRelatedProperties = false;

            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord, isIncludeRelatedProperties);

            if (!isforJqGrid)
            {
                if (objCommissionsFileCol is null)
                    return "";

                return objCommissionsFileCol;
            }

            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCommissionsFileCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCommissionsFile in objCommissionsFileCol
                    select new
                    {
                        id = objCommissionsFile.Id,
                        cell = new string[] {
                             objCommissionsFile.Id.ToString(),
                             objCommissionsFile.CarrierId.ToString(),
                             objCommissionsFile.ExtractedDate.ToString("d"),
                             objCommissionsFile.FileUrl,
                             objCommissionsFile.Extension,
                             objCommissionsFile.Active.ToString(),
                             objCommissionsFile.AddedBy,
                             objCommissionsFile.AddedDate.ToString("d"),
                             objCommissionsFile.UpdatedBy,
                             objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records based on the search filters.
        /// </summary>
        /// <param name="_search">true or false</param>
        /// <param name="nd">nd</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="page">Current page</param>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="filters">Optional.  Filters used in search</param>
        /// <returns>Serialized CommissionsFile collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTakeWithFilters(string _search, string nd, int rows, int _page, string sidx, string sord, string filters = "")
        {
            int? id = null;
            int? carrierId = null;
            DateTime? extractedDate = null;
            string fileUrl = String.Empty;
            string extension = String.Empty;
            bool? active = null;
            string addedBy = String.Empty;
            DateTime? addedDate = null;
            string updatedBy = String.Empty;
            DateTime? updatedDate = null;

            if (!String.IsNullOrEmpty(filters))
            {
                // deserialize json and get values being searched
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(filters);

                foreach (var rule in jsonResult["rules"])
                {
                    if (rule["field"].Value.ToLower() == "id")
                        id = Convert.ToInt32(rule["data"].Value);

                    if (rule["field"].Value.ToLower() == "carrierid")
                        carrierId = Convert.ToInt32(rule["data"].Value);

                    if (rule["field"].Value.ToLower() == "extracteddate")
                        extractedDate = Convert.ToDateTime(rule["data"].Value);

                    if (rule["field"].Value.ToLower() == "fileurl")
                        fileUrl = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "extension")
                        extension = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "active")
                        active = Convert.ToBoolean(rule["data"].Value);

                    if (rule["field"].Value.ToLower() == "addedby")
                        addedBy = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "addeddate")
                        addedDate = Convert.ToDateTime(rule["data"].Value);

                    if (rule["field"].Value.ToLower() == "updatedby")
                        updatedBy = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "updateddate")
                        updatedDate = Convert.ToDateTime(rule["data"].Value);

                }

                // sometimes jqgrid assigns a -1 to numeric fields when no value is assigned
                // instead of assigning a null, we'll correct this here
                if (id == -1)
                    id = null;

                if (carrierId == -1)
                    carrierId = null;

            }

            int totalRecords = CommissionsFile.GetRecordCountDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
            int startRowIndex = ((_page * rows) - rows);
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTakeDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCommissionsFileCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCommissionsFile in objCommissionsFileCol
                    select new
                    {
                        id = objCommissionsFile.Id,
                        cell = new string[] {
                             objCommissionsFile.Id.ToString(),
                             objCommissionsFile.CarrierId.ToString(),
                             objCommissionsFile.ExtractedDate.ToString("d"),
                             objCommissionsFile.FileUrl,
                             objCommissionsFile.Extension,
                             objCommissionsFile.Active.ToString(),
                             objCommissionsFile.AddedBy,
                             objCommissionsFile.AddedDate.ToString("d"),
                             objCommissionsFile.UpdatedBy,
                             objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records.
        /// </summary>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="page">Current page</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <returns>Serialized CommissionsFile collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTakeWithTotals(string sidx, string sord, int _page, int rows)
        {
            int totalRecords = CommissionsFile.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);

            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCommissionsFileCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCommissionsFile in objCommissionsFileCol
                    select new
                    {
                        id = objCommissionsFile.Id,
                        cell = new string[] {
                             objCommissionsFile.Id.ToString(),
                             objCommissionsFile.CarrierId.ToString(),
                             objCommissionsFile.ExtractedDate.ToString("d"),
                             objCommissionsFile.FileUrl,
                             objCommissionsFile.Extension,
                             objCommissionsFile.Active.ToString(),
                             objCommissionsFile.AddedBy,
                             objCommissionsFile.AddedDate.ToString("d"),
                             objCommissionsFile.UpdatedBy,
                             objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records.
        /// </summary>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="page">Current page</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <returns>Serialized CommissionsFile collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTakeGroupedByCarrierId(string sidx, string sord, int _page, int rows)
        {
            // using a groupField in the jqgrid passes that field
            // along with the field to sort, remove the groupField
            string groupBy = "Name asc, ";
            sidx = sidx.Replace(groupBy, "");

            int totalRecords = CommissionsFile.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);

            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCommissionsFileCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCommissionsFile in objCommissionsFileCol
                    select new
                    {
                        id = objCommissionsFile.Id,
                        cell = new string[] {
                             objCommissionsFile.Id.ToString(),
                             objCommissionsFile.CarrierId.ToString(),
                             objCommissionsFile.ExtractedDate.ToString("d"),
                             objCommissionsFile.FileUrl,
                             objCommissionsFile.Extension,
                             objCommissionsFile.Active.ToString(),
                             objCommissionsFile.AddedBy,
                             objCommissionsFile.AddedDate.ToString("d"),
                             objCommissionsFile.UpdatedBy,
                             objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : "",
                             objCommissionsFile.CarrierIdNavigation.Name

                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Selects a record by primary key(s)
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One serialized CommissionsFile record in json format</returns>
        [HttpGet]
        public object SelectByPrimaryKey(int id)
        {
            CommissionsFile objCommissionsFile = CommissionsFile.SelectByPrimaryKey(id);

            var jsonData = new
            {
                Id = objCommissionsFile.Id,
                CarrierId = objCommissionsFile.CarrierId,
                ExtractedDate = objCommissionsFile.ExtractedDate.ToString("d"),
                FileUrl = objCommissionsFile.FileUrl,
                Extension = objCommissionsFile.Extension,
                Active = objCommissionsFile.Active,
                AddedBy = objCommissionsFile.AddedBy,
                AddedDate = objCommissionsFile.AddedDate.ToString("d"),
                UpdatedBy = objCommissionsFile.UpdatedBy,
                UpdatedDate = objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : null
            };

            return jsonData;
        }

        /// <summary>
        /// Gets the total number of records in the CommissionsFile table
        /// </summary>
        /// <returns>Total number of records in the CommissionsFile table</returns>
        [HttpGet]
        public int GetRecordCount()
        {
            return CommissionsFile.GetRecordCount();
        }

        /// <summary>
        /// Gets the total number of records in the CommissionsFile table by CarrierId
        /// </summary>
        /// <param name="id">carrierId</param>
        /// <returns>Total number of records in the CommissionsFile table by carrierId</returns>
        [HttpGet]
        public int GetRecordCountByCarrierId(int id)
        {
            return CommissionsFile.GetRecordCountByCarrierId(id);
        }

        /// <summary>
        /// Gets the total number of records in the CommissionsFile table based on search parameters
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="carrierId">CarrierId</param>
        /// <param name="extractedDate">ExtractedDate</param>
        /// <param name="fileUrl">FileUrl</param>
        /// <param name="extension">Extension</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <returns>Total number of records in the CommissionsFile table based on the search parameters</returns>
        [HttpGet]
        public int GetRecordCountDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
        {
            return CommissionsFile.GetRecordCountDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
        }

        /// <summary>
        /// Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
        /// </summary>
        public List<CommissionsFile> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression, bool isIncludeRelatedProperties = true)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            return CommissionsFile.SelectSkipAndTake(rows, startRowIndex, sortByExpression, isIncludeRelatedProperties);
        }

        /// <summary>
        /// Selects records by CarrierId as a collection (List) of CommissionsFile sorted by the sortByExpression starting from the startRowIndex
        /// </summary>
        /// <param name="id">Carrier Id</param>
        /// <param name="sidx">Column to sort</param>
        /// <param name="sord">Sort direction</param>
        /// <param name="page">Page of the grid to show</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectSkipAndTakeByCarrierId(int id, string sidx, string sord, int _page, int rows)
        {
            string sortByExpression = GetSortExpression(sidx + " " + sord);
            int startRowIndex = _page - 1;
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTakeByCarrierId(rows, startRowIndex, sortByExpression, id);
            int totalRecords = CommissionsFile.GetRecordCountByCarrierId(id);
            return GetJsonCollection(objCommissionsFileCol, totalRecords, _page, rows);
        }

        /// <summary>
        /// Selects records as a collection (List) of CommissionsFile sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="carrierId">CarrierId</param>
        /// <param name="extractedDate">ExtractedDate</param>
        /// <param name="fileUrl">FileUrl</param>
        /// <param name="extension">Extension</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="startRowIndex">Zero-based.  Row index where to start taking rows from</param>
        /// <param name="sortByExpression">Field to sort and sort direction.  E.g. "FieldName asc" or "FieldName desc"</param>
        /// <param name="page">Page of the grid to show</param>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectSkipAndTakeDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression, int _page)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTakeDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sortByExpression);
            int totalRecords = CommissionsFile.GetRecordCountDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
            return GetJsonCollection(objCommissionsFileCol, totalRecords, _page, rows);
        }

        /// <summary>
        /// Selects all records as a collection (List) of CommissionsFile
        /// </summary>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectAll()
        {
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectAll();
            return GetJsonCollection(objCommissionsFileCol, objCommissionsFileCol.Count, 1, objCommissionsFileCol.Count);
        }

        /// <summary>
        /// Selects all records as a collection (List) of CommissionsFile sorted by the sort expression
        /// </summary>
        /// <param name="sortByExpression">Field to sort and sort direction.  E.g. "FieldName asc" or "FieldName desc"</param>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectAll(string sortByExpression)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectAll(sortByExpression);
            return GetJsonCollection(objCommissionsFileCol, objCommissionsFileCol.Count, 1, objCommissionsFileCol.Count);
        }

        /// <summary>
        /// Selects records based on the passed filters as a collection (List) of CommissionsFile.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="carrierId">CarrierId</param>
        /// <param name="extractedDate">ExtractedDate</param>
        /// <param name="fileUrl">FileUrl</param>
        /// <param name="extension">Extension</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectAllDynamicWhere(int? id, int? carrierId, DateTime? extractedDate, string fileUrl, string extension, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
        {
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectAllDynamicWhere(id, carrierId, extractedDate, fileUrl, extension, active, addedBy, addedDate, updatedBy, updatedDate);
            return GetJsonCollection(objCommissionsFileCol, objCommissionsFileCol.Count, 1, objCommissionsFileCol.Count);
        }

        /// <summary>
        /// Selects all CommissionsFile by Carriers, related to column CarrierId
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sidx">Column to sort</param>
        /// <param name="sord">Sort direction</param>
        /// <param name="page">Page of the grid to show</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <returns>Total number of records in the CommissionsFile table by carrierId</returns>
        [HttpGet]
        public object SelectCommissionsFileCollectionByCarrierId(int id, string sidx, string sord, int _page, int rows)
        {
            string sortByExpression = GetSortExpression(sidx + " " + sord);
            int startRowIndex = _page;
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectSkipAndTakeByCarrierId(rows, startRowIndex, sortByExpression, id);
            int totalRecords = CommissionsFile.GetRecordCountByCarrierId(id);
            return GetJsonCollection(objCommissionsFileCol, totalRecords, _page, rows);
        }

        /// <summary>
        /// Selects Id and AddedBy columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
        /// </summary>
        /// <returns>Serialized CommissionsFile collection in json format</returns>
        [HttpGet]
        public object SelectCommissionsFileDropDownListData()
        {
            List<CommissionsFile> objCommissionsFileCol = CommissionsFile.SelectCommissionsFileDropDownListData();

            if (objCommissionsFileCol != null)
            {
                var jsonData = (from objCommissionsFile in objCommissionsFileCol
                                select new
                                {
                                    Id = objCommissionsFile.Id,
                                    AddedBy = objCommissionsFile.AddedBy
                                }).ToArray();

                return jsonData;
            }

            return null;
        }

        private object GetJsonCollection(List<CommissionsFile> objCommissionsFileCol, int totalRecords, int _page, int rows)
        {
            if (objCommissionsFileCol is null)
                return null;

            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCommissionsFile in objCommissionsFileCol
                    select new
                    {
                        id = objCommissionsFile.Id,
                        cell = new string[] {
                             objCommissionsFile.Id.ToString(),
                             objCommissionsFile.CarrierId.ToString(),
                             objCommissionsFile.ExtractedDate.ToString("d"),
                             objCommissionsFile.FileUrl,
                             objCommissionsFile.Extension,
                             objCommissionsFile.Active.ToString(),
                             objCommissionsFile.AddedBy,
                             objCommissionsFile.AddedDate.ToString("d"),
                             objCommissionsFile.UpdatedBy,
                             objCommissionsFile.UpdatedDate.HasValue ? objCommissionsFile.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        private string GetSortExpression(string sortByExpression)
        {
            if (String.IsNullOrEmpty(sortByExpression) || sortByExpression == " asc")
                sortByExpression = "Id";
            else if (sortByExpression.Contains(" asc"))
                sortByExpression = sortByExpression.Replace(" asc", "");

            return sortByExpression;
        }
    }
}
