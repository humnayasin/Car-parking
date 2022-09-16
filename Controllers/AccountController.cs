using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarModel;
using Cardb;
using System.Web.Security;
namespace Semester_Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Emploee
        public ActionResult Loginpage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginpage(EmployeeModel model)
        {
            using (var context = new Car_ParkingEntities())
            {
                bool isValid = context.Employee.Any(x=>x.UserName == model.UserName &&x.Pass == model.Pass);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("EmployeeDashboard", "Home");
                }

                ModelState.AddModelError("", "invalid username or password");
                return View();  
            }
                
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Loginpage");
        }
    }
}