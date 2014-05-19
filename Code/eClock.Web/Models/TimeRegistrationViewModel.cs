using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class TimeRegistrationViewModel
    {
        public EmployeeWeekSelectionViewModel EmployeeWeekSelectionVM { get; set; }
        public IEnumerable<TimeRegistration> TimeRegistrations { get; set; }
    }
}