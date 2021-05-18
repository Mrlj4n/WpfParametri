USE [master]
GO
/****** Object:  Database [Magacin]    Script Date: 5/18/2021 13:22:32 ******/
CREATE DATABASE [Magacin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Magacin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Magacin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Magacin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Magacin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Magacin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Magacin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Magacin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Magacin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Magacin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Magacin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Magacin] SET ARITHABORT OFF 
GO
ALTER DATABASE [Magacin] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Magacin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Magacin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Magacin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Magacin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Magacin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Magacin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Magacin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Magacin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Magacin] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Magacin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Magacin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Magacin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Magacin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Magacin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Magacin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Magacin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Magacin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Magacin] SET  MULTI_USER 
GO
ALTER DATABASE [Magacin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Magacin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Magacin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Magacin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Magacin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Magacin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Magacin] SET QUERY_STORE = OFF
GO
USE [Magacin]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 5/18/2021 13:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[KategorijaId] [int] IDENTITY(1,1) NOT NULL,
	[NazivKategorije] [nvarchar](50) NOT NULL,
	[OpisKategorije] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KategorijaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvod]    Script Date: 5/18/2021 13:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvod](
	[ProizvodId] [int] IDENTITY(1,1) NOT NULL,
	[KategorijaId] [int] NOT NULL,
	[NazivProizvoda] [nvarchar](50) NOT NULL,
	[Cena] [decimal](12, 3) NOT NULL,
	[KolicinaNaLageru] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProizvodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategorija] ON 

INSERT [dbo].[Kategorija] ([KategorijaId], [NazivKategorije], [OpisKategorije]) VALUES (1, N'Laptopovi', N'Laptopovi razlicitih proizvodjaca')
INSERT [dbo].[Kategorija] ([KategorijaId], [NazivKategorije], [OpisKategorije]) VALUES (2, N'Stampaci', N'Stampaci razlicitih proizvodjaca')
INSERT [dbo].[Kategorija] ([KategorijaId], [NazivKategorije], [OpisKategorije]) VALUES (3, N'Tableti', N'Tablet racunari razlicitih proizvodjaca')
INSERT [dbo].[Kategorija] ([KategorijaId], [NazivKategorije], [OpisKategorije]) VALUES (16, N'Alati', N'razni alati 123')
SET IDENTITY_INSERT [dbo].[Kategorija] OFF
GO
SET IDENTITY_INSERT [dbo].[Proizvod] ON 

INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (1, 1, N'Laptop Dell Inspiron N4050', CAST(30999.250 AS Decimal(12, 3)), 39)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (2, 1, N'Laptop Asus X55U-SX009D', CAST(32990.120 AS Decimal(12, 3)), 17)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (3, 1, N'Acer Aspire laptop E5-521G-47DX', CAST(41989.000 AS Decimal(12, 3)), 25)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (4, 2, N'Stampac Laser A4 Lexmark E260', CAST(8549.100 AS Decimal(12, 3)), 13)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (5, 2, N'Canon laserski stampac LBP-6670DN', CAST(31989.100 AS Decimal(12, 3)), 18)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (6, 2, N'Canon stampac imageCLASS LBP6030W', CAST(13589.120 AS Decimal(12, 3)), 11)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (7, 3, N'Acer tablet B1-730HD 8GB', CAST(11999.300 AS Decimal(12, 3)), 12)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (8, 3, N'Asus tablet MeMO Pad 7 ME70C-1A003A', CAST(12999.900 AS Decimal(12, 3)), 14)
INSERT [dbo].[Proizvod] ([ProizvodId], [KategorijaId], [NazivProizvoda], [Cena], [KolicinaNaLageru]) VALUES (9, 3, N'Goclever tablet ORION 70 L KB', CAST(5699.450 AS Decimal(12, 3)), 25)
SET IDENTITY_INSERT [dbo].[Proizvod] OFF
GO
ALTER TABLE [dbo].[Proizvod]  WITH CHECK ADD FOREIGN KEY([KategorijaId])
REFERENCES [dbo].[Kategorija] ([KategorijaId])
GO
USE [master]
GO
ALTER DATABASE [Magacin] SET  READ_WRITE 
GO
