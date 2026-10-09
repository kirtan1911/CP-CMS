using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class NotificationRecord
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public bool IsUnread { get; set; } = true;
        public string Icon { get; set; } = "bell";
        public string Bg { get; set; } = "var(--p-dim)";
        public string Ic { get; set; } = "var(--cyan)";
        public string TargetAudience { get; set; } = "All";
    }
}
