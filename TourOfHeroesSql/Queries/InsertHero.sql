INSERT INTO [dbo].[Hero] ([Name]
           ,[PowerTypeId]
           ,[Strength]
           ,[Popularity]
           ,[LastUpdate])
OUTPUT INSERTED.HeroId
VALUES (@Name, @PowerTypeId, @Strength, @Popularity, NULL)