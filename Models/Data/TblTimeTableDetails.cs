using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblTimeTableDetails
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? TimeTableId { get; set; }
        public string Day { get; set; }
    }
}
