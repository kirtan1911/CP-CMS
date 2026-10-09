using System;
using System.ComponentModel.DataAnnotations;

namespace NorthfieldCMS.API.Models
{
    public class PasswordResetOtp
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
