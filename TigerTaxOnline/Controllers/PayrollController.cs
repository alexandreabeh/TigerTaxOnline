using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TigerTaxOnline.Classes;
using TigerTaxOnline.Models;
using Microsoft.AspNet.Identity;

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
            //TODO: must be restricted to all employees belonging to this user.
            return View(_userRepository.GetEmployees());
        }

        public ActionResult CreateEmployee(Employee employee)
        {
            employee.IsActive = true;
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

        public ActionResult DeleteEmployee(int employeeId)
        {
            _userRepository.DeleteEmployee(employeeId);
            return RedirectToAction("ManageEmployees");
        }
    }
}