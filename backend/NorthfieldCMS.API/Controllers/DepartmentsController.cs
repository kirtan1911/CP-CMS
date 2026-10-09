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
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DepartmentsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var list = await _db.Departments.Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Head = d.HeadOfDepartment,
                Courses = d.CoursesCount,
                Students = d.StudentsCount,
                Status = d.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            _db.Departments.Add(department);
            await _db.SaveChangesAsync();
            return Ok(department);
        }
    }
}
