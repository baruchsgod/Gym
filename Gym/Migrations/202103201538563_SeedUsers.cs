namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'37650ac0-098b-4d3b-a942-fb72908fc5c1', N'guest@energyx.com', 0, N'AAURT5DaQG7+cWBg0OdnABYs4T3MxEyA74c66hNj8KCRu08cwGwbRZ6nNkI0MDMsBQ==', N'92c698e0-0339-49fa-9bf1-dbac7549e6ab', NULL, 0, 0, NULL, 1, 0, N'guest@energyx.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8361690c-6a09-4833-be1b-f5cedf247015', N'trainer@energyx.com', 0, N'AMbkuCdlhOGjcC8K7QLYqoj0+K2OPZLqIgkf9KFg1O49K/8Po0qVA/ecfXaYBuIBqw==', N'74abc611-981a-4c07-9aa5-5400b1e3a41b', NULL, 0, 0, NULL, 1, 0, N'trainer@energyx.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa1859d2-9c9b-461b-94bc-9ec139759c50', N'admin@energyx.com', 0, N'AERQ12bqiSleaqV+uF+1JEYr/rI6oGbpqfwwCf7m08MN2wxFM3s9TOxZqJDG86uMdA==', N'bee85d65-8411-4c7b-b983-e601b0298686', NULL, 0, 0, NULL, 1, 0, N'admin@energyx.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5460b322-d4d1-4fc7-bc4c-feaab33159ce', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1aa6ef9e-d8e2-45f2-b359-4f882d26c250', N'Trainer')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8361690c-6a09-4833-be1b-f5cedf247015', N'1aa6ef9e-d8e2-45f2-b359-4f882d26c250')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa1859d2-9c9b-461b-94bc-9ec139759c50', N'5460b322-d4d1-4fc7-bc4c-feaab33159ce')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
