using TourOfHeroesCore.Impl;

namespace TourOfHeroesCore.Interfaces
{
    public interface IReaderNotifier<T>
    {
        Task NotifyReaders(Notification<T> notification);
    }
}