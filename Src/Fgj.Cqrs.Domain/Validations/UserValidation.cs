using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Queries;
using System;

namespace Fgj.Cqrs.Domain.Validations
{
    public class UserValidation
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserValidation(IUserSqlServerRepository userSqlServerRepository)
        {
            _userSqlServerRepository = userSqlServerRepository;
        }

        public Tuple<bool, string> IsDuplicateName(int id, string name)
        {
            UserGetRequestQuery request = new UserGetRequestQuery(0, name);
            UserGetResponseQuery response = _userSqlServerRepository.Get(request);
            return Tuple.Create(response != null && response.Id != id, "Name already exist");
        }
    }
}
