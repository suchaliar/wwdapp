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
    public class DeliveryMadesController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: DeliveryMades
        public ActionResult Index()
        {
            var deliveryMades = db.DeliveryMades.Include(d => d.Account).Include(d => d.Employee).Include(d => d.Employee1);
            return View(deliveryMades.ToList());
        }

        // GET: DeliveryMades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMade deliveryMade = db.DeliveryMades.Find(id);
            if (deliveryMade == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMade);
        }

        // GET: DeliveryMades/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.EmployeeDeliveredID = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: DeliveryMades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOrdered,DateDelivered,EmployeeOrderedID,EmployeeDeliveredID,Description,AccountID")] DeliveryMade deliveryMade)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryMades.Add(deliveryMade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", deliveryMade.AccountID);
            ViewBag.EmployeeDeliveredID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeDeliveredID);
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeOrderedID);
            return View(deliveryMade);
        }

        // GET: DeliveryMades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMade deliveryMade = db.DeliveryMades.Find(id);
            if (deliveryMade == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", deliveryMade.AccountID);
            ViewBag.EmployeeDeliveredID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeDeliveredID);
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeOrderedID);
            return View(deliveryMade);
        }

        // POST: DeliveryMades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOrdered,DateDelivered,EmployeeOrderedID,EmployeeDeliveredID,Description,AccountID")] DeliveryMade deliveryMade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryMade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", deliveryMade.AccountID);
            ViewBag.EmployeeDeliveredID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeDeliveredID);
            ViewBag.EmployeeOrderedID = new SelectList(db.Employees, "Id", "FirstName", deliveryMade.EmployeeOrderedID);
            return View(deliveryMade);
        }

        // GET: DeliveryMades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMade deliveryMade = db.DeliveryMades.Find(id);
            if (deliveryMade == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMade);
        }

        // POST: DeliveryMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryMade deliveryMade = db.DeliveryMades.Find(id);
            db.DeliveryMades.Remove(deliveryMade);
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
