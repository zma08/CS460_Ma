-- Create tables and populate with seed data
--    follow naming convention: "Students" table contains rows that are each "User" objects

-- ***********  Attach ***********
CREATE DATABASE [Record] ON
PRIMARY (NAME=[Record], FILENAME='$(dbdir)\Record.mdf')
LOG ON (NAME=[Record_log], FILENAME='$(dbdir)\Record_log.ldf');
--FOR ATTACH;
GO

USE [Record];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Students','U') IS NOT NULL
	DROP TABLE [dbo].[Students];
GO


-- ########### Students ###########
CREATE TABLE [dbo].[Students]
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
	CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([ID] ASC)
);
--insert the seed data from csv file format
BULK INSERT [dbo].[Students]
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

ALTER DATABASE [Record] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db 'Record', 'true'