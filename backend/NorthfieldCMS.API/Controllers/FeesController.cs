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
    public class FeesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FeesController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetFees()
        {
            var list = await _db.FeeRecords.Select(f => new FeeDto
            {
                FeeId = f.FeeId,
                StudentName = f.StudentName,
                Course = f.Course,
                TotalFees = $"₹{f.TotalFees:N0}",
                Paid = $"₹{f.PaidAmount:N0}",
                Pending = $"₹{f.PendingAmount:N0}",
                DueDate = f.DueDate.ToString("dd MMM yyyy"),
                Status = f.Status
            }).ToListAsync();

            return Ok(list);
        }
    }
}
