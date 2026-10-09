namespace NorthfieldCMS.API.DTOs
{
    public class MarkResultDto
    {
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
