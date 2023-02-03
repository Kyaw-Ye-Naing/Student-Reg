using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;

namespace StudentRegistrationSys.Controllers
{
    public class SemesterController : Controller
    {
        private readonly StudentInfoContext _context;
        public SemesterController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: Semester
        public ActionResult Index()
        {
            var result = _context.TblSemester.Where(a=>a.Active == true).ToList();
            return View(result);
        }

        // GET: Semester/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester/Create
        public ActionResult SaveSemester(TblSemester semester)
        {
            var isExist = _context.TblSemester.Any(a => a.Active == true && a.Name == semester.Name);

            if (!isExist) {
                TblSemester tblSemester = new TblSemester
                {
                    Name = semester.Name,
                    Description = semester.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Active = true
                };
                _context.TblSemester.Add(tblSemester);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Semester name already exist" });
        }

        // GET: Semester/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.TblSemester.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        // POST: Semester/Edit/5
        public ActionResult EditSemester(TblSemester semester)
        {
                var isExist = _context.TblSemester.Any(a => a.Active == true && a.Name == semester.Name);

                if (!isExist) {
                    TblSemester tblSemester = _context.TblSemester.Find(semester.Id);

                    tblSemester.Name = semester.Name;
                    tblSemester.Description = semester.Description;
                    tblSemester.UpdatedDate = DateTime.Now;
                    tblSemester.Active = semester.Active;

                    _context.SaveChanges();

                    return Json(new { status = "success", message = "Data Saving Successfully" });
                }

                return Json(new { status = "fail", message = "Semester name already exist" });
        }
    }
}