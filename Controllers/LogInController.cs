using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSys.Models.Data;
using StudentRegistrationSys.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentRegistrationSys.Common;

namespace StudentRegistrationSys.Controllers
{
    public class LogInController : Controller
    {
        private readonly StudentInfoContext _context;
        const string SessionName = "_Name";
        const string SessionAccount = "_Account";
        const string SessionId = "_Id";

        public LogInController(StudentInfoContext context)
        {
            _context = context;
        }

        // GET: LogInController
        public ActionResult Index()
        {
            return View();
        }
     
        // POST: LogInController/Create
        public ActionResult CheckIsAuthenticated(LogIn logIn)
        {
           //  try
           // {
               // var pp = SaveTest();

                //JsonResponse result = new JsonResponse();
                var tolower = logIn.AccountName.ToLower();
                var type = "";

                var isContain = tolower.Contains("mkpt");

                if (!isContain)
                {
                    var result = _context.TblAdmin.Where(a => a.Name == logIn.AccountName && a.Password == logIn.Password).FirstOrDefault();

                    if (result == null)
                    {
                        return Json(new { status = "fail", message = "Account name or password is incorrect!" });
                    }

                type = "admin";

                    HttpContext.Session.SetString(SessionName, result.Name);
                    HttpContext.Session.SetInt32(SessionId, result.Id);
                }
                else
                {
                    var result = _context.TblStudentAccount.Where(a => a.AccountId == logIn.AccountName && a.Password == logIn.Password).FirstOrDefault();

                    if (result == null)
                    {
                        return Json(new { status = "fail", message = "Account name or password is incorrect!" });
                    }

                type = "student";

                HttpContext.Session.SetString(SessionName, result.Name);
                    HttpContext.Session.SetInt32(SessionId, result.Id);
                    HttpContext.Session.SetString(SessionAccount, result.AccountId);
                }

                return Json(new { status = "success", message = type });
           //  }
         //   catch
          //  {
          //      return View();
          //  }
        }

        public bool SaveTest()
        {
           // try
           // {
                TblTesting1 tblTesting1 = new TblTesting1()
                {
                    Testone = "aa",
                    Testtwo = "bb"
                };
                _context.TblTesting1.Add(tblTesting1);
                _context.SaveChanges();

                report report = new report();
                report.SaveTest("a", "b");

                return true;
          //  }
          //  catch
          //  {
           ////     return false;
          //  }
          
        }
    }
}
