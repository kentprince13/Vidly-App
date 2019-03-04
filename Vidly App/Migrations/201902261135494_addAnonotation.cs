namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnonotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
