using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentInfoContext _context;
        const string SessionId = "_Id";

        public StudentController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: Student / Registration
        public IActionResult Registration()
        {
            var accid = HttpContext.Session.GetInt32(SessionId);

            var getcurrentid = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;

            var isRegistered = _context.TblStudentInfo.Any(a => a.AccountId == accid && a.IsRegister == true && a.AcademicYearId == getcurrentid);

            if (isRegistered)
            {
                TempData["alert"] = "You have already registered!";
                return RedirectToAction("AlertPage","Course");
            }

            return View();
        }

        // POST: Student / SaveRegistration
        public IActionResult SaveRegistration(StudentInfo studentInfo)
        {
            TblStudentAccount tblStudentAccount = _context.TblStudentAccount.Where(a=>a.AccountId == studentInfo.AccountId).FirstOrDefault();

            tblStudentAccount.Name = studentInfo.Name;
            tblStudentAccount.Email = studentInfo.Email;
            tblStudentAccount.AccountId = studentInfo.AccountId;
            _context.SaveChanges();

            TblStudentInfo tblStudentInfo = _context.TblStudentInfo.Where(a => a.AccountId == tblStudentAccount.Id && a.Active == true).FirstOrDefault();

            tblStudentInfo.Phone = studentInfo.Phone;
            tblStudentInfo.AcademicYearId = studentInfo.AcademicYearId;
            tblStudentInfo.SectionId = studentInfo.SectionId;
            tblStudentInfo.Gender = studentInfo.Gender;
            tblStudentInfo.Address = studentInfo.Address;
            tblStudentInfo.Active = true;
            tblStudentInfo.YearLevelId = studentInfo.YearLevelId;
            tblStudentInfo.SemesterId = studentInfo.SemesterId;
            tblStudentInfo.AccountId = tblStudentAccount.Id;
            tblStudentInfo.DegreeProgram = studentInfo.DegreeProgram;
            tblStudentInfo.IsRegister = true;
           
            _context.SaveChanges();

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAccount(StudentInfoReportcs infoReportcs)
        {
            TblStudentAccount studentAccount = new TblStudentAccount()
            {
                Name = infoReportcs.Name,
                Password = infoReportcs.Password,
                AccountId = infoReportcs.AccountId,
                Active = true,
                CreatedDate = DateTime.Now,
                Description = infoReportcs.Description
            };

            _context.TblStudentAccount.Add(studentAccount);
            _context.SaveChanges();

            var getcurrentSemester = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;
            var getcurrentAcademic = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;

            TblStudentInfo tblStudentInfo = new TblStudentInfo()
            {
                
                AcademicYearId = getcurrentAcademic,
                Active = true,
                YearLevelId = 1,
                SemesterId = getcurrentSemester,
                AccountId = studentAccount.Id,
                IsRegister = false,
                IsCourseSelect = false,
                IsSecondSelect = false,
            };
            _context.TblStudentInfo.Add(tblStudentInfo);
            _context.SaveChanges();

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        public IActionResult TimeLimit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveTimeLimit(TblTimeLimit timeLimit)
        {
            TblTimeLimit tblTimeLimit = new TblTimeLimit()
            {
                AcademicYearId = timeLimit.AcademicYearId,
                SemesterId = timeLimit.SemesterId,
                StartDate = timeLimit.StartDate,
                EndDate = timeLimit.EndDate,
                Description = timeLimit.Description,
                Active = true,
                Type = timeLimit.Type,
                CreatedDate = DateTime.Now,
            };
            _context.TblTimeLimit.Add(tblTimeLimit);
            _context.SaveChanges();

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        public ActionResult TimeLimitIndex()
        {
            List<TimeLimitInfo> timeLimitInfos = new List<TimeLimitInfo>();
            timeLimitInfos = (from t in _context.TblTimeLimit
                              join y in _context.TblAcademicYear
                              on t.AcademicYearId equals y.Id
                              join s in _context.TblSemester
                              on t.SemesterId equals s.Id
                              select new TimeLimitInfo
                              {
                                  AcademicYear = y.Name,
                                  Semester = s.Name,
                                  StartDate = t.StartDate.Value.ToString("dd-MM-yyyy"),
                                  EndDate = t.EndDate.Value.ToString("dd-MM-yyyy"),
                                  Type = t.Type,
                                  Id = t.Id
                              }).ToList();
            return View(timeLimitInfos);
        }

        public IActionResult EditTimeLimit(int id)
        {
            var result = _context.TblTimeLimit.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public ActionResult SaveTimeLimitEdit(TblTimeLimit timeLimit)
        {

            TblTimeLimit tblTimeLimit = _context.TblTimeLimit.Find(timeLimit.Id);

            tblTimeLimit.AcademicYearId = timeLimit.AcademicYearId;
            tblTimeLimit.SemesterId = timeLimit.SemesterId;
            tblTimeLimit.StartDate = timeLimit.StartDate;
            tblTimeLimit.EndDate = timeLimit.EndDate;
            tblTimeLimit.Description = timeLimit.Description;
            tblTimeLimit.Active = timeLimit.Active;
            tblTimeLimit.Type = timeLimit.Type;
            tblTimeLimit.CreatedDate = DateTime.Now;

            _context.SaveChanges();

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult SaveChangePassword(ChangePassword changePassword)
        {
            var accid = HttpContext.Session.GetInt32(SessionId);

            var result = _context.TblStudentAccount.Find(accid);

            if (result.Password == changePassword.OldPassword)
            {
                result.Password = changePassword.NewPassword;
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }
            return Json(new { status = "fail", message = "Old password don't match!" });
        }
    }
}
