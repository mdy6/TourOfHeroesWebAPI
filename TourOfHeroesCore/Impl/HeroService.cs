using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.Extensions;

namespace TourOfHeroesCore.Impl
{
    public class HeroService : IHeroService
    {

        private readonly IHeroRepository heroRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public HeroService(IHeroRepository heroRepository, IDateTimeProvider dateTimeProvider)
        {
            this.heroRepository = heroRepository;
            this.dateTimeProvider = dateTimeProvider;
        }
        public async Task ComputeHeroLikeCount(Id<int> id)
        {
            var heroPapers = await heroRepository.GetHeroPapers(id.ToDao());
            if(heroPapers.Length == 0) {return; }
            var newHeroPopularity = heroPapers.Select(p => p.ToDomain().GetPaperPopularityValue()).Sum();
            var currentHero = await heroRepository.GetHeroById(id.ToDao());
            var heroToUpdate = currentHero with
            {
                Popularity = newHeroPopularity,
                LastUpdate = dateTimeProvider.GetDateTime(),
            };
            await heroRepository.UpdateHero(heroToUpdate);
        }

        public async Task<Hero> GetHeroById(Id<int> id)
        {
            var heroById = await heroRepository.GetHeroById(id.ToDao());
            var heroPapers = await heroRepository.GetHeroPapers(id.ToDao());
            var foudedHero = heroById.ToDomain();
            foudedHero.Papers = heroPapers.Select(p => p.ToDomain()).ToArray();
            return foudedHero;
        }
    }
}