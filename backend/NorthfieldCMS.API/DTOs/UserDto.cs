namespace NorthfieldCMS.API.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public string CreatedAt { get; set; } = string.Empty;
    }
}
