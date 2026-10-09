using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthfieldCMS.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "Student"; // Admin, Faculty, Student

        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string HeadOfDepartment { get; set; } = string.Empty;

        public int CoursesCount { get; set; }
        public int StudentsCount { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }

    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public double AttendancePercentage { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Faculty { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }

    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public string ExamName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = "10:00 AM";
        public string Duration { get; set; } = "2 Hours";
        public int MaxMarks { get; set; } = 100;
        public string Status { get; set; } = "Scheduled";
    }

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

    public class AttendanceRecord
    {
        [Key]
        public int AttendanceId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Present";
        public double Percentage { get; set; }
    }

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

    public class NotificationRecord
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public bool IsUnread { get; set; } = true;
        public string Icon { get; set; } = "bell";
        public string Bg { get; set; } = "var(--p-dim)";
        public string Ic { get; set; } = "var(--cyan)";
        public string TargetAudience { get; set; } = "All";
    }
}
