﻿namespace Fgj.Cqrs.Application.ViewModels
{
    public class UserAddRequestViewModel
    {
        public int IdType { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public string CpfCnpj { get; set; }

        public string Address { get; set; }
    }
}
