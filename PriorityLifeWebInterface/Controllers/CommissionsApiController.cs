using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeWebInterface.Filters;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.Models;

namespace PriorityLifeWebInterface
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionsApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CommissionsApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost("uploadbyrange")]
        public IActionResult UploadCommissionJsonByRage([FromBody] List<ExtractedCommissionsModel> model)
        {
            try
            {
                var header = Request.Headers["Carrier"];
                var carrier = Carriers.GetCarriersByShortName(header);

                int startYear = Convert.ToInt32( Request.Headers["start_year"] );
                int startMonth = Convert.ToInt32( Request.Headers["start_month"] );
                int startDay = Convert.ToInt32(Request.Headers["start_day"]);

                int endYear = Convert.ToInt32(Request.Headers["end_year"]);
                int endMonth = Convert.ToInt32(Request.Headers["end_month"]);
                int endDay = Convert.ToInt32(Request.Headers["end_day"]);
                foreach ( var com in model)
                {
                    string extractFirstName = com.agent_givenname.GetFirstValueIfSpaceExist();

                    if (!Salesperson.SalespersonExist(extractFirstName, com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName[0]))
                    {
                        Salesperson salesperson = new Salesperson()
                        {
                            FirstName = extractFirstName.ToUpper(),
                            LastName = com.agent_surname.Trim().ToUpper(),
                            Initials = com.agent_surname.Trim().ToUpper() + " " + extractFirstName.ToUpper()[0],
                            Active = true,
                            AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                            AddedDate = DateTime.Now
                        };
                        salesperson.Insert();
                    }

                    var date = new DateTime(com.year, com.month, com.day);
                    CommissionsExtracted extracted = new CommissionsExtracted()
                    {
                        Carrier = carrier.ShortName,
                        FirstName = com.agent_givenname.Trim().ToUpper(),
                        LastName = com.agent_surname.Trim().ToUpper(),
                        DownloadType = "DATE",
                        Date = date,
                        Active = true,
                        Amount = Convert.ToDecimal(com.amount),
                        UCode = com.pl_number.Trim(),
                        AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                        AddedDate = DateTime.Now
                    };
                    extracted.Insert();
                    var startDate = new DateTime(startYear, startMonth, startDay);
                    var endDate = new DateTime(endYear, endMonth, endDay);
                    var salesValue = Salesperson.GetSalespersonWithInitials(extractFirstName.ToUpper(), com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName[0]);
                    var commissions = new Commissions()
                    {
                        SalespersonId = salesValue.Id,
                        CarrierId = carrier.Id,
                        Amount = extracted.Amount,
                        CommissionDate = extracted.Date,
                        CommissionStartDate = startDate,
                        CommissionEndDate = endDate,
                        AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                        AddedDate = DateTime.Now
                    };
                    commissions.Insert();
                    
                }


                return new OkResult();

            }
            catch
            {
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Upload Commissions Data by Date Back 1 Day
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("uploadbydate")]
        public IActionResult UploadCommissionsJsonByDate([FromBody] List<ExtractedCommissionsModel> model)
        {
            try
            {
                ///Insert Extracted Commissions
                var header = Request.Headers["Carrier"];
                var carrier = Carriers.GetCarriersByShortName(header);
                foreach (var com in model)
                {
                    string extractFirstName = com.agent_givenname.GetFirstValueIfSpaceExist();

                    if (!Salesperson.SalespersonExist(extractFirstName, com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName[0] ))
                    {
                        Salesperson salesperson = new Salesperson()
                        {
                            FirstName = extractFirstName.ToUpper(),
                            LastName = com.agent_surname.Trim().ToUpper(),
                            Initials = com.agent_surname.Trim().ToUpper() + " " + extractFirstName.ToUpper()[0],
                            Active = true,
                            AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                            AddedDate = DateTime.Now
                        };
                        salesperson.Insert();
                    }

                    var date = new DateTime(com.year, com.month, com.day);
                    CommissionsExtracted extracted = new CommissionsExtracted()
                    {
                        Carrier = carrier.ShortName,
                        FirstName = com.agent_givenname.Trim().ToUpper(),
                        LastName = com.agent_surname.Trim().ToUpper(),
                        DownloadType = "DATE",
                        Date = date,
                        Active = true,
                        Amount = Convert.ToDecimal(com.amount),
                        UCode =  (String.IsNullOrEmpty(com.pl_number) ? "": com.pl_number.Trim()),
                        AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                        AddedDate = DateTime.Now
                    };
                    extracted.Insert();
                    var salesValue = Salesperson.GetSalespersonWithInitials(extractFirstName.ToUpper(), com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName[0]);
                    var commissions = new Commissions()
                    {
                        SalespersonId =  salesValue.Id,
                        CarrierId = carrier.Id,
                        Amount = extracted.Amount,
                        CommissionDate = extracted.Date,
                        AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                        AddedDate = DateTime.Now
                    };
                    commissions.Insert();

                }
                return new OkResult();
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }

        }
        /// <summary>
        /// Upload Commissions Data Bulk Back 1 Day
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        public IActionResult UploadCommissionsJson([FromBody] List<ExtractedCommissionsModel> model)
        {
            try
            {
                var header = Request.Headers["Carrier"];
                var carrier = Carriers.GetCarriersByShortName(header);
                //INSERT EXTRACTED DATA
                foreach (var com in model)
                {

                    CommissionsExtracted extracted = null;
                    Salesperson salesperson = null;
                    string extractFirstName = com.agent_givenname.GetFirstValueIfSpaceExist();
                    if (!CommissionsExtracted.CommissionsExist(carrier.ShortName, com.pl_number, com.agent_givenname.Trim().ToUpper(), com.agent_surname.Trim().ToUpper()))
                    {
                        var date = new DateTime(com.year, com.month, com.day);

                        extracted = new CommissionsExtracted()
                        {
                            Carrier = carrier.ShortName,
                            FirstName = com.agent_givenname.Trim().ToUpper(),
                            LastName = com.agent_surname.Trim().ToUpper(),
                            DownloadType = "BULK",
                            Date = date,
                            Active = true,
                            Amount = Convert.ToDecimal(com.amount),
                            UCode = (String.IsNullOrEmpty(com.pl_number) ? "" : com.pl_number.Trim()),
                            AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                            AddedDate = DateTime.Now
                        };
                        extracted.Insert();
                    }

                    if (!Salesperson.SalespersonExist(extractFirstName.ToUpper(), com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName.ToUpper()[0]))
                    {
                        salesperson = new Salesperson()
                        {
                            FirstName = extractFirstName.ToUpper(),
                            LastName = com.agent_surname.Trim().ToUpper(),
                            MiddleName = "",
                            Initials = com.agent_surname.Trim().ToUpper() + " " + extractFirstName.ToUpper()[0],
                            Active = true,
                            AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                            AddedDate = DateTime.Now
                        };
                        salesperson.Insert();
                    }
                    if (extracted != null)
                    {
                        var salesValue = Salesperson.GetSalespersonWithInitials(extractFirstName.ToUpper(), com.agent_surname.Trim().ToUpper(), com.agent_surname.Trim() + " " + extractFirstName.ToUpper()[0]);
                        var commissions = new Commissions()
                        {
                            SalespersonId = salesValue.Id,
                            CarrierId = carrier.Id,
                            Amount = extracted.Amount,
                            CommissionDate = extracted.Date,
                            AddedBy = _configuration.GetSection("AdminSettings")["Email"],
                            AddedDate = DateTime.Now
                        };
                        commissions.Insert();
                    }
                }

                return new OkResult();
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
    }
}