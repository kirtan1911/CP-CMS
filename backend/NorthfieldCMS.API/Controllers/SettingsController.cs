using Microsoft.AspNetCore.Mvc;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSettings()
        {
            var dto = new SettingsDto
            {
                SystemName = "Northfield College Management System",
                EnableNotifications = true,
                MaintenanceMode = false,
                ActiveTheme = "Liquid Glassmorphic Dark"
            };

            return Ok(dto);
        }
    }
}
