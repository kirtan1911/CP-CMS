using Microsoft.EntityFrameworkCore;
using NorthfieldCMS.API.Models;
using BCrypt.Net;
using System;

namespace NorthfieldCMS.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Faculty> FacultyMembers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<MarkResult> MarkResults { get; set; } = null!;
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<FeeRecord> FeeRecords { get; set; } = null!;
        public DbSet<NotificationRecord> NotificationRecords { get; set; } = null!;
        public DbSet<PasswordResetOtp> PasswordResetOtps { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Pre-hashed passwords using BCrypt (Static hashes to ensure deterministic EF Core migrations)
            const string adminHash = "$2a$11$KDt1JeSelReBn2NuOOOZWOoOD2epPdSCkzuCB.1C9gZOmZLCUyQB2";
            const string facultyHash = "$2a$11$2LGwlZ4fOxBjIX96p74OreFUxdwpcBhH6O9evcHkJF1x13IPgwfFW";
            const string studentHash = "$2a$11$cuvg/FToBh2KswPM0PmL3.oogYD9AhXBJHxmIJN4TXXmFEMciSSr.";

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Aarav Patel", Email = "admin@northfield.edu", PasswordHash = adminHash, Role = "Admin", Department = "Administration", IsActive = true, CreatedAt = new DateTime(2024, 8, 1) },
                new User { UserId = 2, FullName = "Dr. Meera Shah", Email = "meera.shah@northfield.edu", PasswordHash = facultyHash, Role = "Faculty", Department = "Computer Science", IsActive = true, CreatedAt = new DateTime(2024, 8, 10) },
                new User { UserId = 3, FullName = "Riya Mehta", Email = "riya.mehta@northfield.edu", PasswordHash = studentHash, Role = "Student", Department = "Computer Science", IsActive = true, CreatedAt = new DateTime(2024, 9, 1) },
                new User { UserId = 4, FullName = "Dr. Kavita Rao", Email = "kavita.rao@northfield.edu", PasswordHash = facultyHash, Role = "Faculty", Department = "Information Technology", IsActive = true, CreatedAt = new DateTime(2024, 8, 10) },
                new User { UserId = 5, FullName = "Prof. Nikhil Joshi", Email = "nikhil.joshi@northfield.edu", PasswordHash = facultyHash, Role = "Faculty", Department = "Electronics Engineering", IsActive = false, CreatedAt = new DateTime(2024, 8, 12) },
                new User { UserId = 6, FullName = "Kirtan Barot", Email = "kirtan.barot@northfield.edu", PasswordHash = studentHash, Role = "Student", Department = "Computer Science", IsActive = true, CreatedAt = new DateTime(2024, 9, 1) }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Computer Science", HeadOfDepartment = "Dr. Meera Shah", CoursesCount = 12, StudentsCount = 428, Status = "Active" },
                new Department { DepartmentId = 2, Name = "Information Technology", HeadOfDepartment = "Dr. Kavita Rao", CoursesCount = 10, StudentsCount = 316, Status = "Active" },
                new Department { DepartmentId = 3, Name = "Electronics Engineering", HeadOfDepartment = "Dr. S. Iyer", CoursesCount = 9, StudentsCount = 274, Status = "Active" },
                new Department { DepartmentId = 4, Name = "Business Administration", HeadOfDepartment = "Dr. Ananya Sen", CoursesCount = 8, StudentsCount = 218, Status = "Active" },
                new Department { DepartmentId = 5, Name = "Mathematics", HeadOfDepartment = "Dr. Vivek Menon", CoursesCount = 6, StudentsCount = 152, Status = "Active" }
            );

            // Seed Faculty
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyId = 1, FacultyCode = "FAC-001", Name = "Dr. Meera Shah", Email = "meera.shah@northfield.edu", Department = "Computer Science", Specialization = "Machine Learning, DBMS", Experience = "12 Years", Status = "Active" },
                new Faculty { FacultyId = 2, FacultyCode = "FAC-002", Name = "Dr. Kavita Rao", Email = "kavita.rao@northfield.edu", Department = "Information Technology", Specialization = "Cybersecurity, Cloud", Experience = "9 Years", Status = "Active" },
                new Faculty { FacultyId = 3, FacultyCode = "FAC-003", Name = "Prof. Nikhil Joshi", Email = "nikhil.joshi@northfield.edu", Department = "Electronics Engineering", Specialization = "VLSI, Embedded Systems", Experience = "7 Years", Status = "Inactive" },
                new Faculty { FacultyId = 4, FacultyCode = "FAC-004", Name = "Dr. S. Iyer", Email = "s.iyer@northfield.edu", Department = "Electronics Engineering", Specialization = "Signal Processing", Experience = "14 Years", Status = "Active" },
                new Faculty { FacultyId = 5, FacultyCode = "FAC-005", Name = "Dr. Ananya Sen", Email = "ananya.sen@northfield.edu", Department = "Business Administration", Specialization = "Strategic Management", Experience = "10 Years", Status = "Active" }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentCode = "STU-2024-001", Name = "Riya Mehta", Email = "riya.mehta@northfield.edu", Department = "Computer Science", Semester = "Semester 5", AttendancePercentage = 92.5, Status = "Active" },
                new Student { StudentId = 2, StudentCode = "STU-2024-002", Name = "Kirtan Barot", Email = "kirtan.barot@northfield.edu", Department = "Computer Science", Semester = "Semester 5", AttendancePercentage = 88.0, Status = "Active" },
                new Student { StudentId = 3, StudentCode = "STU-2024-003", Name = "Aditi Sharma", Email = "aditi.sharma@northfield.edu", Department = "Information Technology", Semester = "Semester 3", AttendancePercentage = 95.0, Status = "Active" },
                new Student { StudentId = 4, StudentCode = "STU-2024-004", Name = "Dev Malhotra", Email = "dev.malhotra@northfield.edu", Department = "Electronics Engineering", Semester = "Semester 7", AttendancePercentage = 78.4, Status = "Active" },
                new Student { StudentId = 5, StudentCode = "STU-2024-005", Name = "Harsh Mehta", Email = "harsh.mehta@northfield.edu", Department = "Business Administration", Semester = "Semester 1", AttendancePercentage = 81.2, Status = "Active" }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Code = "CS301", Name = "Database Management Systems", Department = "Computer Science", Credits = 4, Faculty = "Dr. Meera Shah", Semester = "Semester 5", Status = "Active" },
                new Course { CourseId = 2, Code = "CS302", Name = "Operating Systems", Department = "Computer Science", Credits = 4, Faculty = "Dr. Meera Shah", Semester = "Semester 5", Status = "Active" },
                new Course { CourseId = 3, Code = "CS303", Name = "Web Technologies", Department = "Computer Science", Credits = 3, Faculty = "Dr. Kavita Rao", Semester = "Semester 5", Status = "Active" },
                new Course { CourseId = 4, Code = "IT201", Name = "Computer Networks", Department = "Information Technology", Credits = 4, Faculty = "Dr. Kavita Rao", Semester = "Semester 3", Status = "Active" },
                new Course { CourseId = 5, Code = "EC401", Name = "Digital Signal Processing", Department = "Electronics Engineering", Credits = 4, Faculty = "Dr. S. Iyer", Semester = "Semester 7", Status = "Active" }
            );

            // Seed Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { ExamId = 1, ExamName = "Mid Semester Exam", Subject = "Database Management Systems", Course = "CS301 - DBMS", Date = new DateTime(2026, 8, 20), Time = "10:00 AM", Duration = "2 Hours", MaxMarks = 50, Status = "Scheduled" },
                new Exam { ExamId = 2, ExamName = "Mid Semester Exam", Subject = "Operating Systems", Course = "CS302 - OS", Date = new DateTime(2026, 8, 22), Time = "02:00 PM", Duration = "2 Hours", MaxMarks = 50, Status = "Scheduled" },
                new Exam { ExamId = 3, ExamName = "Practical Evaluation", Subject = "Web Technologies", Course = "CS303 - Web Tech", Date = new DateTime(2026, 8, 25), Time = "10:00 AM", Duration = "3 Hours", MaxMarks = 25, Status = "Scheduled" }
            );

            // Seed Marks
            modelBuilder.Entity<MarkResult>().HasData(
                new MarkResult { MarkResultId = 1, StudentName = "Riya Mehta", Subject = "Database Management Systems", InternalMarks = 28, ExamMarks = 62, TotalMarks = 90, Grade = "A+", Status = "Passed" },
                new MarkResult { MarkResultId = 2, StudentName = "Riya Mehta", Subject = "Operating Systems", InternalMarks = 25, ExamMarks = 56, TotalMarks = 81, Grade = "A", Status = "Passed" },
                new MarkResult { MarkResultId = 3, StudentName = "Riya Mehta", Subject = "Web Technologies", InternalMarks = 23, ExamMarks = 51, TotalMarks = 74, Grade = "B+", Status = "Passed" },
                new MarkResult { MarkResultId = 4, StudentName = "Kirtan Barot", Subject = "Database Management Systems", InternalMarks = 26, ExamMarks = 60, TotalMarks = 86, Grade = "A", Status = "Passed" }
            );

            // Seed Fees
            modelBuilder.Entity<FeeRecord>().HasData(
                new FeeRecord { FeeId = 1, StudentName = "Riya Mehta", Course = "B.Tech CSE - Semester 5", TotalFees = 85000, PaidAmount = 85000, PendingAmount = 0, DueDate = new DateTime(2026, 7, 31), Status = "Paid" },
                new FeeRecord { FeeId = 2, StudentName = "Kirtan Barot", Course = "B.Tech CSE - Semester 5", TotalFees = 85000, PaidAmount = 68000, PendingAmount = 17000, DueDate = new DateTime(2026, 8, 30), Status = "Partial" },
                new FeeRecord { FeeId = 3, StudentName = "Aditi Sharma", Course = "B.Tech IT - Semester 3", TotalFees = 80000, PaidAmount = 80000, PendingAmount = 0, DueDate = new DateTime(2026, 7, 31), Status = "Paid" }
            );

            // Seed Notifications
            modelBuilder.Entity<NotificationRecord>().HasData(
                new NotificationRecord { NotificationId = 1, Title = "Mid-Semester Exam Schedule Published", Body = "The mid-semester timetable for B.Tech Semester 5 is now live. Exams start Aug 20.", Time = "10 mins ago", IsUnread = true, Icon = "calendar-event", Bg = "rgba(141,123,255,.16)", Ic = "#8d7bff", TargetAudience = "All" },
                new NotificationRecord { NotificationId = 2, Title = "Fee Payment Reminder", Body = "Second installment of tuition fees is due on 30 August 2026.", Time = "2 hours ago", IsUnread = true, Icon = "credit-card", Bg = "rgba(245,158,11,.15)", Ic = "#f59e0b", TargetAudience = "Students" },
                new NotificationRecord { NotificationId = 3, Title = "Faculty Meeting Today at 4 PM", Body = "Department review meeting in Seminar Hall B regarding NBA accreditation.", Time = "Yesterday", IsUnread = false, Icon = "people", Bg = "rgba(34,211,238,.12)", Ic = "#22d3ee", TargetAudience = "Faculty" }
            );

            // Seed Materials
            modelBuilder.Entity<Material>().HasData(
                new Material { MaterialId = 1, Title = "DBMS Unit 3 — Relational Algebra Notes", Subject = "Database Management Systems", FileType = "PDF", UploadedBy = "Dr. Meera Shah", UploadedDate = new DateTime(2026, 8, 10) },
                new Material { MaterialId = 2, Title = "OS CPU Scheduling Lab Guide", Subject = "Operating Systems", FileType = "DOCX", UploadedBy = "Dr. Meera Shah", UploadedDate = new DateTime(2026, 8, 11) },
                new Material { MaterialId = 3, Title = "Web Tech — React JS Slides", Subject = "Web Technologies", FileType = "PPTX", UploadedBy = "Dr. Kavita Rao", UploadedDate = new DateTime(2026, 8, 12) }
            );
        }
    }
}
