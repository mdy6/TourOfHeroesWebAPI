using FluentAssertions;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesTests
{

    public class FakeHeroRepository : IHeroRepository
    {
        private readonly List<HeroDto> _heroDao = new List<HeroDto>();
        private readonly IPaperRepository paperRepository;
        private int currentId = 1;
        public static HeroDto DEFAULT_HERO = new HeroDto(0, string.Empty, 0, 0, 0, DateTimeOffset.MinValue);

        public FakeHeroRepository(IPaperRepository paperRepository)
        {

            _heroDao.Add(new HeroDto(1, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));

            _heroDao.Add(new HeroDto(2, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
            paperRepository.AddPapers(new PaperDto(1, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 2, 1));

            _heroDao.Add(new HeroDto(3, string.Empty, 0, 0, 0, DateTimeOffset.MinValue));
            paperRepository.AddPapers(new PaperDto(2, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 1, 0, 3, 1));
            this.paperRepository = paperRepository;
        }

        public Task<IdDto> AddOrUpdateHero(HeroDto heroDao)
        {
            var heroDaoToInsert = heroDao with
            {
                HeroId = currentId
            };

            _heroDao.Add(heroDaoToInsert);
            currentId++;
            return Task.FromResult(new IdDto(heroDaoToInsert.HeroId));

        }

        public Task<HeroDto> GetHeroById(IdDto id)
        {
            return Task.FromResult(_heroDao.FirstOrDefault(h => h.HeroId == id.IdValue) ?? DEFAULT_HERO);
        }

        public async Task<PaperDto[]> GetHeroPapers(IdDto heroId)
        {
            return (await paperRepository.GetPapers()).Where(p => p.HeroId == heroId.IdValue).ToArray();
        }

        public Task UpdateHero(HeroDto heroToUpdate)
        {
            var indexToUpdate = _heroDao.FindIndex(h => h.HeroId == heroToUpdate.HeroId);
            _heroDao[indexToUpdate] = heroToUpdate;
            return Task.CompletedTask;
        }

        public Task DeleteHero(IdDto idDao)
        {
            var heroToDelete = _heroDao.FirstOrDefault(t => t.HeroId == idDao.IdValue);
             if(heroToDelete == null)
            return Task.CompletedTask;
            _heroDao.Remove(heroToDelete);
            return Task.CompletedTask;
        }

        public Task<HeroDto[]> GetHeroes()
        {
            throw new NotImplementedException();
        }
    }
}