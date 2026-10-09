using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetReportsSummary()
        {
            var dto = new ReportDto
            {
                ReportTitle = "Academic & Fee Collection Performance Report",
                GeneratedDate = DateTime.Now.ToString("dd MMM yyyy"),
                Department = "All Departments",
                TotalRecords = 1388,
                Status = "Completed"
            };

            return Ok(dto);
        }
    }
}
