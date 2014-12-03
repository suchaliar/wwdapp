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
    public class VendorContactsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: VendorContacts
        public ActionResult Index()
        {
            var vendorContacts = db.VendorContacts.Include(v => v.ContactInformation).Include(v => v.Vendor);
            return View(vendorContacts.ToList());
        }

        // GET: VendorContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorContact vendorContact = db.VendorContacts.Find(id);
            if (vendorContact == null)
            {
                return HttpNotFound();
            }
            return View(vendorContact);
        }

        // GET: VendorContacts/Create
        public ActionResult Create()
        {
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1");
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name");
            return View();
        }

        // POST: VendorContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactInformationID,Description,VendorID")] VendorContact vendorContact)
        {
            if (ModelState.IsValid)
            {
                db.VendorContacts.Add(vendorContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", vendorContact.ContactInformationID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", vendorContact.VendorID);
            return View(vendorContact);
        }

        // GET: VendorContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorContact vendorContact = db.VendorContacts.Find(id);
            if (vendorContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", vendorContact.ContactInformationID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", vendorContact.VendorID);
            return View(vendorContact);
        }

        // POST: VendorContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactInformationID,Description,VendorID")] VendorContact vendorContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", vendorContact.ContactInformationID);
            ViewBag.VendorID = new SelectList(db.Vendors, "Id", "Name", vendorContact.VendorID);
            return View(vendorContact);
        }

        // GET: VendorContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorContact vendorContact = db.VendorContacts.Find(id);
            if (vendorContact == null)
            {
                return HttpNotFound();
            }
            return View(vendorContact);
        }

        // POST: VendorContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorContact vendorContact = db.VendorContacts.Find(id);
            db.VendorContacts.Remove(vendorContact);
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
