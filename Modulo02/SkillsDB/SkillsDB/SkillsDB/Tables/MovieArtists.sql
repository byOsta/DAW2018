CREATE TABLE [dbo].[MovieArtists]
(
	[MovieId] INT NOT NULL, 
    [ArtistId] INT NOT NULL,
	CONSTRAINT PK_MovieArtists PRIMARY KEY(MovieId, ArtistId),
	CONSTRAINT FK_MovieArtists_Movie FOREIGN KEY (MovieId) REFERENCES Movie(MovieId),
	CONSTRAINT FK_MovieArtists_Artist FOREIGN KEY (ArtistId) REFERENCES Artist(ArtistId)
)