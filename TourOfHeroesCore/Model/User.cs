namespace TourOfHeroesCore.Model
{
    public class User : IObjectId<int>
    {
        public Id<int> Id { get; set; } = IdInt.Create(0);
        public string UserName { get; set; }
        public Role[] Roles { get; set; }
    }
}
