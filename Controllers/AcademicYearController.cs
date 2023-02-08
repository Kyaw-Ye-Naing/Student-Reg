using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSys.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class AcademicYearController : Controller
    {
        private readonly StudentInfoContext _context;
        public AcademicYearController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: AcademicYearController
        public ActionResult Index()
        {
            var result = _context.TblAcademicYear.ToList();
            return View(result);
        }

        // GET: AcademicYearController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYearController/Create
        public ActionResult SaveAcademicYear(TblAcademicYear academicYear)
        {
            try
            {
                TblAcademicYear tblAcademicYear = new TblAcademicYear
                {
                    Name = academicYear.Name,
                    Description = academicYear.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Active = true
                };
                _context.TblAcademicYear.Add(tblAcademicYear);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }
            catch
            {
                return View();
            }
        }

        // GET: AcademicYearController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.TblAcademicYear.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        // POST: AcademicYearController/Edit/5
        public ActionResult EditAcademicYear(TblAcademicYear academicYear)
        {
            try
            {
                if (academicYear.Active == true)
                {
                    _context.Database.ExecuteSqlInterpolated($"Update tbl_AcademicYear Set Active = 0;");
                }

                TblAcademicYear tblAcademic = _context.TblAcademicYear.Find(academicYear.Id);

                tblAcademic.Name = academicYear.Name;
                tblAcademic.Description = academicYear.Description;
                tblAcademic.UpdatedDate = DateTime.Now;
                tblAcademic.Active = academicYear.Active;

                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }
            catch
            {
                return View();
            }
        }

    }
}
