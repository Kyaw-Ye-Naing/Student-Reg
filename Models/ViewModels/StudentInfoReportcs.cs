using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class StudentInfoReportcs
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string DegreeProgram { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public List<StudentInfoHistory> InfoHistories { get; set; }
        public List<CourseDetails> CourseDetails { get; set; }
    }

    public class StudentInfoHistory
    {
        public int AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public int YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int MajorId { get; set; }
        public string MajorName { get; set; }
    }

    public class CourseDetails
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
    }



    public class StudentInfoReportView
    {
        public string Status { get; set; }
        public int YearlevelId { get; set; }
        public List<StudentInfoReportViewDetails> studentInfoReportViews { get; set; }
    }

    public class StudentInfoReportViewDetails
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public int YearLevelId { get; set; }
        public string YearLevelName { get; set; }

    }
}

