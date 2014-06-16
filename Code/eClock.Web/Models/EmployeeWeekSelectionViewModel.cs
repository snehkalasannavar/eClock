using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class EmployeeWeekSelectionViewModel
    {
        [Display(Name="Employee")]
        public IEnumerable<Employee> Employees { get; set; }
        public Employee CurrentEmployee { get; set; }

        //public IEnumerable<Week> Weeks { get; set; }
        public Week CurrentWeek { get; set; }

        [Display(Name = "Select Week")]
        public string SelectedWeek { get; set; }

        public EmployeeWeekState State { get; set; }
    }
}