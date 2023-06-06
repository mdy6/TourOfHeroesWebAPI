using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesTests
{

    public class FakePaperRepository : IPaperRepository
    {
        private readonly List<PaperDao> _paperDaos = new List<PaperDao>() { };
        private readonly PaperDao DEFAULT_PAPER = new PaperDao(0, string.Empty, string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 0, 0, 0);
        public Task<IdDao> AddPapers(PaperDao paper)
        {
            _paperDaos.Add(paper);
            return Task.FromResult(new IdDao(_paperDaos.Count));
        }

        public Task DeleteByHeroId(IdDao idDao)
        {
            throw new NotImplementedException();
        }

        public Task<PaperDao> GetPaperById(IdDao id)
        {
            return Task.FromResult(_paperDaos.FirstOrDefault(t => t.PaperId == id.IdValue) ?? DEFAULT_PAPER);
        }

        public Task<PaperDao[]> GetPapers()
        {
            return Task.FromResult(_paperDaos.ToArray());
        }

        public Task<IdDao> Update(PaperDao paperDao)
        {
            var index = _paperDaos.FindIndex(p => p.PaperId == paperDao.PaperId);
            _paperDaos[index] = paperDao;
            return Task.FromResult(new IdDao(_paperDaos[index].IdValue));
        }
    }
}