namespace NorthfieldCMS.API.DTOs
{
    public class SettingsDto
    {
        public string SystemName { get; set; } = "Northfield CMS";
        public bool EnableNotifications { get; set; } = true;
        public bool MaintenanceMode { get; set; } = false;
        public string ActiveTheme { get; set; } = "Liquid Glassmorphic Dark";
    }
}
