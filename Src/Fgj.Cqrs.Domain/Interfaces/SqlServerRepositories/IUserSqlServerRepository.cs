using Fgj.Cqrs.Domain.Commands;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IUserSqlServerRepository
    {
        int Add(UserAddCommand request);
    }
}
