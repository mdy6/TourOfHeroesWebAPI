using TourOfHeroesCore.Impl;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroNotification : Notification<HeroEventArgs>
    {
        public HeroNotification(HeroEventArgs notificationArgs) : base(notificationArgs)
        {
        }
    }
}
