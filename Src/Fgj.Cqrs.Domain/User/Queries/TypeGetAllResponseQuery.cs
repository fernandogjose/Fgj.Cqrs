namespace Fgj.Cqrs.Domain.Queries
{
    public class TypeGetAllResponseQuery
    {
        public int Id { get; }

        public string Description { get; set; }

        public TypeGetAllResponseQuery(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
