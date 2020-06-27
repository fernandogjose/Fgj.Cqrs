namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetAllResponseQuery
    {
        public int Id { get; }

        public int IdProfile { get; }

        public string Name { get; }

        public string Email { get; }

        public UserGetAllResponseQuery(int id, int idProfile, string name, string email)
        {
            Id = id;
            IdProfile = idProfile;
            Name = name;
            Email = email;
        }
    }
}
