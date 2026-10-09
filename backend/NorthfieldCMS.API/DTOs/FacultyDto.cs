namespace NorthfieldCMS.API.DTOs
{
    public class FacultyDto
    {
        public int FacultyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }
}
