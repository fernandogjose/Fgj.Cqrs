namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetRequestQuery
    {
        public int Id { get; }

        public string Name { get; }

        public UserGetRequestQuery(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
