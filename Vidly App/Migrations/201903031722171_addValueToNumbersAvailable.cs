namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValueToNumbersAvailable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                UPDATE Movies SET NumbersInStock = NumbersAvailable");
        }
        
        public override void Down()
        {
        }
    }
}
