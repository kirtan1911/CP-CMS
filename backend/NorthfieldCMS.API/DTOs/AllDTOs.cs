using System;
using System.Collections.Generic;

namespace NorthfieldCMS.API.DTOs
{
    // Auth DTOs
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "student"; // admin, faculty, student
        public string Department { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    // Entity DTOs
    public class UserDto
    {
        public int UserId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public string CreatedAt { get; set; } = string.Empty;
    }

    public class FacultyDto
    {
        public int FacultyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }

    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Attendance { get; set; } = "85%";
        public string Status { get; set; } = "Active";
    }

    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Faculty { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }

    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Head { get; set; } = string.Empty;
        public int Courses { get; set; }
        public int Students { get; set; }
        public string Status { get; set; } = "Active";
    }

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

    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public bool Unread { get; set; }
        public string Icon { get; set; } = "bell";
        public string Bg { get; set; } = "var(--p-dim)";
        public string Ic { get; set; } = "var(--cyan)";
    }

    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileType { get; set; } = "PDF";
        public string UploadedBy { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }

    // Chatbot DTOs
    public class ChatRequestDto
    {
        public string Message { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
    }

    public class ChatResponseDto
    {
        public string Reply { get; set; } = string.Empty;
        public string Timestamp { get; set; } = DateTime.Now.ToString("HH:mm");
        public bool Success { get; set; } = true;
    }
}
