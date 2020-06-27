using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ResponseCommand>
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserUpdateCommandHandler(IUserSqlServerRepository userSqlServerRepository)
        {
            _userSqlServerRepository = userSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            _userSqlServerRepository.Update(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "User Updated"));
        }
    }
}