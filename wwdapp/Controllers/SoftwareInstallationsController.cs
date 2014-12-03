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
    public class SoftwareInstallationsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: SoftwareInstallations
        public ActionResult Index()
        {
            var softwareInstallations = db.SoftwareInstallations.Include(s => s.Account).Include(s => s.Employee);
            return View(softwareInstallations.ToList());
        }

        // GET: SoftwareInstallations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareInstallation softwareInstallation = db.SoftwareInstallations.Find(id);
            if (softwareInstallation == null)
            {
                return HttpNotFound();
            }
            return View(softwareInstallation);
        }

        // GET: SoftwareInstallations/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: SoftwareInstallations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountID,EmployeeID,SoftwareName,Version,LicenseStart,LicenseEnd,MachineInstalledOn,Description")] SoftwareInstallation softwareInstallation)
        {
            if (ModelState.IsValid)
            {
                db.SoftwareInstallations.Add(softwareInstallation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", softwareInstallation.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", softwareInstallation.EmployeeID);
            return View(softwareInstallation);
        }

        // GET: SoftwareInstallations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareInstallation softwareInstallation = db.SoftwareInstallations.Find(id);
            if (softwareInstallation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", softwareInstallation.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", softwareInstallation.EmployeeID);
            return View(softwareInstallation);
        }

        // POST: SoftwareInstallations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountID,EmployeeID,SoftwareName,Version,LicenseStart,LicenseEnd,MachineInstalledOn,Description")] SoftwareInstallation softwareInstallation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwareInstallation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", softwareInstallation.AccountID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", softwareInstallation.EmployeeID);
            return View(softwareInstallation);
        }

        // GET: SoftwareInstallations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareInstallation softwareInstallation = db.SoftwareInstallations.Find(id);
            if (softwareInstallation == null)
            {
                return HttpNotFound();
            }
            return View(softwareInstallation);
        }

        // POST: SoftwareInstallations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoftwareInstallation softwareInstallation = db.SoftwareInstallations.Find(id);
            db.SoftwareInstallations.Remove(softwareInstallation);
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
