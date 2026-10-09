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
    public class MaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MaterialsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetMaterials()
        {
            var list = await _db.Materials.Select(m => new MaterialDto
            {
                MaterialId = m.MaterialId,
                Title = m.Title,
                Subject = m.Subject,
                FileType = m.FileType,
                UploadedBy = m.UploadedBy,
                Date = m.UploadedDate.ToString("dd MMM yyyy")
            }).ToListAsync();

            return Ok(list);
        }
    }
}
