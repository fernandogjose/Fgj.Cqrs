using Dapper;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;

namespace Fgj.Cqrs.SqlServer.Repositories
{
    public class ProfileSqlServerRepository : BaseSqlServerRepository, IProfileSqlServerRepository
    {
        public ProfileSqlServerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Add(ProfileAddCommand request)
        {
            const string sql = "" +
                " INSERT INTO " +
                " FgjCqrsProfile (IdType, Avatar, CpfCnpj, Address) " +
                "         VALUES (@IdType, @Avatar, @CpfCnpj, @Address) " +
                " SELECT @@IDENTITY";

            return _unitOfWork.Connection.ExecuteScalar<int>(sql, request, _unitOfWork.Transaction);
        }
    }
}
