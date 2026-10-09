namespace NorthfieldCMS.API.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Faculty { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }
}
