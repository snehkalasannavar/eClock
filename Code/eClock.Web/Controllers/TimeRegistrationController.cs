using eClock.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace eClock.Web.Controllers
{
    public class TimeRegistrationController : Controller
    {
        private eClockWebContext db = new eClockWebContext();

         //GET: /TimeRegistration/
        public ActionResult Index()
        {
            TimeRegistrationViewModel timeRegistrationVM = new TimeRegistrationViewModel
            {
                EmployeeWeekSelectionVM = GetEmployeeWeekSelection(),
                WorkItemFinderVM = new WorkItemFinderViewModel { Projects = db.Projects.ToList() },
                TimeRegistrations = new List<TimeRegistration>()
            };
            return View(timeRegistrationVM);
        }

        private EmployeeWeekSelectionViewModel GetEmployeeWeekSelection()
        {
            EmployeeWeekSelectionViewModel weekSelectionVM = new EmployeeWeekSelectionViewModel();
            weekSelectionVM.Employees = db.Employees.ToList();
            weekSelectionVM.CurrentEmployee = GetCurrentEmployee();
            return weekSelectionVM;
        }

        private Employee GetCurrentEmployee()
        {
            string userId = User.Identity.GetUserId();
            var currentEmployee = db.Employees.Where(e => e.UserId == userId).FirstOrDefault();
            return currentEmployee;
        }

    }
}
