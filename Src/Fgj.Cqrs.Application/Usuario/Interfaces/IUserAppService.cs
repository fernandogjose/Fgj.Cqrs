using Fgj.Cqrs.Application.Share.ViewModels;
using Fgj.Cqrs.Application.ViewModels;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<ResponseViewModel> CreateAsync(UserCreateRequestViewModel request);

        Task<ResponseViewModel> UpdateAsync(UserUpdateRequestViewModel request);

        Task<ResponseViewModel> DeleteAsync(string guidUser, string guidProfile);

        ResponseViewModel GetByGuid(string request);

        ResponseViewModel GetAll();
    }
}
