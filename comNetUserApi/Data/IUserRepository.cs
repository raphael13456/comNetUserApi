using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public User? GetUser(Guid id);
        public List<User> GetUsers();
        public User? Validate(UserLoginDto loginDto);
    }
}
