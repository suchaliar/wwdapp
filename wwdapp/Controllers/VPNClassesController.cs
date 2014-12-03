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
    public class VPNClassesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: VPNClasses
        public ActionResult Index()
        {
            return View(db.VPNClasses.ToList());
        }

        // GET: VPNClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPNClass vPNClass = db.VPNClasses.Find(id);
            if (vPNClass == null)
            {
                return HttpNotFound();
            }
            return View(vPNClass);
        }

        // GET: VPNClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VPNClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Class")] VPNClass vPNClass)
        {
            if (ModelState.IsValid)
            {
                db.VPNClasses.Add(vPNClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vPNClass);
        }

        // GET: VPNClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPNClass vPNClass = db.VPNClasses.Find(id);
            if (vPNClass == null)
            {
                return HttpNotFound();
            }
            return View(vPNClass);
        }

        // POST: VPNClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Class")] VPNClass vPNClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vPNClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vPNClass);
        }

        // GET: VPNClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPNClass vPNClass = db.VPNClasses.Find(id);
            if (vPNClass == null)
            {
                return HttpNotFound();
            }
            return View(vPNClass);
        }

        // POST: VPNClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VPNClass vPNClass = db.VPNClasses.Find(id);
            db.VPNClasses.Remove(vPNClass);
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
