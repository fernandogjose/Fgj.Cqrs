namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetResponseQuery
    {
        public int IdProfile { get; }

        public string Guid { get; }

        public string Name { get; }

        public string Email { get; }

        public UserGetResponseQuery(int idProfile, string guid, string name, string email)
        {
            IdProfile = idProfile;
            Guid = guid;
            Name = name;
            Email = email;
        }
    }
}
