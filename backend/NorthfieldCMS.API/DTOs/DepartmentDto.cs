namespace NorthfieldCMS.API.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Head { get; set; } = string.Empty;
        public int Courses { get; set; }
        public int Students { get; set; }
        public string Status { get; set; } = "Active";
    }
}
