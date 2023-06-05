using FluentAssertions;
using Moq;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesTests
{
    public class HeroLikeCalculatorTests
    {
        private IHeroService _heroService;

        public HeroLikeCalculatorTests()
        {
            _heroService = new HeroService(new FakeHeroRepository());
        }

        [Fact]
        public async Task a_hero_without_article_should_have_a_popularity_equal_to_zero()
        {
            IdInt heroId = new IdInt(1);
            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Papers.Count().Should().Be(0);
            heroResutlt.Popularity.Value.Should().Be(0);
        }

        public class FakeHeroRepository : IHeroRepository
        {
            private readonly List<HeroDao> _heroDao = new List<HeroDao>();
            private readonly List<PaperDao> _paperDao = new List<PaperDao>() {  };
            private int currentId = 1;
            public static HeroDao DEFAULT_HERO = new HeroDao(0, string.Empty, 0, 0, 0, DateTimeOffset.MinValue);

            public Task<IdDao> AddHero(HeroDao heroDao)
            {
                var heroDaoToInsert = heroDao with
                {
                    Id = currentId
                };
                
                _heroDao.Add(heroDaoToInsert);
                currentId++;
                return Task.FromResult(new IdDao(heroDaoToInsert.Id));

            }

            public Task<HeroDao> GetHeroById(IdDao id)
            {
                return Task.FromResult(_heroDao.FirstOrDefault(h => h.Id == id.Id) ?? DEFAULT_HERO);
            }

            public Task<PaperDao[]> GetHeroPapers(IdDao heroId)
            {
                return Task.FromResult(_paperDao.Where(p => p.HeroId == heroId.Id).ToArray());
            }
        }
    }

}