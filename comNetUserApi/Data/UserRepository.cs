using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User? GetUser(Guid id)
        {
            var result = users.Where(x => x.UserId == id).ToList();
            return result.FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
