using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public virtual List<Orderregel> Orderregel { get; set; }
        public Reservatie Reservatie { get; set; }
        public Medewerker Medewerker { get; set; }
    }
}