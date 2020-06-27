using MediatR;
using System;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class ProfileAddCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public int IdType { get; }

        public string Avatar { get; }

        public string CpfCnpj { get; }

        public string Address { get; }

        public ProfileAddCommand(int idType, string avatar, string cpfCnpj, string address)
        {
            IdType = idType;
            Avatar = avatar;
            CpfCnpj = cpfCnpj;
            Address = address;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

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
