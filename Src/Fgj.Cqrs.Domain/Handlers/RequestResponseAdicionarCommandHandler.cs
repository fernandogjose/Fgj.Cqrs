using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class RequestResponseAdicionarCommandHandler : IRequestHandler<RequestResponseAdicionarCommand, ResponseCommand>
    {
        private readonly IRequestResponseMongoDbRepository _requestResponseMongoRepository;

        public RequestResponseAdicionarCommandHandler(IRequestResponseMongoDbRepository requestResponseMongoRepository)
        {
            _requestResponseMongoRepository = requestResponseMongoRepository;
        }

        public Task<ResponseCommand> Handle(RequestResponseAdicionarCommand request, CancellationToken cancellationToken)
        {
            // Persistir no mongo
            _requestResponseMongoRepository.AdicionarAsync(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Request e Response adicionado com sucesso"));
        }
    }
}