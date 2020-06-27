using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class ProfileAddCommandHandler : IRequestHandler<ProfileAddCommand, ResponseCommand>
    {
        private readonly IProfileSqlServerRepository _profileSqlServerRepository;

        public ProfileAddCommandHandler(IProfileSqlServerRepository profileSqlServerRepository)
        {
            _profileSqlServerRepository = profileSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            int profileId = _profileSqlServerRepository.Add(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, profileId));
        }
    }
}