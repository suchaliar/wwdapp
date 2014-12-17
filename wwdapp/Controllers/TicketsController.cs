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
    public class TicketsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Account).Include(t => t.Employee).Include(t => t.Priority).Include(t => t.TicketStatu);
            return View(tickets.Where(t => t.StatusID != 6).OrderBy(t => t.PriorityID).ThenBy(t => t.DateOpened).ToList());
        }

        // GET: Tickets/Closed
        public ActionResult ClosedIndex()
        {
            var tickets = db.Tickets.Include(t => t.Account).Include(t => t.Employee).Include(t => t.Priority).Include(t => t.TicketStatu);
            return View(tickets.Where(t => t.StatusID == 6).OrderBy(t => t.PriorityID).ThenBy(t => t.DateOpened).ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // Tickets/ClosedDetails/5
        public ActionResult ClosedDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull");
            ViewBag.PriorityID = new SelectList(db.Priorities, "Id", "Priority1");
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Status");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountID,EmployeeID,StatusID,DateOpened,DateClosed,Description,PriorityID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", ticket.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", ticket.EmployeeID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "Id", "Priority1", ticket.PriorityID);
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Status", ticket.StatusID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", ticket.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", ticket.EmployeeID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "Id", "Priority1", ticket.PriorityID);
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Status", ticket.StatusID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountID,EmployeeID,StatusID,DateOpened,DateClosed,Description,PriorityID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", ticket.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "NameFull", ticket.EmployeeID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "Id", "Priority1", ticket.PriorityID);
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Status", ticket.StatusID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
