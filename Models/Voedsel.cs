using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Voedsel
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public VoedselType VoedselType { get; set; }
        public double Prijs { get; set; }
        public Btw_Tarief Btw_Tarief { get; set; }
        public bool Beschikbaar { get; set; }
    }

    public enum VoedselType
    {
        Soepen,
        Hoofdgerechten,
        Snacks,
        Alcoholvrije_Dranken,
        Alcohol,
        Desserts
    }

    public enum Btw_Tarief
    {
        Low = 9,
        High = 21
    }
}