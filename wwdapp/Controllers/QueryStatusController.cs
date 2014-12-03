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
    public class QueryStatusController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: QueryStatus
        public ActionResult Index()
        {
            return View(db.QueryStatus.ToList());
        }

        // GET: QueryStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryStatu queryStatu = db.QueryStatus.Find(id);
            if (queryStatu == null)
            {
                return HttpNotFound();
            }
            return View(queryStatu);
        }

        // GET: QueryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QueryStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] QueryStatu queryStatu)
        {
            if (ModelState.IsValid)
            {
                db.QueryStatus.Add(queryStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(queryStatu);
        }

        // GET: QueryStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryStatu queryStatu = db.QueryStatus.Find(id);
            if (queryStatu == null)
            {
                return HttpNotFound();
            }
            return View(queryStatu);
        }

        // POST: QueryStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] QueryStatu queryStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queryStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(queryStatu);
        }

        // GET: QueryStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryStatu queryStatu = db.QueryStatus.Find(id);
            if (queryStatu == null)
            {
                return HttpNotFound();
            }
            return View(queryStatu);
        }

        // POST: QueryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QueryStatu queryStatu = db.QueryStatus.Find(id);
            db.QueryStatus.Remove(queryStatu);
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
