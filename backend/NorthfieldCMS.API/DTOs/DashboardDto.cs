using System.Collections.Generic;

namespace NorthfieldCMS.API.DTOs
{
    public class DashboardDto
    {
        public int TotalStudents { get; set; } = 1388;
        public int TotalFaculty { get; set; } = 54;
        public string AvgAttendance { get; set; } = "88.4%";
        public string TotalFeeCollection { get; set; } = "₹48.2L";
        public List<ExamDto> UpcomingExams { get; set; } = new List<ExamDto>();
        public List<NotificationDto> RecentAnnouncements { get; set; } = new List<NotificationDto>();
    }
}
