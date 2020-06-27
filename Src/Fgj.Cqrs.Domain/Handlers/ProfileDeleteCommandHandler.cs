using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class ProfileDeleteCommandHandler : IRequestHandler<ProfileDeleteCommand, ResponseCommand>
    {
        private readonly IProfileSqlServerRepository _profileSqlServerRepository;

        public ProfileDeleteCommandHandler(IProfileSqlServerRepository profileSqlServerRepository)
        {
            _profileSqlServerRepository = profileSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ProfileDeleteCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            _profileSqlServerRepository.Delete(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Profile deleted"));
        }
    }
}