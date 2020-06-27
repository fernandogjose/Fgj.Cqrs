using Dapper;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.SqlServer.Repositories
{
    public class UserSqlServerRepository : BaseSqlServerRepository, IUserSqlServerRepository
    {
        public UserSqlServerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Add(UserAddCommand request)
        {
            const string sql = "" +
                " INSERT INTO " +
                " FgjCqrsUser (IdProfile, Name, Email) " +
                "      VALUES (@IdProfile, @Name, @Email) " +
                " SELECT @@IDENTITY";

            return _unitOfWork.Connection.ExecuteScalar<int>(sql, request, _unitOfWork.Transaction);
        }

        public UserGetResponseQuery Get(UserGetRequestQuery request)
        {
            const string sql = "" +
                " SELECT Id, IdProfile, Name, Email " +
                " FROM FgjCqrsUser " +
                " WHERE (Id = @Id OR @Id = 0) AND (Name = @Name OR @Name = '')";

            return _unitOfWork.Connection.QueryFirstOrDefault<UserGetResponseQuery>(sql, request, _unitOfWork.Transaction);
        }

        public IEnumerable<UserGetAllResponseQuery> GetAll()
        {
            const string sql = "" +
                " SELECT Id, IdProfile, Name, Email " +
                " FROM FgjCqrsUser ";

            return _unitOfWork.Connection.Query<UserGetAllResponseQuery>(sql, _unitOfWork.Transaction);
        }
    }
}
