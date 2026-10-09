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
    public class FacultyController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FacultyController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetFaculty()
        {
            var list = await _db.FacultyMembers.Select(f => new FacultyDto
            {
                FacultyId = f.FacultyId,
                Code = f.FacultyCode,
                Name = f.Name,
                Email = f.Email,
                Department = f.Department,
                Specialization = f.Specialization,
                Experience = f.Experience,
                Status = f.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateFaculty([FromBody] Faculty faculty)
        {
            _db.FacultyMembers.Add(faculty);
            await _db.SaveChangesAsync();
            return Ok(faculty);
        }
    }
}
