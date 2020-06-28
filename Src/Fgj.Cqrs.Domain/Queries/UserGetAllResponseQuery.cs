namespace Fgj.Cqrs.Domain.Queries
{
    public class UserGetAllResponseQuery
    {
        public int IdProfile { get; }

        public string Type { get; set; }

        public string Avatar { get; set; }

        public string CpfCnpj { get; set; }

        public string Address { get; set; }

        public string GuidProfile { get; }

        public string GuidUser { get; }

        public string Name { get; }

        public string Email { get; }

        public UserGetAllResponseQuery(int idProfile, string guidUser, string name, string email, string guidProfile, string avatar, string cpfCnpj, string address, string type)
        {
            IdProfile = idProfile;
            Type = type;
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
