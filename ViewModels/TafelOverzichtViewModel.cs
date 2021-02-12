using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModels
{
    public class TafelOverzichtViewModel
    {
        public List<Tafel> AlleTafels { get; set; }
        public List<TimeSpan> AlleTijdstippen { get; set; }
        public DateTime Dag { get; set; }
        public List<Reservatie> Reservaties { get; set; }
    }
}