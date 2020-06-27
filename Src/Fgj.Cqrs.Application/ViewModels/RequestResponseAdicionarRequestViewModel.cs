using System;

namespace Fgj.Cqrs.Application.ViewModels
{
    public class RequestResponseAdicionarRequestViewModel
    {
        public DateTime Data { get; }

        public string Request { get; }

        public string Response { get; }

        public string EndPoint { get; }

        public RequestResponseAdicionarRequestViewModel(DateTime data, string request, string response, string endpoint)
        {
            Data = data;
            Request = request;
            Response = response;
            EndPoint = endpoint;
        }
    }
}
