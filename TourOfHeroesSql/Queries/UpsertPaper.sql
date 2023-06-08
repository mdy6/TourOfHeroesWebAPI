UPDATE [dbo].[Paper]
   SET [Title] = @Title                                          
      ,[Description]  =@Description                                   
      ,[Content] = @Content                                        
      ,[PublicationDate]  =@PublicationDate                               
      ,[Like]  = @Like                                          
      ,[DontLike] = @DontLike                                       
      ,[HeroId]   =@HeroId                                       
      ,[AuthorId] = @AuthorId
	  OUTPUT INSERTED.PaperId
 WHERE PaperId = @PaperId
IF (@@ROWCOUNT = 0)
	INSERT INTO [dbo].[Paper]
			   ([Title]
			   ,[Description]
			   ,[Content]
			   ,[PublicationDate]
			   ,[Like]
			   ,[DontLike]
			   ,[HeroId]
			   ,[AuthorId])
		 VALUES
			   ( @Title
			   ,@Description 
			   ,@Content 
			   ,@PublicationDate 
			   , @Like    
			   ,@DontLike
			   ,@HeroId     
			   , @AuthorId)
	SELECT SCOPE_IDENTITY()
