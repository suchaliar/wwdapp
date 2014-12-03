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
    public class SupportAgreementsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: SupportAgreements
        public ActionResult Index()
        {
            var supportAgreements = db.SupportAgreements.Include(s => s.Account);
            return View(supportAgreements.ToList());
        }

        // GET: SupportAgreements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportAgreement supportAgreement = db.SupportAgreements.Find(id);
            if (supportAgreement == null)
            {
                return HttpNotFound();
            }
            return View(supportAgreement);
        }

        // GET: SupportAgreements/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            return View();
        }

        // POST: SupportAgreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Description,AccountID,DateStart,DateEnd")] SupportAgreement supportAgreement)
        {
            if (ModelState.IsValid)
            {
                db.SupportAgreements.Add(supportAgreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", supportAgreement.AccountID);
            return View(supportAgreement);
        }

        // GET: SupportAgreements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportAgreement supportAgreement = db.SupportAgreements.Find(id);
            if (supportAgreement == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", supportAgreement.AccountID);
            return View(supportAgreement);
        }

        // POST: SupportAgreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Description,AccountID,DateStart,DateEnd")] SupportAgreement supportAgreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportAgreement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", supportAgreement.AccountID);
            return View(supportAgreement);
        }

        // GET: SupportAgreements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportAgreement supportAgreement = db.SupportAgreements.Find(id);
            if (supportAgreement == null)
            {
                return HttpNotFound();
            }
            return View(supportAgreement);
        }

        // POST: SupportAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportAgreement supportAgreement = db.SupportAgreements.Find(id);
            db.SupportAgreements.Remove(supportAgreement);
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
