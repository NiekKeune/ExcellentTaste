using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.DAL;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ReservatieController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Reservatie
        public ActionResult Index()
        {
            IEnumerable<Restaurant.Models.Reservatie> ReservatieList = db.Reservaties.ToList();
            return View(ReservatieList);
        }

        // GET: Reservatie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            return View(reservatie);
        }

        // GET: Reservatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservatie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KlantNaam,Datum,Tijd,ReservatieType")] Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                db.Reservaties.Add(reservatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservatie);
        }

        // GET: Reservatie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            return View(reservatie);
        }

        // POST: Reservatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KlantNaam,Datum,Tijd,ReservatieType")] Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservatie);
        }

        // GET: Reservatie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservatie reservatie = db.Reservaties.Find(id);
            if (reservatie == null)
            {
                return HttpNotFound();
            }
            return View(reservatie);
        }

        // POST: Reservatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservatie reservatie = db.Reservaties.Find(id);
            db.Reservaties.Remove(reservatie);
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
