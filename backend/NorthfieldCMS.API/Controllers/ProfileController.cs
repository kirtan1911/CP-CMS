using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? "admin@northfield.edu";
            var role = User.FindFirst(ClaimTypes.Role)?.Value ?? "Admin";
            var name = User.FindFirst(ClaimTypes.Name)?.Value ?? "Prof. Rajesh Kumar";
            var dept = User.FindFirst("Department")?.Value ?? "Administration";

            var dto = new ProfileDto
            {
                UserId = 1,
                Name = name,
                Email = email,
                Role = role,
                Department = dept,
                Phone = "+91 98765 43210",
                JoinedDate = "01 Aug 2024"
            };

            return Ok(dto);
        }
    }
}
