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
    public class VendorStatusController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: VendorStatus
        public ActionResult Index()
        {
            return View(db.VendorStatus.ToList());
        }

        // GET: VendorStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorStatu vendorStatu = db.VendorStatus.Find(id);
            if (vendorStatu == null)
            {
                return HttpNotFound();
            }
            return View(vendorStatu);
        }

        // GET: VendorStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] VendorStatu vendorStatu)
        {
            if (ModelState.IsValid)
            {
                db.VendorStatus.Add(vendorStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorStatu);
        }

        // GET: VendorStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorStatu vendorStatu = db.VendorStatus.Find(id);
            if (vendorStatu == null)
            {
                return HttpNotFound();
            }
            return View(vendorStatu);
        }

        // POST: VendorStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] VendorStatu vendorStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorStatu);
        }

        // GET: VendorStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorStatu vendorStatu = db.VendorStatus.Find(id);
            if (vendorStatu == null)
            {
                return HttpNotFound();
            }
            return View(vendorStatu);
        }

        // POST: VendorStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorStatu vendorStatu = db.VendorStatus.Find(id);
            db.VendorStatus.Remove(vendorStatu);
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
