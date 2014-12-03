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
    public class ProjectTypesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: ProjectTypes
        public ActionResult Index()
        {
            return View(db.ProjectTypes.ToList());
        }

        // GET: ProjectTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectType projectType = db.ProjectTypes.Find(id);
            if (projectType == null)
            {
                return HttpNotFound();
            }
            return View(projectType);
        }

        // GET: ProjectTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] ProjectType projectType)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTypes.Add(projectType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectType);
        }

        // GET: ProjectTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectType projectType = db.ProjectTypes.Find(id);
            if (projectType == null)
            {
                return HttpNotFound();
            }
            return View(projectType);
        }

        // POST: ProjectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] ProjectType projectType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectType);
        }

        // GET: ProjectTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectType projectType = db.ProjectTypes.Find(id);
            if (projectType == null)
            {
                return HttpNotFound();
            }
            return View(projectType);
        }

        // POST: ProjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectType projectType = db.ProjectTypes.Find(id);
            db.ProjectTypes.Remove(projectType);
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
