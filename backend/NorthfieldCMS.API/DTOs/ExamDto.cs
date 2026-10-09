namespace NorthfieldCMS.API.DTOs
{
    public class ExamDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int MaxMarks { get; set; }
        public string Status { get; set; } = "Scheduled";
    }
}
