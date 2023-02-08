using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{

    public class StudentCourseSearch
    {
        public int AcademicYearId { get; set; }
        public int YearLevelId { get; set; }
        public int RegistrationId { get; set; }
        public int CourseSelectId { get; set; }
        public List<StudentCourseInfo> StudentCourseInfos { get; set; }
    }

    public class StudentCourseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public bool IsRegister { get; set; }
        public bool IsCourseSelect { get; set; }
        public bool IsSecondSelect { get; set; }
        public string Description { get; set; }
        public int YearLevelId { get; set; }
        public string YearLevelName { get; set; }
    }
}

