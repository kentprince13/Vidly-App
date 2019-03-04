namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnameandDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql(@"
                UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE Id= 1
                UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id= 2
                UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id= 3
                UPDATE MembershipTypes SET Name = 'Yearly' WHERE Id= 4
"
                );
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
