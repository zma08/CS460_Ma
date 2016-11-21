create database [Psc] on primary
(name=[Pcs],filename='C:\Users\mazhe\Documents\cs460\HW8\PirateApp\PirateApp\App_Data\Pcs.mdf') 
log on (name = [Pcs_log],filename='C:\Users\mazhe\Documents\cs460\HW8\PirateApp\PirateApp\App_Data\Pcs_log.ldf');
go

use[Psc];
go

if OBJECT_ID ('dbo.Pirates') is not null
drop table [dbo].[Pirates];

if object_id ('dbo.Ships') is not null
drop table [dbo].[Ships];

if Object_id('Crews') is not null
drop table [dbo].[Crews];
go

create table [dbo].[Pirates]
(
	[Id] int not null identity (1,1),
	[Name] nvarchar(50) not null,
	[Date] datetime2(7) not null,
	constraint [pk_dbo.Pirates] primary key clustered ([Id]asc)
);

create table[dbo].[Ships]
(
	[Id] int not null identity (1,1),
	[Name] nvarchar(20) not null,
	[Type] nvarchar(10),
	[Tonnage] int not null,
	constraint [pk_dbo.Ships] primary key clustered ([Id]asc)
);

create table [dbo].[Crews]
(
	[Id] int not null identity(1,1),
	[ShipId] int not null,
	[PirateId] int not null,
	[Booty] decimal not null,
	constraint [pk_dob.Crews] primary key clustered([Id]asc),
	constraint [fk_dbo.Crews_dbo.Ships_Id]	foreign key([ShipId]) references [dbo].[Ships]([Id]),
	constraint[fk_dbo.Crews_dbo.Pirates_Id] foreign key([PirateId]) references [dbo].[Pirates]([Id])
);

--detach--
use master
go

----set the database in single user mode
alter database [Psc] set single_user with rollback immediate
go

exec sp_detach_db 'Psc','true'