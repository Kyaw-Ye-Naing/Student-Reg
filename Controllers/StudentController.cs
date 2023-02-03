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
        public StudentController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: Student / Registration
        public IActionResult Registration()
        {
            return View();
        }

        // POST: Student / SaveRegistration
        public IActionResult SaveRegistration(StudentInfo studentInfo)
        {
            TblStudentAccount tblStudentAccount = _context.TblStudentAccount.Find(studentInfo.Id);

            tblStudentAccount.Name = studentInfo.Name;
            tblStudentAccount.Email = studentInfo.Email;
            tblStudentAccount.AccountId = studentInfo.AccountId;
            _context.SaveChanges();

            TblStudentInfo tblStudentInfo = new TblStudentInfo()
            {
                Phone = studentInfo.Phone,
                AcademicYearId = studentInfo.AcademicYearId,
                SectionId = studentInfo.SectionId,
                Gender = studentInfo.Gender,
                Address = studentInfo.Address,
                Active = true,
                DegreeProgram = studentInfo.DegreeProgram
            };
            _context.TblStudentInfo.Add(tblStudentInfo);
            _context.SaveChanges();

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        public IActionResult CourseSelection()
        {
            return View();
        }

        public IActionResult SaveCourseSelection()
        {
            return View();
        }

        public IActionResult StudentResult()
        {
            return View();
        }

        public IActionResult StudentInfo()
        {
            return View();
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

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }
    }
}
