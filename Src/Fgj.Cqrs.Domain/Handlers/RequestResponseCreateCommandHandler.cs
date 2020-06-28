using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class RequestResponseCreateCommandHandler : IRequestHandler<RequestResponseCreateCommand, ResponseCommand>
    {
        private readonly IRequestResponseMongoDbRepository _requestResponseMongoDbRepository;

        public RequestResponseCreateCommandHandler(IRequestResponseMongoDbRepository requestResponseMongoDbRepository)
        {
            _requestResponseMongoDbRepository = requestResponseMongoDbRepository;
        }

        public Task<ResponseCommand> Handle(RequestResponseCreateCommand request, CancellationToken cancellationToken)
        {
            // Persistir no mongo
            _requestResponseMongoDbRepository.CreateAsync(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Request e Response adicionado com sucesso"));
        }
    }
}