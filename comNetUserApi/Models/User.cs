namespace comNetUserApi.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Key { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
    }
}
