namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetResponseQuery
    {
        public int Id { get; }

        public int IdProfile { get; }

        public string Name { get; }

        public string Email { get; }

        public UserGetResponseQuery(int id, int idProfile, string name, string email)
        {
            Id = id;
            IdProfile = idProfile;
            Name = name;
            Email = email;
        }
    }
}
