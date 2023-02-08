using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class CheckTimeTable
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public int PeriodId { get; set; }
        public string Day { get; set; }
        public int Id { get; set; }
    }
}
