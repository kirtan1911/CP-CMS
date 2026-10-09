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
    public class MarksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MarksController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetMarks()
        {
            var list = await _db.MarkResults.Select(m => new MarkResultDto
            {
                MarkResultId = m.MarkResultId,
                StudentName = m.StudentName,
                Subject = m.Subject,
                InternalMarks = m.InternalMarks,
                ExamMarks = m.ExamMarks,
                TotalMarks = m.TotalMarks,
                Grade = m.Grade,
                Status = m.Status
            }).ToListAsync();

            return Ok(list);
        }
    }
}
