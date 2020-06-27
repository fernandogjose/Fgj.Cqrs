using Fgj.Cqrs.Domain.Commands;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories
{
    public interface IRequestResponseMongoDbRepository
    {
        Task AddAsync(RequestResponseAddCommand request);
    }
}
