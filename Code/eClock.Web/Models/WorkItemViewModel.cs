using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class WorkItemViewModel
    {
        public IQueryable<WorkItem> WorkItemList { get; set; }
        public IQueryable<WorkItem> WorkItemSearchString { get; set; }
    }
}