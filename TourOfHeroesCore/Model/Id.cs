namespace TourOfHeroesCore.Model
{
    public abstract class Id<T>
    {
        public Id(T idValue)
        {
            Value = idValue;
        }
        public T Value { get; set; }
    }

    public class IdInt : Id<int>
    {
        public IdInt(int idValue) : base(idValue)
        {
        }
    }
}
