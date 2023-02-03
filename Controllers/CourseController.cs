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
    public class CourseController : Controller
    {
        private readonly StudentInfoContext _context;
        public CourseController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var result = (from c in _context.TblCourse
                          join ac in _context.TblAcademicYear
                          on c.AcademicYearId equals ac.Id
                          join s in _context.TblSemester
                          on c.SemesterId equals s.Id
                          join y in _context.TblYearLevel
                          on c.YearLevelId equals y.Id
                          where c.Active == true
                          select new Course_info
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Code = c.Code,
                              AcademicYearName = ac.Name,
                              SemesterName = s.Name,
                              YearLevelName = y.Name,
                              Description=c.Description
                          });

            return View(result);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        public ActionResult SaveCourse(TblCourse course)
        {
            var isCodeExist = _context.TblCourse.Any(a => a.AcademicYearId == course.AcademicYearId &&
            a.SemesterId == course.SemesterId && a.Active == true && a.Code == course.Code && a.YearLevelId == course.YearLevelId);

            if (isCodeExist)
            {
                return Json(new { status = "fail", message = "Code name already exist" });
            }

            var isExist = _context.TblCourse.Any(a => a.Active == true && a.AcademicYearId == course.AcademicYearId &&
            a.SemesterId == course.SemesterId && a.YearLevelId == course.YearLevelId && a.Name == course.Name);

            if (!isExist) {
                TblCourse tblCourse = new TblCourse()
                {
                    YearLevelId = course.YearLevelId,
                    AcademicYearId = course.AcademicYearId,
                    Name = course.Name,
                    Description = course.Description,
                    Active = course.Active,
                    SemesterId = course.SemesterId,
                    Code = course.Code,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    MajorCode = course.MajorCode
                };
                _context.TblCourse.Add(tblCourse);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Course name already exist" });
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = (from c in _context.TblCourse
                          where c.Active == true && c.Id == id
                          select c).FirstOrDefault();

            return View(result);
        }

        // POST: CourseController/Edit/5
        public ActionResult EditCourse(TblCourse course)
        {
            var isCodeExist = _context.TblCourse.Any(a => a.AcademicYearId == course.AcademicYearId &&
              a.SemesterId == course.SemesterId && a.Active == true && a.Code == course.Code && a.YearLevelId == course.YearLevelId);

            if (isCodeExist)
            {
                return Json(new { status = "fail", message = "Code name already exist" });
            }

            var isExist = _context.TblCourse.Any(a => a.Active == true && a.AcademicYearId == course.AcademicYearId &&
          a.SemesterId == course.SemesterId && a.YearLevelId == course.YearLevelId && a.Name == course.Name);

            if (!isExist)
            {
                TblCourse tblCourse = _context.TblCourse.Find(course.Id);

                tblCourse.YearLevelId = course.YearLevelId;
                tblCourse.AcademicYearId = course.AcademicYearId;
                tblCourse.Name = course.Name;
                tblCourse.Description = course.Description;
                tblCourse.Active = course.Active;
                tblCourse.SemesterId = course.SemesterId;
                tblCourse.Code = course.Code;
                tblCourse.UpdatedDate = DateTime.Now;
                tblCourse.MajorCode = course.MajorCode;
                
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Course name already exist" });
        }

        public ActionResult CourseSelection()
        {
            return View();
        }
    }
}
