using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthfieldCMS.API.Data;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public AttendanceController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAttendance()
        {
            var list = await _db.AttendanceRecords.Select(a => new AttendanceDto
            {
                AttendanceId = a.AttendanceId,
                StudentName = a.StudentName,
                Course = a.Course,
                Date = a.Date.ToString("dd MMM yyyy"),
                Status = a.Status,
                Percentage = a.Percentage
            }).ToListAsync();

            return Ok(list);
        }
    }
}
