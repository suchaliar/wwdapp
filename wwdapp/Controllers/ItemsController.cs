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
    public class ItemsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.AcquisitionEvent).Include(i => i.DeliveryMade).Include(i => i.ItemStatu).Include(i => i.ItemType);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.AcquisitionEventID = new SelectList(db.AcquisitionEvents, "Id", "Description");
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description");
            ViewBag.ItemStatusID = new SelectList(db.ItemStatus, "Id", "Status");
            ViewBag.ItemTypeID = new SelectList(db.ItemTypes, "Id", "ItemType1");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Model,Description,Cost,AcquisitionEventID,ItemStatusID,ItemTypeID,DeliveryMadeID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcquisitionEventID = new SelectList(db.AcquisitionEvents, "Id", "Description", item.AcquisitionEventID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", item.DeliveryMadeID);
            ViewBag.ItemStatusID = new SelectList(db.ItemStatus, "Id", "Status", item.ItemStatusID);
            ViewBag.ItemTypeID = new SelectList(db.ItemTypes, "Id", "ItemType1", item.ItemTypeID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcquisitionEventID = new SelectList(db.AcquisitionEvents, "Id", "Description", item.AcquisitionEventID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", item.DeliveryMadeID);
            ViewBag.ItemStatusID = new SelectList(db.ItemStatus, "Id", "Status", item.ItemStatusID);
            ViewBag.ItemTypeID = new SelectList(db.ItemTypes, "Id", "ItemType1", item.ItemTypeID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Model,Description,Cost,AcquisitionEventID,ItemStatusID,ItemTypeID,DeliveryMadeID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcquisitionEventID = new SelectList(db.AcquisitionEvents, "Id", "Description", item.AcquisitionEventID);
            ViewBag.DeliveryMadeID = new SelectList(db.DeliveryMades, "Id", "Description", item.DeliveryMadeID);
            ViewBag.ItemStatusID = new SelectList(db.ItemStatus, "Id", "Status", item.ItemStatusID);
            ViewBag.ItemTypeID = new SelectList(db.ItemTypes, "Id", "ItemType1", item.ItemTypeID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
