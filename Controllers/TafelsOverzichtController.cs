using Restaurant.ViewModels;
using Restaurant.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.DAL;

namespace Restaurant.Controllers
{
    public class TafelsOverzichtController : Controller
    {
        RestaurantContext context = new RestaurantContext();

        // GET: TafelsOverzicht
        public ActionResult Index()
        {
            var tafelOverzichtViewModel = new TafelOverzichtViewModel
            {
                AlleTijdstippen = Constants.Constants.tijdstippen,
                AlleTafels = context.Tafels.ToList()
            };
            return View(tafelOverzichtViewModel); 
        }
    }
}