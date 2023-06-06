using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperEventArgs
    {
        public PaperEventArgs(Paper paper)
        {
            PaperId = paper.Id.Value;
            PaperName = paper.Title;
        }

        public int PaperId { get; private set; }
        public string PaperName { get; private set; }
    }
}
