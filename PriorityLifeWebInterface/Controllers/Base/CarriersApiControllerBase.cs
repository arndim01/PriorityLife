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
    public class CarriersApiControllerBase : Controller
    {
        /// <summary>
        /// Inserts/Adds/Creates a new record in the database
        /// </summary>
        /// <param name="model">Pass the CarriersModel here.  Arrives as CarriersFields which automatically strips the data annotations from the CarriersModel.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Insert([FromBody]CarriersModel model, bool isForListInline = false)
        {
            return AddEditCarriers(model, CrudOperation.Add, isForListInline);
        }

        /// <summary>
        /// Updates an existing record in the database by primary key.  Pass the primary key in the CarriersModel
        /// </summary>
        /// <param name="model">Pass the CarriersModel here.  Arrives as CarriersFields which automatically strips the data annotations from the CarriersModel.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Update([FromBody]CarriersModel model, bool isForListInline = false)
        {
            return AddEditCarriers(model, CrudOperation.Update, isForListInline);
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
                Carriers.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private IActionResult AddEditCarriers(CarriersModel model, CrudOperation operation, bool isForListInline = false)
        {
            try
            {
                Carriers objCarriers;

                if (operation == CrudOperation.Add)
                    objCarriers = new Carriers();
                else
                    objCarriers = Carriers.SelectByPrimaryKey(model.Id);

                objCarriers.Id = model.Id;
                objCarriers.Name = model.Name;
                objCarriers.ShortName = model.ShortName;
                objCarriers.Url = model.Url;
                objCarriers.Username = model.Username;
                objCarriers.Password = model.Password;
                objCarriers.Active = model.Active;
                objCarriers.AddedBy = model.AddedBy;
                objCarriers.AddedDate = model.AddedDate;
                objCarriers.UpdatedBy = model.UpdatedBy;
                objCarriers.UpdatedDate = model.UpdatedDate;

                if (operation == CrudOperation.Add)
                    objCarriers.Insert();
                else
                    objCarriers.Update();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private List<Carriers> GetFilteredData(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, string sidx, string sord, int rows, int startRowIndex, string sortExpression)
        {
            if (id != null || !String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(shortName) || !String.IsNullOrEmpty(url) || !String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(password) || active != null || !String.IsNullOrEmpty(addedBy) || addedDate != null || !String.IsNullOrEmpty(updatedBy) || updatedDate != null)
                return Carriers.SelectSkipAndTakeDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sortExpression);

            return Carriers.SelectSkipAndTake(rows, startRowIndex, sortExpression);
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of Carriers sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records.
        /// </summary>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="page">Current page</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="isforJqGrid">Optional isforJqGrid.  Default is true, returns json formatted string, otherwise, returns serialized List of Carriers</param>
        /// <returns>Serialized Carriers collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTake(string sidx, string sord, int _page, int rows, bool isforJqGrid = true)
        {
            int totalRecords = Carriers.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);
            List<Carriers> objCarriersCol = Carriers.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);

            if (!isforJqGrid)
            {
                if (objCarriersCol is null)
                    return "";

                return objCarriersCol;
            }

            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCarriersCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCarriers in objCarriersCol
                    select new
                    {
                        id = objCarriers.Id,
                        cell = new string[] {
                             objCarriers.Id.ToString(),
                             objCarriers.Name,
                             objCarriers.ShortName,
                             objCarriers.Url,
                             objCarriers.Username,
                             objCarriers.Password,
                             objCarriers.Active.ToString(),
                             objCarriers.AddedBy,
                             objCarriers.AddedDate.ToString("d"),
                             objCarriers.UpdatedBy,
                             objCarriers.UpdatedDate.HasValue ? objCarriers.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of Carriers sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records based on the search filters.
        /// </summary>
        /// <param name="_search">true or false</param>
        /// <param name="nd">nd</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="page">Current page</param>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="filters">Optional.  Filters used in search</param>
        /// <returns>Serialized Carriers collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTakeWithFilters(string _search, string nd, int rows, int _page, string sidx, string sord, string filters = "")
        {
            int? id = null;
            string name = String.Empty;
            string shortName = String.Empty;
            string url = String.Empty;
            string username = String.Empty;
            string password = String.Empty;
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

                    if (rule["field"].Value.ToLower() == "name")
                        name = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "shortname")
                        shortName = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "url")
                        url = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "username")
                        username = rule["data"].Value;

                    if (rule["field"].Value.ToLower() == "password")
                        password = rule["data"].Value;

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

            }

            int totalRecords = Carriers.GetRecordCountDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
            int startRowIndex = ((_page * rows) - rows);
            List<Carriers> objCarriersCol = Carriers.SelectSkipAndTakeDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCarriersCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCarriers in objCarriersCol
                    select new
                    {
                        id = objCarriers.Id,
                        cell = new string[] {
                             objCarriers.Id.ToString(),
                             objCarriers.Name,
                             objCarriers.ShortName,
                             objCarriers.Url,
                             objCarriers.Username,
                             objCarriers.Password,
                             objCarriers.Active.ToString(),
                             objCarriers.AddedBy,
                             objCarriers.AddedDate.ToString("d"),
                             objCarriers.UpdatedBy,
                             objCarriers.UpdatedDate.HasValue ? objCarriers.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Use in a JQGrid plugin.  Selects records as a collection (List) of Carriers sorted by the sortByExpression.
        /// Also returns total pages, current page, and total records.
        /// </summary>
        /// <param name="sidx">Field to sort.  Can be an empty string.</param>
        /// <param name="sord">asc or an empty string = ascending.  desc = descending</param>
        /// <param name="page">Current page</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <returns>Serialized Carriers collection in json format for use in a JQGrid plugin</returns>
        [HttpGet]
        public object SelectSkipAndTakeWithTotals(string sidx, string sord, int _page, int rows)
        {
            int totalRecords = Carriers.GetRecordCount();
            int startRowIndex = ((_page * rows) - rows);

            List<Carriers> objCarriersCol = Carriers.SelectSkipAndTake(rows, startRowIndex, sidx + " " + sord);
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (objCarriersCol is null)
                return Json("{ total = 0, page = 0, records = 0, rows = null }");

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCarriers in objCarriersCol
                    select new
                    {
                        id = objCarriers.Id,
                        cell = new string[] {
                             objCarriers.Id.ToString(),
                             objCarriers.Name,
                             objCarriers.ShortName,
                             objCarriers.Url,
                             objCarriers.Username,
                             objCarriers.Password,
                             objCarriers.Active.ToString(),
                             objCarriers.AddedBy,
                             objCarriers.AddedDate.ToString("d"),
                             objCarriers.UpdatedBy,
                             objCarriers.UpdatedDate.HasValue ? objCarriers.UpdatedDate.Value.ToString("d") : ""
                        }
                    }).ToArray()
            };

            return jsonData;
        }

        /// <summary>
        /// Selects a record by primary key(s)
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One serialized Carriers record in json format</returns>
        [HttpGet]
        public object SelectByPrimaryKey(int id)
        {
            Carriers objCarriers = Carriers.SelectByPrimaryKey(id);

            var jsonData = new
            {
                Id = objCarriers.Id,
                Name = objCarriers.Name,
                ShortName = objCarriers.ShortName,
                Url = objCarriers.Url,
                Username = objCarriers.Username,
                Password = objCarriers.Password,
                Active = objCarriers.Active,
                AddedBy = objCarriers.AddedBy,
                AddedDate = objCarriers.AddedDate.ToString("d"),
                UpdatedBy = objCarriers.UpdatedBy,
                UpdatedDate = objCarriers.UpdatedDate.HasValue ? objCarriers.UpdatedDate.Value.ToString("d") : null
            };

            return jsonData;
        }

        /// <summary>
        /// Gets the total number of records in the Carriers table
        /// </summary>
        /// <returns>Total number of records in the Carriers table</returns>
        [HttpGet]
        public int GetRecordCount()
        {
            return Carriers.GetRecordCount();
        }

        /// <summary>
        /// Gets the total number of records in the Carriers table based on search parameters
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="shortName">ShortName</param>
        /// <param name="url">Url</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <returns>Total number of records in the Carriers table based on the search parameters</returns>
        [HttpGet]
        public int GetRecordCountDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
        {
            return Carriers.GetRecordCountDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
        }

        /// <summary>
        /// Selects records as a collection (List) of Carriers sorted by the sortByExpression and returns the rows (# of records) starting from the startRowIndex
        /// </summary>
        public List<Carriers> SelectSkipAndTake(int rows, int startRowIndex, string sortByExpression)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            return Carriers.SelectSkipAndTake(rows, startRowIndex, sortByExpression);
        }

        /// <summary>
        /// Selects records as a collection (List) of Carriers sorted by the sortByExpression starting from the startRowIndex, based on the search parameters
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="shortName">ShortName</param>
        /// <param name="url">Url</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <param name="rows">Number of rows to retrieve</param>
        /// <param name="startRowIndex">Zero-based.  Row index where to start taking rows from</param>
        /// <param name="sortByExpression">Field to sort and sort direction.  E.g. "FieldName asc" or "FieldName desc"</param>
        /// <param name="page">Page of the grid to show</param>
        /// <returns>Serialized Carriers collection in json format</returns>
        [HttpGet]
        public object SelectSkipAndTakeDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate, int rows, int startRowIndex, string sortByExpression, int _page)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            List<Carriers> objCarriersCol = Carriers.SelectSkipAndTakeDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate, rows, startRowIndex, sortByExpression);
            int totalRecords = Carriers.GetRecordCountDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
            return GetJsonCollection(objCarriersCol, totalRecords, _page, rows);
        }

        /// <summary>
        /// Selects all records as a collection (List) of Carriers
        /// </summary>
        /// <returns>Serialized Carriers collection in json format</returns>
        [HttpGet]
        public object SelectAll()
        {
            List<Carriers> objCarriersCol = Carriers.SelectAll();
            return GetJsonCollection(objCarriersCol, objCarriersCol.Count, 1, objCarriersCol.Count);
        }

        /// <summary>
        /// Selects all records as a collection (List) of Carriers sorted by the sort expression
        /// </summary>
        /// <param name="sortByExpression">Field to sort and sort direction.  E.g. "FieldName asc" or "FieldName desc"</param>
        /// <returns>Serialized Carriers collection in json format</returns>
        [HttpGet]
        public object SelectAll(string sortByExpression)
        {
            sortByExpression = GetSortExpression(sortByExpression);
            List<Carriers> objCarriersCol = Carriers.SelectAll(sortByExpression);
            return GetJsonCollection(objCarriersCol, objCarriersCol.Count, 1, objCarriersCol.Count);
        }

        /// <summary>
        /// Selects records based on the passed filters as a collection (List) of Carriers.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="shortName">ShortName</param>
        /// <param name="url">Url</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="active">Active</param>
        /// <param name="addedBy">AddedBy</param>
        /// <param name="addedDate">AddedDate</param>
        /// <param name="updatedBy">UpdatedBy</param>
        /// <param name="updatedDate">UpdatedDate</param>
        /// <returns>Serialized Carriers collection in json format</returns>
        [HttpGet]
        public object SelectAllDynamicWhere(int? id, string name, string shortName, string url, string username, string password, bool? active, string addedBy, DateTime? addedDate, string updatedBy, DateTime? updatedDate)
        {
            List<Carriers> objCarriersCol = Carriers.SelectAllDynamicWhere(id, name, shortName, url, username, password, active, addedBy, addedDate, updatedBy, updatedDate);
            return GetJsonCollection(objCarriersCol, objCarriersCol.Count, 1, objCarriersCol.Count);
        }

        /// <summary>
        /// Selects Id and Name columns for use with a DropDownList web control, ComboBox, CheckedBoxList, ListView, ListBox, etc
        /// </summary>
        /// <returns>Serialized Carriers collection in json format</returns>
        [HttpGet]
        public object SelectCarriersDropDownListData()
        {
            List<Carriers> objCarriersCol = Carriers.SelectCarriersDropDownListData();

            if (objCarriersCol != null)
            {
                var jsonData = (from objCarriers in objCarriersCol
                                select new
                                {
                                    Id = objCarriers.Id,
                                    Name = objCarriers.Name
                                }).ToArray();

                return jsonData;
            }

            return null;
        }

        private object GetJsonCollection(List<Carriers> objCarriersCol, int totalRecords, int _page, int rows)
        {
            if (objCarriersCol is null)
                return null;

            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            var jsonData = new
            {
                total = totalPages,
                _page,
                records = totalRecords,
                rows = (
                    from objCarriers in objCarriersCol
                    select new
                    {
                        id = objCarriers.Id,
                        cell = new string[] {
                             objCarriers.Id.ToString(),
                             objCarriers.Name,
                             objCarriers.ShortName,
                             objCarriers.Url,
                             objCarriers.Username,
                             objCarriers.Password,
                             objCarriers.Active.ToString(),
                             objCarriers.AddedBy,
                             objCarriers.AddedDate.ToString("d"),
                             objCarriers.UpdatedBy,
                             objCarriers.UpdatedDate.HasValue ? objCarriers.UpdatedDate.Value.ToString("d") : ""
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
