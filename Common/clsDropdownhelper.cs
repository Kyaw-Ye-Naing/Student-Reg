using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Common
{
    public class clsDropdownhelper
    {
        public static List<SelectListItem> GetAcademicYearList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var academicYear = (from a in db.TblAcademicYear
                                    //where a.Active == true
                                orderby a.Name ascending
                                select a).ToList();
            if (id != 0)
            {
                foreach (var item in academicYear)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in academicYear)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetYearLevelList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var yearlevel = (from a in db.TblYearLevel
                                 //where a.Active == true
                             orderby a.Id ascending
                             select a).ToList();

            if (id != 0)
            {
                foreach (var item in yearlevel)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in yearlevel)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetYearLevelForReport(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var yearlevel = (from a in db.TblYearLevel
                                 //where a.Active == true
                             orderby a.Id ascending
                             select a).ToList();


            listItems.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (var item in yearlevel)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString().Trim(),
                    Selected = item.Id == id
                });
            }

            return listItems;
        }

        public static List<SelectListItem> GetSemesterList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblSemesters = (from a in db.TblSemester
                                orderby a.Name ascending
                                select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblSemesters)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblSemesters)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetSemesterListForReport(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblSemesters = (from a in db.TblSemester                              
                                orderby a.Name ascending
                                select a).ToList();

            if (id != 0)
            {
                listItems.Add(new SelectListItem { Text = "All", Value = "0" });
                foreach (var item in tblSemesters)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "All", Value = "0" });
                foreach (var item in tblSemesters)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetPeriodList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblPeriods = (from a in db.TblPeriod
                              where a.Active == true
                              orderby a.PeriodName ascending
                              select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblPeriods)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.PeriodName,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblPeriods)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.PeriodName,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetSectionList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblsection = (from a in db.TblSection
                              where a.Active == true
                              orderby a.Name ascending
                              select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblsection)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblsection)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetStudentList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblStudents = (from a in db.TblStudentAccount
                               where a.Active == true
                               orderby a.Name ascending
                               select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetStudentListForReport(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblStudents = (from a in db.TblStudentAccount
                               where a.Active == true
                               orderby a.Name ascending
                               select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "All", Value = "0" });
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetCourseList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblStudents = (from a in db.TblCourse
                               where a.Active == true
                               orderby a.Name ascending
                               select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetCourseCodeList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();
            var tblStudents = (from a in db.TblCourse
                               where a.Active == true
                               orderby a.Code ascending
                               select a).ToList();

            if (id != 0)
            {
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Code,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }
            else
            {
                listItems.Add(new SelectListItem { Text = "Please Select", Value = "0" });
                foreach (var item in tblStudents)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Code,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            }


            return listItems;
        }

        public static List<SelectListItem> GetRegisterList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();

            List<DropdownSample> items = new List<DropdownSample>()
            {
                new DropdownSample{ Id=1, Name="Register"},
                new DropdownSample{ Id=2, Name="UnRegister"}
            };

                listItems.Add(new SelectListItem { Text = "All", Value = "0" });
                foreach (var item in items)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString().Trim(),
                        Selected = item.Id == id
                    });
                }
            
            return listItems;
        }

        public static List<SelectListItem> GetCourseSelectList(int? id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();

            List<DropdownSample> items = new List<DropdownSample>()
            {
                new DropdownSample{ Id=1, Name="Selected"},
                new DropdownSample{ Id=2, Name="UnSelect"}
            };

            listItems.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (var item in items)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString().Trim(),
                    Selected = item.Id == id
                });
            }

            return listItems;
        }

        public static List<SelectListItem> GetMajorCodeList(string code)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using var db = new StudentInfoContext();

            List<DropdownSample> items = new List<DropdownSample>()
            {
                new DropdownSample{ Id=1, Name="CST"},            
                new DropdownSample{ Id=2, Name="CS"},
                new DropdownSample{ Id=2, Name="CT"},         
                new DropdownSample{ Id=2, Name="BIS"},
                new DropdownSample{ Id=2, Name="HPC"},
                new DropdownSample{ Id=2, Name="KE"},
                new DropdownSample{ Id=2, Name="SE"},
                new DropdownSample{ Id=2, Name="CCN"},
                new DropdownSample{ Id=2, Name="ES"}
     
            };

            foreach (var item in items)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name.ToString().Trim(),
                    Selected = item.Name == code
                });
            }

            return listItems;
        }
    }
}
