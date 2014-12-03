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
    public class InvoicesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Account).Include(i => i.DeliveryMade).Include(i => i.Project).Include(i => i.Ticket);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description");
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description");
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Description");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,AccountID,Description,TicketID,ProjectID,BilledItems,DeliveryMadeID,Total")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", invoice.AccountID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", invoice.DeliveryMadeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", invoice.ProjectID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Description", invoice.TicketID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", invoice.AccountID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", invoice.DeliveryMadeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", invoice.ProjectID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Description", invoice.TicketID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,AccountID,Description,TicketID,ProjectID,BilledItems,DeliveryMadeID,Total")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", invoice.AccountID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", invoice.DeliveryMadeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "Description", invoice.ProjectID);
            ViewBag.TicketID = new SelectList(db.Tickets, "Id", "Description", invoice.TicketID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
