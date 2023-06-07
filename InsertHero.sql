INSERT INTO [dbo].[Hero] ([Name]
           ,[PowerTypeId]
           ,[Strength]
           ,[Popularity]
           ,[LastUpdate])
OUTPUT INSERTED.Id
VALUES (@Name, @PowerTypeId, @Strength, @Popularity, NULL)