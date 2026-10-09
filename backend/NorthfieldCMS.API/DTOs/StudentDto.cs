namespace NorthfieldCMS.API.DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Attendance { get; set; } = "85%";
        public string Status { get; set; } = "Active";
    }
}
