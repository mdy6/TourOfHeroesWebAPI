using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Impl
{
    public class PaperNotification : Notification<PaperEventArgs>
    {
        private readonly string notificationType;

        public PaperNotification(Paper paper): base(new PaperEventArgs(paper))
        {
                
        }
        public PaperNotification(PaperEventArgs notificationArgs) : base(notificationArgs)
        {
        }

        public PaperNotification(PaperEventArgs notificationArgs, string notificationType): base(notificationArgs)
        {
            this.notificationType = notificationType;
        }

        public override string GetNotificationContent()
        {
            return $"Paper {NotificationArgs.PaperName} {notificationType}";
        }
    }
}