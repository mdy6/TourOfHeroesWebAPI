using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesTests
{
    public partial class HeroServiceTests
    {
        public class FakePaperRepository : IPaperRepository
        {
            private readonly List<PaperDao> _paperDao = new List<PaperDao>() {  };
            public Task<IdDao> AddPapers(PaperDao paper)
            {
                _paperDao.Add(paper);
                return Task.FromResult(new IdDao(_paperDao.Count));
            }

            public Task<PaperDao[]> GetPapers()
            {
                return Task.FromResult(_paperDao.ToArray());
            }
        }
    }
}