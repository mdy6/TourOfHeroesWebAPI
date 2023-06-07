using TourOfHeroesCore.Interfaces.Helpers;

namespace TourOfHeroesCore.Impl.Helpers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetDateTime()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}