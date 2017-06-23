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
    public class AirborneOperationController : Controller
    {
        private AirborneBuddyContext db = new AirborneBuddyContext();

        // GET: AirborneOperation
        public ActionResult Index()
        {
            return View(db.AirborneOperations.ToList());
        }

        // GET: AirborneOperation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirborneOperation airborneOperation = db.AirborneOperations.Find(id);
            if (airborneOperation == null)
            {
                return HttpNotFound();
            }
            return View(airborneOperation);
        }

        // GET: AirborneOperation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirborneOperation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DropZone,AircraftPlatform,DateTime,PayPeriodCovered,JumpType")] AirborneOperation airborneOperation)
        {
            if (ModelState.IsValid)
            {
                db.AirborneOperations.Add(airborneOperation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airborneOperation);
        }

        // GET: AirborneOperation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirborneOperation airborneOperation = db.AirborneOperations.Find(id);
            if (airborneOperation == null)
            {
                return HttpNotFound();
            }
            return View(airborneOperation);
        }

        // POST: AirborneOperation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DropZone,AircraftPlatform,DateTime,PayPeriodCovered,JumpType")] AirborneOperation airborneOperation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airborneOperation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airborneOperation);
        }

        // GET: AirborneOperation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirborneOperation airborneOperation = db.AirborneOperations.Find(id);
            if (airborneOperation == null)
            {
                return HttpNotFound();
            }
            return View(airborneOperation);
        }

        // POST: AirborneOperation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirborneOperation airborneOperation = db.AirborneOperations.Find(id);
            db.AirborneOperations.Remove(airborneOperation);
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
