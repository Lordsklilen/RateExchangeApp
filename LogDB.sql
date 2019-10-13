USE [master]
GO
/****** Object:  Database [ExchangeRates_LOG]    Script Date: 13.10.2019 16:17:11 ******/
CREATE DATABASE [ExchangeRates_LOG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExchangeRates_LOG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ExchangeRates_LOG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExchangeRates_LOG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ExchangeRates_LOG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExchangeRates_LOG] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExchangeRates_LOG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExchangeRates_LOG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExchangeRates_LOG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExchangeRates_LOG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExchangeRates_LOG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExchangeRates_LOG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExchangeRates_LOG] SET  MULTI_USER 
GO
ALTER DATABASE [ExchangeRates_LOG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExchangeRates_LOG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExchangeRates_LOG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExchangeRates_LOG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExchangeRates_LOG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExchangeRates_LOG] SET QUERY_STORE = OFF
GO
USE [ExchangeRates_LOG]
GO
/****** Object:  Table [dbo].[ExchangeRatesLog]    Script Date: 13.10.2019 16:17:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRatesLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestedURL] [varchar](100) NULL,
	[OperationType] [varchar](50) NOT NULL,
	[CurrencyFrom] [varchar](50) NULL,
	[CurrencyTo] [varchar](50) NULL,
	[ValueInput] [decimal](16, 2) NULL,
	[ValueOutput] [decimal](16, 2) NULL,
	[Exception] [varchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ExchangeRates_LOG] SET  READ_WRITE 
GO
