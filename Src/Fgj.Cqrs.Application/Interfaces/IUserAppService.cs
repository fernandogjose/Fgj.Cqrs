using Fgj.Cqrs.Application.ViewModels;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<ResponseViewModel> AddAsync(UserAddRequestViewModel request);
    }
}
