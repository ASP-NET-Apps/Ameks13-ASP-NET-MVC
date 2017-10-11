USE [master]
GO
/****** Object:  Database [MyWoodenHouse]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE DATABASE [MyWoodenHouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyWoodenHouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyWoodenHouse.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyWoodenHouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyWoodenHouse_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyWoodenHouse] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyWoodenHouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyWoodenHouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyWoodenHouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyWoodenHouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyWoodenHouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyWoodenHouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET RECOVERY FULL 
GO
ALTER DATABASE [MyWoodenHouse] SET  MULTI_USER 
GO
ALTER DATABASE [MyWoodenHouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyWoodenHouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyWoodenHouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyWoodenHouse] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyWoodenHouse] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyWoodenHouse', N'ON'
GO
USE [MyWoodenHouse]
GO
/****** Object:  User [mywoodenhouse]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE USER [mywoodenhouse] FOR LOGIN [mywoodenhouse] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [mywoodenhouse]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[UsableArea] [real] NULL,
	[BuiltUpArea] [real] NULL,
	[FloorsCount] [int] NULL,
	[RoomsCount] [int] NULL,
	[BathroomsCount] [int] NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuildingsMaterials]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingsMaterials](
	[BuildingId] [int] NOT NULL,
	[MaterialId] [int] NOT NULL,
 CONSTRAINT [PK_BuildingsMaterials] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC,
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuildingsPictures]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingsPictures](
	[BuildingId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_BuildingsPictures] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC,
	[PictureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Categories_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Materials_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pictures](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[FileContent] [varbinary](max) NULL,
	[Url] [varchar](250) NULL,
	[GetFrom] [int] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PriceCategories]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PriceCategories](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PriceCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [real] NULL,
	[Currency] [varchar](10) NULL,
	[PerSquareMeter] [real] NOT NULL,
	[PriceCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductsPrices]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsPrices](
	[ProductId] [int] NOT NULL,
	[PriceId] [int] NOT NULL,
 CONSTRAINT [PK_ProductsPrices] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 12.10.2017 г. 01:26:12 ч. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Building_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Building_Categories]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Building_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Building_Products]
GO
ALTER TABLE [dbo].[BuildingsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_BuildingsMaterials_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
GO
ALTER TABLE [dbo].[BuildingsMaterials] CHECK CONSTRAINT [FK_BuildingsMaterials_Building]
GO
ALTER TABLE [dbo].[BuildingsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_BuildingsMaterials_Materials] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[BuildingsMaterials] CHECK CONSTRAINT [FK_BuildingsMaterials_Materials]
GO
ALTER TABLE [dbo].[BuildingsPictures]  WITH CHECK ADD  CONSTRAINT [FK_BuildingsPictures_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
GO
ALTER TABLE [dbo].[BuildingsPictures] CHECK CONSTRAINT [FK_BuildingsPictures_Building]
GO
ALTER TABLE [dbo].[BuildingsPictures]  WITH CHECK ADD  CONSTRAINT [FK_BuildingsPictures_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Id])
GO
ALTER TABLE [dbo].[BuildingsPictures] CHECK CONSTRAINT [FK_BuildingsPictures_Pictures]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_PriceCategories] FOREIGN KEY([PriceCategoryId])
REFERENCES [dbo].[PriceCategories] ([Id])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_PriceCategories]
GO
ALTER TABLE [dbo].[ProductsPrices]  WITH CHECK ADD  CONSTRAINT [FK_ProductsPrices_Prices] FOREIGN KEY([PriceId])
REFERENCES [dbo].[Prices] ([Id])
GO
ALTER TABLE [dbo].[ProductsPrices] CHECK CONSTRAINT [FK_ProductsPrices_Prices]
GO
ALTER TABLE [dbo].[ProductsPrices]  WITH CHECK ADD  CONSTRAINT [FK_ProductsPrices_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductsPrices] CHECK CONSTRAINT [FK_ProductsPrices_Products]
GO
ALTER TABLE [dbo].[Buildings]  WITH NOCHECK ADD  CONSTRAINT [CK_Buildings_BathroomsCount_Range] CHECK NOT FOR REPLICATION (([BathroomsCount]>=(0) AND [BathroomsCount]<=(100)))
GO
ALTER TABLE [dbo].[Buildings] NOCHECK CONSTRAINT [CK_Buildings_BathroomsCount_Range]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [CK_Buildings_BuiltUpArea_Range] CHECK  (([BuiltUpArea]>=(0.0) AND [BuiltUpArea]<=(1000000.0)))
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [CK_Buildings_BuiltUpArea_Range]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [CK_Buildings_FloorsCount_Range] CHECK  (([FloorsCount]>=(0) AND [FloorsCount]<=(1000)))
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [CK_Buildings_FloorsCount_Range]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [CK_Buildings_RoomsCount_Range] CHECK  (([RoomsCount]>=(0) AND [RoomsCount]<=(1000)))
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [CK_Buildings_RoomsCount_Range]
GO
ALTER TABLE [dbo].[Buildings]  WITH NOCHECK ADD  CONSTRAINT [CK_Buildings_UsableArea_Range] CHECK NOT FOR REPLICATION (([UsableArea]>=(0.0) AND [UsableArea]<=(1000000.0)))
GO
ALTER TABLE [dbo].[Buildings] NOCHECK CONSTRAINT [CK_Buildings_UsableArea_Range]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [CK_Categories_Id_MinValue] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [CK_Categories_Id_MinValue]
GO
USE [master]
GO
ALTER DATABASE [MyWoodenHouse] SET  READ_WRITE 
GO
