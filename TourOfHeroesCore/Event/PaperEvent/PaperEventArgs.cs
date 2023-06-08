using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperEventArgs
    {
        public PaperEventArgs(Paper paper)
        {
            PaperId = paper.Id.Value;
            PaperName = paper.Title;
            HeroId = paper.Hero.Id.Value;
        }

        public int PaperId { get; private set; }
        public string PaperName { get; private set; }
        public int HeroId { get;private set; }
    }
}
