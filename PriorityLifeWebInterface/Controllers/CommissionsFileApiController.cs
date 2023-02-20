using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.Models;
using PriorityLifeWebInterface.Controllers.Base;
using PriorityLifeWebInterface.Filters;

namespace PriorityLifeWebInterface.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionsFileApiController : CommissionsFileApiControllerBase
    {
        [HttpPost("addfile")]
        public IActionResult AddFile([FromBody] CommissionsFileModel model)
        {
            try
            {
                Insert(model);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
        [HttpGet("files/{date}")]
        public IActionResult GetListFiles(DateTime date)
        {
            try
            {
                var files = CommissionsFile.GetAllCFileByDate(date);
                object result = GetJsonCollection(files, files.Count, 1, files.Count);
                return new OkObjectResult(result);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
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
    }
}
