using Fgj.Cqrs.Application.Blog.ViewModels;
using Fgj.Cqrs.Application.Share.ViewModels;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Blog.Interfaces
{
    public interface IBlogAppService
    {
        Task<ResponseViewModel> CreateAsync(BlogCreateRequestViewModel request);

        Task<ResponseViewModel> GetAllAsync();
    }
}
