using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DAO;

public class HeroRepository : IHeroRepository
{
    private readonly IConfiguration configuration;

    public HeroRepository(IDbConnection dbConnection, IConfiguration configuration)
    {
        DbConnection = dbConnection;
        this.configuration = configuration;
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
        var getHeroesQuery = File.ReadAllText(configuration["SqlQueryPath"]);
        return (await DbConnection.QueryAsync<HeroDao>(getHeroesQuery)).ToArray();
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