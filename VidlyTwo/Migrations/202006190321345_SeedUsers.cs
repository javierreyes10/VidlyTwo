namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'000b207f-1b3c-4d17-a245-1b3882e7a303', N'guest@vidly.com', 0, N'AD3HpQbgPpVHJw4DD81YqqXeewOq2yJz+CyMocbM0tethHiNdGVZT712KBqg1GG8AQ==', N'e51b5b4d-d95b-4fb8-95dc-cf97628d9978', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b968ebb-7d27-486c-9e3e-cc5c905bebf4', N'admin@vidly.com', 0, N'AFlXbj6+jm0lZlEX2M/G7W7VF1OFgFs7faeY3iwjyr1eoHk/A4Rsr/7DstJX9U255g==', N'8a87a98b-6a56-419d-a7e5-33ece190308e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7550439c-abaa-4a01-b694-2c3acaed3797', N'CanManageMovie')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b968ebb-7d27-486c-9e3e-cc5c905bebf4', N'7550439c-abaa-4a01-b694-2c3acaed3797')
            
");
        }
        
        public override void Down()
        {
        }
    }
}
