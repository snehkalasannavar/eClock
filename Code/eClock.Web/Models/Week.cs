using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class Week
    {
        public Week(DateTime date)
        {
            StartDate = date.AddDays(DayOfWeek.Monday - DateTime.Today.DayOfWeek);
            EndDate = StartDate.AddDays(6);
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}