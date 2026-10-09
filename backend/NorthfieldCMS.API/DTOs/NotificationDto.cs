namespace NorthfieldCMS.API.DTOs
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public bool Unread { get; set; }
        public string Icon { get; set; } = "bell";
        public string Bg { get; set; } = "var(--p-dim)";
        public string Ic { get; set; } = "var(--cyan)";
    }
}
