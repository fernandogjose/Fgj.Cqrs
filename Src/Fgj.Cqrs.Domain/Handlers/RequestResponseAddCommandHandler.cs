using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class RequestResponseAddCommandHandler : IRequestHandler<RequestResponseAddCommand, ResponseCommand>
    {
        private readonly IRequestResponseMongoDbRepository _requestResponseMongoDbRepository;

        public RequestResponseAddCommandHandler(IRequestResponseMongoDbRepository requestResponseMongoDbRepository)
        {
            _requestResponseMongoDbRepository = requestResponseMongoDbRepository;
        }

        public Task<ResponseCommand> Handle(RequestResponseAddCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir no mongo
            _requestResponseMongoDbRepository.AddAsync(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Request e Response adicionado com sucesso"));
        }
    }
}