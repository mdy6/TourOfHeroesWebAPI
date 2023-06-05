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
        private Mock<IDateTimeProvider> _dateTimeProvider;
        public HeroLikeCalculatorTests()
        {
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _dateTimeProvider.Setup(x => x.GetDateTime()).Returns(DateTimeOffset.UtcNow);
            _heroService = new HeroService(new FakeHeroRepository(),_dateTimeProvider.Object);
        }

        [Fact]
        public async Task a_hero_without_article_should_have_a_popularity_equal_to_zero()
        {
            IdInt heroId = new IdInt(1);
            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Id.Value.Should().Be(heroId.Value);
            heroResutlt.Papers.Count().Should().Be(0);
            heroResutlt.Popularity.Value.Should().Be(0);
        }

        [Fact]
        public async Task a_hero_with_article_with_nolike_nodontlike_should_have_a_popularity_equal_to_zero()
        {
            IdInt heroId = new IdInt(2);
            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Papers.Count().Should().Be(1);
            heroResutlt.Popularity.Value.Should().Be(0);
        }


        [Fact]
        public async Task a_hero_with_article_with_more_like_than_dontlike_should_have_a_popularity_equal_to_one()
        {
            IdInt heroId = new IdInt(3);

            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Papers.Count().Should().Be(1);
            heroResutlt.Popularity.Value.Should().Be(1);
        }

        public class FakeHeroRepository : IHeroRepository
        {
            private readonly List<HeroDao> _heroDao = new List<HeroDao>();
            private readonly List<PaperDao> _paperDao = new List<PaperDao>() {  };
            private int currentId = 1;
            public static HeroDao DEFAULT_HERO = new HeroDao(0, string.Empty, 0, 0, 0, DateTimeOffset.MinValue);

            public FakeHeroRepository() 
            {
                _heroDao.Add(new HeroDao(1, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                
                _heroDao.Add(new HeroDao(2, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                _paperDao.Add(new PaperDao(1, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 2));
                
                _heroDao.Add(new HeroDao(3, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                _paperDao.Add(new PaperDao(1, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 1, 0, 3));

            }

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

            public Task UpdateHero(HeroDao heroToUpdate)
            {
                var indexToUpdate = _heroDao.FindIndex(h =>  h.Id == heroToUpdate.Id);
                _heroDao[indexToUpdate] = heroToUpdate;
                return Task.CompletedTask;
            }
        }
    }

}