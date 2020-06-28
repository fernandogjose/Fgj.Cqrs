using Dapper;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.SqlServer.Repositories
{
    public class TypeSqlServerRepository : BaseSqlServerRepository, ITypeSqlServerRepository
    {
        public TypeSqlServerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<TypeGetAllResponseQuery> GetAll()
        {
            const string sql = "" +
                " SELECT Id, Description" +
                " FROM FgjCqrsType ";

            return _unitOfWork.Connection.Query<TypeGetAllResponseQuery>(sql);
        }
    }
}
