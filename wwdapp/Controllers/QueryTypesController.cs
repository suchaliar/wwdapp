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
    public class QueryTypesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: QueryTypes
        public ActionResult Index()
        {
            return View(db.QueryTypes.ToList());
        }

        // GET: QueryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryType queryType = db.QueryTypes.Find(id);
            if (queryType == null)
            {
                return HttpNotFound();
            }
            return View(queryType);
        }

        // GET: QueryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QueryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] QueryType queryType)
        {
            if (ModelState.IsValid)
            {
                db.QueryTypes.Add(queryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(queryType);
        }

        // GET: QueryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryType queryType = db.QueryTypes.Find(id);
            if (queryType == null)
            {
                return HttpNotFound();
            }
            return View(queryType);
        }

        // POST: QueryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] QueryType queryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(queryType);
        }

        // GET: QueryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QueryType queryType = db.QueryTypes.Find(id);
            if (queryType == null)
            {
                return HttpNotFound();
            }
            return View(queryType);
        }

        // POST: QueryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QueryType queryType = db.QueryTypes.Find(id);
            db.QueryTypes.Remove(queryType);
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
