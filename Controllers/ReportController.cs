using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class ReportController : Controller
    {
        private readonly StudentInfoContext _context;
        public ReportController(StudentInfoContext context)
        {
            _context = context;
        }

        public IActionResult StudentInfo()
        {
            StudentInfoReportView infoReportView = new StudentInfoReportView();
            List<StudentInfoReportViewDetails> studentInfo = new List<StudentInfoReportViewDetails>();

            infoReportView.Status = (TempData["status"] == null ? "all" : TempData["status"]).ToString();
            var status = (TempData["status"] == null ? "all" : TempData["status"]).ToString();

            studentInfo = (from stu in _context.TblStudentAccount
                           join det in _context.TblStudentInfo
                           on stu.Id equals det.AccountId
                           join y in _context.TblYearLevel
                           on det.YearLevelId equals y.Id
                           where det.Active == true
                           select new StudentInfoReportViewDetails
                           {
                               Id = stu.Id,
                               Name = stu.Name,
                               Email = stu.Email,
                               AccountId = stu.AccountId,
                               YearLevelId = (int)det.YearLevelId,
                               YearLevelName = y.Name
                           }).ToList();

            if(status == "lock")
            {
                studentInfo = studentInfo.Where(a => a.Active).ToList();
            }
            if (status == "unlock")
            {
                studentInfo = studentInfo.Where(a => a.Active == false).ToList();
            }

            infoReportView.studentInfoReportViews = studentInfo;
            return View(infoReportView);
        }

        public IActionResult StudentInfoDetails(int id)
        {
            StudentInfoReportcs studentInfo = new StudentInfoReportcs();
            List<StudentInfoHistory> infoHistory = new List<StudentInfoHistory>();

            studentInfo = (from stu in _context.TblStudentAccount
                           join det in _context.TblStudentInfo
                           on stu.Id equals det.AccountId
                           where det.Active == true && stu.Id == id
                           select new StudentInfoReportcs
                           {
                               Id = stu.Id,
                               Name = stu.Name,
                               Email = stu.Email,
                               AccountId = stu.AccountId,
                               Address = det.Address,
                               DegreeProgram = det.DegreeProgram,
                               Gender = det.Gender,
                               Phone = det.Phone
                           }).FirstOrDefault();

            infoHistory = (from det in _context.TblStudentInfo
                           join ac in _context.TblAcademicYear
                           on det.AcademicYearId equals ac.Id
                           join y in _context.TblYearLevel
                           on det.YearLevelId equals y.Id
                           join sec in _context.TblSection
                           on det.SectionId equals sec.Id
                           where det.AccountId == id && det.Active == false
                           select new StudentInfoHistory
                           {
                               AcademicYearName = ac.Name,
                               YearLevelName = y.Name,
                               MajorName = sec.Name
                           }).ToList();

            if (infoHistory != null)
            {
                studentInfo.InfoHistories = infoHistory;
            }
           

            return View(studentInfo);
        }

        [HttpPost]
        public IActionResult Search(StudentInfoReportView scl)
        {
            TempData["status"] = scl.Status;
            return RedirectToAction("StudentInfo");
        }

        public IActionResult SearchCourse(StudentCourseSearch scl)
        {
            TempData["academicyear"] = scl.AcademicYearId;
            TempData["yearlevel"] = scl.YearLevelId;
            TempData["register"] = scl.RegistrationId;
            TempData["courseselect"] = scl.CourseSelectId;
            return RedirectToAction("StudentCourseInfo");
        }

        public IActionResult StudentCourseInfo()
        {
            StudentCourseSearch studentCourse = new StudentCourseSearch();
            List<StudentCourseInfo> studentCourseInfos = new List<StudentCourseInfo>();

            studentCourse.AcademicYearId = (TempData["academicyear"] == null ? 0 : Convert.ToInt32(TempData["academicyear"]));
            studentCourse.YearLevelId = (TempData["yearlevel"] == null ? 0 : Convert.ToInt32(TempData["yearlevel"]));
            studentCourse.RegistrationId = (TempData["register"] == null ? 0 : Convert.ToInt32(TempData["register"]));
            studentCourse.CourseSelectId = (TempData["courseselect"] == null ? 0 : Convert.ToInt32(TempData["courseselect"]));

            var academicYearId = (TempData["academicyear"] == null ? 0 : Convert.ToInt32(TempData["academicyear"]));
            var yearLevelId = (TempData["yearlevel"] == null ? 0 : Convert.ToInt32(TempData["yearlevel"]));
            var registrationId = (TempData["register"] == null ? 0 : Convert.ToInt32(TempData["register"]));
            var courseSelectId = (TempData["courseselect"] == null ? 0 : Convert.ToInt32(TempData["courseselect"]));

            // string str = "Select s.Name As Name,s.AccountId As AccountId,s.Email AS Email,sf.IsRegister AS IsRegister,sf.IsCourseSelect AS IsCourseSelect,sf.Description AS Description ";
            //        str += "From tbl_StudentAccount As s Inner Join tbl_StudentInfo As sf On s.Id = sf.AccountId ";
            //if (academicYearId != 0)
            //{
            //    str += "Where sf.AcademicYearId =" + academicYearId;
            //}
            //if (yearLevelId != 0)
            //{
            //    str += " And sf.YearLevelId =" + yearLevelId;
            //}

            academicYearId = academicYearId == 0 ? _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id : academicYearId;
            studentCourse.AcademicYearId = academicYearId;

           studentCourseInfos = (from st in _context.TblStudentAccount
                                  join sf in _context.TblStudentInfo
                                  on st.Id equals sf.AccountId
                                  join y in _context.TblYearLevel
                                  on sf.YearLevelId equals y.Id
                                  where sf.AcademicYearId == academicYearId && st.Active == true
                                  select new StudentCourseInfo
                                  {
                                      Name = st.Name,
                                      AccountId = st.AccountId,
                                      Email = st.Email,
                                      Description = sf.Description,
                                      IsCourseSelect = sf.IsCourseSelect,
                                      IsRegister = sf.IsRegister,
                                      YearLevelId = (int)sf.YearLevelId,
                                      YearLevelName = y.Name
                                  }).ToList();

            if (yearLevelId != 0)
            {
                studentCourseInfos = studentCourseInfos.Where(a => a.YearLevelId == yearLevelId).ToList();
            }
            if (registrationId != 0)
            {
                var temp_r = registrationId == 1 ? true : false;
                studentCourseInfos = studentCourseInfos.Where(a => a.IsRegister == temp_r).ToList();
            }
            if (courseSelectId != 0)
            {
                var temp_c = courseSelectId == 1 ? true : false;
                studentCourseInfos = studentCourseInfos.Where(a => a.IsCourseSelect == temp_c).ToList();
            }

             studentCourse.StudentCourseInfos = studentCourseInfos;

            return View(studentCourse);
        }
    }
}
