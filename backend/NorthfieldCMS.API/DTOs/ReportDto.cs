namespace NorthfieldCMS.API.DTOs
{
    public class ReportDto
    {
        public string ReportTitle { get; set; } = string.Empty;
        public string GeneratedDate { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int TotalRecords { get; set; }
        public string Status { get; set; } = "Completed";
    }
}
