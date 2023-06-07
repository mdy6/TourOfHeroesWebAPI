using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesRepository.Repository.DAO;

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

        public Task<IdDto> AddHero(HeroDto heroDao)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHero(IdDto idDao)
        {
            throw new NotImplementedException();
        }

        public Task<HeroDto> GetHeroById(IdDto id)
        {
            throw new NotImplementedException();
        }

        public async Task<HeroDto[]> GetHeroes()
        {
            using var connection = new SqlConnection(databaseInfoOptions.Value.ConnectionString);
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