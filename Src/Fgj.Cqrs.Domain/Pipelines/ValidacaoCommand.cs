using Fgj.Cqrs.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Pipelines
{
    public class ValidacaoCommand<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : ResponseCommand
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is RequestCommand requestCommand)
            {
                requestCommand.Validar();
            }

            return await next().ConfigureAwait(true);
        }
    }
}