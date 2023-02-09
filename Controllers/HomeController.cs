using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRegistrationSys.Models;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;

namespace StudentRegistrationSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentInfoContext _context;

        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";
        const string SessionAccount = "_Account";
        const string SessionId = "_Id";

        public HomeController(ILogger<HomeController> logger,StudentInfoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.acc = HttpContext.Session.GetInt32(SessionAccount);
            ViewBag.accid = HttpContext.Session.GetInt32(SessionId);

            var currentAcademicId = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;
            var currentSemesterId = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;

            var firstyearcount = _context.TblStudentInfo.Where(a => a.Active == true && a.AcademicYearId == currentAcademicId &&
                                a.YearLevelId == 1).Count();

            var secondyearcount = _context.TblStudentInfo.Where(a => a.Active == true && a.AcademicYearId == currentAcademicId &&
                                a.YearLevelId == 2).Count();

            var thirdyearcount = _context.TblStudentInfo.Where(a => a.Active == true && a.AcademicYearId == currentAcademicId &&
                                a.YearLevelId == 3).Count();

            var fourthyearcount = _context.TblStudentInfo.Where(a => a.Active == true && a.AcademicYearId == currentAcademicId &&
                                a.YearLevelId == 4).Count();

            var finalyearcount = _context.TblStudentInfo.Where(a => a.Active == true && a.AcademicYearId == currentAcademicId &&
                                a.YearLevelId == 5).Count();

            int[] student = new int[5];
            student[0] = firstyearcount;
            student[1] = secondyearcount;
            student[2] = thirdyearcount;
            student[3] = fourthyearcount;
            student[4] = finalyearcount;

            ViewBag.pieData = student;

            var tempAcademicId = currentSemesterId == 1 ? currentAcademicId - 1 : currentAcademicId;
            var tempSemesterId = currentSemesterId == 1 ? 2 : 1;

            var faillist = (from r in _context.TblResult
                            join rd in _context.TblResultDetails
                            on r.Id equals rd.ResultId
                            where r.AcademicYearId == tempAcademicId && r.SemesterId == tempSemesterId && (rd.Grade == "D" || rd.Grade == "E")
                            select new
                            {
                                Id = r.Id,
                                YearId = r.YearLevelId,
                                DetailsId = rd.Id,
                                Grade = rd.Grade
                            }
                           ).ToList();

            var passlist = (from r in _context.TblResult
                            join rd in _context.TblResultDetails
                            on r.Id equals rd.ResultId
                            where r.AcademicYearId == tempAcademicId && r.SemesterId == tempSemesterId && (rd.Grade == "A" || rd.Grade == "B" || rd.Grade == "C")
                            select new
                            {
                                Id = r.Id,
                                YearId = r.YearLevelId,
                                DetailsId = rd.Id,
                                Grade = rd.Grade
                            }
                           ).ToList();

            return View();
        }

        public IActionResult StudentIndex()
        {
            var name = HttpContext.Session.GetString(SessionName);
            var acc = HttpContext.Session.GetInt32(SessionAccount);
            var accid = HttpContext.Session.GetInt32(SessionId);
            var tempacid = 0;
            var tempsemid = 0;
            var tempyearid = 0;

            var getcurrentAcademicid = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;
            var getcurrentSemesterid = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;
            var getcurrentSectionid = _context.TblStudentInfo.Where(a => a.Active == true && a.AccountId == accid).FirstOrDefault().SectionId;

            tempacid = getcurrentSemesterid == 1 ? getcurrentAcademicid - 1 : getcurrentAcademicid;
            tempsemid = getcurrentSemesterid == 1 ? 2 : 1 ;

            StudentDashboardInfo studentDashboardInfo = new StudentDashboardInfo();
            List<CourseDashboard> courseDashboards = new List<CourseDashboard>();
            ProfileDashboard profileDashboard = new ProfileDashboard();
            List<ResultDashboard> resultDashboard = new List<ResultDashboard>();

            profileDashboard = (from stu in _context.TblStudentAccount
                                join std in _context.TblStudentInfo
                                on stu.Id equals std.AccountId
                                join y in _context.TblYearLevel
                                on std.YearLevelId equals y.Id
                                where std.Active == true && stu.Id == accid
                                select new ProfileDashboard
                                {
                                    Name = stu.Name,
                                    AccountId = stu.AccountId,
                                    YearLevelName = y.Name,
                                    YearLevelId = y.Id,
                                    Email = stu.Email,
                                    Phone = std.Phone,
                                    Address = std.Address
                                }).FirstOrDefault();

            studentDashboardInfo.ProfileDashboards = profileDashboard;

            tempyearid = getcurrentSemesterid == 1 ? profileDashboard.YearLevelId - 1 : profileDashboard.YearLevelId;

            courseDashboards = (from sbc in _context.TblSubjectCourse
                                join c in _context.TblCourse
                                on sbc.CourseId equals c.Id
                                where sbc.StudentId == accid && sbc.AcademicYearId == getcurrentAcademicid && sbc.SemesterId == getcurrentSemesterid &&
                                sbc.YearLevelId == profileDashboard.YearLevelId
                                select new CourseDashboard
                                {
                                    CourseName = c.Name
                                }).ToList();

            studentDashboardInfo.CourseDashboards = courseDashboards;

            resultDashboard = (from rm in _context.TblResult
                                join rd in _context.TblResultDetails
                                on rm.Id equals rd.ResultId
                                join c in _context.TblCourse
                                on rd.CourseId equals c.Id
                                where rm.StudentId == accid && rm.AcademicYearId == tempacid && rm.SemesterId == tempsemid &&
                                rm.YearLevelId == tempyearid
                                select new ResultDashboard
                                {
                                    CourseName = c.Name,
                                    Grade = rd.Grade
                                }).ToList();

            studentDashboardInfo.ResultDashboards = resultDashboard;

            List<TimeTableInfocsDetails> timeTableInfocsDetails = new List<TimeTableInfocsDetails>();

            var result = (from time in _context.TblTimeTable
                          where time.SemesterId == tempsemid
                          && time.YearLevelId == tempyearid && time.SectionId == getcurrentSectionid
                          select new
                          {
                              Id = time.Id
                          }).FirstOrDefault();

            if(result != null)
            {
                timeTableInfocsDetails = (from td in _context.TblTimeTableDetails
                                          join c in _context.TblCourse
                                          on td.CourseId equals c.Id
                                          where td.TimeTableId == result.Id
                                          orderby td.Id
                                          select new TimeTableInfocsDetails
                                          {
                                              CourseId = (int)td.CourseId,
                                              PeriodId = td.PeriodId,
                                              CourseCode = c.Code,
                                              Day = td.Day,
                                              Id = td.Id,
                                              CourseName = c.Name
                                          }).ToList();
            }
            studentDashboardInfo.TimeTableInfocsDetails = timeTableInfocsDetails;

            return View(studentDashboardInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
