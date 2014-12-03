using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wwdapp.Models;

namespace wwdapp.Controllers
{
    public class ProjectEventsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: ProjectEvents
        public ActionResult Index()
        {
            var projectEvents = db.ProjectEvents.Include(p => p.Employee).Include(p => p.Project);
            return View(projectEvents.ToList());
        }

        // GET: ProjectEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectEvent projectEvent = db.ProjectEvents.Find(id);
            if (projectEvent == null)
            {
                return HttpNotFound();
            }
            return View(projectEvent);
        }

        // GET: ProjectEvents/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description");
            return View();
        }

        // POST: ProjectEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectID,EmployeeID,Description,TimeStart,TimeEnd,MaterialsUsed")] ProjectEvent projectEvent)
        {
            if (ModelState.IsValid)
            {
                db.ProjectEvents.Add(projectEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", projectEvent.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", projectEvent.ProjectID);
            return View(projectEvent);
        }

        // GET: ProjectEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectEvent projectEvent = db.ProjectEvents.Find(id);
            if (projectEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", projectEvent.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", projectEvent.ProjectID);
            return View(projectEvent);
        }

        // POST: ProjectEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectID,EmployeeID,Description,TimeStart,TimeEnd,MaterialsUsed")] ProjectEvent projectEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", projectEvent.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", projectEvent.ProjectID);
            return View(projectEvent);
        }

        // GET: ProjectEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectEvent projectEvent = db.ProjectEvents.Find(id);
            if (projectEvent == null)
            {
                return HttpNotFound();
            }
            return View(projectEvent);
        }

        // POST: ProjectEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectEvent projectEvent = db.ProjectEvents.Find(id);
            db.ProjectEvents.Remove(projectEvent);
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
