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
    public class QueryEventsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: QueryEvents
        public ActionResult Index()
        {
            var queryEvents = db.QueryEvents.Include(q => q.ContactInformation).Include(q => q.QueryStatu).Include(q => q.QueryType);
            return View(queryEvents.ToList());
        }

        // GET: QueryEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryEvent queryEvent = db.QueryEvents.Find(id);
            if (queryEvent == null)
            {
                return HttpNotFound();
            }
            return View(queryEvent);
        }

        // GET: QueryEvents/Create
        public ActionResult Create()
        {
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1");
            ViewBag.StatusID = new SelectList(db.QueryStatus, "Id", "Status");
            ViewBag.TypeID = new SelectList(db.QueryTypes, "Id", "Type");
            return View();
        }

        // POST: QueryEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContactInformationID,Description,Date,StatusID,TypeID")] QueryEvent queryEvent)
        {
            if (ModelState.IsValid)
            {
                db.QueryEvents.Add(queryEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", queryEvent.ContactInformationID);
            ViewBag.StatusID = new SelectList(db.QueryStatus, "Id", "Status", queryEvent.StatusID);
            ViewBag.TypeID = new SelectList(db.QueryTypes, "Id", "Type", queryEvent.TypeID);
            return View(queryEvent);
        }

        // GET: QueryEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryEvent queryEvent = db.QueryEvents.Find(id);
            if (queryEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", queryEvent.ContactInformationID);
            ViewBag.StatusID = new SelectList(db.QueryStatus, "Id", "Status", queryEvent.StatusID);
            ViewBag.TypeID = new SelectList(db.QueryTypes, "Id", "Type", queryEvent.TypeID);
            return View(queryEvent);
        }

        // POST: QueryEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactInformationID,Description,Date,StatusID,TypeID")] QueryEvent queryEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queryEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactInformationID = new SelectList(db.ContactInformations, "Id", "Phone1", queryEvent.ContactInformationID);
            ViewBag.StatusID = new SelectList(db.QueryStatus, "Id", "Status", queryEvent.StatusID);
            ViewBag.TypeID = new SelectList(db.QueryTypes, "Id", "Type", queryEvent.TypeID);
            return View(queryEvent);
        }

        // GET: QueryEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryEvent queryEvent = db.QueryEvents.Find(id);
            if (queryEvent == null)
            {
                return HttpNotFound();
            }
            return View(queryEvent);
        }

        // POST: QueryEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QueryEvent queryEvent = db.QueryEvents.Find(id);
            db.QueryEvents.Remove(queryEvent);
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
