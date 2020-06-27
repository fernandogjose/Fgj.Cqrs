using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.ViewModels;
using Fgj.Cqrs.Domain.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.AppServices
{
    public class RequestResponseAppService : IRequestResponseAppService
    {
        private readonly IMediator _mediator;

        public RequestResponseAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task AdicionarAsync(RequestResponseAdicionarRequestViewModel request)
        {
            RequestResponseAdicionarCommand command = new RequestResponseAdicionarCommand(DateTime.Now, request.Request, request.Response, request.EndPoint);
            await _mediator.Send(command, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
