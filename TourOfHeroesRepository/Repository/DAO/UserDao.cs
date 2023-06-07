namespace TourOfHeroesRepository.Repository.DAO
{
    public class UserDao
    {
        public UserDao()
        {
        }

        public UserDao(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public int UserId { get;set; }
        public string UserName { get;set; }
    }
}
