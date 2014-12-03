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
    public class IPAddressesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: IPAddresses
        public ActionResult Index()
        {
            var iPAddresses = db.IPAddresses.Include(i => i.Account);
            return View(iPAddresses.ToList());
        }

        // GET: IPAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPAddress iPAddress = db.IPAddresses.Find(id);
            if (iPAddress == null)
            {
                return HttpNotFound();
            }
            return View(iPAddress);
        }

        // GET: IPAddresses/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            return View();
        }

        // POST: IPAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IP,Name,Purpose,Description,AccountID")] IPAddress iPAddress)
        {
            if (ModelState.IsValid)
            {
                db.IPAddresses.Add(iPAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", iPAddress.AccountID);
            return View(iPAddress);
        }

        // GET: IPAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPAddress iPAddress = db.IPAddresses.Find(id);
            if (iPAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", iPAddress.AccountID);
            return View(iPAddress);
        }

        // POST: IPAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IP,Name,Purpose,Description,AccountID")] IPAddress iPAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iPAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", iPAddress.AccountID);
            return View(iPAddress);
        }

        // GET: IPAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPAddress iPAddress = db.IPAddresses.Find(id);
            if (iPAddress == null)
            {
                return HttpNotFound();
            }
            return View(iPAddress);
        }

        // POST: IPAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IPAddress iPAddress = db.IPAddresses.Find(id);
            db.IPAddresses.Remove(iPAddress);
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
