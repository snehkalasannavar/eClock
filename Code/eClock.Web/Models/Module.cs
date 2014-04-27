using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Project Project { get; set; }
        //[Key]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
    }
}