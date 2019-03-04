namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeding : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) VALUES (0,0,0)
                INSERT INTO MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) VALUES (30,1,10)
                INSERT INTO MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) VALUES (90,3,15)
                INSERT INTO MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) VALUES (300,12,20)"
);

        }
        
        public override void Down()
        {
            Sql("DROP MembershpTyps WHERE (DiscountRate) values(0,10,25,20)");
        }
    }
}
