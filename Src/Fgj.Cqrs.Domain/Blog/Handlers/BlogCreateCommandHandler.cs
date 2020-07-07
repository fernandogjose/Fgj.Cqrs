using Fgj.Cqrs.Domain.Blog.Commands;
using Fgj.Cqrs.Domain.Blog.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Blog.Handlers
{
    public class BlogCreateCommandHandler : IRequestHandler<BlogCreateCommand, ResponseCommand>
    {
        private readonly IBlogMongoDbRepository _blogMongoDbRepository;

        public BlogCreateCommandHandler(IBlogMongoDbRepository requestResponseMongoDbRepository)
        {
            _blogMongoDbRepository = requestResponseMongoDbRepository;
        }

        public Task<ResponseCommand> Handle(BlogCreateCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir no mongo
            _blogMongoDbRepository.CreateAsync(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Request e Response adicionado com sucesso"));
        }
    }
}