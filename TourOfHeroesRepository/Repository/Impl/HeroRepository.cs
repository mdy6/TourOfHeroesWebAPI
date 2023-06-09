using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesRepository.Repository.DAO;
using TourOfHeroesRepository.Repository.Exceptions;

namespace TourOfHeroesRepository.Repository.Impl
{
    public class HeroRepository :RepositoryBase, IHeroRepository
    {
        public HeroRepository(IOptions<DatabaseInfoOptions> options) : base(options)
        {
        }

        public async Task<IdDto> AddOrUpdateHero(HeroDto heroDto)
        {
            using var connection = options.GetConnection();
            var heroToInsert = heroDto.ToDao();
            var id = await connection.ExecuteScalarAsync<int>(options.GetSqlQueryContent("UpsertHero.sql"),
                                                      new {HeroId = heroToInsert.HeroId , Name = heroToInsert.Name, Popularity = heroToInsert.Popularity, Strength = heroToInsert.Strength, PowerTypeId = heroToInsert.PowerTypeId, LastUpdate = heroToInsert.LastUpdate });
            if (id  == 0)
                throw new ObjectNotInsertedException("This hero has not been inserted");
            return new IdDto(id);

        }

        public Task DeleteHero(IdDto idDao)
        {
            using var connection = options.GetConnection();
            connection.QueryAsync(options.GetSqlQueryContent("DeleteHero.sql"), new {HeroId =  idDao.IdValue});
            return Task.CompletedTask;
        }

   

        public async Task<HeroDto> GetHeroById(IdDto id)
        {
            using var connection = options.GetConnection();
            var hero = await connection.QueryFirstAsync<HeroDao>(options.GetSqlQueryContent("GetHeroById.sql"), new { HeroId = id.IdValue });
            return hero.ToDto();
        }

        public async Task<HeroDto[]> GetHeroes()
        {
            using var connection = options.GetConnection();
            var getHeroesQuery = options.GetSqlQueryContent("GetHeroes.sql");
            return (await connection.QueryAsync<HeroDao>(getHeroesQuery)).Select(dao => dao.ToDto()).ToArray();
        }


        public async Task<PaperDto[]> GetHeroPapers(IdDto heroId)
        {
            using var connection = options.GetConnection();
            var getPapersByHeroId = options.GetSqlQueryContent("GetPapersByHeroId.sql");
            return (await connection.QueryAsync<PaperDao>(getPapersByHeroId, new {HeroId = heroId.IdValue})).Select(dao => dao.ToDto()).ToArray();
        }

        public async Task UpdateHero(HeroDto hero)
        {
            using var connection = options.GetConnection();
            var heroToUpdate = hero.ToDao();
            var id = await connection.QueryAsync<int>(options.GetSqlQueryContent("UpsertHero.sql"),
                                                      new { HeroId = heroToUpdate.HeroId, Name = heroToUpdate.Name, Popularity = heroToUpdate.Popularity, Strength = heroToUpdate.Strength, PowerTypeId = heroToUpdate.PowerTypeId, LastUpdate = heroToUpdate.LastUpdate });
            if (id is null || id.FirstOrDefault() == 0)
                throw new ObjectNotInsertedException("This hero has not been inserted");
        }
    }
}