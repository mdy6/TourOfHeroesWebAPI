using Microsoft.Extensions.Options;
using TourOfHeroesCore.Configuration;

namespace TourOfHeroesRepository.Repository.Impl
{
    public class RepositoryBase
    {
        protected IOptions<DatabaseInfoOptions> options;

        public RepositoryBase(IOptions<DatabaseInfoOptions> options)
        {
            this.options = options;
        }
    }
}