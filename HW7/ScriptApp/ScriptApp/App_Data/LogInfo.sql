create database [Log] on
primary (name=[Log],filename='C:\Users\mazhe\Documents\cs460\HW7\ScriptApp\ScriptApp\App_Data\Log.mdf')
log on (name=[Log_log],filename='C:\Users\mazhe\Documents\cs460\HW7\ScriptApp\ScriptApp\App_Data\Log_log.ldf');
go

use [Log];
go

if OBJECT_ID ('CallerInfoes') is not null
drop table [dbo].[CallerInfoes];
go

create table CallerInfoes
(
	[Id] int identity (1,1) not null,
	[TimeStamp] DateTime2 not null,
	[CallerIp] nvarchar(100) not null,
	[CallerAgent] nvarchar(200) not null,
	[CallerRequestString] nvarchar(200) not null
	constraint [pk_dbo.CallerInfoes] primary key clustered ([Id]asc)
);

use master;
go

alter database[Log] set single_user with rollback immediate
go

exec sp_detach_db 'Log', 'true'