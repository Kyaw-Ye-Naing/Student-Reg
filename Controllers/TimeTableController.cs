using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly StudentInfoContext _context;
        public TimeTableController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: TimeTable
        public IActionResult Index()
        {
            var result = (from time in _context.TblTimeTable
                          join ac in _context.TblAcademicYear
                          on time.AcademicYearId equals ac.Id
                          join y in _context.TblYearLevel
                          on time.YearLevelId equals y.Id
                          join s in _context.TblSemester
                          on time.SemesterId equals s.Id
                          join sec in _context.TblSection
                          on time.SectionId equals sec.Id
                          select new TimeTableInfocs
                          {
                              Id = time.Id,
                              SectionId = time.SectionId,
                              SectionName = sec.Name,
                              YearLevelId = time.YearLevelId,
                              YearLevelName = y.Name,
                              AcademicYearId = time.AcademicYearId,
                              AcademicYearName = ac.Name,
                              SemesterId = time.SemesterId,
                              SemesterName = s.Name
                          });

            return View(result);
        }

        // GET: TimeTable / Details
        public IActionResult Details(int id)
        {
            List<TimeTableInfocsDetails> timeTableInfocsDetails = new List<TimeTableInfocsDetails>();

            TimeTableInfocs result = (from time in _context.TblTimeTable
                                      join ac in _context.TblAcademicYear
                                      on time.AcademicYearId equals ac.Id
                                      join y in _context.TblYearLevel
                                      on time.YearLevelId equals y.Id
                                      join s in _context.TblSemester
                                      on time.SemesterId equals s.Id
                                      join sec in _context.TblSection
                                      on time.SectionId equals sec.Id
                                      where time.Id == id
                                      select new TimeTableInfocs
                                      {
                                          Id = time.Id,
                                          SectionId = time.SectionId,
                                          SectionName = sec.Name,
                                          YearLevelId = time.YearLevelId,
                                          YearLevelName = y.Name,
                                          AcademicYearId = time.AcademicYearId,
                                          AcademicYearName = ac.Name,
                                          SemesterId = time.SemesterId,
                                          SemesterName = s.Name
                                      }).FirstOrDefault();

            timeTableInfocsDetails = (from td in _context.TblTimeTableDetails
                                      join c in _context.TblCourse
                                      on td.CourseId equals c.Id
                                      where td.TimeTableId == result.Id
                                      orderby td.Id
                                      select new TimeTableInfocsDetails
                                      {
                                          CourseId = (int)td.CourseId,
                                          PeriodId = td.PeriodId,
                                          CourseCode = c.Code,
                                          Day = td.Day,
                                          Id = td.Id,
                                          CourseName = c.Name
                                      }).ToList();

            result.TableInfocsDetails = timeTableInfocsDetails;

            return View(result);
        }

        // GET: TimeTable / Edit
        public IActionResult Edit(int id)
        {
            List<TimeTableInfocsDetails> timeTableInfocsDetails = new List<TimeTableInfocsDetails>();

            TimeTableInfocs result = (from time in _context.TblTimeTable
                                      join ac in _context.TblAcademicYear
                                      on time.AcademicYearId equals ac.Id
                                      join y in _context.TblYearLevel
                                      on time.YearLevelId equals y.Id
                                      join s in _context.TblSemester
                                      on time.SemesterId equals s.Id
                                      join sec in _context.TblSection
                                      on time.SectionId equals sec.Id
                                      where time.Id == id
                                      select new TimeTableInfocs
                                      {
                                          Id = time.Id,
                                          SectionId = time.SectionId,
                                          SectionName = sec.Name,
                                          YearLevelId = time.YearLevelId,
                                          YearLevelName = y.Name,
                                          AcademicYearId = time.AcademicYearId,
                                          AcademicYearName = ac.Name,
                                          SemesterId = time.SemesterId,
                                          SemesterName = s.Name
                                      }).FirstOrDefault();

            timeTableInfocsDetails = (from td in _context.TblTimeTableDetails
                                      join c in _context.TblCourse
                                      on td.CourseId equals c.Id
                                      where td.TimeTableId == result.Id
                                      select new TimeTableInfocsDetails
                                      {
                                          CourseId = (int)td.CourseId,
                                          PeriodId = td.PeriodId,
                                          Day = td.Day,
                                          Id = td.Id,
                                          CourseName = c.Name
                                      }).ToList();

            result.TableInfocsDetails = timeTableInfocsDetails;

            return View(result);
        }

        // GET: TimeTable / Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeTable / Create
        public IActionResult SaveTimeTable(TimeTableInfocs timeTableInfocs)
        {
            TblTimeTable tblTimeTable = new TblTimeTable()
            {
                SectionId = timeTableInfocs.SectionId,
                SemesterId = timeTableInfocs.SemesterId,
                AcademicYearId = timeTableInfocs.AcademicYearId,
                YearLevelId = timeTableInfocs.YearLevelId,
                Active = true,
                CreatedDate = DateTime.Now
            };

            _context.TblTimeTable.Add(tblTimeTable);
            _context.SaveChanges();

            var masterId = tblTimeTable.Id;

            foreach (var item in timeTableInfocs.TableInfocsDetails)
            {
                TblTimeTableDetails tblTimeTableDetails = new TblTimeTableDetails()
                {
                    CourseId = item.CourseId,
                    PeriodId = item.PeriodId,
                    Day = item.Day,
                    CreatedDate = DateTime.Now,
                    TimeTableId = masterId
                };

                _context.TblTimeTableDetails.Add(tblTimeTableDetails);
                _context.SaveChanges();
            }

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        // POST: TimeTable / Create
        public IActionResult EditTimeTable(TimeTableInfocs timeTableInfocs)
        {
            TblTimeTable tblTimeTable = _context.TblTimeTable.Find(timeTableInfocs.Id);

            tblTimeTable.SectionId = timeTableInfocs.SectionId;
            tblTimeTable.SemesterId = timeTableInfocs.SemesterId;
            tblTimeTable.AcademicYearId = timeTableInfocs.AcademicYearId;
            tblTimeTable.YearLevelId = timeTableInfocs.YearLevelId;
            tblTimeTable.Active = timeTableInfocs.Active;
            tblTimeTable.UpdatedDate = DateTime.Now;          

            _context.SaveChanges();

            var masterId = timeTableInfocs.Id;

            foreach (var item in timeTableInfocs.TableInfocsDetails)
            {
                TblTimeTableDetails tblTimeTableDetails = _context.TblTimeTableDetails.Find(item.Id);

                tblTimeTableDetails.CourseId = item.CourseId;
                tblTimeTableDetails.PeriodId = item.PeriodId;
                tblTimeTableDetails.Day = item.Day;
                tblTimeTableDetails.UpdatedDate = DateTime.Now;
                tblTimeTableDetails.TimeTableId = masterId;
                
                _context.SaveChanges();
            }

            return Json(new { status = "success", message = "Data Saving Successfully" });
        }
    }
}
