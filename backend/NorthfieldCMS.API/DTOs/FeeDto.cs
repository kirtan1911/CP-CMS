namespace NorthfieldCMS.API.DTOs
{
    public class FeeDto
    {
        public int FeeId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string TotalFees { get; set; } = string.Empty;
        public string Paid { get; set; } = string.Empty;
        public string Pending { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string Status { get; set; } = "Paid";
    }
}
