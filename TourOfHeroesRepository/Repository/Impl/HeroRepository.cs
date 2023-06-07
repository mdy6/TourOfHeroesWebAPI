using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesRepository.Repository.DAO;
using TourOfHeroesRepository.Repository.Exceptions;

namespace TourOfHeroesRepository.Repository.Impl
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IOptions<DatabaseInfoOptions> databaseInfoOptions;

        public HeroRepository(IOptions<DatabaseInfoOptions> databaseInfoOptions)
        {
            this.databaseInfoOptions = databaseInfoOptions;
        }

        public IDbConnection DbConnection { get; }

        public async Task<IdDto> AddHero(HeroDto heroDto)
        {
            using var connection = GetConnection();
            var heroToInsert = heroDto.ToDao();
            var id = await connection.QueryAsync<int>(GetSqlQueryContent("InsertHero.sql"),
                                                      new { Name = heroToInsert.Name, Popularity = heroToInsert.Popularity, Strength = heroToInsert.Strength, PowerTypeId = heroToInsert.PowerTypeId, LastUpdate = heroToInsert.LastUpdate });
            if (id is null || id.FirstOrDefault() == 0)
                throw new ObjectNotInsertedException("This hero has not been inserted");
            return new IdDto(id.FirstOrDefault());

        }

        public Task DeleteHero(IdDto idDao)
        {
            using var connection = GetConnection();
            connection.QueryAsync(GetSqlQueryContent("DeleteHero.sql"), new {HeroId =  idDao.IdValue});
            return Task.CompletedTask;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(databaseInfoOptions.Value.ConnectionString);
        }

        public async Task<HeroDto> GetHeroById(IdDto id)
        {
            using var connection = GetConnection();
            var hero = await connection.QueryFirstAsync<HeroDao>(GetSqlQueryContent("GetHeroById.sql"), new { HeroId = id.IdValue });
            return hero.ToDto();
        }

        public async Task<HeroDto[]> GetHeroes()
        {
            using var connection = GetConnection();
            var getHeroesQuery = GetSqlQueryContent("GetHeroes.sql");
            return (await connection.QueryAsync<HeroDao>(getHeroesQuery)).Select(dao => dao.ToDto()).ToArray();
        }

        private string GetSqlQueryContent(string sqlFileName)
        {
            return File.ReadAllText($"{databaseInfoOptions.Value.SqlScriptPath}\\{sqlFileName}");
        }

        public Task<PaperDto[]> GetHeroPapers(IdDto heroId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHero(HeroDto heroToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}