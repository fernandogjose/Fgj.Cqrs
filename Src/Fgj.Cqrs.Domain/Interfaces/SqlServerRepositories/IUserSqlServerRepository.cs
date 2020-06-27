using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IUserSqlServerRepository
    {
        int Add(UserAddCommand request);

        UserGetResponseQuery Get(UserGetRequestQuery request);

        IEnumerable<UserGetAllResponseQuery> GetAll();
    }
}
