using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        public string Status { get; set; }
        public int? SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public List<StudentResultDetails> StudentResultDetails { get; set; } 
    }

    public class StudentResultDetails
    {
        public int? ResultDetailsId { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string Description { get; set; }
    }
}
