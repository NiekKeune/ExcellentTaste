using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant.DAL
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("DefaultConnection")
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Orderregel> Orderregels { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Voedsel> Voedsel { get; set; }
        public DbSet<Tafel> Tafels { get; set; }
    }
}