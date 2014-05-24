﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class WorkItemFinderViewModel
    {
        public bool ProjectFilterRequired { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public IEnumerable<WorkItem> WorkItems { get; set; }
    }
}