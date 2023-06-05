using TourOfHeroesCore.Model;

namespace TourOfHeroesTests
{
    public interface IPaperService
    {
        Task Publish(Paper paper);
    }
}