-- Create tables and populate with seed data
--    follow naming convention: "Users" table contains rows that are each "User" objects

-- ***********  Attach ***********
CREATE DATABASE [Student] ON
PRIMARY (NAME=[Student], FILENAME='$(dbdir)\Student.mdf')
LOG ON (NAME=[Student_log], FILENAME='$(dbdir)\Student_log.ldf');
--FOR ATTACH;
GO

USE [Student];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Student','U') IS NOT NULL
	DROP TABLE [dbo].[Student];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[Student]
(
	[ID] INT IDENTITY (1,1) NOT NULL,

	[VNumber] NVARCHAR (50) NOT NULL, 
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[Date] NVARCHAR(50) NOT NULL,
	[PhoneNumber]  NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR (50) NOT NULL,
	[Major] NVARCHAR (50) NOT NULL,
	[Minor] NVARCHAR (50) NOT NULL,
	[Advisor] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED ([ID] ASC)
);

BULK INSERT [dbo].[Student]
	FROM '$(dbdir)\SeedData\Students.csv'		-- VN,FirstName,LastName,Date,Email,PhoneNumber,Major,Minor,Advisor
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR	= '\n',
		FIRSTROW = 2
	);
GO

-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [Student] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db 'Student', 'true'