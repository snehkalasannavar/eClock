using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClock.Web.Models;

namespace eClock.Web.Controllers
{
    public class ProjectController : Controller
    {
        private eClockWebContext db = new eClockWebContext();

        // GET: /Project/
        public ActionResult Index()
        {
            DbSet<Project> p = db.Projects;

            return View(p.ToList());
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        public ActionResult GetNewModuleRow(int projectId)
        {
            return PartialView("NewModuleRow", projectId);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,StartDate,EndDate,State")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Name,StartDate,EndDate,State,Modules")] */Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: /Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        public ActionResult SaveModule([Bind(Include = "Id,Name,ProjectId")] Module module)
        {
            JsonResult returnSaveModule;
            try
            {
                if (module.Id == 0)
                {
                    var newModule = db.Modules.Add(module);
                    int newId = db.SaveChanges();
                    returnSaveModule = Json(
                        new 
                        {
                            Success = true,
                            NewModuleId = newModule.Id
                        });
                }
                else
                {
                    db.Entry(module).State = EntityState.Modified;
                    db.SaveChanges();
                    returnSaveModule = Json(new { Success = true });
                }
            }
            catch (Exception exc)
            {
                returnSaveModule = Json(new { Error = exc.Message });
            }
            return returnSaveModule;
        }

        [HttpPost]
        public ActionResult DeleteModule(int moduleId)
        {
            JsonResult returnDeleteModule;
            var module = db.Modules.Find(moduleId);
            db.Modules.Remove(module);
            db.SaveChanges();
            returnDeleteModule = Json(new { Success = true });
            return returnDeleteModule;
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
