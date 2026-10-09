using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public double AttendancePercentage { get; set; }
        public string Status { get; set; } = "Active";
    }
}
