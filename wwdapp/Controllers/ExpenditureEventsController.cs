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
    public class ExpenditureEventsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: ExpenditureEvents
        public ActionResult Index()
        {
            var expenditureEvents = db.ExpenditureEvents.Include(e => e.Employee);
            return View(expenditureEvents.ToList());
        }

        // GET: ExpenditureEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenditureEvent expenditureEvent = db.ExpenditureEvents.Find(id);
            if (expenditureEvent == null)
            {
                return HttpNotFound();
            }
            return View(expenditureEvent);
        }

        // GET: ExpenditureEvents/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: ExpenditureEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Amount,EmployeeID,Description,Justification")] ExpenditureEvent expenditureEvent)
        {
            if (ModelState.IsValid)
            {
                db.ExpenditureEvents.Add(expenditureEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", expenditureEvent.EmployeeID);
            return View(expenditureEvent);
        }

        // GET: ExpenditureEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenditureEvent expenditureEvent = db.ExpenditureEvents.Find(id);
            if (expenditureEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", expenditureEvent.EmployeeID);
            return View(expenditureEvent);
        }

        // POST: ExpenditureEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Amount,EmployeeID,Description,Justification")] ExpenditureEvent expenditureEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenditureEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", expenditureEvent.EmployeeID);
            return View(expenditureEvent);
        }

        // GET: ExpenditureEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenditureEvent expenditureEvent = db.ExpenditureEvents.Find(id);
            if (expenditureEvent == null)
            {
                return HttpNotFound();
            }
            return View(expenditureEvent);
        }

        // POST: ExpenditureEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenditureEvent expenditureEvent = db.ExpenditureEvents.Find(id);
            db.ExpenditureEvents.Remove(expenditureEvent);
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
