using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class Prerequisities
    {
        public int Id { get; set; }
        public int PassCourseId { get; set; }
        public int NewCourseId { get; set; }
        public string PassCourseName { get; set; }
        public string NewCourseName { get; set; }
        public string PassCode { get; set; }
        public string NewCode { get; set; }
        public bool Active { get; set; }
    }
}
