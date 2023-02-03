using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblTimeTable
    {
        public int Id { get; set; }
        public int? SectionId { get; set; }
        public int? YearLevelId { get; set; }
        public int? AcademicYearId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? SemesterId { get; set; }
    }
}
