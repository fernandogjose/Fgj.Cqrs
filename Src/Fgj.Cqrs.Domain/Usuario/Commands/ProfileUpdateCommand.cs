using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class ProfileUpdateCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public int IdType { get; }

        public string Guid { get; }

        public string Avatar { get; }

        public string CpfCnpj { get; }

        public string Address { get; }

        public ProfileUpdateCommand(int idType, string guid, string avatar, string cpfCnpj, string address)
        {
            IdType = idType;
            Guid = guid;
            Avatar = avatar;
            CpfCnpj = cpfCnpj;
            Address = address;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Guid))
            {
                Errors.Add("Guid is required");
            }

            if (IdType == 0)
            {
                Errors.Add("Type is required");
            }

            if (string.IsNullOrEmpty(CpfCnpj))
            {
                Errors.Add("CpfCnpj is required");
            }
        }
    }
}
