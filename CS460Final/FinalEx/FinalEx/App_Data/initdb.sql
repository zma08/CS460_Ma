create database [Final] on primary
(name=[Final],filename='C:\Users\mazhe\Documents\cs460\CS460Final\FinalEx\FinalEx\App_Data\Final.mdf') 
log on (name = [Final_log],filename='C:\Users\mazhe\Documents\cs460\CS460Final\FinalEx\FinalEx\App_Data\Final_log.ldf');
go

use[Psc];
go

alter table [dbo].[Crews]
drop constraint [fk_dbo.Crews_dbo.Ships_Id],	
	constraint[fk_dbo.Crews_dbo.Pirates_Id]; 


if OBJECT_ID ('dbo.Crews') is not null
drop table [dbo].[Crews];

go


if OBJECT_ID ('dbo.Pirates') is not null
drop table [dbo].[Pirates];

go



create table [dbo].[Crews]
(
	[Id] int not null identity(1,1),
	[ShipId] int not null,
	[PirateId] int not null,
	[Booty] decimal not null,
	constraint [pk_dbo.Crews] primary key clustered([Id]asc),
	constraint [fk_dbo.Crews_dbo.Ships_Id]	foreign key([ShipId]) references [dbo].[Ships]([Id]),
	constraint[fk_dbo.Crews_dbo.Pirates_Id] foreign key([PirateId]) references [dbo].[Pirates]([Id])
);

create table [dbo].[Bs]
(
	[Id] int not null identity(1,1),
	
	constraint [pk_dbo.Bs] primary key clustered([Id]asc),
	
);

create table [dbo].[As]
(
	[Id] int not null identity(1,1),
	
	constraint [pk_dbo.As] primary key clustered([Id]asc),
	
);