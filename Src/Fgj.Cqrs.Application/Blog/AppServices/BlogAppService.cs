using Fgj.Cqrs.Application.Blog.Interfaces;
using Fgj.Cqrs.Application.Blog.ViewModels;
using Fgj.Cqrs.Application.Share.ViewModels;
using Fgj.Cqrs.Domain.Blog.Commands;
using Fgj.Cqrs.Domain.Blog.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Blog.AppServices
{
    public class BlogAppService : IBlogAppService
    {
        private readonly IMediator _mediator;
        private readonly IBlogMongoDbRepository _blogMongoDbRepository;

        public BlogAppService(IMediator mediator, IBlogMongoDbRepository blogMongoDbRepository)
        {
            _mediator = mediator;
            _blogMongoDbRepository = blogMongoDbRepository;
        }

        public async Task<ResponseViewModel> CreateAsync(BlogCreateRequestViewModel request)
        {
            // Adiciona o Blog
            BlogCreateCommand blogCreateCommand = new BlogCreateCommand(request.Title, request.Description, request.Image, request.Tag, request.Url);
            ResponseCommand responseCommand = await _mediator.Send(blogCreateCommand, CancellationToken.None).ConfigureAwait(true);

            // Retorna
            return (!responseCommand.Success)
                ? new ResponseViewModel(false, responseCommand.Object)
                : new ResponseViewModel(true, "Blog created");
        }

        public async Task<ResponseViewModel> GetAllAsync()
        {
            ResponseViewModel response = new ResponseViewModel(true, await _blogMongoDbRepository.GetAllAsync().ConfigureAwait(true));
            return response;
        }
    }
}
