using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.Extensions;

namespace TourOfHeroesCore.Impl
{
    public class HeroService : IHeroService
    {

        private readonly IHeroRepository heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            this.heroRepository = heroRepository;
        }
        public async Task ComputeHeroLikeCount(Id<int> id)
        {
            var heroPapers = await heroRepository.GetHeroPapers(id.ToDao());
            if(heroPapers.Length == 0) {return; }
        }

        public async Task<Hero> GetHeroById(Id<int> id)
        {
            var heroById = await heroRepository.GetHeroById(id.ToDao());
            return heroById.ToDomain();
        }
    }
}