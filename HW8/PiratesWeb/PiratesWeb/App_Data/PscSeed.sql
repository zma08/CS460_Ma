

insert into [dbo].[Pirates](Name,Date)values('William Kidd','12/1/1695');
insert into [dbo].[Pirates](Name,Date)values('John Cooke','09/11/1683');
insert into [dbo].[Pirates](Name,Date)values('Wang Zhi','06/06/1551');
insert into [dbo].[Pirates](Name,Date)values('William Dampier','2/21/1651');
insert into [dbo].[Pirates](Name,Date)values('Zheng Zhilong','12/1/1604');


insert into [dbo].[Ships](Name,Type,Tonnage)values('Adventure Galley','hybrid',1000);
insert into [dbo].[Ships](Name,Type,Tonnage)values('WHYDAH','slave_ship',1000);
insert into [dbo].[Ships](Name,Type,Tonnage)values('CSS Alabama','Sailing',1100);
insert into [dbo].[Ships](Name,Type,Tonnage)values('Royal Fortune','Sailing',800);
insert into [dbo].[Ships](Name,Type,Tonnage)values('Fancy','Brigantine',1000);


insert into [dbo].[Crews](ShipId,PirateId,Booty)values(1,1,20000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(2,3,100000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(3,5,90000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(4,2,120000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(1,4,120000);
			
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(5,1,125000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(1,3,105000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(5,5,99000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(5,2,140000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(3,4,110000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(4,1,136000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(3,3,150000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(4,5,99000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(3,2,115000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(4,4,168000);
			
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(3,1,129000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(4,3,109000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(1,5,136000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(1,2,186000);
insert into [dbo].[Crews](ShipId,PirateId,Booty)values(5,4,132000);