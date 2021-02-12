namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medewerkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Rol = c.Int(nullable: false),
                        Beschikbaar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Medewerker_Id = c.Int(),
                        Reservatie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medewerkers", t => t.Medewerker_Id)
                .ForeignKey("dbo.Reservaties", t => t.Reservatie_Id)
                .Index(t => t.Medewerker_Id)
                .Index(t => t.Reservatie_Id);
            
            CreateTable(
                "dbo.Orderregels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aantal = c.Int(nullable: false),
                        Gereed = c.Boolean(nullable: false),
                        Voedsel_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voedsels", t => t.Voedsel_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Voedsel_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Voedsels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        VoedselType = c.Int(nullable: false),
                        Prijs = c.Double(nullable: false),
                        Btw_Tarief = c.Int(nullable: false),
                        Beschikbaar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservaties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KlantNaam = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Tijd = c.Time(nullable: false, precision: 7),
                        ReservatieType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tafels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TafelNummer = c.Int(nullable: false),
                        TafelStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Reservatie_Id", "dbo.Reservaties");
            DropForeignKey("dbo.Orderregels", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orderregels", "Voedsel_Id", "dbo.Voedsels");
            DropForeignKey("dbo.Orders", "Medewerker_Id", "dbo.Medewerkers");
            DropIndex("dbo.Orderregels", new[] { "Order_Id" });
            DropIndex("dbo.Orderregels", new[] { "Voedsel_Id" });
            DropIndex("dbo.Orders", new[] { "Reservatie_Id" });
            DropIndex("dbo.Orders", new[] { "Medewerker_Id" });
            DropTable("dbo.Tafels");
            DropTable("dbo.Reservaties");
            DropTable("dbo.Voedsels");
            DropTable("dbo.Orderregels");
            DropTable("dbo.Orders");
            DropTable("dbo.Medewerkers");
        }
    }
}
