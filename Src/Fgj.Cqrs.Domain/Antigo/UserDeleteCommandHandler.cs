using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, ResponseCommand>
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserDeleteCommandHandler(IUserSqlServerRepository userSqlServerRepository)
        {
            _userSqlServerRepository = userSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            _userSqlServerRepository.Delete(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "User deleted"));
        }
    }
}