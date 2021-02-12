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
    public class OrderregelController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Orderregel
        public ActionResult Index()
        {
            return View(db.Orderregels.ToList());
        }

        // GET: Orderregel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderregel orderregel = db.Orderregels.Find(id);
            if (orderregel == null)
            {
                return HttpNotFound();
            }
            return View(orderregel);
        }

        // GET: Orderregel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orderregel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aantal,Gereed")] Orderregel orderregel)
        {
            if (ModelState.IsValid)
            {
                db.Orderregels.Add(orderregel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderregel);
        }

        // GET: Orderregel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderregel orderregel = db.Orderregels.Find(id);
            if (orderregel == null)
            {
                return HttpNotFound();
            }
            return View(orderregel);
        }

        // POST: Orderregel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aantal,Gereed")] Orderregel orderregel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderregel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderregel);
        }

        // GET: Orderregel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderregel orderregel = db.Orderregels.Find(id);
            if (orderregel == null)
            {
                return HttpNotFound();
            }
            return View(orderregel);
        }

        // POST: Orderregel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orderregel orderregel = db.Orderregels.Find(id);
            db.Orderregels.Remove(orderregel);
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
