using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TigerTaxOnline.Classes;
using TigerTaxOnline.Models;
using Microsoft.AspNet.Identity;
using System.Net;

namespace TigerTaxOnline.Controllers
{
    public class PayrollController : Controller
    {
        private UserRepository _userRepository = new UserRepository();

        // GET: Payroll
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageEmployees()
        {
            var userId = (int)Session["UserId"];
            var employees = _userRepository.Dal.Employees.Where(e => e.UserId == userId);
            
            return View(employees);
        }

        public ActionResult CreateEmployee(Employee employee)
        {
            employee.IsActive = true;
            ViewBag.Title = "Add An Employee";
            return View(employee);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            employee.UserId = (int)Session["UserId"];

            if(ModelState.IsValid)
            {
                _userRepository.CreateNewEmployee(employee);
            }
            else
            {
                return View("CreateEmployee", employee);
            }

            return RedirectToAction("ManageEmployees");
        }

        public ActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = _userRepository.Dal.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            
            return View(employee);
        }

        [HttpPost, ActionName("UpdateEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployeePost(Employee employee)
        {
            var employeeToUpdate = _userRepository.Dal.Employees.Find(employee.EmployeeId);

            if (ModelState.IsValid)
            {
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.PhoneNumber = employee.PhoneNumber;
                employeeToUpdate.IsActive = employee.IsActive;
                employeeToUpdate.Notes = employee.Notes;

                _userRepository.Dal.SaveChanges();

                return RedirectToAction("ManageEmployees");
            }

            return View("UpdateEmployee");
        }


        public ActionResult DeleteEmployee(int employeeId)
        {
            _userRepository.DeleteEmployee(employeeId);
            return RedirectToAction("ManageEmployees");
        }
    }
}