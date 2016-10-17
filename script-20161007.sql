USE [LocalDev_Webservice]
GO
/****** Object:  Database [LocalDev_Webservice]    Script Date: 2016-09-07 10:55:27 ******/
/*CREATE DATABASE [LocalDev_Webservice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LocalDev_Webservice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LocalDev_Webservice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LocalDev_Webservice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LocalDev_Webservice_log.ldf' , SIZE = 33088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO*/
ALTER DATABASE [LocalDev_Webservice] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LocalDev_Webservice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LocalDev_Webservice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET ARITHABORT OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LocalDev_Webservice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LocalDev_Webservice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LocalDev_Webservice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LocalDev_Webservice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LocalDev_Webservice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET RECOVERY FULL 
GO
ALTER DATABASE [LocalDev_Webservice] SET  MULTI_USER 
GO
ALTER DATABASE [LocalDev_Webservice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LocalDev_Webservice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LocalDev_Webservice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LocalDev_Webservice] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LocalDev_Webservice', N'ON'
GO
USE [LocalDev_Webservice]
GO
/****** Object:  User [svcUser]    Script Date: 2016-09-07 10:55:27 ******/
CREATE USER [svcUser] FOR LOGIN [svcUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Adress]    Script Date: 2016-09-07 10:55:27 ******/
CREATE SCHEMA [Adress]
GO
/****** Object:  Schema [Organisation]    Script Date: 2016-09-07 10:55:27 ******/
CREATE SCHEMA [Organisation]
GO
/****** Object:  Schema [Person]    Script Date: 2016-09-07 10:55:27 ******/
CREATE SCHEMA [Person]
GO
/****** Object:  Table [Adress].[Adress]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Adress](
	[Id] [bigint] NOT NULL,
	[AdressTyp_FKID] [bigint] NOT NULL,
	[AdressVariant_FKID] [bigint] NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Id],
	[SkapadDatum]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[AdressTyp]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[AdressTyp](
	[Id] [bigint] NOT NULL,
	[Typ] [nvarchar](50) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_AdressTyp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[AdressVariant]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[AdressVariant](
	[Id] [bigint] NOT NULL,
	[AdressTyp_FKID] [bigint] NOT NULL,
	[Variant] [nvarchar](255) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_AdressVariant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[GatuAdress]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[GatuAdress](
	[Id] [bigint] NOT NULL,
	[Adress_FKID] [bigint] NOT NULL,
	[AdressRad1] [nvarchar](255) NULL,
	[AdressRad2] [nvarchar](255) NULL,
	[AdressRad3] [nvarchar](255) NULL,
	[AdressRad4] [nvarchar](255) NULL,
	[AdressRad5] [nvarchar](255) NULL,
	[Postnummer] [numeric](18, 0) NOT NULL,
	[Stad] [nvarchar](255) NOT NULL,
	[Land] [nvarchar](255) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NULL,
 CONSTRAINT [PK_GatuAdress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Adress_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[Mail]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Adress].[Mail](
	[Id] [bigint] NOT NULL,
	[Adress_FKID] [bigint] NOT NULL,
	[MailAdress] [varchar](255) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Mail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Adress_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Adress].[Organisation_Adress]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Organisation_Adress](
	[Id] [bigint] NOT NULL,
	[Organisation_FKID] [bigint] NOT NULL,
	[Adress_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Organisation_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Organisation_FKID] ASC,
	[Adress_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[Person_Adress]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Person_Adress](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[Adress_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[Adress_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[Telefon]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Telefon](
	[Id] [bigint] NOT NULL,
	[Adress_FKID] [bigint] NOT NULL,
	[TelefonNummer] [numeric](25, 0) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Telefon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Adress_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Organisation].[Organisation]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organisation].[Organisation](
	[Id] [bigint] NOT NULL,
	[OrganisationsId] [varchar](50) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpDateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[IngarIOrganisation] [bigint] NULL,
 CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED 
(
	[Id],
	[SkapadDatum]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Person].[Person]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Person].[Person](
	[Id] [bigint] NOT NULL,
	[ForNamn] [nvarchar](255) NOT NULL,
	[MellanNamn] [nvarchar](255) NULL,
	[EfterNamn] [nvarchar](255) NOT NULL,
	[PersonNummer] [varchar](12) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id],
	[SkapadDatum]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [Person].[Anstalld]    Script Date: 2016-10-05 15:58:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Person].[Anstalld](
	[Id] [bigint] NOT NULL,
	[Alias] [varchar](50) NULL,
	[Ftgnr] [int] NULL,
	[Enhet] [varchar](12) NULL,
	[Befnr] [varchar](12) NULL,
	[Kstnr] [int] NULL,
	[Aktiv] [varchar](12) NULL,
	[Ansvarig] [varchar](12) NULL,
	[Chef] [varchar](12) NULL,
	[Befkod] [int] NULL,
	[Beftext] [text] NULL,
	[AvtalsKod] [varchar](12) NULL,
	[AvtalsText] [varchar](255) NULL,
	[AnstallningsDatum] [datetime] NULL,
	[AvgangsDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [Person].[Konsult]    Script Date: 2016-10-07 10:14:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Person].[Konsult](
	[Id] [bigint] NOT NULL,
	[Alias] [varchar](50) NULL,
	[Kstnr] [int] NULL,
	[Aktiv] [varchar](12) NULL,
	[Ansvarig] [varchar](12) NULL,
	[Chef] [varchar](12) NULL,
	[Befkod] [int] NULL,
	[Beftext] [text] NULL,
	[AvtalsKod] [varchar](12) NULL,
	[AvtalsText] [varchar](255) NULL,
	[AnstallningsDatum] [datetime] NULL,
	[AvgangsDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Konsult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [Person].[Person.Person_Sjuk_Halsovards_Personal]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person.Person_Sjuk_Halsovards_Personal](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[Sjuk_Halsovards_Personal_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Sjuk_Hälsovårds_Personal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[Sjuk_Halsovards_Personal_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person_AnnanPerson]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person_AnnanPerson](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[AnnanPerson_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_AnnanPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[AnnanPerson_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person_Anstalld]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person_Anstalld](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[Anstalld_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Anställd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[Anstalld_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person_Konsult]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person_Konsult](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[Konsult_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Konsult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[Konsult_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person_Patient]    Script Date: 2016-09-07 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person_Patient](
	[Id] [bigint] NOT NULL,
	[Person_FKID] [bigint] NOT NULL,
	[Patient_FKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Person_FKID] ASC,
	[Patient_FKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Adress].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_AdressTyp_02] FOREIGN KEY([AdressTyp_FKID])
REFERENCES [Adress].[AdressTyp] ([Id])
GO
ALTER TABLE [Adress].[Adress] CHECK CONSTRAINT [FK_Adress_AdressTyp_02]
GO
ALTER TABLE [Adress].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_AdressVariant] FOREIGN KEY([AdressVariant_FKID])
REFERENCES [Adress].[AdressVariant] ([Id])
GO
ALTER TABLE [Adress].[Adress] CHECK CONSTRAINT [FK_Adress_AdressVariant]
GO
ALTER TABLE [Adress].[AdressVariant]  WITH CHECK ADD  CONSTRAINT [FK_AdressVariant_AdressTyp] FOREIGN KEY([AdressTyp_FKID])
REFERENCES [Adress].[AdressTyp] ([Id])
GO
ALTER TABLE [Adress].[AdressVariant] CHECK CONSTRAINT [FK_AdressVariant_AdressTyp]
GO
ALTER TABLE [Adress].[GatuAdress]  WITH CHECK ADD  CONSTRAINT [FK_GatuAdress_Adress] FOREIGN KEY([Adress_FKID])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[GatuAdress] CHECK CONSTRAINT [FK_GatuAdress_Adress]
GO
ALTER TABLE [Adress].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_Mail_Adress_02] FOREIGN KEY([Adress_FKID])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Mail] CHECK CONSTRAINT [FK_Mail_Adress_02]
GO
ALTER TABLE [Adress].[Organisation_Adress]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Adress_Adress] FOREIGN KEY([Adress_FKID])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Organisation_Adress] CHECK CONSTRAINT [FK_Organisation_Adress_Adress]
GO
ALTER TABLE [Adress].[Organisation_Adress]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Adress_Organisation] FOREIGN KEY([Organisation_FKID])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Adress].[Organisation_Adress] CHECK CONSTRAINT [FK_Organisation_Adress_Organisation]
GO
ALTER TABLE [Adress].[Person_Adress]  WITH CHECK ADD  CONSTRAINT [FK_Person_Adress_Adress] FOREIGN KEY([Adress_FKID])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Person_Adress] CHECK CONSTRAINT [FK_Person_Adress_Adress]
GO
ALTER TABLE [Adress].[Person_Adress]  WITH CHECK ADD  CONSTRAINT [FK_Person_Adress_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Adress].[Person_Adress] CHECK CONSTRAINT [FK_Person_Adress_Person]
GO
ALTER TABLE [Adress].[Telefon]  WITH CHECK ADD  CONSTRAINT [FK_Telefon_Adress_02] FOREIGN KEY([Adress_FKID])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Telefon] CHECK CONSTRAINT [FK_Telefon_Adress_02]
GO
ALTER TABLE [Organisation].[Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Organisation] FOREIGN KEY([IngarIOrganisation])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Organisation].[Organisation] CHECK CONSTRAINT [FK_Organisation_Organisation]
GO
ALTER TABLE [Person].[Person.Person_Sjuk_Halsovards_Personal]  WITH CHECK ADD  CONSTRAINT [FK_Person_Sjuk_Hälsovårds_Personal_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Person.Person_Sjuk_Halsovards_Personal] CHECK CONSTRAINT [FK_Person_Sjuk_Hälsovårds_Personal_Person]
GO
ALTER TABLE [Person].[Person_AnnanPerson]  WITH CHECK ADD  CONSTRAINT [FK_Person_AnnanPerson_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Person_AnnanPerson] CHECK CONSTRAINT [FK_Person_AnnanPerson_Person]
GO
ALTER TABLE [Person].[Person_Anstalld]  WITH CHECK ADD  CONSTRAINT [FK_Person_Anställd_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Person_Anstalld] CHECK CONSTRAINT [FK_Person_Anställd_Person]
GO
ALTER TABLE [Person].[Person_Konsult]  WITH CHECK ADD  CONSTRAINT [FK_Person_Konsult_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Person_Konsult] CHECK CONSTRAINT [FK_Person_Konsult_Person]
GO
ALTER TABLE [Person].[Person_Patient]  WITH CHECK ADD  CONSTRAINT [FK_Person_Patient_Person] FOREIGN KEY([Person_FKID])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Person_Patient] CHECK CONSTRAINT [FK_Person_Patient_Person]
GO
USE [master]
GO
ALTER DATABASE [LocalDev_Webservice] SET  READ_WRITE 
GO
