using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class SectionController : Controller
    {
        private readonly StudentInfoContext _context;
        public SectionController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: SectionController
        public ActionResult Index()
        {
            var result = _context.TblSection.Where(a => a.Active == true).ToList();
            return View(result);
        }

        // GET: SectionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionController/Create
        public ActionResult SaveSection(TblSection section)
        {
            var isExist = _context.TblSection.Any(a => a.Active == true && a.Name == section.Name);

            if (!isExist) {
                TblSection tblYearLevel = new TblSection
                {
                    Name = section.Name,
                    Description = section.Description,
                    CreatedDate = DateTime.Now,
                    UpdateDate = null,
                    Active = true
                };
                _context.TblSection.Add(section);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Section name already exists" });
        }

        // GET: SectionController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.TblSection.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        // POST: SectionController/Edit/5
        public ActionResult EditSection(TblSection section)
        {
            var isExist = _context.TblSection.Any(a => a.Active == true && a.Name == section.Name);

            if (!isExist) {
                TblSection tblSection = _context.TblSection.Find(section.Id);

                tblSection.Name = section.Name;
                tblSection.Description = section.Description;
                tblSection.UpdateDate = DateTime.Now;
                tblSection.Active = section.Active;

                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Section name already exists" });
        }
    }
}
