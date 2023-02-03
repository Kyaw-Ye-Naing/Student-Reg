using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblResult
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string Status { get; set; }
        public int? SemesterId { get; set; }
        public int? YearLevelId { get; set; }
        public int? AcademicYearId { get; set; }
        public int? NextYearId { get; set; }
    }
}
