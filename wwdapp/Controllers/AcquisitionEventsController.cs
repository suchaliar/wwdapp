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
    public class AcquisitionEventsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: AcquisitionEvents
        public ActionResult Index()
        {
            var acquisitionEvents = db.AcquisitionEvents.Include(a => a.DeliveryReceived).Include(a => a.Vendor);
            return View(acquisitionEvents.ToList());
        }

        // GET: AcquisitionEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcquisitionEvent acquisitionEvent = db.AcquisitionEvents.Find(id);
            if (acquisitionEvent == null)
            {
                return HttpNotFound();
            }
            return View(acquisitionEvent);
        }

        // GET: AcquisitionEvents/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryID = new SelectList(db.DeliveryReceiveds, "Id", "Description");
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name");
            return View();
        }

        // POST: AcquisitionEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,VendorID,AmtPaid,Description,Justification,DeliveryID")] AcquisitionEvent acquisitionEvent)
        {
            if (ModelState.IsValid)
            {
                db.AcquisitionEvents.Add(acquisitionEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryID = new SelectList(db.DeliveryReceiveds, "Id", "Description", acquisitionEvent.DeliveryID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", acquisitionEvent.VendorID);
            return View(acquisitionEvent);
        }

        // GET: AcquisitionEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcquisitionEvent acquisitionEvent = db.AcquisitionEvents.Find(id);
            if (acquisitionEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryID = new SelectList(db.DeliveryReceiveds, "Id", "Description", acquisitionEvent.DeliveryID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", acquisitionEvent.VendorID);
            return View(acquisitionEvent);
        }

        // POST: AcquisitionEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,VendorID,AmtPaid,Description,Justification,DeliveryID")] AcquisitionEvent acquisitionEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acquisitionEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryID = new SelectList(db.DeliveryReceiveds, "Id", "Description", acquisitionEvent.DeliveryID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", acquisitionEvent.VendorID);
            return View(acquisitionEvent);
        }

        // GET: AcquisitionEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcquisitionEvent acquisitionEvent = db.AcquisitionEvents.Find(id);
            if (acquisitionEvent == null)
            {
                return HttpNotFound();
            }
            return View(acquisitionEvent);
        }

        // POST: AcquisitionEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcquisitionEvent acquisitionEvent = db.AcquisitionEvents.Find(id);
            db.AcquisitionEvents.Remove(acquisitionEvent);
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
