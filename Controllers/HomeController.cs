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
