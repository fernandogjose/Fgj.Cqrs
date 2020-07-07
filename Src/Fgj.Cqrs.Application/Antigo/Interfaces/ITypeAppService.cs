using Fgj.Cqrs.Application.Share.ViewModels;
using Fgj.Cqrs.Application.ViewModels;

namespace Fgj.Cqrs.Application.Interfaces
{
    public interface ITypeAppService
    {
        ResponseViewModel GetAll();
    }
}
