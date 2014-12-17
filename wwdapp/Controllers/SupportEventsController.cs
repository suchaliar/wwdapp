using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wwdapp.Models;

namespace wwdapp.Controllers
{
    public class SupportEventsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: SupportEvents
        public ActionResult Index(int? PassTicketID)
        {
            if (PassTicketID == null)
            {
                var supportEvents = db.SupportEvents.Include(s => s.Employee).Include(s => s.Procedure).Include(s => s.Ticket);
                return View(supportEvents.ToList());
            }
            else
            {
                var query = from s in db.SupportEvents
                                        where s.TicketID == PassTicketID
                                        select s;
                            return View(query.ToList());
            }
        }

        // GET: SupportEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportEvent supportEvent = db.SupportEvents.Find(id);
            if (supportEvent == null)
            {
                return HttpNotFound();
            }
            return View(supportEvent);
        }

        // GET: SupportEvents/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull");
            ViewBag.ProcedureID = new SelectList(db.Procedures, "Id", "Name");
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Id");
            return View();
        }

        // POST: SupportEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeStart,TimeEnd,EmployeeID,ProcedureID,Description,TicketID")] SupportEvent supportEvent)
        {
            if (ModelState.IsValid)
            {
                db.SupportEvents.Add(supportEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", supportEvent.EmployeeID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "Id", "Name", supportEvent.ProcedureID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Id", supportEvent.TicketID);
            ViewBag.ticket = supportEvent.TicketID;
            return View(supportEvent);
        }

        // GET: SupportEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportEvent supportEvent = db.SupportEvents.Find(id);
            if (supportEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", supportEvent.EmployeeID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "Id", "Name", supportEvent.ProcedureID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Id", supportEvent.TicketID);
            return View(supportEvent);
        }

        // POST: SupportEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeStart,TimeEnd,EmployeeID,ProcedureID,Description,TicketID")] SupportEvent supportEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", supportEvent.EmployeeID);
            ViewBag.ProcedureID = new SelectList(db.Procedures, "Id", "Name", supportEvent.ProcedureID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Id", supportEvent.TicketID);
            return View(supportEvent);
        }

        // GET: SupportEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportEvent supportEvent = db.SupportEvents.Find(id);
            if (supportEvent == null)
            {
                return HttpNotFound();
            }
            return View(supportEvent);
        }

        // POST: SupportEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportEvent supportEvent = db.SupportEvents.Find(id);
            db.SupportEvents.Remove(supportEvent);
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
