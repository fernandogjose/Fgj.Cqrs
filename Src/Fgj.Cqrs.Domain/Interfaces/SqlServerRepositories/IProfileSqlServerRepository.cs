using Fgj.Cqrs.Domain.Commands;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IProfileSqlServerRepository
    {
        int Add(ProfileAddCommand request);

        void Update(ProfileUpdateCommand request);

        void Delete(ProfileDeleteCommand request);
    }
}
