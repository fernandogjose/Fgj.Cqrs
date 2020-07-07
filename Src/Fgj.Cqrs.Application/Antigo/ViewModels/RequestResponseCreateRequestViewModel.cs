using System;

namespace Fgj.Cqrs.Application.ViewModels
{
    public class RequestResponseCreateRequestViewModel
    {
        public DateTime DateTime { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public string Method { get; }

        public RequestResponseCreateRequestViewModel(DateTime dataTime, string request, string response, string endpoint, string method)
        {
            DateTime = dataTime;
            Request = request;
            Response = response;
            EndPoint = endpoint;
            Method = method;
        }
    }
}
