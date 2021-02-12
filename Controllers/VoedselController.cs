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
    public class VoedselController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Voedsel
        public ActionResult Index()
        {
            return View(db.Voedsel.ToList());
        }

        // GET: Voedsel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voedsel voedsel = db.Voedsel.Find(id);
            if (voedsel == null)
            {
                return HttpNotFound();
            }
            return View(voedsel);
        }

        // GET: Voedsel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voedsel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,VoedselType,Prijs,Btw_Tarief,Beschikbaar")] Voedsel voedsel)
        {
            if (ModelState.IsValid)
            {
                db.Voedsel.Add(voedsel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voedsel);
        }

        // GET: Voedsel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voedsel voedsel = db.Voedsel.Find(id);
            if (voedsel == null)
            {
                return HttpNotFound();
            }
            return View(voedsel);
        }

        // POST: Voedsel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,VoedselType,Prijs,Btw_Tarief,Beschikbaar")] Voedsel voedsel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voedsel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voedsel);
        }

        // GET: Voedsel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voedsel voedsel = db.Voedsel.Find(id);
            if (voedsel == null)
            {
                return HttpNotFound();
            }
            return View(voedsel);
        }

        // POST: Voedsel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voedsel voedsel = db.Voedsel.Find(id);
            db.Voedsel.Remove(voedsel);
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
