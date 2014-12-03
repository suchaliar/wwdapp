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
    public class InternetDomainsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: InternetDomains
        public ActionResult Index()
        {
            var internetDomains = db.InternetDomains.Include(i => i.Account).Include(i => i.ContactInformation);
            return View(internetDomains.ToList());
        }

        // GET: InternetDomains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetDomain internetDomain = db.InternetDomains.Find(id);
            if (internetDomain == null)
            {
                return HttpNotFound();
            }
            return View(internetDomain);
        }

        // GET: InternetDomains/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.AdministrativeContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1");
            return View();
        }

        // POST: InternetDomains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountID,Registrant,DomainName,RegistrarName,RegistrarHomepage,Username,Password,AdministrativeContactName,AdministrativeContactInformationID,CreatedOn,ExpiresOn")] InternetDomain internetDomain)
        {
            if (ModelState.IsValid)
            {
                db.InternetDomains.Add(internetDomain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", internetDomain.AccountID);
            ViewBag.AdministrativeContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", internetDomain.AdministrativeContactInformationID);
            return View(internetDomain);
        }

        // GET: InternetDomains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetDomain internetDomain = db.InternetDomains.Find(id);
            if (internetDomain == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", internetDomain.AccountID);
            ViewBag.AdministrativeContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", internetDomain.AdministrativeContactInformationID);
            return View(internetDomain);
        }

        // POST: InternetDomains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountID,Registrant,DomainName,RegistrarName,RegistrarHomepage,Username,Password,AdministrativeContactName,AdministrativeContactInformationID,CreatedOn,ExpiresOn")] InternetDomain internetDomain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internetDomain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", internetDomain.AccountID);
            ViewBag.AdministrativeContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", internetDomain.AdministrativeContactInformationID);
            return View(internetDomain);
        }

        // GET: InternetDomains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetDomain internetDomain = db.InternetDomains.Find(id);
            if (internetDomain == null)
            {
                return HttpNotFound();
            }
            return View(internetDomain);
        }

        // POST: InternetDomains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InternetDomain internetDomain = db.InternetDomains.Find(id);
            db.InternetDomains.Remove(internetDomain);
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
