using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblCourse
    {
        public int Id { get; set; }
        public int? YearLevelId { get; set; }
        public int? AcademicYearId { get; set; }
        public string Name { get; set; }
        public int? SemesterId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Code { get; set; }
        public int? GroupId { get; set; }
        public string MajorCode { get; set; }
    }
}
