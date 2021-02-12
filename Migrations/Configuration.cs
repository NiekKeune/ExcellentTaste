namespace Restaurant.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Restaurant.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.DAL.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Restaurant.DAL.RestaurantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Voedsel Voedsel1 = new Voedsel
            {
                Naam = "Bitterballen",
                Beschikbaar = true,
                Btw_Tarief = Btw_Tarief.Low,
                Prijs = 1.50,
                VoedselType = VoedselType.Snacks
            };
            Voedsel Voedsel2 = new Voedsel
            {
                Naam = "Bier",
                Beschikbaar = true,
                Btw_Tarief = Btw_Tarief.High,
                Prijs = 2,
                VoedselType = VoedselType.Alcohol
            };

            Voedsel Voedsel3 = new Voedsel
            {
                Naam = "Boerenkool",
                Beschikbaar = true,
                Btw_Tarief = Btw_Tarief.Low,
                Prijs = 7,
                VoedselType = VoedselType.Hoofdgerechten
            };

            Voedsel Voedsel4 = new Voedsel
            {
                Naam = "Pizza Hawaii",
                Beschikbaar = false,
                Btw_Tarief = Btw_Tarief.Low,
                Prijs = 20,
                VoedselType = VoedselType.Hoofdgerechten
            };
            new List<Voedsel> { Voedsel1, Voedsel2, Voedsel3, Voedsel4 }.ForEach(x => context.Voedsel.AddOrUpdate(x));
            context.Voedsel.AddRange(new List<Voedsel> { Voedsel1, Voedsel2, Voedsel3, Voedsel4});
            context.SaveChanges();

            Medewerker Medewerker1 = new Medewerker
            {
                Id = 1,
                Naam = "Jan Slager",
                Beschikbaar = true,
                Rol = Rol.Ober
            };

            Medewerker Medewerker2 = new Medewerker
            {
                Id = 2,
                Naam = "Piet Visser",
                Beschikbaar = false,
                Rol = Rol.Ober
            };

            Medewerker Medewerker3 = new Medewerker
            {
                Id = 3,
                Naam = "Klaas Bakker",
                Beschikbaar = true,
                Rol = Rol.Kok
            };

            Medewerker Medewerker4 = new Medewerker
            {
                Id = 4,
                Naam = "Bart Molenaar",
                Rol = Rol.Barman
            };
            new List<Medewerker> { Medewerker1, Medewerker2, Medewerker3, Medewerker4 }.ForEach(x => context.Medewerkers.AddOrUpdate(x));
            context.SaveChanges();

            Tafel Tafel1 = new Tafel
            {
                Id = 1,
                TafelNummer = 1,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel2 = new Tafel
            {
                Id = 2,
                TafelNummer = 2,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel3 = new Tafel
            {
                Id = 3,
                TafelNummer = 3,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel4 = new Tafel
            {
                Id = 4,
                TafelNummer = 4,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel5 = new Tafel
            {
                Id = 5,
                TafelNummer = 5,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel6 = new Tafel
            {
                Id = 6,
                TafelNummer = 6,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel7 = new Tafel
            {
                Id = 7,
                TafelNummer = 7,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel8 = new Tafel
            {
                Id = 8,
                TafelNummer = 8,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel9 = new Tafel
            {
                Id = 9,
                TafelNummer = 9,
                TafelStatus = TafelStatus.Vrij
            };

            Tafel Tafel10 = new Tafel
            {
                Id = 10,
                TafelNummer = 10,
                TafelStatus = TafelStatus.Vrij
            };
            new List<Tafel> { Tafel1, Tafel2, Tafel3, Tafel4, Tafel5, Tafel6, Tafel7, Tafel8, Tafel9, Tafel10 }.ForEach(x => context.Tafels.AddOrUpdate(x));
            context.SaveChanges();

            CreateMockdata(context);
        }

        private void CreateMockdata(Restaurant.DAL.RestaurantContext context)
        {
            Reservatie Reservatie1 = new Reservatie
            {
                Id = 1,
                KlantNaam = "Hendrik Veen",
                Datum = new DateTime(2020, 2, 2),
                Tijd = new TimeSpan(17, 12, 54),
                ReservatieType = ReservatieType.Diner
            };

            Reservatie Reservatie2 = new Reservatie
            {
                Id = 2,
                KlantNaam = "Rianne Visser",
                Datum = new DateTime(2020, 2, 2),
                Tijd = new TimeSpan(11, 30, 12),
                ReservatieType = ReservatieType.Lunch
            };

            Reservatie Reservatie3 = new Reservatie
            {
                Id = 3,
                KlantNaam = "Dirk Kavelaar",
                Datum = new DateTime(2020, 2, 19),
                Tijd = new TimeSpan(19, 0, 0),
                ReservatieType = ReservatieType.Diner
            };
            new List<Reservatie> { Reservatie1, Reservatie2, Reservatie3 }.ForEach(x => context.Reservaties.AddOrUpdate(x));
            context.SaveChanges();

            Order Order1 = new Order
            {
                Medewerker = context.Medewerkers.FirstOrDefault(m => m.Naam == "Piet Visser"),
                Reservatie = context.Reservaties.FirstOrDefault(r => r.KlantNaam == "Dirk Kavelaar"),
                Orderregel = new List<Orderregel>
                {
                    new Orderregel
                    {
                        Voedsel = context.Voedsel.FirstOrDefault(v => v.Naam == "Boerenkool"),
                        Aantal = 1,
                        Gereed = false
                    },
                    new Orderregel
                    {
                        Voedsel = context.Voedsel.FirstOrDefault(v => v.Naam == "Bier"),
                        Aantal = 2,
                        Gereed = false
                    }
                }

            };
            new List<Order> { Order1 }.ForEach(x => context.Orders.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}