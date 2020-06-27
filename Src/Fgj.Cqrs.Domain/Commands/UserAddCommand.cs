using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class UserAddCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public int IdProfile { get; }

        public string Name { get; }

        public string Email { get; }

        public UserAddCommand(int idProfile, string name, string email)
        {
            IdProfile = idProfile;
            Name = name;
            Email = email;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (IdProfile <= 0)
            {
                Errors.Add("Profile is required");
            }

            if (string.IsNullOrEmpty(Name))
            {
                Errors.Add("Name is required");
            }

            if (string.IsNullOrEmpty(Email))
            {
                Errors.Add("E-mail is required");
            }
        }
    }
}
