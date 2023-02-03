using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public int? AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public string DegreeProgram { get; set; }
        public int? SectionId { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public string Address { get; set; }
        public int? SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
