using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Impl
{
    public class PaperNotification : Notification<PaperEventArgs>
    {
        public PaperNotification(Paper paper): base(new PaperEventArgs(paper))
        {
                
        }
        public PaperNotification(PaperEventArgs notificationArgs) : base(notificationArgs)
        {
        }
    }
}