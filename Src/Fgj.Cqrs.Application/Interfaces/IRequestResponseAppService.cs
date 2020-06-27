using Fgj.Cqrs.Application.ViewModels;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Interfaces
{
    public interface IRequestResponseAppService
    {
        Task AdicionarAsync(RequestResponseAdicionarRequestViewModel request);
    }
}
