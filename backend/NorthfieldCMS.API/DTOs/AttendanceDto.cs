namespace NorthfieldCMS.API.DTOs
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Status { get; set; } = "Present";
        public double Percentage { get; set; }
    }
}
