namespace Fgj.Cqrs.Application.ViewModels
{
    public class UserUpdateRequestViewModel
    {
        public int IdType { get; set; }

        public string GuidUser { get; set; }

        public string GuidProfile { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public string CpfCnpj { get; set; }

        public string Address { get; set; }
    }
}
