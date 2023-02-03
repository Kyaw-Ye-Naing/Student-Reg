using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class PeriodController : Controller
    {
        private readonly StudentInfoContext _context;
        public PeriodController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: PeriodController
        public ActionResult Index()
        {
            var result = _context.TblPeriod.Where(a=>a.Active == true).ToList();
            return View(result);
        }

        // GET: PeriodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodController/Create
        public ActionResult SavePeriod(TblPeriod period)
        {
            var isExist = _context.TblPeriod.Any(a => a.Active == true && a.PeriodName == period.PeriodName);

            if (!isExist) {
                TblPeriod tblPeriod = new TblPeriod
                {
                    PeriodName = period.PeriodName,
                    Description = period.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Active = true,
                    StartTime = period.StartTime,
                    EndTime = period.EndTime
                };
                _context.TblPeriod.Add(tblPeriod);
                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Period name already exist" });
        }

        // GET: PeriodController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _context.TblPeriod.Where(a => a.Id == id).FirstOrDefault();
            return View(result);
        }

        // POST: PeriodController/Edit/5
        public ActionResult EditPeriod(TblPeriod period)
        {
            var isExist = _context.TblPeriod.Any(a => a.Active == true && a.PeriodName == period.PeriodName);

            if (!isExist) {
                TblPeriod tblPeriod = _context.TblPeriod.Find(period.Id);

                tblPeriod.PeriodName = period.PeriodName;
                tblPeriod.Description = period.Description;
                tblPeriod.UpdatedDate = DateTime.Now;
                tblPeriod.Active = period.Active;
                tblPeriod.StartTime = period.StartTime;
                tblPeriod.EndTime = period.EndTime;

                _context.SaveChanges();

                return Json(new { status = "success", message = "Data Saving Successfully" });
            }

            return Json(new { status = "fail", message = "Period name already exist" });
        }

    }
}
