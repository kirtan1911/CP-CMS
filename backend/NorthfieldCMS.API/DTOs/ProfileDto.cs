namespace NorthfieldCMS.API.DTOs
{
    public class ProfileDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JoinedDate { get; set; } = string.Empty;
    }
}
