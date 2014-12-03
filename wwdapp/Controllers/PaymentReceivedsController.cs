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
    public class PaymentReceivedsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: PaymentReceiveds
        public ActionResult Index()
        {
            var paymentReceiveds = db.PaymentReceiveds.Include(p => p.Account).Include(p => p.Employee);
            return View(paymentReceiveds.ToList());
        }

        // GET: PaymentReceiveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentReceived paymentReceived = db.PaymentReceiveds.Find(id);
            if (paymentReceived == null)
            {
                return HttpNotFound();
            }
            return View(paymentReceived);
        }

        // GET: PaymentReceiveds/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: PaymentReceiveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountID,Amount,Date,Description,EmployeeID")] PaymentReceived paymentReceived)
        {
            if (ModelState.IsValid)
            {
                db.PaymentReceiveds.Add(paymentReceived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", paymentReceived.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", paymentReceived.EmployeeID);
            return View(paymentReceived);
        }

        // GET: PaymentReceiveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentReceived paymentReceived = db.PaymentReceiveds.Find(id);
            if (paymentReceived == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", paymentReceived.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", paymentReceived.EmployeeID);
            return View(paymentReceived);
        }

        // POST: PaymentReceiveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountID,Amount,Date,Description,EmployeeID")] PaymentReceived paymentReceived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentReceived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", paymentReceived.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", paymentReceived.EmployeeID);
            return View(paymentReceived);
        }

        // GET: PaymentReceiveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentReceived paymentReceived = db.PaymentReceiveds.Find(id);
            if (paymentReceived == null)
            {
                return HttpNotFound();
            }
            return View(paymentReceived);
        }

        // POST: PaymentReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentReceived paymentReceived = db.PaymentReceiveds.Find(id);
            db.PaymentReceiveds.Remove(paymentReceived);
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
