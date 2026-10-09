using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthfieldCMS.API.Data;
using NorthfieldCMS.API.DTOs;
using NorthfieldCMS.API.Models;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ExamsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var list = await _db.Exams.Select(e => new ExamDto
            {
                ExamId = e.ExamId,
                ExamName = e.ExamName,
                Subject = e.Subject,
                Course = e.Course,
                Date = e.Date.ToString("dd MMM yyyy"),
                Time = e.Time,
                Duration = e.Duration,
                MaxMarks = e.MaxMarks,
                Status = e.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Faculty")]
        public async Task<IActionResult> CreateExam([FromBody] Exam exam)
        {
            _db.Exams.Add(exam);
            await _db.SaveChangesAsync();
            return Ok(exam);
        }
    }
}
