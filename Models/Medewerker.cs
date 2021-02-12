using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Medewerker
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public Rol Rol { get; set; }
        public bool Beschikbaar { get; set; }
    }

    public enum Rol
    {
        Ober,
        Kok,
        Barman
    }
}