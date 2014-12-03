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
    public class MOUsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: MOUs
        public ActionResult Index()
        {
            var mOUs = db.MOUs.Include(m => m.ContactInformation);
            return View(mOUs.ToList());
        }

        // GET: MOUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOU mOU = db.MOUs.Find(id);
            if (mOU == null)
            {
                return HttpNotFound();
            }
            return View(mOU);
        }

        // GET: MOUs/Create
        public ActionResult Create()
        {
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1");
            return View();
        }

        // POST: MOUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Description,Name,Date,ContactInformationID")] MOU mOU)
        {
            if (ModelState.IsValid)
            {
                db.MOUs.Add(mOU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", mOU.ContactInformationID);
            return View(mOU);
        }

        // GET: MOUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOU mOU = db.MOUs.Find(id);
            if (mOU == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", mOU.ContactInformationID);
            return View(mOU);
        }

        // POST: MOUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Description,Name,Date,ContactInformationID")] MOU mOU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", mOU.ContactInformationID);
            return View(mOU);
        }

        // GET: MOUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOU mOU = db.MOUs.Find(id);
            if (mOU == null)
            {
                return HttpNotFound();
            }
            return View(mOU);
        }

        // POST: MOUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOU mOU = db.MOUs.Find(id);
            db.MOUs.Remove(mOU);
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
