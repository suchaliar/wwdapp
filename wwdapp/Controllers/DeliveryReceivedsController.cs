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
    public class DeliveryReceivedsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: DeliveryReceiveds
        public ActionResult Index()
        {
            var deliveryReceiveds = db.DeliveryReceiveds.Include(d => d.Employee).Include(d => d.Employee1);
            return View(deliveryReceiveds.ToList());
        }

        // GET: DeliveryReceiveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryReceived deliveryReceived = db.DeliveryReceiveds.Find(id);
            if (deliveryReceived == null)
            {
                return HttpNotFound();
            }
            return View(deliveryReceived);
        }

        // GET: DeliveryReceiveds/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.EmployeeReceivingID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: DeliveryReceiveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOrdered,EmployeeOrderedID,Description,DateReceived,EmployeeReceivingID")] DeliveryReceived deliveryReceived)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryReceiveds.Add(deliveryReceived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeOrderedID);
            ViewBag.EmployeeReceivingID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeReceivingID);
            return View(deliveryReceived);
        }

        // GET: DeliveryReceiveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryReceived deliveryReceived = db.DeliveryReceiveds.Find(id);
            if (deliveryReceived == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeOrderedID);
            ViewBag.EmployeeReceivingID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeReceivingID);
            return View(deliveryReceived);
        }

        // POST: DeliveryReceiveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOrdered,EmployeeOrderedID,Description,DateReceived,EmployeeReceivingID")] DeliveryReceived deliveryReceived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryReceived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeOrderedID);
            ViewBag.EmployeeReceivingID = new SelectList(db.Employees, "Id", "FirstName", deliveryReceived.EmployeeReceivingID);
            return View(deliveryReceived);
        }

        // GET: DeliveryReceiveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryReceived deliveryReceived = db.DeliveryReceiveds.Find(id);
            if (deliveryReceived == null)
            {
                return HttpNotFound();
            }
            return View(deliveryReceived);
        }

        // POST: DeliveryReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryReceived deliveryReceived = db.DeliveryReceiveds.Find(id);
            db.DeliveryReceiveds.Remove(deliveryReceived);
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
