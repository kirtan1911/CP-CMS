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
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CoursesController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var list = await _db.Courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                Code = c.Code,
                Name = c.Name,
                Department = c.Department,
                Credits = c.Credits,
                Faculty = c.Faculty,
                Semester = c.Semester,
                Status = c.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return Ok(course);
        }
    }
}
