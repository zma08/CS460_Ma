USE [master]
GO

/****** Object:  Database [Student]    Script Date: 10/27/2016 11:21:00 AM ******/
CREATE DATABASE [Student]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Student', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Student.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Student_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Student_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Student] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Student].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Student] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Student] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Student] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Student] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Student] SET ARITHABORT OFF 
GO

ALTER DATABASE [Student] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Student] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Student] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Student] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Student] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Student] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Student] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Student] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Student] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Student] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Student] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Student] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Student] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Student] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Student] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Student] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Student] SET  MULTI_USER 
GO

ALTER DATABASE [Student] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Student] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Student] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Student] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Student] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Student] SET QUERY_STORE = OFF
GO

USE [Student]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [Student] SET  READ_WRITE 
GO

