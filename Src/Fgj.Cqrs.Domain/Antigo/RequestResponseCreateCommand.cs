using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System;

namespace Fgj.Cqrs.Domain.Commands
{
    public class RequestResponseCreateCommand : IRequest<ResponseCommand>
    {
        public DateTime DateTime { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public string Method { get; }

        public RequestResponseCreateCommand(DateTime dataTime, string request, string response, string endPoint, string method)
        {
            DateTime = dataTime;
            Request = request;
            Response = response;
            EndPoint = endPoint;
            Method = method;
        }
    }
}
