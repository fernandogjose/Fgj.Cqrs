using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class UserUpdateCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public string Guid { get; }

        public int IdProfile { get; }

        public string Name { get; }

        public string Email { get; }

        public UserUpdateCommand(string guid, int idProfile, string name, string email)
        {
            Guid = guid;
            IdProfile = idProfile;
            Name = name;
            Email = email;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Guid))
            {
                Errors.Add("Guid is required");
            }

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
