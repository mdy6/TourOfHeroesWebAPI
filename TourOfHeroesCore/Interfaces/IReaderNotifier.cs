namespace TourOfHeroesCore.Interfaces
{
    public interface IReaderNotifier<T>
    {
        Task NotifyReaders(INotification<T> notification);
    }
}