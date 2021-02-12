using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Reservatie
    {
        [Key]
        public int Id { get; set; }
        public string KlantNaam { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Tijd { get; set; }
        public Tafel Tafel { get; set; }
        public virtual ReservatieType ReservatieType { get; set; }
    }
    
    public enum ReservatieType
    {
        Lunch,
        Diner
    }
}