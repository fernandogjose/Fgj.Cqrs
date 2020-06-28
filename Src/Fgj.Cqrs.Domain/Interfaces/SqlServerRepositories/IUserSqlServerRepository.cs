using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IUserSqlServerRepository
    {
        int Create(UserCreateCommand request);

        void Update(UserUpdateCommand request);

        void Delete(UserDeleteCommand request);

        IEnumerable<UserGetAllResponseQuery> GetAll();

        UserGetResponseQuery GetByName(string request);

        UserGetResponseQuery GetByGuid(string request);
    }
}
