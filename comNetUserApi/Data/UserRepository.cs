using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User()
            {
                Username = "alex",
                Key = "alexAlex123",
                Email = "alex.patola@mail.com"
            }
        };
        
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

        public User? Validate(UserLoginDto loginDto)
        {
            return users.FirstOrDefault(x => x.Key == loginDto.Key && x.Username == loginDto.Username);
        }
    }
}
