using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.ViewModels;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseViewModel> AddAsync(UserAddRequestViewModel request)
        {
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Adiciona o Perfil
                ProfileAddCommand profileAddCommand = new ProfileAddCommand(request.IdType, request.Avatar, request.CpfCnpj, request.Address);
                ResponseCommand profileAddResponse = await _mediator.Send(profileAddCommand, CancellationToken.None).ConfigureAwait(true);
                if (!profileAddResponse.Success) return new ResponseViewModel(false, profileAddResponse.Object);

                // Adiciona o Usuário
                UserAddCommand userAddCommand = new UserAddCommand((int)profileAddResponse.Object, request.Name, request.Email);
                ResponseCommand userAddResponse = await _mediator.Send(userAddCommand, CancellationToken.None).ConfigureAwait(true);
                if (!userAddResponse.Success) return new ResponseViewModel(false, userAddResponse.Object);

                // Comita e Retorna
                _unitOfWork.CommitTransaction();
                return new ResponseViewModel(true, "Usuário adicionado com sucesso");
            }
        }
    }
}
