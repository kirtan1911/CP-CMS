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
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var list = await _db.Students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                Code = s.StudentCode,
                Name = s.Name,
                Email = s.Email,
                Department = s.Department,
                Semester = s.Semester,
                Attendance = $"{s.AttendancePercentage}%",
                Status = s.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Faculty")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return Ok(student);
        }
    }
}
