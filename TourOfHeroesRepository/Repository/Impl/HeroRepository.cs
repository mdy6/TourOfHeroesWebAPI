using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DAO;

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

        public Task<IdDao> AddHero(HeroDao heroDao)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHero(IdDao idDao)
        {
            throw new NotImplementedException();
        }

        public Task<HeroDao> GetHeroById(IdDao id)
        {
            throw new NotImplementedException();
        }

        public async Task<HeroDao[]> GetHeroes()
        {
            using var connection = new SqlConnection(databaseInfoOptions.Value.ConnectionString);
            var getHeroesQuery = GetSqlQueryContent("GetHeroes.sql");
            return (await connection.QueryAsync<HeroDao>(getHeroesQuery)).ToArray();
        }

        private string GetSqlQueryContent(string sqlFileName)
        {
            return File.ReadAllText($"{databaseInfoOptions.Value.SqlScriptPath}\\{sqlFileName}");
        }

        public Task<PaperDao[]> GetHeroPapers(IdDao heroId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHero(HeroDao heroToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}