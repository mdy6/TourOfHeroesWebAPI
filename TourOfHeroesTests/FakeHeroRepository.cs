using FluentAssertions;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesTests
{

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
            paperRepository.AddPapers(new PaperDao(1, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 2, 1));

            _heroDao.Add(new HeroDao(3, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
            paperRepository.AddPapers(new PaperDao(2, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 1, 0, 3, 1));
            this.paperRepository = paperRepository;
        }

        public Task<IdDao> AddHero(HeroDao heroDao)
        {
            var heroDaoToInsert = heroDao with
            {
                IdValue = currentId
            };

            _heroDao.Add(heroDaoToInsert);
            currentId++;
            return Task.FromResult(new IdDao(heroDaoToInsert.IdValue));

        }

        public Task<HeroDao> GetHeroById(IdDao id)
        {
            return Task.FromResult(_heroDao.FirstOrDefault(h => h.IdValue == id.IdValue) ?? DEFAULT_HERO);
        }

        public async Task<PaperDao[]> GetHeroPapers(IdDao heroId)
        {
            return (await paperRepository.GetPapers()).Where(p => p.HeroId == heroId.IdValue).ToArray();
        }

        public Task UpdateHero(HeroDao heroToUpdate)
        {
            var indexToUpdate = _heroDao.FindIndex(h => h.IdValue == heroToUpdate.IdValue);
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