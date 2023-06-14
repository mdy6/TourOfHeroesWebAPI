using TourOfHeroesCore.Impl;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroPopularityIncreaseNotification : Notification<HeroEventArgs>
    {
        public HeroPopularityIncreaseNotification(HeroEventArgs notificationArgs) : base(notificationArgs)
        {
        }

        public override string GetNotificationContent()
        {

            return $"{NotificationArgs.Name} popularity increased by 1 ";
        }
    }
}
