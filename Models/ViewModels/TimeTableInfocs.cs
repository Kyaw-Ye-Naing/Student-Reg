using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class TimeTableInfocs
    {
        public int Id { get; set; }
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public bool? Active { get; set; }
        public int? SemesterId { get; set; }
        public string SemesterName { get; set; }
        public List<TimeTableInfocsDetails> TableInfocsDetails { get; set; }
    }

    public class TimeTableInfocsDetails
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? PeriodId { get; set; }
        public string Day { get; set; }
    }
}
