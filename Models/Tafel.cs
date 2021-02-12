using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Tafel
    {
        [Key]
        public int Id { get; set; }
        public int TafelNummer { get; set; }
        public TafelStatus TafelStatus { get; set; }
    }

    public enum TafelStatus
    {
        Vrij,
        Gereserveerd,
        Bezet,
        Afrekenen_gewenst
    }
}