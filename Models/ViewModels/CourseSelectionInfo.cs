using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class CourseSelectionInfo
    {
        public int PrevSemesterId { get; set; }
        public string PrevSemester { get; set; }
        public int PrevAcademicId { get; set; }
        public string PrevAcademic { get; set; }
        public int PrevYearLevelId { get; set; }
        public string PrevYearLevel { get; set; }
        public int PrevMajorId { get; set; }
        public string PrevMajor { get; set; }
        public List<CourseSelectionDetails> PrevCourse { get; set; }
        public int NextSemesterId { get; set; }
        public string NextSemester { get; set; }
        public int NextAcademicId { get; set; }
        public string NextAcademic { get; set; }
        public int NextYearLevelId { get; set; }
        public string NextYearLevel { get; set; }
        public int NextMajorId { get; set; }
        public string NextMajor { get; set; }
        public List<CourseSelectionDetails> NextCourse { get; set; }
    }

    public class CourseSelectionDetails
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
    }
}
