using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class ProfileDeleteCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public string Guid { get; }

        public ProfileDeleteCommand(string guid)
        {
            Guid = guid;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Guid))
            {
                Errors.Add("Guid is required");
            }
        }
    }
}
