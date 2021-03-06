﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class eClockWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eClockWebContext() : base("name=eClockWebContext")
        {
        }

        public System.Data.Entity.DbSet<eClock.Web.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<eClock.Web.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<eClock.Web.Models.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<eClock.Web.Models.WorkItem> WorkItems { get; set; }

        public System.Data.Entity.DbSet<EmployeeWeek> EmployeeWeeks { get; set; }

        public DbSet<RegisteredHours> RegisteredHours { get; set; }

        public DbSet<TimeRegistration> TimeRegisterations { get; set; }
    
    }
}
