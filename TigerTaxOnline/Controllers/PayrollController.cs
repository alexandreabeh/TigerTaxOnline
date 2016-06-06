using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TigerTaxOnline.Classes;
using TigerTaxOnline.Models;

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

        public ActionResult CreateEmployee()
        {
            var employee = new Employee();
            employee.IsActive = true;
            return View(employee);
        }

        public ActionResult AddEmployee()
        {

            return View("Index");
        }
    }
}