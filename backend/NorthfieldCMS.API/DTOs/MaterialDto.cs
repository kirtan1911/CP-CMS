namespace NorthfieldCMS.API.DTOs
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileType { get; set; } = "PDF";
        public string UploadedBy { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }
}
