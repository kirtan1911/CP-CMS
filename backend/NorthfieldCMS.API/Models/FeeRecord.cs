using System;
using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class FeeRecord
    {
        [Key]
        public int FeeId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public decimal TotalFees { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Paid";
    }
}
