using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirborneBuddy.DAL;
using AirborneBuddy.Models;

namespace AirborneBuddy.Controllers
{
    public class ParatrooperController : Controller
    {
        private AirborneBuddyContext db = new AirborneBuddyContext();

        // GET: Paratroopers
        public ActionResult Index()
        {
            var paratroopers = db.Paratroopers.Include(p => p.Organization).Include(p => p.Qualification);
            return View(paratroopers.ToList());
        }

        // GET: Paratroopers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paratrooper paratrooper = db.Paratroopers.Find(id);
            if (paratrooper == null)
            {
                return HttpNotFound();
            }
            return View(paratrooper);
        }

        // GET: Paratroopers/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Unit");
            ViewBag.QualificationID = new SelectList(db.Qualifications, "ID", "ID");
            return View();
        }

        // POST: Paratroopers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,CurrentStatus,OrganizationID,QualificationID")] Paratrooper paratrooper)
        {
            if (ModelState.IsValid)
            {
                db.Paratroopers.Add(paratrooper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Unit", paratrooper.OrganizationID);
            ViewBag.QualificationID = new SelectList(db.Qualifications, "ID", "ID", paratrooper.QualificationID);
            return View(paratrooper);
        }

        // GET: Paratroopers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paratrooper paratrooper = db.Paratroopers.Find(id);
            if (paratrooper == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Unit", paratrooper.OrganizationID);
            ViewBag.QualificationID = new SelectList(db.Qualifications, "ID", "ID", paratrooper.QualificationID);
            return View(paratrooper);
        }

        // POST: Paratroopers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,CurrentStatus,OrganizationID,QualificationID")] Paratrooper paratrooper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paratrooper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Unit", paratrooper.OrganizationID);
            ViewBag.QualificationID = new SelectList(db.Qualifications, "ID", "ID", paratrooper.QualificationID);
            return View(paratrooper);
        }

        // GET: Paratroopers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paratrooper paratrooper = db.Paratroopers.Find(id);
            if (paratrooper == null)
            {
                return HttpNotFound();
            }
            return View(paratrooper);
        }

        // POST: Paratroopers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paratrooper paratrooper = db.Paratroopers.Find(id);
            db.Paratroopers.Remove(paratrooper);
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
