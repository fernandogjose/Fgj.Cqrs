using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Interfaces.Validations;
using Fgj.Cqrs.Domain.Queries;
using System;

namespace Fgj.Cqrs.Domain.Validations
{
    public class UserValidation : IUserValidation
    {
        private readonly IUserSqlServerRepository _userSqlServerRepository;

        public UserValidation(IUserSqlServerRepository userSqlServerRepository)
        {
            _userSqlServerRepository = userSqlServerRepository;
        }

        public Tuple<bool, string> IsDuplicateName(string guid, string name)
        {
            UserGetByNameResponseQuery response = _userSqlServerRepository.GetByName(name);
            return Tuple.Create(response != null && response.Guid != guid, "Name already exist");
        }
    }
}
