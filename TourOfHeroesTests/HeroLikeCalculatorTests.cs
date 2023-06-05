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
        private FakePaperRepository _paperRepository;
        private IHeroService _heroService;
        private Mock<IPaperService> _paperService;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        public HeroLikeCalculatorTests()
        {
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _dateTimeProvider.Setup(x => x.GetDateTime()).Returns(DateTimeOffset.UtcNow);
            _paperRepository = new FakePaperRepository();
            _heroService = new HeroService(new FakeHeroRepository(_paperRepository), _dateTimeProvider.Object);
            _paperService = new Mock<IPaperService>();
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

        [Fact]
        public async Task a_hero_with_articles_with_a_positive_popularity_should_have_a_popularity_lose_popularity_when_a_new_paper_has_dontlike_then_like()
        {
            IdInt heroId = new IdInt(3);

            _paperService.Setup(m => m.Publish(It.IsAny<Paper>()))
                .Returns(_paperRepository.AddPapers(new PaperDao(3, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 2, 3)));

            await _paperService.Object.Publish(new Paper { Title="new paper on hero 3" });

            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Papers.Count().Should().Be(2);
            heroResutlt.Popularity.Value.Should().Be(0);
        }


        public class FakePaperRepository : IPaperRepository
        {
            private readonly List<PaperDao> _paperDao = new List<PaperDao>() {  };
            public Task<IdDao> AddPapers(PaperDao paper)
            {
                _paperDao.Add(paper);
                return Task.FromResult(new IdDao(_paperDao.Count));
            }

            public Task<PaperDao[]> GetPapers()
            {
                return Task.FromResult(_paperDao.ToArray());
            }
        }

        public class FakeHeroRepository : IHeroRepository
        {
            private readonly List<HeroDao> _heroDao = new List<HeroDao>();
            private readonly IPaperRepository paperRepository;
            private int currentId = 1;
            public static HeroDao DEFAULT_HERO = new HeroDao(0, string.Empty, 0, 0, 0, DateTimeOffset.MinValue);

            public FakeHeroRepository(IPaperRepository paperRepository) 
            {

                _heroDao.Add(new HeroDao(1, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                
                _heroDao.Add(new HeroDao(2, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                paperRepository.AddPapers(new PaperDao(1, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 2));
                
                _heroDao.Add(new HeroDao(3, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
                paperRepository.AddPapers(new PaperDao(2, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 1, 0, 3));
                this.paperRepository = paperRepository;
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

            public async Task<PaperDao[]> GetHeroPapers(IdDao heroId)
            {
                return (await paperRepository.GetPapers()).Where(p => p.HeroId == heroId.Id).ToArray();
            }

            public Task UpdateHero(HeroDao heroToUpdate)
            {
                var indexToUpdate = _heroDao.FindIndex(h =>  h.Id == heroToUpdate.Id);
                _heroDao[indexToUpdate] = heroToUpdate;
                return Task.CompletedTask;
            }

            public Task DeleteHero(IdDao idDao)
            {
                throw new NotImplementedException();
            }

            public Task<HeroDao[]> GetHeroes()
            {
                throw new NotImplementedException();
            }
        }
    }
}