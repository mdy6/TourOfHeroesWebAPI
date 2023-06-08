using Dapper;
using Microsoft.Extensions.Options;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesRepository.Repository.DAO;
using TourOfHeroesRepository.Repository.Exceptions;

namespace TourOfHeroesRepository.Repository.Impl
{
    public class PaperRepository : RepositoryBase, IPaperRepository
    {
        public PaperRepository(IOptions<DatabaseInfoOptions> options) : base(options)
        {
        }

        public async Task<IdDto> AddPapers(PaperDto paper)
        {
            using var connection = options.GetConnection();
            var paperToInsert = paper.ToDao();
            var id = await connection.QueryAsync<int>(options.GetSqlQueryContent("UpsertPaper.sql"),
                                                      new { HeroId = paperToInsert.HeroId, Title = paperToInsert.Title, Description = paperToInsert.Description, Content = paperToInsert.Content, PublicationDate = paperToInsert.PublicationDate, Like = paperToInsert.Like, DontLike = paperToInsert.DontLike, AuthorId = paperToInsert.AuthorId });
            if (id is null || id.FirstOrDefault() == 0)
                throw new ObjectNotInsertedException("This hero has not been inserted");
            return new IdDto(id.FirstOrDefault());
        }

        public Task DeleteByHeroId(IdDto idDao)
        {
            using var connection = options.GetConnection();
            connection.QueryAsync(options.GetSqlQueryContent("DeletePapersByHeroId.sql"), new { HeroId = idDao.IdValue });
            return Task.CompletedTask;
        }

        public async Task<PaperDto> GetPaperById(IdDto id)
        {
            using var connection = options.GetConnection();
            var getPapersByHeroId = options.GetSqlQueryContent("GetPapers.sql");
            return (await connection.QueryFirstAsync<PaperDao>(getPapersByHeroId, new {PaperId = id.IdValue})).ToDto();
        }

        public async Task<PaperDto[]> GetPapers()
        {
            using var connection = options.GetConnection();
            var getPapersByHeroId = options.GetSqlQueryContent("GetPapers.sql");
            return (await connection.QueryAsync<PaperDao>(getPapersByHeroId)).Select(dao => dao.ToDto()).ToArray();
        }

        public async Task<IdDto> Update(PaperDto paper)
        {
            using var connection = options.GetConnection();
            var paperToUpdate = paper.ToDao();
            var id = await connection.QueryAsync<int>(options.GetSqlQueryContent("UpsertPaper.sql"),
                                                      new { HeroId = paperToUpdate.HeroId, Title = paperToUpdate.Title, Description = paperToUpdate.Description, Content = paperToUpdate.Content, PublicationDate = paperToUpdate.PublicationDate, Like = paperToUpdate.Like, DontLike = paperToUpdate.DontLike, AuthorId = paperToUpdate.AuthorId });
            if (id is null || id.FirstOrDefault() == 0)
                throw new ObjectNotInsertedException("This hero has not been inserted");
            return new IdDto(id.FirstOrDefault());
        }
    }
}