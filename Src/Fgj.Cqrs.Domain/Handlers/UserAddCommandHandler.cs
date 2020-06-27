using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Validations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommand, ResponseCommand>
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;
        private readonly UserValidation _userValidation;

        public UserAddCommandHandler(IUserSqlServerRepository userSqlServerRepository, UserValidation userValidation)
        {
            _userSqlServerRepository = userSqlServerRepository;
            _userValidation = userValidation;
        }

        public Task<ResponseCommand> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Validações de persistencia
            Tuple<bool, string> validation = _userValidation.IsDuplicateName(0, request.Name);
            if (validation.Item1)
            {
                request.AddError(validation.Item2);
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            int userId = _userSqlServerRepository.Add(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, userId));
        }
    }
}