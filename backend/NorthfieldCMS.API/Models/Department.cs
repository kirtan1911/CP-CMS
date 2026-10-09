using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string HeadOfDepartment { get; set; } = string.Empty;

        public int CoursesCount { get; set; }
        public int StudentsCount { get; set; }
        public string Status { get; set; } = "Active";
    }
}
