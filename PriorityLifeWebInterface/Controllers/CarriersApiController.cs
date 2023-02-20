using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriorityLifeWebInterface.Controllers.Base;
using PriorityLifeWebInterface.Filters;

namespace PriorityLifeWebInterface.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersApiController : CarriersApiControllerBase
    {
        [HttpGet("list")]
        public IActionResult CarrierList()
        {
            try
            {
                var carriers = SelectAll();
                return new OkObjectResult(carriers);
            }catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
    }
}