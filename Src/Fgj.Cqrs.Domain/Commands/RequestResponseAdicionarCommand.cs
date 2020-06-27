using MediatR;
using System;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class RequestResponseAdicionarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public DateTime Data { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public RequestResponseAdicionarCommand(DateTime data, string request, string response, string endPoint)
        {
            Data = data;
            Request = request;
            Response = response;
            EndPoint = endPoint;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

            if (string.IsNullOrEmpty(Request))
            {
                Erros.Add("Request é obrigatório");
            }

            if (string.IsNullOrEmpty(Response))
            {
                Erros.Add("Response é obrigatório");
            }

            if (string.IsNullOrEmpty(EndPoint))
            {
                Erros.Add("EndPoint é obrigatório");
            }
        }
    }
}
