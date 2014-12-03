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
    public class AccountContactsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: AccountContacts
        public ActionResult Index()
        {
            var accountContacts = db.AccountContacts.Include(a => a.Account).Include(a => a.ContactInformation);
            return View(accountContacts.ToList());
        }

        // GET: AccountContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountContact accountContact = db.AccountContacts.Find(id);
            if (accountContact == null)
            {
                return HttpNotFound();
            }
            return View(accountContact);
        }

        // GET: AccountContacts/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1");
            return View();
        }

        // POST: AccountContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactInformationID,Description,AccountID")] AccountContact accountContact)
        {
            if (ModelState.IsValid)
            {
                db.AccountContacts.Add(accountContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", accountContact.AccountID);
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", accountContact.ContactInformationID);
            return View(accountContact);
        }

        // GET: AccountContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountContact accountContact = db.AccountContacts.Find(id);
            if (accountContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", accountContact.AccountID);
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", accountContact.ContactInformationID);
            return View(accountContact);
        }

        // POST: AccountContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactInformationID,Description,AccountID")] AccountContact accountContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", accountContact.AccountID);
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", accountContact.ContactInformationID);
            return View(accountContact);
        }

        // GET: AccountContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountContact accountContact = db.AccountContacts.Find(id);
            if (accountContact == null)
            {
                return HttpNotFound();
            }
            return View(accountContact);
        }

        // POST: AccountContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountContact accountContact = db.AccountContacts.Find(id);
            db.AccountContacts.Remove(accountContact);
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
