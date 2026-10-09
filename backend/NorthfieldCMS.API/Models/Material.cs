using System;
using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileType { get; set; } = "PDF";
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedDate { get; set; } = DateTime.Now;
    }
}
