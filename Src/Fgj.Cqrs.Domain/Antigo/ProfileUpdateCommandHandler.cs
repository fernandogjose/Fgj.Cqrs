using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Domain.Handlers
{
    public class ProfileUpdateCommandHandler : IRequestHandler<ProfileUpdateCommand, ResponseCommand>
    {
        private readonly IProfileSqlServerRepository _profileSqlServerRepository;

        public ProfileUpdateCommandHandler(IProfileSqlServerRepository profileSqlServerRepository)
        {
            _profileSqlServerRepository = profileSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            // Validações
            if (!request.IsValid())
            {
                return Task.FromResult(new ResponseCommand(false, request.Errors));
            }

            // Persistir
            _profileSqlServerRepository.Update(request);

            // Response
            return Task.FromResult(new ResponseCommand(true, "Profile updated"));
        }
    }
}