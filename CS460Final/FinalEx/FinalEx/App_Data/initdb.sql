create database [Final] on primary
(name=[Final],filename='C:\Users\mazhe\Documents\cs460\CS460Final\FinalEx\FinalEx\App_Data\Final.mdf') 
log on (name = [Final_log],filename='C:\Users\mazhe\Documents\cs460\CS460Final\FinalEx\FinalEx\App_Data\Final_log.ldf');
go

use[Final];
go

alter table [dbo].[Classifications]
drop constraint [fk_dbo.Classifications_dbo.Genres_Id],	
	constraint[fk_dbo.Classifications_dbo.ArtWorks_Id]; 

alter table [dbo].[ArtWorks]
drop constraint [fk_dbo.ArtWorks_dbo.Artists_Id];
	

if OBJECT_ID ('dbo.Classifications') is not null
drop table [dbo].[Classifications];

go


if OBJECT_ID ('dbo.Genres') is not null
drop table [dbo].[Genres];

go

if OBJECT_ID ('dbo.ArtWorks') is not null
drop table [dbo].[ArtWorks];

go
if OBJECT_ID ('dbo.Artists') is not null
drop table [dbo].[Artists];

go


create table [dbo].[Classifications]
(
	[Id] int not null identity(1,1),
	[GenreId] int not null,
	[ArtWorkId] int not null,
	[ArtWorkName] nvarchar(50) not null,
	[GenreName] nvarchar(50) not null,
	constraint [pk_dbo.Classifications] primary key clustered([Id]asc),
	constraint [fk_dbo.Classifications_dbo.Genres_Id]	foreign key([GenreId]) references [dbo].[Genres]([Id]),
	constraint[fk_dbo.Classifications_dbo.ArtWorks_Id] foreign key([ArtWorkId]) references [dbo].[ArtWorks]([Id])
);

create table [dbo].[Genres]
(
	[Id] int not null identity(1,1),
	[Name] nvarchar(50) not null
	constraint [pk_dbo.Genres] primary key clustered([Id]asc),
	
);

create table [dbo].[ArtWorks]
(
	[Id] int not null identity(1,1),
	[ArtistId] int not null,
	[Title] nvarchar(100) not null,
	[ArtistName] nvarchar(50) not null,
	constraint [pk_dbo.ArtWorks] primary key clustered([Id]asc),
	constraint[fk_dbo.ArtWorks_dbo.Artists_Id] foreign key([ArtistId]) references [dbo].[Artists]([Id])
);

create table [dbo].[Artists]
(
	[Id] int not null identity(1,1),
	[BirthDate] Datetime2 not null,
	[BirthCity] nvarchar(100) not null,
	[Name] nvarchar(50) not null,
	constraint [pk_dbo.Artists] primary key clustered([Id]asc),
	
);