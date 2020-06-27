using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IUserSqlServerRepository
    {
        int Add(UserAddCommand request);

        void Update(UserUpdateCommand request);

        void Delete(UserDeleteCommand request);

        UserGetByNameResponseQuery GetByName(string name);

        IEnumerable<UserGetAllResponseQuery> GetAll();
    }
}
