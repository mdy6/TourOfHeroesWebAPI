﻿CREATE TABLE [dbo].[Paper]
(
	[PaperId] INT NOT NULL  IDENTITY(1,1) , 
    [Title] VARCHAR(250) NOT NULL, 
    [Description] VARCHAR(500) NULL, 
    [Content] varchar(MAX) NULL, 
    [PublicationDate] DATETIMEOFFSET NOT NULL, 
    [Like] INT NOT NULL DEFAULT 0, 
    [DontLike] INT NOT NULL DEFAULT 0, 
    [HeroId] INT NOT NULL, 
    [AuthorId] INT NOT NULL, 
    PRIMARY KEY ([PaperId]), 
    CONSTRAINT [FK_Paper_ToTable] FOREIGN KEY ([HeroId]) REFERENCES [Hero]([HeroId]), 
    CONSTRAINT [FK_Paper_ToTable_1] FOREIGN KEY ([AuthorId]) REFERENCES [User]([UserId]) 
)
