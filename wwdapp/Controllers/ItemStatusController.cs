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
    public class ItemStatusController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: ItemStatus
        public ActionResult Index()
        {
            return View(db.ItemStatus.ToList());
        }

        // GET: ItemStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemStatu itemStatu = db.ItemStatus.Find(id);
            if (itemStatu == null)
            {
                return HttpNotFound();
            }
            return View(itemStatu);
        }

        // GET: ItemStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] ItemStatu itemStatu)
        {
            if (ModelState.IsValid)
            {
                db.ItemStatus.Add(itemStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemStatu);
        }

        // GET: ItemStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemStatu itemStatu = db.ItemStatus.Find(id);
            if (itemStatu == null)
            {
                return HttpNotFound();
            }
            return View(itemStatu);
        }

        // POST: ItemStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] ItemStatu itemStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemStatu);
        }

        // GET: ItemStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemStatu itemStatu = db.ItemStatus.Find(id);
            if (itemStatu == null)
            {
                return HttpNotFound();
            }
            return View(itemStatu);
        }

        // POST: ItemStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemStatu itemStatu = db.ItemStatus.Find(id);
            db.ItemStatus.Remove(itemStatu);
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
