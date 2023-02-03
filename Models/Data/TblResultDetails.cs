using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblResultDetails
    {
        public int Id { get; set; }
        public int? ResultId { get; set; }
        public int? CourseId { get; set; }
        public string Grade { get; set; }
    }
}
