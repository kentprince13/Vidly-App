namespace Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedRolesandUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d4be026-bc73-44d5-b5b7-c88e25b91881', N'admin@vidly.com', 0, N'AJQK8abzGfWuQZ3Kegc5GkPS0UtaPYKF4bQ4DwQ3GLFnaURVA22xnblqYQE1YuDysA==', N'52f34c69-8736-4269-a525-dde71af4e1a3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'79ca0b7e-7aaf-4b8d-b3a9-f7df8dfcfdc5', N'guest@vidly.com', 0, N'AFSkLNp8ppKDwn/MN9OCutdHwRkWxNz1sAm5waDIzTzZDgEtolY7F6HdOc688wdSiQ==', N'f22d9389-0a79-4f82-892e-ed35e654b87b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'033ab4c7-935b-40c6-a080-adb5ff7e0693', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d4be026-bc73-44d5-b5b7-c88e25b91881', N'033ab4c7-935b-40c6-a080-adb5ff7e0693')

");
        }
        
        public override void Down()
        {
        }
    }
}
