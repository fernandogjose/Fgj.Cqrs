namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetByGuidResponseQuery
    {
        public int IdType { get; }

        public string Avatar { get; set; }

        public string CpfCnpj { get; set; }

        public string Address { get; set; }

        public string GuidProfile { get; }

        public string GuidUser { get; }

        public string Name { get; }

        public string Email { get; }

        public UserGetByGuidResponseQuery(string guidUser, string name, string email, string guidProfile, string avatar, string cpfCnpj, string address, int idType)
        {
            IdType = idType;
            Avatar = avatar;
            CpfCnpj = cpfCnpj;
            Address = address;
            GuidProfile = guidProfile;
            GuidUser = guidUser;
            Name = name;
            Email = email;
        }
    }
}
