using System;
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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Code = $"USR-{u.UserId:D3}",
                Name = u.FullName,
                Email = u.Email,
                Role = u.Role,
                Status = u.IsActive ? "Active" : "Inactive",
                CreatedAt = u.CreatedAt.ToString("dd MMM yyyy")
            }).ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("default123");
            user.CreatedAt = DateTime.UtcNow;
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
