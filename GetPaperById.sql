﻿SELECT top 1 [PaperId]
      ,[Title]
      ,[Description]
      ,[Content]
      ,[PublicationDate]
      ,[Like]
      ,[DontLike]
      ,[HeroId]
      ,[AuthorId]
  FROM [dbo].[Paper]
  WHERE [PaperId] = @PaperId