namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MoviesId = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MoviesId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MoviesId);
            
            AddColumn("dbo.Movies", "NumbersAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MoviesId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "MoviesId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropColumn("dbo.Movies", "NumbersAvailable");
            DropTable("dbo.Rentals");
        }
    }
}
