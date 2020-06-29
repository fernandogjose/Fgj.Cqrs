using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.ViewModels;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserAppService(IMediator mediator, IUnitOfWork unitOfWork, IUserSqlServerRepository userSqlServerRepository)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _userSqlServerRepository = userSqlServerRepository;
        }

        public async Task<ResponseViewModel> CreateAsync(UserCreateRequestViewModel request)
        {
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Adiciona o Perfil
                ProfileCreateCommand profileCreateCommand = new ProfileCreateCommand(Convert.ToInt32(request.IdType), Guid.NewGuid().ToString(), request.Avatar, request.CpfCnpj, request.Address);
                ResponseCommand profileCreateResponse = await _mediator.Send(profileCreateCommand, CancellationToken.None).ConfigureAwait(true);
                if (!profileCreateResponse.Success) return new ResponseViewModel(false, profileCreateResponse.Object);

                // Adiciona o Usuário
                UserCreateCommand userCreateCommand = new UserCreateCommand((int)profileCreateResponse.Object, Guid.NewGuid().ToString(), request.Name, request.Email);
                ResponseCommand userCreateResponse = await _mediator.Send(userCreateCommand, CancellationToken.None).ConfigureAwait(true);
                if (!userCreateResponse.Success) return new ResponseViewModel(false, userCreateResponse.Object);

                // Comita e Retorna
                _unitOfWork.CommitTransaction();
                return new ResponseViewModel(true, "User created");
            }
        }

        public async Task<ResponseViewModel> UpdateAsync(UserUpdateRequestViewModel request)
        {
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Atualiza o Perfil
                ProfileUpdateCommand profileUpdateCommand = new ProfileUpdateCommand(request.IdType, request.GuidProfile, request.Avatar, request.CpfCnpj, request.Address);
                ResponseCommand profileUpdateResponse = await _mediator.Send(profileUpdateCommand, CancellationToken.None).ConfigureAwait(true);
                if (!profileUpdateResponse.Success) return new ResponseViewModel(false, profileUpdateResponse.Object);

                // Atualiza o Usuário
                UserUpdateCommand userUpdateCommand = new UserUpdateCommand(request.GuidUser, request.Name, request.Email);
                ResponseCommand userUpdateResponse = await _mediator.Send(userUpdateCommand, CancellationToken.None).ConfigureAwait(true);
                if (!userUpdateResponse.Success) return new ResponseViewModel(false, userUpdateResponse.Object);

                // Comita e Retorna
                _unitOfWork.CommitTransaction();
                return new ResponseViewModel(true, "User updated");
            }
        }

        public async Task<ResponseViewModel> DeleteAsync(string guidUser, string guidProfile)
        {
            // Obs: Fiz pensando em ser um para um entre usuário e perfil, poderia ser um para muitos e ai neste caso não excluiria o perfil quando o usuário fosse excluido

            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Remove o Usuário
                UserDeleteCommand userDeleteCommand = new UserDeleteCommand(guidUser);
                ResponseCommand userAddResponse = await _mediator.Send(userDeleteCommand, CancellationToken.None).ConfigureAwait(true);
                if (!userAddResponse.Success) return new ResponseViewModel(false, userAddResponse.Object);

                // Deleta o Perfil
                ProfileDeleteCommand profileDeleteCommand = new ProfileDeleteCommand(guidProfile);
                ResponseCommand profileDeleteResponse = await _mediator.Send(profileDeleteCommand, CancellationToken.None).ConfigureAwait(true);
                if (!profileDeleteResponse.Success) return new ResponseViewModel(false, profileDeleteResponse.Object);

                // Comita e Retorna
                _unitOfWork.CommitTransaction();
                return new ResponseViewModel(true, "User deleted");
            }
        }

        public ResponseViewModel GetAll()
        {
            IEnumerable<UserGetAllResponseQuery> userGetAllResponseQuery = _userSqlServerRepository.GetAll();
            return new ResponseViewModel(true, userGetAllResponseQuery);
        }

        public ResponseViewModel GetByGuid(string request)
        {
            UserGetResponseQuery userGetResponseQuery = _userSqlServerRepository.GetByGuid(request);
            return new ResponseViewModel(true, userGetResponseQuery);
        }
    }
}
