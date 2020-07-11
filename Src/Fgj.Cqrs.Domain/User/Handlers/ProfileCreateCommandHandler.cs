using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class ProfileCreateCommandHandler : IRequestHandler<ProfileCreateCommand, ResponseCommand>
    {
        private readonly IProfileSqlServerRepository _profileSqlServerRepository;

        public ProfileCreateCommandHandler(IProfileSqlServerRepository profileSqlServerRepository)
        {
            _profileSqlServerRepository = profileSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ProfileCreateCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            int profileId = _profileSqlServerRepository.Create(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, profileId));
        }
    }
}