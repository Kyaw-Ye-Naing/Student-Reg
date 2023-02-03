using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class YearLevelController : Controller
    {
        private readonly StudentInfoContext _context;
        public YearLevelController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: YearLevelController
        public ActionResult Index()
        {
            var result = _context.TblYearLevel.Where(a => a.Active == true).ToList();
            return View(result);
        }

        // GET: YearLevelController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SaveYearLevel(TblYearLevel yearLevel)
        {
            var isExist = _context.TblYearLevel.Any(a => a.Active == true && a.Name == yearLevel.Name);

            if (!isExist)
            {
                TblYearLevel tblYearLevel = new TblYearLevel
                {
                    Name = yearLevel.Name,
                    Description = yearLevel.Description,
                    CreatedDate = DateTime.Now,
                    UpdateDate = null,
                    Active = true
                };
                _context.TblYearLevel.Add(tblYearLevel);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Year name is already exist" });
        }

        // GET: YearLevelController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.TblYearLevel.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        // POST: YearLevelController/Edit/5
        public ActionResult EditYearLevel(TblYearLevel yearLevel)
        {
            var isExist = _context.TblYearLevel.Any(a => a.Active == true && a.Name == yearLevel.Name);

            if (!isExist)
            {
                TblYearLevel tblYearLevel = _context.TblYearLevel.Find(yearLevel.Id);

                tblYearLevel.Name = yearLevel.Name;
                tblYearLevel.Description = yearLevel.Description;
                tblYearLevel.UpdateDate = DateTime.Now;
                tblYearLevel.Active = yearLevel.Active;

                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Year name is already exist" });
        }
    }
}
