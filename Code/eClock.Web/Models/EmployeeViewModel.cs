using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public string Password { get; set; }
        public ApplicationUser User { get; set; }
    }
}