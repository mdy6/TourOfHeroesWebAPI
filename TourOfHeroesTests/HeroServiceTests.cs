using FluentAssertions;
using Moq;
using TourOfHeroesCore;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DAO;
using static TourOfHeroesTests.HeroServiceTests;

namespace TourOfHeroesTests
{
    public class PaperServiceTests
    {
        private IPaperService _paperService;
        private Mock<IReaderNotifier<Paper>> _readerNotifier;
        public PaperServiceTests()
        {
            _readerNotifier = new Mock<IReaderNotifier<Paper>>();
            _paperService = new PaperService(new FakePaperRepository(), _readerNotifier.Object);
        }
        [Fact]
        public void when_paper_is_published_then_reader_are_notified()
        {
            var newPaper = new Paper() 
            { 
                Author = new Author(),
                Hero = new Hero()
            };

            _paperService.Publish(newPaper);

            _readerNotifier.Verify(m => m.NotifyReaders(It.IsAny<INotification<Paper>>()), Times.Once());
        }
    }
    public partial class HeroServiceTests
    {
        private FakePaperRepository _paperRepository;
        private IHeroService _heroService;
        private Mock<IPaperService> _paperService;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        public HeroServiceTests()
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
                .Returns(_paperRepository.AddPapers(new PaperDao(3, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 2, 3,1)));

            await _paperService.Object.Publish(new Paper { Title="new paper on hero 3" });

            await _heroService.ComputeHeroLikeCount(heroId);

            Hero heroResutlt = await _heroService.GetHeroById(heroId);

            heroResutlt.Papers.Count().Should().Be(2);
            heroResutlt.Popularity.Value.Should().Be(0);
        }
    }
}