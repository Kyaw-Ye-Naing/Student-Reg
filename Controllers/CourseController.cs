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
        const string SessionName = "_Name";
        const string SessionAccount = "_Account";
        const string SessionId = "_Id";
        public CourseController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            Course_Master course_Master = new Course_Master();
            List<Course_info> course_Infos = new List<Course_info>();

            course_Master.SemesterId = Convert.ToInt32((TempData["semester"] == null ? 0 : TempData["semester"]));
            var semesterid = Convert.ToInt32((TempData["semester"] == null ? 0 : TempData["semester"]));
            course_Master.YearLevelId = Convert.ToInt32((TempData["yearlevel"] == null ? 0 : TempData["yearlevel"]));
            var yearlevelid = Convert.ToInt32((TempData["yearlevel"] == null ? 0 : TempData["yearlevel"]));

            course_Infos = (from c in _context.TblCourse
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
                              SemesterId = s.Id,
                              YearLevelName = y.Name,
                              YearLevelId = y.Id,
                              Description = c.Description
                          }).ToList();

            if(semesterid != 0 && yearlevelid != 0)
            {
                course_Infos = course_Infos.Where(a => a.YearLevelId == yearlevelid && a.SemesterId == semesterid).ToList();
                course_Master.course_Infos = course_Infos;
            }
            if (semesterid != 0 && yearlevelid == 0)
            {
                course_Infos = course_Infos.Where(a => a.SemesterId == semesterid).ToList();
                course_Master.course_Infos = course_Infos;
            }
            if (semesterid == 0 && yearlevelid != 0)
            {
                course_Infos = course_Infos.Where(a => a.YearLevelId == yearlevelid).ToList();
                course_Master.course_Infos = course_Infos;
            }
           
            course_Master.course_Infos = course_Infos;
            
            return View(course_Master);
        }

        public ActionResult Search(Course_Master scl)
        {
            TempData["semester"] = scl.SemesterId;
            TempData["yearlevel"] = scl.YearLevelId;
            return RedirectToAction("Index");
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

            if (!isExist)
            {
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

        // GET: CourseController/Create
        public ActionResult AlertPage()
        {
            ViewBag.alert = TempData["alert"].ToString();
            return View();
        }
      
        public ActionResult CourseSelection()
        {
             CourseSelectionInfo courseSelectionInfo = new CourseSelectionInfo();
             List<CourseSelectionDetails> courseSelections_1 = new List<CourseSelectionDetails>();
             List<CourseSelectionDetails> courseSelections_2 = new List<CourseSelectionDetails>();
            var isRegistered = false;

            var accid = HttpContext.Session.GetInt32(SessionId);

            var getCurrentSemester = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault();
            var getCurrentAcademic = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault();

            if(getCurrentSemester.Id == 1)
            {
                var isExist = _context.TblStudentInfo.Any(a => a.AccountId == accid && a.IsRegister == false & a.AcademicYearId == getCurrentAcademic.Id);
                if (isExist)
                {
                    TempData["alert"] = "You have to register first!";
                    return RedirectToAction("AlertPage");
                }
            }

            var getsectionCode = (from stu in _context.TblStudentAccount
                                  join std in _context.TblStudentInfo
                                  on stu.Id equals std.AccountId
                                  join sec in _context.TblSection
                                  on std.SectionId equals sec.Id
                                  where stu.Id == accid && std.Active == true
                                  select new { 
                                     sec.Name
                                  }).FirstOrDefault();

            if (getCurrentSemester.Id == 1)
            {
                isRegistered = _context.TblStudentInfo.Any(a => a.AccountId == accid && a.IsCourseSelect == true & a.AcademicYearId == getCurrentAcademic.Id);
            }
            if(getCurrentSemester.Id == 2)
            {
                isRegistered = _context.TblStudentInfo.Any(a => a.AccountId == accid && a.IsSecondSelect == true & a.AcademicYearId == getCurrentAcademic.Id);
            }
           

            if (isRegistered)
            {
                TempData["alert"] = "You have already selected courses!";
                return RedirectToAction("AlertPage");
            }

            var majorList = _context.TblSection.ToList();
            var academicYearList = _context.TblAcademicYear.ToList();
            var semesterList = _context.TblSemester.ToList();
            var yearlevelList = _context.TblYearLevel.ToList();
            var courseList = _context.TblCourse.ToList();

            var getYearLevel = (from stu in _context.TblStudentAccount
                                join std in _context.TblStudentInfo
                                on stu.Id equals std.AccountId
                                where stu.Id == accid && std.Active == true
                                select new
                                {
                                    std.YearLevelId
                                }).FirstOrDefault();

            //---first semester of first year student
            if (getCurrentSemester.Id == 1 && getYearLevel.YearLevelId == 1)
            {
                courseSelectionInfo.NextAcademic = getCurrentAcademic.Name;
                courseSelectionInfo.NextAcademicId = getCurrentAcademic.Id;
                courseSelectionInfo.NextSemester = getCurrentSemester.Name;
                courseSelectionInfo.NextSemesterId = getCurrentSemester.Id;
                courseSelectionInfo.NextYearLevel = "First Year";
                courseSelectionInfo.NextYearLevelId = 1;
                courseSelectionInfo.NextMajor = "CST";
                courseSelectionInfo.NextMajorId = majorList.Where(a=>a.Name == "CST").FirstOrDefault().Id;

                var firseyear_courses = courseList.Where(a => a.SemesterId == 1 && a.YearLevelId == 1
                                        && a.Active == true).ToList();

                foreach (var item in firseyear_courses)
                {
                    courseSelections_1.Add(new CourseSelectionDetails
                    {
                        IsSelected = false,
                        CourseCode = item.Code,
                        CourseId = item.Id,
                        CourseName = item.Name
                    });
                }

                courseSelectionInfo.NextCourse = courseSelections_1;
            }
            //---second semester of first year student
            if (getCurrentSemester.Id == 2 && getYearLevel.YearLevelId == 1)
            {
                courseSelectionInfo.NextAcademic = getCurrentAcademic.Name;
                courseSelectionInfo.NextAcademicId = getCurrentAcademic.Id;
                courseSelectionInfo.NextSemester = getCurrentSemester.Name;
                courseSelectionInfo.NextSemesterId = getCurrentSemester.Id;
                courseSelectionInfo.NextYearLevel = "First Year";
                courseSelectionInfo.NextYearLevelId = 1;
                courseSelectionInfo.NextMajor = "CST";
                courseSelectionInfo.NextMajorId = majorList.Where(a => a.Name == "CST").FirstOrDefault().Id;

                var firseyear_courses = courseList.Where(a => a.SemesterId == 2 && a.YearLevelId == 1
                                         && a.Active == true).ToList();

                foreach (var item in firseyear_courses)
                {
                    courseSelections_1.Add(new CourseSelectionDetails
                    {
                        IsSelected = false,
                        CourseCode = item.Code,
                        CourseId = item.Id,
                        CourseName = item.Name
                    });
                }

                courseSelectionInfo.NextCourse = courseSelections_1;
            }
            //---not first year 
            if (getYearLevel.YearLevelId != 1)
            {
                var getcurrentyearinfo = (from stu in _context.TblStudentAccount
                                             join std in _context.TblStudentInfo
                                             on stu.Id equals std.AccountId
                                             where stu.Id == accid && std.Active == true
                                             select new
                                             {
                                                 std.YearLevelId,
                                                 std.SectionId
                                             }).FirstOrDefault();

                var prevSectionId = _context.TblStudentInfo.Where(a => a.AccountId == accid && a.AcademicYearId == (getCurrentAcademic.Id - 1)
                                              && a.Active == false).FirstOrDefault().SectionId;

                courseSelectionInfo.PrevAcademic = academicYearList.Where(a => a.Id == (getCurrentAcademic.Id - 1)).FirstOrDefault().Name;
                courseSelectionInfo.PrevAcademicId = getCurrentAcademic.Id - 1;
                courseSelectionInfo.PrevSemester = semesterList.Where(a => a.Id == getCurrentSemester.Id).FirstOrDefault().Name;
                courseSelectionInfo.PrevSemesterId = getCurrentSemester.Id;
                courseSelectionInfo.PrevYearLevel = yearlevelList.Where(a => a.Id == (getcurrentyearinfo.YearLevelId - 1)).FirstOrDefault().Name;
                courseSelectionInfo.PrevYearLevelId = (int)getcurrentyearinfo.YearLevelId - 1;
                courseSelectionInfo.PrevMajor = majorList.Where(a => a.Id == prevSectionId).FirstOrDefault().Name;
                courseSelectionInfo.PrevMajorId = (int)prevSectionId;

                courseSelectionInfo.NextAcademic = getCurrentAcademic.Name;
                courseSelectionInfo.NextAcademicId = getCurrentAcademic.Id;
                courseSelectionInfo.NextSemester = getCurrentSemester.Name;
                courseSelectionInfo.NextSemesterId = getCurrentSemester.Id;
                courseSelectionInfo.NextYearLevel = yearlevelList.Where(a => a.Id == getcurrentyearinfo.YearLevelId).FirstOrDefault().Name;
                courseSelectionInfo.NextYearLevelId = (int)getcurrentyearinfo.YearLevelId;
                courseSelectionInfo.NextMajor = majorList.Where(a => a.Id == getcurrentyearinfo.SectionId).FirstOrDefault().Name;
                courseSelectionInfo.NextMajorId = (int)getcurrentyearinfo.SectionId;

                var prevAcYear = getCurrentAcademic.Id - 1;
                var prevYear = getYearLevel.YearLevelId - 1;
                var currentSemester = getCurrentSemester.Id;
                var prevResultId = _context.TblResult.Where(a => a.AcademicYearId == prevAcYear && a.SemesterId == currentSemester && a.YearLevelId == prevYear && a.StudentId == accid).FirstOrDefault();

                var prevResultList = _context.TblResultDetails.Where(a => a.ResultId == prevResultId.Id).ToList();

                foreach (var item1 in prevResultList)
                {
                    courseSelections_2.Add(new CourseSelectionDetails
                    {
                        IsSelected = item1.Grade == "D" ? true : false,
                        CourseCode = courseList.Where(a=>a.Id == item1.CourseId).FirstOrDefault().Code,
                        CourseId = (int)item1.CourseId,
                        CourseName = courseList.Where(a => a.Id == item1.CourseId).FirstOrDefault().Name
                    });
                }

                courseSelectionInfo.PrevCourse = courseSelections_2;

                var nextyear_courses = courseList.Where(a => a.SemesterId == getCurrentSemester.Id && a.YearLevelId == getYearLevel.YearLevelId
                                       && a.Active == true ).ToList();

                if (getsectionCode.Name == "BIS" || getsectionCode.Name == "HPC" || getsectionCode.Name == "SE" || getsectionCode.Name == "KE")
                {
                    nextyear_courses = nextyear_courses.Where(a => a.MajorCode == "CS" || a.MajorCode == getsectionCode.Name || a.MajorCode == "CST").ToList();
                }
                if(getsectionCode.Name == "Computer Communication and Network")
                {
                    nextyear_courses = nextyear_courses.Where(a => a.MajorCode == "CT" || a.MajorCode == "CCN" || a.MajorCode == "CST").ToList();
                }
                if (getsectionCode.Name == "Embedded System")
                {
                    nextyear_courses = nextyear_courses.Where(a => a.MajorCode == "CT" || a.MajorCode == "ES" || a.MajorCode == "CST").ToList();
                }
                if (getsectionCode.Name == "CS")
                {
                    nextyear_courses = nextyear_courses.Where(a => a.MajorCode == "CS" || a.MajorCode == "CST").ToList();
                }
                if (getsectionCode.Name == "CT")
                {
                    nextyear_courses = nextyear_courses.Where(a => a.MajorCode == "CT" ||  a.MajorCode == "CST").ToList();
                }

                foreach (var item in nextyear_courses)
                {
                    courseSelections_1.Add(new CourseSelectionDetails
                    {
                        IsSelected = false,
                        CourseCode = item.Code,
                        CourseId = item.Id,
                        CourseName = item.Name
                    });
                }

                courseSelectionInfo.NextCourse = courseSelections_1;
            }
            return View(courseSelectionInfo);
        }

        [HttpPost]
        public IActionResult SaveCourseSelection(CourseSelectionInfo courseSelectionInfo)
        {
            var name = HttpContext.Session.GetString(SessionName);
            var acc = HttpContext.Session.GetInt32(SessionAccount);
            var accid = HttpContext.Session.GetInt32(SessionId);        
            var prerequisiteList = _context.TblPrerequisities.ToList();
            var courseList = _context.TblCourse.ToList();
            var prevCount = 0;
            List<CourseSelectionDetails> prevActivelist = new List<CourseSelectionDetails>();

            if (courseSelectionInfo.PrevCourse != null)
            {
                 prevActivelist = courseSelectionInfo.PrevCourse.Where(a => a.IsSelected == true).ToList();
                 prevCount = prevActivelist.Count();
            }
           
            var nextActivelist = courseSelectionInfo.NextCourse.Where(a => a.IsSelected == true).ToList(); 
            var nextCount = nextActivelist.Count();

            //-----------------check course count total
            if (prevCount + nextCount > 6)
            {
                return Json(new { status = "fail", message = "You cannot choose more than 6 course!" });
            }

            if (prevCount == 3 && nextCount != 0)
            {
                return Json(new { status = "fail", message = "You cannot choose next year level course!" });
            }

            #region
            //----------------check prev course is same with D
            ////---get prev result list
            //var prevResult = (from rm in _context.TblResult
            //                  join rd in _context.TblResultDetails
            //                  on rm.Id equals rd.ResultId
            //                  join course in _context.TblCourse
            //                  on rd.CourseId equals course.Id
            //                  where rm.StudentId == accid && rm.AcademicYearId == courseSelectionInfo.PrevAcademicId &&
            //                  rm.SemesterId == courseSelectionInfo.PrevSemesterId && rm.YearLevelId == courseSelectionInfo.PrevYearLevelId
            //                  select new
            //                  {
            //                      _courseId = rd.CourseId,
            //                      _courseName = course.Name,
            //                      _grade = rd.Grade
            //                  }).ToList();
            #endregion

            var getcurrentAcademic = _context.TblAcademicYear.Where(a => a.Active == true).FirstOrDefault().Id;
            var getcurrentSemester = _context.TblSemester.Where(a => a.Active == true).FirstOrDefault().Id;
           

            if (courseSelectionInfo.NextYearLevelId != 1)//---contain D
            {
                #region
                //---check prev course is same D course
                //foreach (var item in courseSelectionInfo.PrevCourse)
                //{
                //    var isExist = prevResult.Any(a => a._courseId == item.CourseId && a._grade == "D");
                //    if (!isExist)
                //    {
                //        isSame = false;
                //    }
                //}

                //if (isSame)
                //{
                //    return Json(new { status = "fail", message = "Your fail course don't match!" });
                //}
                #endregion

                //--check prerequisite of next course

                var prevCourseHistory = (from rm in _context.TblResult
                                         join rd in _context.TblResultDetails
                                         on rm.Id equals rd.ResultId
                                         where rm.StudentId == accid
                                         select rd).ToList();

                    foreach (var item in prevActivelist)
                    {
                        foreach (var item2 in nextActivelist)
                        {
                            var isExist = prerequisiteList.Any(a => a.PassCourseId == item.CourseId && a.NewCourseId == item2.CourseId);
                            if (isExist)
                            {
                                return Json(new { status = "fail", message = item.CourseCode + " and " + item2.CourseCode + " is prerequisite course!" });
                            }
                        }
                    }

                foreach (var item56 in nextActivelist)
                {
                    var prelist = prerequisiteList.Where(a => a.NewCourseId == item56.CourseId).ToList();
                 
                    foreach (var item89 in prelist)
                    {
                        var grade = prevCourseHistory.Where(a => a.CourseId == item89.PassCourseId).FirstOrDefault().Grade;
                        if (grade == "D")
                        {
                            var code = courseList.Where(a => a.Id == item89.PassCourseId).FirstOrDefault().Code;
                            return Json(new
                            { status = "fail",
                              message = item56.CourseCode + " and " + code + " is prerequisite course! You fail" + code
                            });
                        }
                    }
                }

                if(prevCount != 0)
                {
                    //---check prev and next time table period
                    List<CheckTimeTable> prevTimeTableDetails = new List<CheckTimeTable>();
                    List<CheckTimeTable> nextTimeTableDetails = new List<CheckTimeTable>();


                    var result1 = (from tm in _context.TblTimeTable
                                   join td in _context.TblTimeTableDetails
                                   on tm.Id equals td.TimeTableId
                                   join c in _context.TblCourse
                                   on td.CourseId equals c.Id
                                   where tm.SemesterId == courseSelectionInfo.PrevSemesterId && tm.AcademicYearId == courseSelectionInfo.PrevAcademicId
                                   && tm.YearLevelId == courseSelectionInfo.PrevYearLevelId && tm.SectionId == courseSelectionInfo.PrevMajorId
                                   select new
                                   {
                                       td.PeriodId,
                                       td.Day,
                                       td.CourseId,
                                       c.Code
                                   }).ToList();

                    var result2 = (from tm in _context.TblTimeTable
                                   join td in _context.TblTimeTableDetails
                                   on tm.Id equals td.TimeTableId
                                   join c in _context.TblCourse
                                   on td.CourseId equals c.Id
                                   where tm.SemesterId == courseSelectionInfo.NextSemesterId && tm.AcademicYearId == courseSelectionInfo.NextAcademicId
                                   && tm.YearLevelId == courseSelectionInfo.NextYearLevelId && tm.SectionId == courseSelectionInfo.NextMajorId
                                   select new
                                   {
                                       td.PeriodId,
                                       td.Day,
                                       td.CourseId,
                                       c.Code
                                   }).ToList();

                    foreach (var item3 in courseSelectionInfo.PrevCourse)
                    {
                        var temp1 = result1.Where(a => a.CourseId == item3.CourseId).ToList();

                        foreach (var item4 in temp1)
                        {
                            prevTimeTableDetails.Add(new CheckTimeTable
                            {
                                PeriodId = (int)item4.PeriodId,
                                Day = item4.Day,
                                CourseCode = item4.Code,
                                CourseId = (int)item4.CourseId
                            });
                        }

                    }

                    foreach (var item6 in courseSelectionInfo.NextCourse)
                    {
                        var temp2 = result2.Where(a => a.CourseId == item6.CourseId).ToList();

                        foreach (var item5 in temp2)
                        {
                            nextTimeTableDetails.Add(new CheckTimeTable
                            {
                                PeriodId = (int)item5.PeriodId,
                                Day = item5.Day,
                                CourseCode = item5.Code,
                                CourseId = (int)item5.CourseId
                            });
                        }

                    }

                    foreach (var item7 in prevTimeTableDetails)
                    {
                        var isExist23 = nextTimeTableDetails.Any(a => a.Day == item7.Day && a.PeriodId == item7.PeriodId);
                        if (isExist23)
                        {
                            var courseCode = nextTimeTableDetails.Where(a => a.Day == item7.Day && a.PeriodId == item7.PeriodId).First().CourseCode;
                            return Json(new { status = "fail", message = item7.CourseCode + " and " + courseCode + " is timetable period same!" });
                        }
                    }
                }
            }

            #region
            ////---check new total course is 6
            //if (nextCount != 6)
            //{
            //    return Json(new { status = "fail", message = "You must choose six course!" });
            //}
            #endregion

            foreach (var item99 in courseSelectionInfo.NextCourse)
            {
                TblSubjectCourse tblSubjectCourse = new TblSubjectCourse()
                {
                    StudentId = accid,
                    AcademicYearId = courseSelectionInfo.NextAcademicId,
                    Active = true,
                    SemesterId = courseSelectionInfo.NextSemesterId,
                    SectionId = courseSelectionInfo.NextMajorId,
                    Code = item99.CourseCode,
                    CourseId = item99.CourseId,
                    CreatedDate = DateTime.Now,
                    YearLevelId = courseSelectionInfo.NextYearLevelId
                };

                _context.TblSubjectCourse.Add(tblSubjectCourse);
                _context.SaveChanges();
            }

            var acinfo = _context.TblStudentInfo.Where(a => a.AccountId == accid && a.Active == true).FirstOrDefault();

            if (courseSelectionInfo.NextSemesterId == 1)
            {
                acinfo.IsCourseSelect = true;
            }
            if (courseSelectionInfo.NextSemesterId == 2)
            {
                acinfo.IsSecondSelect = true;
            }


            _context.SaveChanges();

            return Json(new { status = "success", message = "Course select successfully " });
        }
    }
}
