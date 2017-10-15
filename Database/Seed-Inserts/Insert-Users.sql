USE [MyWoodenHouse]
GO
-- administrator passwprd:111111
-- admin passwprd:111111
-- user passwprd:123456
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6885d20d-fa25-41e2-8e8e-c98c708a3966', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee10cb57-fe4a-49cf-9427-a92f942a7434', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6fc5a944-adf6-45a8-8f28-7bd6f51fc41a', N'User')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be40d596-c96a-43ae-bcef-9727821477b8', N'6885d20d-fa25-41e2-8e8e-c98c708a3966')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70c30366-1b22-47fa-998e-1362dac3c154', N'ee10cb57-fe4a-49cf-9427-a92f942a7434')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5892c8ec-214f-4e1b-83de-568d9a292ef9', N'user@abv.bg', 0, N'AEe4nAELh95dJH6OjVHr2e3nrxdi0h9huFTBqFTEjYcTvJPv0SGG4G8vzXNIWagwVA==', N'a0bc8027-13f5-44fe-b2c4-96256e1a3e34', NULL, 0, 0, NULL, 1, 0, N'user@abv.bg')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70c30366-1b22-47fa-998e-1362dac3c154', N'administrator@abv.bg', 0, N'AGdXpDUXNbAi3fSrulwxla6LezG3SOeeGd0nCZIX9/N94LQt69kjulAxouB8/fPn0g==', N'2860b835-b8dc-43d7-bdae-0b1116803098', NULL, 0, 0, NULL, 1, 0, N'administrator@abv.bg')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'be40d596-c96a-43ae-bcef-9727821477b8', N'admin@abv.bg', 0, N'APnfOH9ehzpTlGhBojVtyceqf7fj5VXjWF+TBl9FaI7H6NGH1BoEh6wxoIk5sTlEdQ==', N'84b594d4-e867-46e9-a445-f4c447e37e8c', NULL, 0, 0, NULL, 1, 0, N'admin@abv.bg')
GO


