using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Orderregel
    {
        [Key]
        public int Id { get; set; }
        public Voedsel Voedsel { get; set; }
        public int Aantal { get; set; }
        public bool Gereed { get; set; }
    }

}