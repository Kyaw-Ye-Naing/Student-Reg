using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class StudentDashboardInfo
    {
        public List<CourseDashboard> CourseDashboards { get; set; }
        public ProfileDashboard ProfileDashboards { get; set; }
        public List<ResultDashboard> ResultDashboards { get; set; }
        public List<TimeTableInfocsDetails> TimeTableInfocsDetails { get; set; }
    }

    public class CourseDashboard
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
    }

    public class ResultDashboard
    {
        public string CourseName { get; set; }
        public string Grade { get; set; }
    }

    public class ProfileDashboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }     
        public string SectionName { get; set; }
        public string AcademicYearName { get; set; }
        public string DegreeProgram { get; set; }    
        public string YearLevelName { get; set; }
        public int YearLevelId { get; set; }
        public string Address { get; set; }
        public string SemesterName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
