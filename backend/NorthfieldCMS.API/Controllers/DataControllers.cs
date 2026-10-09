using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthfieldCMS.API.Data;
using NorthfieldCMS.API.DTOs;
using NorthfieldCMS.API.Models;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Code = $"USR-{u.UserId:D3}",
                Name = u.FullName,
                Email = u.Email,
                Role = u.Role,
                Status = u.IsActive ? "Active" : "Inactive",
                CreatedAt = u.CreatedAt.ToString("dd MMM yyyy")
            }).ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("default123");
            user.CreatedAt = DateTime.UtcNow;
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FacultyController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetFaculty()
        {
            var list = await _db.FacultyMembers.Select(f => new FacultyDto
            {
                FacultyId = f.FacultyId,
                Code = f.FacultyCode,
                Name = f.Name,
                Email = f.Email,
                Department = f.Department,
                Specialization = f.Specialization,
                Experience = f.Experience,
                Status = f.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateFaculty([FromBody] Faculty faculty)
        {
            _db.FacultyMembers.Add(faculty);
            await _db.SaveChangesAsync();
            return Ok(faculty);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var list = await _db.Students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                Code = s.StudentCode,
                Name = s.Name,
                Email = s.Email,
                Department = s.Department,
                Semester = s.Semester,
                Attendance = $"{s.AttendancePercentage}%",
                Status = s.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Faculty")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return Ok(student);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CoursesController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var list = await _db.Courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                Code = c.Code,
                Name = c.Name,
                Department = c.Department,
                Credits = c.Credits,
                Faculty = c.Faculty,
                Semester = c.Semester,
                Status = c.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return Ok(course);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DepartmentsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var list = await _db.Departments.Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Head = d.HeadOfDepartment,
                Courses = d.CoursesCount,
                Students = d.StudentsCount,
                Status = d.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            _db.Departments.Add(department);
            await _db.SaveChangesAsync();
            return Ok(department);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ExamsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var list = await _db.Exams.Select(e => new ExamDto
            {
                ExamId = e.ExamId,
                ExamName = e.ExamName,
                Subject = e.Subject,
                Course = e.Course,
                Date = e.Date.ToString("dd MMM yyyy"),
                Time = e.Time,
                Duration = e.Duration,
                MaxMarks = e.MaxMarks,
                Status = e.Status
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Faculty")]
        public async Task<IActionResult> CreateExam([FromBody] Exam exam)
        {
            _db.Exams.Add(exam);
            await _db.SaveChangesAsync();
            return Ok(exam);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MarksController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetMarks()
        {
            var list = await _db.MarkResults.Select(m => new MarkResultDto
            {
                MarkResultId = m.MarkResultId,
                StudentName = m.StudentName,
                Subject = m.Subject,
                InternalMarks = m.InternalMarks,
                ExamMarks = m.ExamMarks,
                TotalMarks = m.TotalMarks,
                Grade = m.Grade,
                Status = m.Status
            }).ToListAsync();

            return Ok(list);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class FeesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FeesController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetFees()
        {
            var list = await _db.FeeRecords.Select(f => new FeeDto
            {
                FeeId = f.FeeId,
                StudentName = f.StudentName,
                Course = f.Course,
                TotalFees = $"₹{f.TotalFees:N0}",
                Paid = $"₹{f.PaidAmount:N0}",
                Pending = $"₹{f.PendingAmount:N0}",
                DueDate = f.DueDate.ToString("dd MMM yyyy"),
                Status = f.Status
            }).ToListAsync();

            return Ok(list);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public NotificationsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var list = await _db.NotificationRecords.Select(n => new NotificationDto
            {
                NotificationId = n.NotificationId,
                Title = n.Title,
                Body = n.Body,
                Time = n.Time,
                Unread = n.IsUnread,
                Icon = n.Icon,
                Bg = n.Bg,
                Ic = n.Ic
            }).ToListAsync();

            return Ok(list);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MaterialsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetMaterials()
        {
            var list = await _db.Materials.Select(m => new MaterialDto
            {
                MaterialId = m.MaterialId,
                Title = m.Title,
                Subject = m.Subject,
                FileType = m.FileType,
                UploadedBy = m.UploadedBy,
                Date = m.UploadedDate.ToString("dd MMM yyyy")
            }).ToListAsync();

            return Ok(list);
        }
    }
}
