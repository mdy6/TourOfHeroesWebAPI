using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesTests
{

    public class FakePaperRepository : IPaperRepository
    {
        private readonly List<PaperDto> _paperDaos = new List<PaperDto>() { };
        private readonly PaperDto DEFAULT_PAPER = new PaperDto(0, string.Empty, string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 0, 0);
        public Task<IdDto> AddPapers(PaperDto paper)
        {
            _paperDaos.Add(paper);
            return Task.FromResult(new IdDto(_paperDaos.Count));
        }

        public Task DeleteByHeroId(IdDto idDao)
        {
            throw new NotImplementedException();
        }

        public Task<PaperDto> GetPaperById(IdDto id)
        {
            return Task.FromResult(_paperDaos.FirstOrDefault(t => t.PaperId == id.IdValue) ?? DEFAULT_PAPER);
        }

        public Task<PaperDto[]> GetPapers()
        {
            return Task.FromResult(_paperDaos.ToArray());
        }

        public Task<IdDto> Update(PaperDto paperDao)
        {
            var index = _paperDaos.FindIndex(p => p.PaperId == paperDao.PaperId);
            _paperDaos[index] = paperDao;
            return Task.FromResult(new IdDto(_paperDaos[index].HeroId));
        }
    }
}