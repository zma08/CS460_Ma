insert into [dbo].[Artists](Name,BirthDate,BirthCity)values('M.C. Escher','06-17-1898','Leeuwarden, Netherlands');
insert into [dbo].[Artists](Name,BirthDate,BirthCity)values('Leonardo Da Vinci','05-2-1519','Vinci, Italy');
insert into [dbo].[Artists](Name,BirthDate,BirthCity)values('Hatip Mehmed Efendi','11-18-1680','Unknown');
insert into [dbo].[Artists](Name,BirthDate,BirthCity)values('Salvador Dali','05-11-1904','Figueres, Spain');



insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(1,'Circle Limit III','M.C. Escher');
insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(1,'Twon Tree','M.C. Escher');
insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(2,'Mona Lisa','Leonardo Da Vinci');
insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(2,'The Vitruvian Man','Leonardo Da Vinci');
insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(3,'Ebru','Hatip Mehmed Efendi');
insert into [dbo].[ArtWorks](ArtistId,Title,ArtistName)values(4,'Honey Is Sweeter Than Blood','Salvador Dali');
	
	
insert into [dbo].[Genres](Name)values('Tesselation');
insert into [dbo].[Genres](Name)values('Surrealism');
insert into [dbo].[Genres](Name)values('Portrait');
insert into [dbo].[Genres](Name)values('Renaissance');


insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Circle Limit III','Tesselation',1,1);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Twon Tree','Tesselation',1,2);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Twon Tree','Surrealism',2,2);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Mona Lisa','Portrait',3,3);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Mona Lisa','Renaissance',4,3);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('The Vitruvian Man','Renaissance',4,4);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Ebru','Tesselation',1,5);
insert into [dbo].[Classifications](ArtWorkName,GenreName,GenreId,ArtWorkId)values('Honey Is Sweeter Than Blood','Surrealism',2,6);										