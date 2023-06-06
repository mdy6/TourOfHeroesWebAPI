CREATE TABLE [dbo].[Hero]
(
	[HeroId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [PowerType] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Popularity] INT NOT NULL, 
    [LastUpdate] DATETIMEOFFSET NULL
)
