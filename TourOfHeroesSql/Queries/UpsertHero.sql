UPDATE [dbo].[Hero]
   SET [Name] = @Name
      ,[PowerTypeId] = @PowerTypeId 
      ,[Strength] = @Strength
      ,[Popularity] =@Popularity
      ,[LastUpdate] = @LastUpdate
       OUTPUT INSERTED.HeroId
   WHERE [HeroId] = @HeroId
IF(@@ROWCOUNT = 0)
    INSERT INTO [dbo].[Hero] ([Name]
               ,[PowerTypeId]
               ,[Strength]
               ,[Popularity]
               ,[LastUpdate])
    VALUES (@Name, @PowerTypeId, @Strength, @Popularity, NULL)
    SELECT SCOPE_IDENTITY()
GO  