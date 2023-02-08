using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class TimeLimitInfo
    {
        public int Id { get; set; }
        public int? AcademicYearId { get; set; }
        public string AcademicYear { get; set; }
        public int? SemesterId { get; set; }
        public string Semester { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool? Active { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
