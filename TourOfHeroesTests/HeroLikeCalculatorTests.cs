using FluentAssertions;
using Moq;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Model;

namespace TourOfHeroesTests
{
    public class HeroLikeCalculatorTests
    {
        private IHeroService _heroService; 
        private Mock<IDateTimeProvider> _dateTimeProvider;
        [Fact]
        public async Task a_hero_without_article_should_have_a_popularity_equal_to_zero()
        {
            var hero = new Hero();
            await _heroService.ComputeHeroLikeCount(hero.Id);

            Hero heroResutlt = await _heroService.GetHeroById(hero.Id);

            heroResutlt.Papers.Count().Should().Be(0);
            heroResutlt.Popularity.Value.Should().Be(0);
        }
    }

}