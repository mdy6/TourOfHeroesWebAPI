namespace TourOfHeroesCore.Model
{
    public interface IObjectId<T>
    {
        public Id<T> Id { get; set; }
    }
}
