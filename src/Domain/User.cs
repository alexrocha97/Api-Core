namespace Domain
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            FirstName = null;
            LastName = null;
            Email = null;
            Password = null;
        }

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
