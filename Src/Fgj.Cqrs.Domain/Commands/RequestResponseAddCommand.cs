using MediatR;
using System;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class RequestResponseAddCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public DateTime DateTime { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public RequestResponseAddCommand(DateTime dataTime, string request, string response, string endPoint)
        {
            DateTime = dataTime;
            Request = request;
            Response = response;
            EndPoint = endPoint;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Request))
            {
                Errors.Add("Request é obrigatório");
            }

            if (string.IsNullOrEmpty(Response))
            {
                Errors.Add("Response é obrigatório");
            }

            if (string.IsNullOrEmpty(EndPoint))
            {
                Errors.Add("EndPoint é obrigatório");
            }
        }
    }
}
