using MediatR;
using System;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Commands
{
    public class RequestResponseAddCommand : IRequest<ResponseCommand>
    {
        public DateTime DateTime { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public string Method { get; }

        public RequestResponseAddCommand(DateTime dataTime, string request, string response, string endPoint, string method)
        {
            DateTime = dataTime;
            Request = request;
            Response = response;
            EndPoint = endPoint;
            Method = method;
        }
    }
}
