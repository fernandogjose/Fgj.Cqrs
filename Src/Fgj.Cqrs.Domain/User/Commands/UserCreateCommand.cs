using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class UserCreateCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public int IdProfile { get; }

        public string Guid { get; set; }

        public string Name { get; }

        public string Email { get; }

        public UserCreateCommand(int idProfile, string guid, string name, string email)
        {
            IdProfile = idProfile;
            Guid = guid;
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

            if (string.IsNullOrEmpty(Guid))
            {
                Errors.Add("Guid is required");
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
