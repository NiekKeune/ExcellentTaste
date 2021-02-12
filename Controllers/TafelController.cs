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
    public class TafelController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Tafel
        public ActionResult Index()
        {
            return View(db.Tafels.ToList());
        }

        // GET: Tafel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tafel tafel = db.Tafels.Find(id);
            if (tafel == null)
            {
                return HttpNotFound();
            }
            return View(tafel);
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
