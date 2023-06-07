CREATE TABLE [dbo].[Hero]
(
	[HeroId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [PowerTypeId] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Popularity] INT NOT NULL, 
    [LastUpdate] DATETIMEOFFSET NULL
)
