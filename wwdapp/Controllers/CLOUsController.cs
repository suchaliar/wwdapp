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
    public class CLOUsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: CLOUs
        public ActionResult Index()
        {
            var cLOUs = db.CLOUs.Include(c => c.Employee);
            return View(cLOUs.ToList());
        }

        // GET: CLOUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLOU cLOU = db.CLOUs.Find(id);
            if (cLOU == null)
            {
                return HttpNotFound();
            }
            return View(cLOU);
        }

        // GET: CLOUs/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: CLOUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Description,EmployeeID,Date")] CLOU cLOU)
        {
            if (ModelState.IsValid)
            {
                db.CLOUs.Add(cLOU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", cLOU.EmployeeID);
            return View(cLOU);
        }

        // GET: CLOUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLOU cLOU = db.CLOUs.Find(id);
            if (cLOU == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", cLOU.EmployeeID);
            return View(cLOU);
        }

        // POST: CLOUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Description,EmployeeID,Date")] CLOU cLOU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLOU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", cLOU.EmployeeID);
            return View(cLOU);
        }

        // GET: CLOUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLOU cLOU = db.CLOUs.Find(id);
            if (cLOU == null)
            {
                return HttpNotFound();
            }
            return View(cLOU);
        }

        // POST: CLOUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLOU cLOU = db.CLOUs.Find(id);
            db.CLOUs.Remove(cLOU);
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
