namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_meervoud_van_gemaakt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservaties", "Tafel_Id", c => c.Int());
            CreateIndex("dbo.Reservaties", "Tafel_Id");
            AddForeignKey("dbo.Reservaties", "Tafel_Id", "dbo.Tafels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservaties", "Tafel_Id", "dbo.Tafels");
            DropIndex("dbo.Reservaties", new[] { "Tafel_Id" });
            DropColumn("dbo.Reservaties", "Tafel_Id");
        }
    }
}
