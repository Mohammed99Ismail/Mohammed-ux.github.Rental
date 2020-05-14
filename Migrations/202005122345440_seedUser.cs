namespace VenMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d57e9b5-925d-4edc-bf53-c911dae7a71e', N'admin@venMovie.com', 0, N'APZFd7FL9MenGqNXKCud8dSuq+Lf5r0t7iQ9YaDfrw//UVWa3B1mNhuTq3MNMRJUmg==', N'849b07ef-0ba9-48f0-ab87-0327f8bd0638', NULL, 0, 0, NULL, 1, 0, N'admin@venMovie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7d7be94c-74b0-4d36-ad1c-af0a8be0a118', N'mohammedmmm640@gmail.com', 0, N'AE8Pspmg0OnO7l6SxsVMb6gQLDtYrt1p+GUZiCFikceKvRefvdtYyJKzjFcIelesLA==', N'bd356edf-b79d-4c88-9ae6-e2864aade76f', NULL, 0, 0, NULL, 1, 0, N'mohammedmmm640@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a670916c-fa1c-41db-9963-6cba95f863a0', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d57e9b5-925d-4edc-bf53-c911dae7a71e', N'a670916c-fa1c-41db-9963-6cba95f863a0')

");
        }
        
        public override void Down()
        {
        }
    }
}
