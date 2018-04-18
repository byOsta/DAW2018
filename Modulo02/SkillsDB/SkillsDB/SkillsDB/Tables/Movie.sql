CREATE TABLE [dbo].[Movie]
(
	[MovieId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(100) NULL, 
	[Director] INT NULL,  
	[Year] INT NULL,
	[Vote] INT NULL, 
	[Rating] DECIMAL(20, 18) NULL, 
	[Image] NVARCHAR(250) NULL,
	[Link] NVARCHAR(250) NULL,
	CONSTRAINT FK_Movie_Director FOREIGN KEY (Director) REFERENCES Artist(ArtistId)
)