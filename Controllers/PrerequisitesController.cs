using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class PrerequisitesController : Controller
    {
        private readonly StudentInfoContext _context;
        public PrerequisitesController(StudentInfoContext context)
        {
            _context = context;
        }

        // Get : Prerequisites
        public IActionResult Index()
        {
            List<Prerequisities> prerequisities = new List<Prerequisities>();
            var courseLists = _context.TblCourse.ToList();

            var result = _context.TblPrerequisities.Where(a => a.Active == true).ToList();

            foreach (var item in result)
            {
                var newcoruse = courseLists.Where(a => a.Id == item.NewCourseId).First().Name;
                var passcoruse = courseLists.Where(a => a.Id == item.PassCourseId).First().Name;

                prerequisities.Add(new Prerequisities
                {
                    NewCourseId = (int)item.NewCourseId,
                    PassCourseId = (int)item.PassCourseId,
                    NewCourseName = newcoruse,
                    PassCourseName = passcoruse,
                    Id = item.Id
                });
            }

            return View(prerequisities);
        }

        // Get : Prerequisites
        public IActionResult Edit(int id)
        {
            var result = _context.TblPrerequisities.Where(a => a.Active == true && a.Id == id).FirstOrDefault();

            return View(result);
        }

        // POST : Prerequisites
        public IActionResult InsertPrerequisities(TblPrerequisities prerequisities)
        {
            var isExist = _context.TblPrerequisities.Any(a => a.NewCourseId == prerequisities.NewCourseId && a.PassCourseId == prerequisities.PassCourseId);

            if (!isExist)
            {
                TblPrerequisities tblPrerequisities = new TblPrerequisities()
                {
                    PassCourseId = prerequisities.PassCourseId,
                    NewCourseId = prerequisities.NewCourseId,
                    Active = true,
                    CreatedDate = DateTime.Now
                };
                _context.TblPrerequisities.Add(tblPrerequisities);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }
            return Json(new { status = "fail", message = "Data Already Exists" });
        }

        // Get : Prerequisites
        public IActionResult Create()
        {
            return View();
        }

        // POST : Prerequisites
        public IActionResult EditPrerequisities(TblPrerequisities prerequisities)
        {
            var isExist = _context.TblPrerequisities.Any(a => a.NewCourseId == prerequisities.NewCourseId && a.PassCourseId == prerequisities.PassCourseId);

            if (!isExist)
            {
                TblPrerequisities tblPrerequisities = _context.TblPrerequisities.Find(prerequisities.Id);

                tblPrerequisities.PassCourseId = prerequisities.PassCourseId;
                tblPrerequisities.NewCourseId = prerequisities.NewCourseId;
                tblPrerequisities.Active = true;
                tblPrerequisities.UpdatedDate = DateTime.Now;

                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }
            return Json(new { status = "fail", message = "Data Already Exists" });
        }
    }
}
