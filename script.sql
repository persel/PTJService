USE [LocalDev_Webservice]
GO
/****** Object:  Database [LocalDev_Webservice]    Script Date: 2016-10-19 10:27:52 ******/
/*CREATE DATABASE [LocalDev_Webservice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LocalDev_Webservice', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LocalDev_Webservice.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LocalDev_Webservice_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LocalDev_Webservice_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
*/
GO
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
USE [LocalDev_Webservice]
GO
/****** Object:  User [test]    Script Date: 2016-10-19 10:27:52 ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Adress]    Script Date: 2016-10-19 10:27:52 ******/
CREATE SCHEMA [Adress]
GO
/****** Object:  Schema [Organisation]    Script Date: 2016-10-19 10:27:52 ******/
CREATE SCHEMA [Organisation]
GO
/****** Object:  Schema [Person]    Script Date: 2016-10-19 10:27:52 ******/
CREATE SCHEMA [Person]
GO
/****** Object:  Table [Adress].[Adress]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Adress](
	[Id] [bigint] NOT NULL,
	[AdressTypFKID] [bigint] NOT NULL,
	[AdressVariantFKID] [bigint] NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[AdressTyp]    Script Date: 2016-10-19 10:27:52 ******/
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
/****** Object:  Table [Adress].[AdressVariant]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[AdressVariant](
	[Id] [bigint] NOT NULL,
	[AdressTypFKID] [bigint] NOT NULL,
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
/****** Object:  Table [Adress].[GatuAdress]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[GatuAdress](
	[Id] [bigint] NOT NULL,
	[AdressFKID] [bigint] NOT NULL,
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
	[AdressFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[Mail]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Adress].[Mail](
	[Id] [bigint] NOT NULL,
	[AdressFKID] [bigint] NOT NULL,
	[MailAdress] [varchar](255) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Mail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[AdressFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Adress].[OrganisationAdress]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[OrganisationAdress](
	[Id] [bigint] NOT NULL,
	[OrganisationFKID] [bigint] NOT NULL,
	[AdressFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Organisation_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[OrganisationFKID] ASC,
	[AdressFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[PersonAdress]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[PersonAdress](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[AdressFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[AdressFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Adress].[Telefon]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Telefon](
	[Id] [bigint] NOT NULL,
	[AdressFKID] [bigint] NOT NULL,
	[TelefonNummer] [numeric](25, 0) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Telefon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[AdressFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Organisation].[Organisation]    Script Date: 2016-10-19 10:27:52 ******/
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
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Organisation].[ResultatEnhet]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organisation].[ResultatEnhet](
	[Id] [bigint] NULL,
	[Kstnr] [int] NULL,
	[Typ] [char](10) NULL,
	[EnhetFKID] [bigint] NULL,
	[OrganisationFKID] [bigint] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Person].[Anstalld]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Person].[Anstalld](
	[Id] [bigint] NOT NULL,
	[Typ] [tinyint] NULL,
	[Alias] [varchar](50) NULL,
	[UppdateradAv] [nvarchar](50) NULL,
	[UppdateradDatum] [datetime] NULL,
	[SkapadDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_Anstalld] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Person].[AnstalldAvtal]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[AnstalldAvtal](
	[Id] [bigint] NOT NULL,
	[AnstalldFKID] [bigint] NOT NULL,
	[AvtalFKID] [bigint] NOT NULL,
 CONSTRAINT [PK_AnstalldAvtal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[AnstalldFKID] ASC,
	[AvtalFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Avtal]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Person].[Avtal](
	[Id] [bigint] NOT NULL,
	[AvtalsKod] [varchar](50) NULL,
	[AvtalsText] [varchar](50) NULL,
	[ArbetsTidVecka] [bigint] NULL,
	[Befkod] [int] NULL,
	[BefText] [nvarchar](50) NULL,
	[Aktiv] [nchar](10) NULL,
	[Ansvarig] [varchar](50) NULL,
	[Chef] [int] NULL,
	[TjledigFran] [datetime] NULL,
	[TjledigTom] [datetime] NULL,
	[Fproc] [float] NULL,
	[DeltidFranvaro] [nchar](10) NULL,
	[FranvaroProcent] [float] NULL,
	[SjukP] [nchar](10) NULL,
	[GrundArbtidVecka] [float] NULL,
	[Lon] [bigint] NULL,
	[LonDatum] [datetime] NULL,
	[LoneTyp] [nchar](10) NULL,
	[LoneTillagg] [bigint] NULL,
	[TimLon] [bigint] NULL,
	[UppdateradAv] [nchar](10) NULL,
	[UppdateradDatum] [datetime] NULL,
	[AnstallningsDatum] [datetime] NULL,
	[AvgangsDatum] [datetime] NULL,
	[SkapadDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_Avtal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Person].[AvtalResultatEnhet]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[AvtalResultatEnhet](
	[Id] [bigint] NULL,
	[AvtalFKID] [bigint] NULL,
	[ResultatEnhetFKID] [bigint] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Konsult]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Konsult](
	[Id] [bigint] NOT NULL,
	[Alias] [nchar](10) NULL,
	[UppdateradAv] [nchar](10) NULL,
	[UppdateradDatum] [datetime] NULL,
	[SkapadDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_Konsult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[KonsultAvtal]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[KonsultAvtal](
	[Id] [bigint] NOT NULL,
	[KonsultFKID] [bigint] NOT NULL,
	[AvtalFKID] [bigint] NOT NULL,
 CONSTRAINT [PK_KonsultAvtal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[KonsultFKID] ASC,
	[AvtalFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person]    Script Date: 2016-10-19 10:27:52 ******/
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
	[Id] ASC,
	[SkapadDatum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Person].[Person.PersonSjukHalsovardsPersonal]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person.PersonSjukHalsovardsPersonal](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[SjukHalsovardsPersonalFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Sjuk_Hälsovårds_Personal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[SjukHalsovardsPersonalFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[PersonAnnanPerson]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[PersonAnnanPerson](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[AnnanPersonFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_AnnanPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[AnnanPersonFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[PersonAnstalld]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[PersonAnstalld](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[AnstalldFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Anställd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[AnstalldFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[PersonKonsult]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[PersonKonsult](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[KonsultFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Konsult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[KonsultFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[PersonPatient]    Script Date: 2016-10-19 10:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[PersonPatient](
	[Id] [bigint] NOT NULL,
	[PersonFKID] [bigint] NOT NULL,
	[PatientFKID] [bigint] NOT NULL,
	[UpdateradAv] [nvarchar](100) NOT NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[UpdateradDatum] [datetime] NULL,
 CONSTRAINT [PK_Person_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[PersonFKID] ASC,
	[PatientFKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Adress].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_AdressTyp_02] FOREIGN KEY([AdressTypFKID])
REFERENCES [Adress].[AdressTyp] ([Id])
GO
ALTER TABLE [Adress].[Adress] CHECK CONSTRAINT [FK_Adress_AdressTyp_02]
GO
ALTER TABLE [Adress].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_AdressVariant] FOREIGN KEY([AdressVariantFKID])
REFERENCES [Adress].[AdressVariant] ([Id])
GO
ALTER TABLE [Adress].[Adress] CHECK CONSTRAINT [FK_Adress_AdressVariant]
GO
ALTER TABLE [Adress].[AdressVariant]  WITH CHECK ADD  CONSTRAINT [FK_AdressVariant_AdressTyp] FOREIGN KEY([AdressTypFKID])
REFERENCES [Adress].[AdressTyp] ([Id])
GO
ALTER TABLE [Adress].[AdressVariant] CHECK CONSTRAINT [FK_AdressVariant_AdressTyp]
GO
USE [master]
GO
ALTER DATABASE [LocalDev_Webservice] SET  READ_WRITE 
GO
