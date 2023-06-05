namespace TourOfHeroesCore.Model
{
    public class User : IObjectId<int>
    {
        public Id<int> Id { get; set; } = new IdInt(0);
        public string UserName { get; set; }
        public Role[] Roles { get; set; }
    }
}
