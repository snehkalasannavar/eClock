using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClock.Web.Models;
using eClock.Web.Utilities;

namespace eClock.Web.Controllers
{
    public class WorkItemController : Controller
    {
        private eClockWebContext db = new eClockWebContext();

        // GET: /WorkItem/
        public ActionResult Index(string searchString)
        {
            var workItems = from wi in db.WorkItems
                            select wi;
            var workitems = db.WorkItems.Include(w => w.Employee).Include(w => w.Project);

            var list1 = workitems.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                var workItemState = EnumUtility.ParseEnum<WorkItemState>(searchString);
                workItems = workItems.Where(s => s.State == workItemState);//.Contains(searchString)
                var list = workItems.ToList();
            }
            return View(new WorkItemViewModel { WorkItemList = workItems/*, WorkItemSearchString = workItems*/ });
        }

        // GET: /WorkItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workitem = db.WorkItems.Find(id);
            if (workitem == null)
            {
                return HttpNotFound();
            }
            return View(workitem);
        }

        // GET: /WorkItem/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: /WorkItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,State,EmployeeId,ProjectId")] WorkItem workitem)
        {
            if (ModelState.IsValid)
            {
                db.WorkItems.Add(workitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", workitem.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workitem.ProjectId);
            return View(workitem);
        }

        // GET: /WorkItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workitem = db.WorkItems.Find(id);
            if (workitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", workitem.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workitem.ProjectId);
            return View(workitem);
        }

        // POST: /WorkItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,State,EmployeeId,ProjectId")] WorkItem workitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", workitem.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workitem.ProjectId);
            return View(workitem);
        }

        // GET: /WorkItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workitem = db.WorkItems.Find(id);
            if (workitem == null)
            {
                return HttpNotFound();
            }
            return View(workitem);
        }

        // POST: /WorkItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItem workitem = db.WorkItems.Find(id);
            db.WorkItems.Remove(workitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
