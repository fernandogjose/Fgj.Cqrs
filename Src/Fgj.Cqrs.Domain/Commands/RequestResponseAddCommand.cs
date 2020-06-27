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

        public string Method { get; }

        public RequestResponseAddCommand(DateTime dataTime, string request, string response, string endPoint, string method)
        {
            DateTime = dataTime;
            Request = request;
            Response = response;
            EndPoint = endPoint;
            Method = method;
        }

        public override void Validate()
        {
            Errors = new List<string>(0);

            if (string.IsNullOrEmpty(Request))
            {
                Errors.Add("Request is required");
            }

            if (string.IsNullOrEmpty(Response))
            {
                Errors.Add("Response is required");
            }

            if (string.IsNullOrEmpty(EndPoint))
            {
                Errors.Add("EndPoint is required");
            }

            if (string.IsNullOrEmpty(Method))
            {
                Errors.Add("Method is required");
            }
        }
    }
}
