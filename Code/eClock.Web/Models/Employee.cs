using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}