using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Controllers
{
    public class ResultController : Controller
    {
        private readonly StudentInfoContext _context;
        public ResultController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: Result
        public IActionResult Index()
        {
            var result = (from r in _context.TblResult
                          join ac in _context.TblAcademicYear
                          on r.AcademicYearId equals ac.Id
                          join y in _context.TblYearLevel
                          on r.YearLevelId equals y.Id
                          join s in _context.TblSemester
                          on r.SemesterId equals s.Id
                          join st in _context.TblStudentAccount
                          on r.StudentId equals st.Id
                          select new StudentResult
                          {
                              Id = r.Id,
                              AcademicYearId = r.AcademicYearId,
                              AcademicYearName = ac.Name,
                              YearLevelId = r.YearLevelId,
                              YearLevelName = y.Name,
                              SemesterId = r.SemesterId,
                              SemesterName = s.Name,
                              StudentId = r.StudentId,
                              StudentName = st.Name,
                              Status = r.Status
                          }).ToList();

            return View(result);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ExportView()
        {
            return View();
        }

        // POST: Semester/Create
        public ActionResult SaveResult(StudentResult result)
        {
            //var d_count = 0;
            TblResult tblResult = new TblResult
            {
                AcademicYearId = result.AcademicYearId,
                YearLevelId = result.YearLevelId,
                SemesterId = result.SemesterId,
                Status = result.Status,
                StudentId = result.StudentId,
                NextYearId = 0
            };
            _context.TblResult.Add(tblResult);
            _context.SaveChanges();

            foreach (var item in result.StudentResultDetails)
            {
                //if (item.Grade.ToLower() == "d")
                //{
                //    d_count += 1;
                //}
                TblResultDetails tblResultDetails = new TblResultDetails
                {
                    CourseId = item.CourseId,
                    Grade = item.Grade.ToUpper(),
                    ResultId = tblResult.Id
                };
                //tblResultDetails.d = result.SemesterId;

                _context.TblResultDetails.Add(tblResultDetails);
                _context.SaveChanges();
            }

            //--second semester
            if (result.SemesterId == 2)
            {
                TblStudentInfo inforesult = _context.TblStudentInfo.Where(a => a.Active == true && a.AccountId == result.StudentId).FirstOrDefault();
                inforesult.Active = false;
                _context.SaveChanges();

               // var acyearid = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;

                TblStudentInfo tblStudentInfo = new TblStudentInfo()
                {
                    AcademicYearId = result.AcademicYearId + 1,
                    Active = true,
                    AccountId = result.StudentId,
                    IsCourseSelect = false,
                    IsRegister =false,
                    IsSecondSelect =false,
                    YearLevelId = result.YearLevelId + 1
                };
                _context.TblStudentInfo.Add(tblStudentInfo);
                _context.SaveChanges();
            }

            return Json(new { status = "success", message = "Data Saving Successfully" });

        }

        // GET: Semester/Edit/5
        public ActionResult Edit(int id)
        {
            List<StudentResultDetails> resultDetails = new List<StudentResultDetails>();

            StudentResult studentResult = (from re in _context.TblResult
                            join ac in _context.TblAcademicYear
                            on re.AcademicYearId equals ac.Id
                            join y in _context.TblYearLevel
                            on re.YearLevelId equals y.Id
                            join st in _context.TblStudentAccount
                            on re.StudentId equals st.Id
                            join s in _context.TblSemester
                            on re.SemesterId equals s.Id
                            where re.StudentId == id
                            select new StudentResult
                            {
                                Id = re.Id,
                                Status = re.Status,
                                SemesterName = s.Name,
                                SemesterId = re.SemesterId,
                                YearLevelId = re.YearLevelId,
                                YearLevelName = y.Name,
                                AcademicYearId = re.AcademicYearId,
                                AcademicYearName = ac.Name,
                                StudentId = re.StudentId,
                                StudentName = st.Name
                            }).FirstOrDefault();

            var t_resultDetails = _context.TblResultDetails.Where(a => a.ResultId == studentResult.Id).ToList();

            foreach (var item in t_resultDetails)
            {
                var coursename = _context.TblCourse.Where(a => a.Id == item.CourseId).FirstOrDefault().Name;
                resultDetails.Add(new StudentResultDetails
                {
                    CourseId = item.CourseId,
                    CourseName = coursename,
                    Grade = item.Grade,
                    Description = "",
                    ResultDetailsId = item.Id
                });
            }

            studentResult.StudentResultDetails = resultDetails;

            return View(studentResult);
        }

        // GET: Semester/Edit/5
        public ActionResult GetCourseInfo(int id)
        {
            StudentResult studentResult = new StudentResult();
            List<StudentResultDetails> resultDetails = new List<StudentResultDetails>();

            var cursemesterId = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;
            var curacademicyearId = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;

            var result = _context.TblSubjectCourse.Where(a => a.StudentId == id && a.SemesterId == cursemesterId && 
                                    a.AcademicYearId == curacademicyearId).ToList();

            var courseList = _context.TblCourse.ToList();

            foreach (var item in result)
            {
                var coursename = courseList.Where(a => a.Id == item.CourseId).FirstOrDefault().Name;
                var coursecode = courseList.Where(a => a.Id == item.CourseId).FirstOrDefault().Code;
                resultDetails.Add(new StudentResultDetails
                {
                    CourseId = item.CourseId,
                    CourseCode = coursecode,
                    CourseName = coursename,
                    Grade = "",
                    Description = "",
                });
            }

            studentResult.StudentResultDetails = resultDetails;

            return Json(new { 
                rresult = resultDetails,
            });
        }

        // POST: Semester/Edit/5
        public ActionResult EditResult(StudentResult result)
        {
                TblResult tblResult = _context.TblResult.Find(result.Id);

                tblResult.AcademicYearId = result.AcademicYearId;
                tblResult.YearLevelId = result.YearLevelId;
                tblResult.SemesterId = result.SemesterId;
                tblResult.Status = result.Status;
                tblResult.StudentId = result.StudentId;
                tblResult.NextYearId = result.SemesterId == 1 ? 0 : result.YearLevelId + 1;

                _context.SaveChanges();

                foreach (var item in result.StudentResultDetails)
                {                 
                    TblResultDetails tblResultDetails = _context.TblResultDetails.Find(item.ResultDetailsId);

                    tblResultDetails.CourseId = item.CourseId;
                    tblResultDetails.Grade = item.Grade;
                    //tblResultDetails.d = result.SemesterId;

                    _context.SaveChanges();
                }

                //--second semester
                if (result.SemesterId == 2)
                {
                    var acyearid = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;

                    TblStudentInfo tblStudentInfo = _context.TblStudentInfo.Where(a => a.Active == true).FirstOrDefault();

                    tblStudentInfo.AcademicYearId = result.AcademicYearId + 1;
                    tblStudentInfo.Active = true;
                    tblStudentInfo.AccountId = result.StudentId;
                    tblStudentInfo.YearLevelId = result.YearLevelId + 1;
                    
                    _context.SaveChanges();
                }

                return Json(new { status = "success", message = "Data Saving Successfully" });
        }

        // GET: Semester/Edit/5
        public ActionResult Details(int id)
        {
            List<StudentResultDetails> resultDetails = new List<StudentResultDetails>();

            StudentResult studentResult = (from re in _context.TblResult
                                           join ac in _context.TblAcademicYear
                                           on re.AcademicYearId equals ac.Id
                                           join y in _context.TblYearLevel
                                           on re.YearLevelId equals y.Id
                                           join st in _context.TblStudentAccount
                                           on re.StudentId equals st.Id
                                           join s in _context.TblSemester
                                           on re.SemesterId equals s.Id
                                           where re.Id == id
                                           select new StudentResult
                                           {
                                               Id = re.Id,
                                               Status = re.Status,
                                               SemesterName = s.Name,
                                               SemesterId = re.SemesterId,
                                               YearLevelId = re.YearLevelId,
                                               YearLevelName = y.Name,
                                               AcademicYearId = re.AcademicYearId,
                                               AcademicYearName = ac.Name,
                                               StudentId = re.StudentId,
                                               StudentName = st.Name
                                           }).FirstOrDefault();

            var t_resultDetails = _context.TblResultDetails.Where(a => a.ResultId == studentResult.Id).ToList();

            foreach (var item in t_resultDetails)
            {
                var coursename = _context.TblCourse.Where(a => a.Id == item.CourseId).FirstOrDefault().Name;
                resultDetails.Add(new StudentResultDetails
                {
                    CourseId = item.CourseId,
                    CourseName = coursename,
                    Grade = item.Grade,
                    Description = "",
                    ResultDetailsId = item.Id
                });
            }

            studentResult.StudentResultDetails = resultDetails;

            return View(studentResult);
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            var stulists = _context.TblStudentAccount.ToList();
            var courselists = _context.TblCourse.ToList();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using(var package = new ExcelPackage(stream))
                {
                    var acyearid = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;
                    var semesterid = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2;row <= rowcount;row ++)
                    {
                        var sid = stulists.Where(a => a.AccountId == worksheet.Cells[row, 1].Value.ToString().Trim()).FirstOrDefault().Id;
                        TblResult tblResult = new TblResult()
                        {
                            AcademicYearId = acyearid,
                            SemesterId = semesterid,
                            YearLevelId = Convert.ToInt32(worksheet.Cells[row, 2].Value.ToString().Trim()),
                            StudentId = sid
                        };
                        _context.TblResult.Add(tblResult);
                        _context.SaveChanges();

                        for (int row1 = 3; row1 <= 13; row1+=2)
                        {
                            if (worksheet.Cells[row, row1].Value.ToString().Trim() == "-") 
                            {
                                
                            }
                            else
                            {
                                var cid = courselists.Where(a => a.Code == worksheet.Cells[row, row1].Value.ToString().Trim()).FirstOrDefault().Id;
                                TblResultDetails tblResultDetails = new TblResultDetails()
                                {
                                    ResultId = tblResult.Id,
                                    CourseId = cid,
                                    Grade = worksheet.Cells[row, row1+1].Value.ToString().Trim()
                                };
                                _context.TblResultDetails.Add(tblResultDetails);
                                _context.SaveChanges();
                            } 
                        }

                        if (semesterid == 2)//--second semester
                        {
                            TblStudentInfo inforesult = _context.TblStudentInfo.Where(a => a.Active == true && a.AccountId == sid).FirstOrDefault();
                            inforesult.Active = false;
                            _context.SaveChanges();

                            TblStudentInfo tblStudentInfo = new TblStudentInfo()
                            {
                                AcademicYearId = acyearid + 1,
                                Active = true,
                                YearLevelId = Convert.ToInt32(worksheet.Cells[row, 2].Value.ToString().Trim())+1,
                                SemesterId = 1,
                                AccountId = sid,
                                IsRegister = false,
                                IsCourseSelect = false,
                                IsSecondSelect = false
                            };
                            _context.TblStudentInfo.Add(tblStudentInfo);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
