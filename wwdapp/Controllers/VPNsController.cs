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
    public class VPNsController : Controller
    {
        private WhiteWaveDBEntities db = new WhiteWaveDBEntities();

        // GET: VPNs
        public ActionResult Index()
        {
            var vPNs = db.VPNs.Include(v => v.Account).Include(v => v.Protocol).Include(v => v.VPNClass);
            return View(vPNs.ToList());
        }

        // GET: VPNs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPN vPN = db.VPNs.Find(id);
            if (vPN == null)
            {
                return HttpNotFound();
            }
            return View(vPN);
        }

        // GET: VPNs/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.ProtocolID = new SelectList(db.Protocols, "Id", "Protocol1");
            ViewBag.ClassID = new SelectList(db.VPNClasses, "Id", "Class");
            return View();
        }

        // POST: VPNs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountID,ClassID,IPAddress,VirtualIPRange,AllowedLANAccess,Name,NeededBy,Purpose,ProtocolID")] VPN vPN)
        {
            if (ModelState.IsValid)
            {
                db.VPNs.Add(vPN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", vPN.AccountID);
            ViewBag.ProtocolID = new SelectList(db.Protocols, "Id", "Protocol1", vPN.ProtocolID);
            ViewBag.ClassID = new SelectList(db.VPNClasses, "Id", "Class", vPN.ClassID);
            return View(vPN);
        }

        // GET: VPNs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPN vPN = db.VPNs.Find(id);
            if (vPN == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", vPN.AccountID);
            ViewBag.ProtocolID = new SelectList(db.Protocols, "Id", "Protocol1", vPN.ProtocolID);
            ViewBag.ClassID = new SelectList(db.VPNClasses, "Id", "Class", vPN.ClassID);
            return View(vPN);
        }

        // POST: VPNs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountID,ClassID,IPAddress,VirtualIPRange,AllowedLANAccess,Name,NeededBy,Purpose,ProtocolID")] VPN vPN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vPN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "Id", "Name", vPN.AccountID);
            ViewBag.ProtocolID = new SelectList(db.Protocols, "Id", "Protocol1", vPN.ProtocolID);
            ViewBag.ClassID = new SelectList(db.VPNClasses, "Id", "Class", vPN.ClassID);
            return View(vPN);
        }

        // GET: VPNs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VPN vPN = db.VPNs.Find(id);
            if (vPN == null)
            {
                return HttpNotFound();
            }
            return View(vPN);
        }

        // POST: VPNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VPN vPN = db.VPNs.Find(id);
            db.VPNs.Remove(vPN);
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
