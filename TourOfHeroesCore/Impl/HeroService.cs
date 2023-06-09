using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.HeroEvent;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesCore.Model.Extensions;

namespace TourOfHeroesCore.Impl
{

    public class HeroService : IHeroService
    {
        private readonly IHeroRepository heroRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IEventBus eventBus;

        public HeroService(IHeroRepository heroRepository, IDateTimeProvider dateTimeProvider, IEventBus eventBus)
        {
            this.heroRepository = heroRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.eventBus = eventBus;
        }
        public async Task ComputeHeroLikeCount(Id<int> id)
        {
            var heroPapers = await heroRepository.GetHeroPapers(id.ToDto());
            if (heroPapers.Length == 0) { return; }
            var newHeroPopularity = heroPapers.Select(p => p.ToDomain().GetPaperPopularityValue()).Sum();
            var currentHero = await heroRepository.GetHeroById(id.ToDto());
            var heroToUpdate = currentHero with
            {
                Popularity = newHeroPopularity,
                LastUpdate = dateTimeProvider.GetDateTime(),
            };
            await heroRepository.AddOrUpdateHero(heroToUpdate);
            await PublishPopularityIncreaseEvent(newHeroPopularity, currentHero, heroToUpdate);
        }

        private async Task PublishPopularityIncreaseEvent(int newHeroPopularity, HeroDto currentHero, HeroDto heroToUpdate)
        {
            if (currentHero.Popularity < newHeroPopularity)
                await eventBus.Publish(new HeroPopularityIncreaseEvent(heroToUpdate.ToDomain()));
        }

        public async Task DeleteHero(Id<int> id)
        {
            await heroRepository.DeleteHero(id.ToDto());
            await eventBus.Publish(new HeroDeletedEvent(new HeroEventArgs(id.Value)));
        }

        public async Task<Hero> GetHeroById(Id<int> id)
        {
            var heroById = await heroRepository.GetHeroById(id.ToDto());
            var heroPapers = await heroRepository.GetHeroPapers(id.ToDto());
            var foudedHero = heroById.ToDomain();
            foudedHero.Papers = heroPapers.Select(p => p.ToDomain()).ToArray();
            return foudedHero;
        }

        public async Task<Hero[]> GetHeroes()
        {
            var heroes = await heroRepository.GetHeroes();
            return heroes.Select(p => p.ToDomain()).ToArray();
        }

        public async Task<Id<int>> CreateOrUpdateHero(Hero hero)
        {
            var insertedOrUpdated = await heroRepository.AddOrUpdateHero(hero.ToDto());
            return IdInt.Create(insertedOrUpdated.IdValue);
        }

    }
}