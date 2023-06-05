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
        }

        public Task<Hero> GetHeroById(Id<int> id)
        {
            throw new NotImplementedException();
        }
    }
}