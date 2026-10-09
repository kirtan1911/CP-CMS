using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class MarkResult
    {
        [Key]
        public int MarkResultId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int InternalMarks { get; set; }
        public int ExamMarks { get; set; }
        public int TotalMarks { get; set; }
        public string Grade { get; set; } = "A";
        public string Status { get; set; } = "Passed";
    }
}
