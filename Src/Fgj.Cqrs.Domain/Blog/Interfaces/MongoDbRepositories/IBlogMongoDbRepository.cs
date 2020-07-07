using Fgj.Cqrs.Domain.Blog.Commands;
using Fgj.Cqrs.Domain.Blog.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Blog.Interfaces.MongoDbRepositories
{
    public interface IBlogMongoDbRepository
    {
        Task CreateAsync(BlogCreateCommand request);

        Task<List<BlogGetAllResponseQuery>> GetAllAsync();
    }
}
