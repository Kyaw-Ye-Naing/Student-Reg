using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class AdminDashboardInfocs
    {
        public int[] PieChartData { get; set; }
        public int[] LineChartPassData { get; set; }
        public int[] LineChartFailData { get; set; }
        public int RegisterCount { get; set; }
        public int UnRegisterCount { get; set; }
        public int CourseCount { get; set; }
        public int UnCourseCount { get; set; }
    }
}
