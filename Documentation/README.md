# Documentation

![Cover photo](./Images/Documentation-Header-Main.jpg) 

##General.

    TODO edit

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.

##Models

**CREATE TABLE [dbo].[Building](**

    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UsableArea] [real] NULL,
    [BuiltUpArea] [real] NULL,
    [FloorsCount] [int] NULL,
    [RoomsCount] [int] NULL,
    [BathroomsCount] [int] NULL,
    [ProductId] [int] NOT NULL,
    [CategoryId] [int] NOT NULL,

**CREATE TABLE [dbo].[BuildingsMaterials](**

	[BuildingId] [int] NOT NULL,
	[MaterialId] [int] NOT NULL,

**CREATE TABLE [dbo].[BuildingsPictures](**

	[BuildingId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,

**CREATE TABLE [dbo].[Categories](**

	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,


**CREATE TABLE [dbo].[Materials](**

	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,

**CREATE TABLE [dbo].[Pictures](**

	[Id] [int] NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[PictureContent] [varbinary](max) NULL,
	[PictureUrl] [varchar](150) NULL,


**CREATE TABLE [dbo].[Pictures](**

	[Id] [int] NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[PictureContent] [varbinary](max) NULL,
	[PictureUrl] [varchar](150) NULL,

**CREATE TABLE [dbo].[Prices](**

	[Id] [int] NOT NULL,
	[Value] [real] NULL,
	[Currency] [varchar](10) NULL,
	[PerSquareMeter] [real] NOT NULL,

**CREATE TABLE [dbo].[Products](**

	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,

**CREATE TABLE [dbo].[ProductsPrices](**

	[ProductId] [int] NOT NULL,
	[PriceId] [int] NOT NULL,