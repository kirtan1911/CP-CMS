using System;
using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public string ExamName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = "10:00 AM";
        public string Duration { get; set; } = "2 Hours";
        public int MaxMarks { get; set; } = 100;
        public string Status { get; set; } = "Scheduled";
    }
}
