using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class Course_info
    {
        public int Id { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public string Name { get; set; }
        public int? SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Code { get; set; }
        public int? GroupId { get; set; }
    }
}
