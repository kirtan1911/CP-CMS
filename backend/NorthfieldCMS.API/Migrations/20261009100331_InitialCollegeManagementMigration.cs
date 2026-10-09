using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NorthfieldCMS.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCollegeManagementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    Course = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Percentage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    Faculty = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    HeadOfDepartment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CoursesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExamName = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Course = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    MaxMarks = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "FacultyMembers",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacultyCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyMembers", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "FeeRecords",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    Course = table.Column<string>(type: "TEXT", nullable: false),
                    TotalFees = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PendingAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeRecords", x => x.FeeId);
                });

            migrationBuilder.CreateTable(
                name: "MarkResults",
                columns: table => new
                {
                    MarkResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    InternalMarks = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamMarks = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMarks = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkResults", x => x.MarkResultId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    FileType = table.Column<string>(type: "TEXT", nullable: false),
                    UploadedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationRecords",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    IsUnread = table.Column<bool>(type: "INTEGER", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Bg = table.Column<string>(type: "TEXT", nullable: false),
                    Ic = table.Column<string>(type: "TEXT", nullable: false),
                    TargetAudience = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRecords", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetOtps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OtpCode = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetOtps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    AttendancePercentage = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Code", "Credits", "Department", "Faculty", "Name", "Semester", "Status" },
                values: new object[,]
                {
                    { 1, "CS301", 4, "Computer Science", "Dr. Meera Shah", "Database Management Systems", "Semester 5", "Active" },
                    { 2, "CS302", 4, "Computer Science", "Dr. Meera Shah", "Operating Systems", "Semester 5", "Active" },
                    { 3, "CS303", 3, "Computer Science", "Dr. Kavita Rao", "Web Technologies", "Semester 5", "Active" },
                    { 4, "IT201", 4, "Information Technology", "Dr. Kavita Rao", "Computer Networks", "Semester 3", "Active" },
                    { 5, "EC401", 4, "Electronics Engineering", "Dr. S. Iyer", "Digital Signal Processing", "Semester 7", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "CoursesCount", "HeadOfDepartment", "Name", "Status", "StudentsCount" },
                values: new object[,]
                {
                    { 1, 12, "Dr. Meera Shah", "Computer Science", "Active", 428 },
                    { 2, 10, "Dr. Kavita Rao", "Information Technology", "Active", 316 },
                    { 3, 9, "Dr. S. Iyer", "Electronics Engineering", "Active", 274 },
                    { 4, 8, "Dr. Ananya Sen", "Business Administration", "Active", 218 },
                    { 5, 6, "Dr. Vivek Menon", "Mathematics", "Active", 152 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Course", "Date", "Duration", "ExamName", "MaxMarks", "Status", "Subject", "Time" },
                values: new object[,]
                {
                    { 1, "CS301 - DBMS", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 Hours", "Mid Semester Exam", 50, "Scheduled", "Database Management Systems", "10:00 AM" },
                    { 2, "CS302 - OS", new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 Hours", "Mid Semester Exam", 50, "Scheduled", "Operating Systems", "02:00 PM" },
                    { 3, "CS303 - Web Tech", new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Hours", "Practical Evaluation", 25, "Scheduled", "Web Technologies", "10:00 AM" }
                });

            migrationBuilder.InsertData(
                table: "FacultyMembers",
                columns: new[] { "FacultyId", "Department", "Email", "Experience", "FacultyCode", "Name", "Specialization", "Status" },
                values: new object[,]
                {
                    { 1, "Computer Science", "meera.shah@northfield.edu", "12 Years", "FAC-001", "Dr. Meera Shah", "Machine Learning, DBMS", "Active" },
                    { 2, "Information Technology", "kavita.rao@northfield.edu", "9 Years", "FAC-002", "Dr. Kavita Rao", "Cybersecurity, Cloud", "Active" },
                    { 3, "Electronics Engineering", "nikhil.joshi@northfield.edu", "7 Years", "FAC-003", "Prof. Nikhil Joshi", "VLSI, Embedded Systems", "Inactive" },
                    { 4, "Electronics Engineering", "s.iyer@northfield.edu", "14 Years", "FAC-004", "Dr. S. Iyer", "Signal Processing", "Active" },
                    { 5, "Business Administration", "ananya.sen@northfield.edu", "10 Years", "FAC-005", "Dr. Ananya Sen", "Strategic Management", "Active" }
                });

            migrationBuilder.InsertData(
                table: "FeeRecords",
                columns: new[] { "FeeId", "Course", "DueDate", "PaidAmount", "PendingAmount", "Status", "StudentName", "TotalFees" },
                values: new object[,]
                {
                    { 1, "B.Tech CSE - Semester 5", new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 85000m, 0m, "Paid", "Riya Mehta", 85000m },
                    { 2, "B.Tech CSE - Semester 5", new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 68000m, 17000m, "Partial", "Kirtan Barot", 85000m },
                    { 3, "B.Tech IT - Semester 3", new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 80000m, 0m, "Paid", "Aditi Sharma", 80000m }
                });

            migrationBuilder.InsertData(
                table: "MarkResults",
                columns: new[] { "MarkResultId", "ExamMarks", "Grade", "InternalMarks", "Status", "StudentName", "Subject", "TotalMarks" },
                values: new object[,]
                {
                    { 1, 62, "A+", 28, "Passed", "Riya Mehta", "Database Management Systems", 90 },
                    { 2, 56, "A", 25, "Passed", "Riya Mehta", "Operating Systems", 81 },
                    { 3, 51, "B+", 23, "Passed", "Riya Mehta", "Web Technologies", 74 },
                    { 4, 60, "A", 26, "Passed", "Kirtan Barot", "Database Management Systems", 86 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "FileType", "Subject", "Title", "UploadedBy", "UploadedDate" },
                values: new object[,]
                {
                    { 1, "PDF", "Database Management Systems", "DBMS Unit 3 — Relational Algebra Notes", "Dr. Meera Shah", new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "DOCX", "Operating Systems", "OS CPU Scheduling Lab Guide", "Dr. Meera Shah", new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "PPTX", "Web Technologies", "Web Tech — React JS Slides", "Dr. Kavita Rao", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "NotificationRecords",
                columns: new[] { "NotificationId", "Bg", "Body", "Ic", "Icon", "IsUnread", "TargetAudience", "Time", "Title" },
                values: new object[,]
                {
                    { 1, "rgba(141,123,255,.16)", "The mid-semester timetable for B.Tech Semester 5 is now live. Exams start Aug 20.", "#8d7bff", "calendar-event", true, "All", "10 mins ago", "Mid-Semester Exam Schedule Published" },
                    { 2, "rgba(245,158,11,.15)", "Second installment of tuition fees is due on 30 August 2026.", "#f59e0b", "credit-card", true, "Students", "2 hours ago", "Fee Payment Reminder" },
                    { 3, "rgba(34,211,238,.12)", "Department review meeting in Seminar Hall B regarding NBA accreditation.", "#22d3ee", "people", false, "Faculty", "Yesterday", "Faculty Meeting Today at 4 PM" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AttendancePercentage", "Department", "Email", "Name", "Semester", "Status", "StudentCode" },
                values: new object[,]
                {
                    { 1, 92.5, "Computer Science", "riya.mehta@northfield.edu", "Riya Mehta", "Semester 5", "Active", "STU-2024-001" },
                    { 2, 88.0, "Computer Science", "kirtan.barot@northfield.edu", "Kirtan Barot", "Semester 5", "Active", "STU-2024-002" },
                    { 3, 95.0, "Information Technology", "aditi.sharma@northfield.edu", "Aditi Sharma", "Semester 3", "Active", "STU-2024-003" },
                    { 4, 78.400000000000006, "Electronics Engineering", "dev.malhotra@northfield.edu", "Dev Malhotra", "Semester 7", "Active", "STU-2024-004" },
                    { 5, 81.200000000000003, "Business Administration", "harsh.mehta@northfield.edu", "Harsh Mehta", "Semester 1", "Active", "STU-2024-005" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Department", "Email", "FullName", "IsActive", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administration", "admin@northfield.edu", "Aarav Patel", true, "$2a$11$KDt1JeSelReBn2NuOOOZWOoOD2epPdSCkzuCB.1C9gZOmZLCUyQB2", "Admin" },
                    { 2, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "meera.shah@northfield.edu", "Dr. Meera Shah", true, "$2a$11$2LGwlZ4fOxBjIX96p74OreFUxdwpcBhH6O9evcHkJF1x13IPgwfFW", "Faculty" },
                    { 3, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "riya.mehta@northfield.edu", "Riya Mehta", true, "$2a$11$cuvg/FToBh2KswPM0PmL3.oogYD9AhXBJHxmIJN4TXXmFEMciSSr.", "Student" },
                    { 4, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "kavita.rao@northfield.edu", "Dr. Kavita Rao", true, "$2a$11$2LGwlZ4fOxBjIX96p74OreFUxdwpcBhH6O9evcHkJF1x13IPgwfFW", "Faculty" },
                    { 5, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics Engineering", "nikhil.joshi@northfield.edu", "Prof. Nikhil Joshi", false, "$2a$11$2LGwlZ4fOxBjIX96p74OreFUxdwpcBhH6O9evcHkJF1x13IPgwfFW", "Faculty" },
                    { 6, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "kirtan.barot@northfield.edu", "Kirtan Barot", true, "$2a$11$cuvg/FToBh2KswPM0PmL3.oogYD9AhXBJHxmIJN4TXXmFEMciSSr.", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "FacultyMembers");

            migrationBuilder.DropTable(
                name: "FeeRecords");

            migrationBuilder.DropTable(
                name: "MarkResults");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "NotificationRecords");

            migrationBuilder.DropTable(
                name: "PasswordResetOtps");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
