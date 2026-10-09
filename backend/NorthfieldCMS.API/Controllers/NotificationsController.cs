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
    public class NotificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public NotificationsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var list = await _db.NotificationRecords.Select(n => new NotificationDto
            {
                NotificationId = n.NotificationId,
                Title = n.Title,
                Body = n.Body,
                Time = n.Time,
                Unread = n.IsUnread,
                Icon = n.Icon,
                Bg = n.Bg,
                Ic = n.Ic
            }).ToListAsync();

            return Ok(list);
        }
    }
}
