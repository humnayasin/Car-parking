using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarModel;
using Cardb.DbOperations;
using Cardb;


namespace Semester_Project.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;
        public ActionResult EmployeeDashboard()
        {



            using (var context = new Car_ParkingEntities())
            {

                var total_parkings = 23;
                var count = context.Vehical.Count();
                ViewBag.totalcars = count;
                var left = (total_parkings - count);
                ViewBag.left = left;    

            }
                return View(); 
            




        }
        public HomeController()
        {
            repository = new EmployeeRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

       
        public ActionResult Delete(int id)
        {

            repository.DeleteEmployee(id);
            return RedirectToAction("GetAllRecords");

        }

        public ActionResult VDelete(int id)
        {

            repository.DeleteVehical(id);
            return RedirectToAction("GetAllVehicals");

        }


        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }
            }
            return View();
        }
        public ActionResult Vehical() { return View(); }

        [HttpPost]
        public ActionResult Vehical(VehicalModel model1)
        {

            if (ModelState.IsValid)
            {
                int id = repository.AddCar(model1);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.addvehical = "Vehical Added to parking database";
                }
            }

            return View();
        }




        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllEmployees();
            return View(result);
        }

        public ActionResult GetAllVehicals()
        {
            var result = repository.GetAllVehicals();
            return View(result);

        }


        public ActionResult Edit(int id)
        {
            var employee = repository.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmployee(model.Id, model);
                return RedirectToAction("GetAllRecords");
            }
            return View();
        }





        public ActionResult VEdit(int id)
        {
            var vehical= repository.GetVehical(id);
            return View(vehical);
        }
        [HttpPost]
        public ActionResult VEdit(VehicalModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateVehical(model.Id, model);
                return RedirectToAction("GetAllVehicals");
            }
            return View();
        }
        public ActionResult adminpage()
        {
            return View();
        }


    }
        
}