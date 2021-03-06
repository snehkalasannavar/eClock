﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class TimeRegistration
    {
        public int Id { get; set; }

        [ForeignKey("EmployeeWeek")]
        public int EmployeeWeekId { get; set; }
        public virtual EmployeeWeek EmployeeWeek { get; set; }

        [ForeignKey("WorkItem")]
        public int WorkItemId { get; set; }
        public virtual WorkItem WorkItem { get; set; }

        [ForeignKey("RegisteredHours")]
        public int RegisteredHoursId { get; set; }
        public virtual RegisteredHours RegisteredHours { get; set; }

        public string Notes { get; set; }
    }
}