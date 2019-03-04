namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedGenres : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                 INSERT INTO Genres (Name) VALUES('Action')
                 INSERT INTO Genres (Name) VALUES('Comedy')
                 INSERT INTO Genres (Name) VALUES('Epic')
                 INSERT INTO Genres (Name) VALUES('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
