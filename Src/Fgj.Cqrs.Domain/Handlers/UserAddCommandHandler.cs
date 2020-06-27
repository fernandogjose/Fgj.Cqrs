using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommand, ResponseCommand>
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserAddCommandHandler(IUserSqlServerRepository userSqlServerRepository)
        {
            _userSqlServerRepository = userSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            int userId = _userSqlServerRepository.Add(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, userId));
        }
    }
}