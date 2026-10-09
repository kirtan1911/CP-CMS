using System;
using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class AttendanceRecord
    {
        [Key]
        public int AttendanceId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Present";
        public double Percentage { get; set; }
    }
}
