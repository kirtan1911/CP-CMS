using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }
}
