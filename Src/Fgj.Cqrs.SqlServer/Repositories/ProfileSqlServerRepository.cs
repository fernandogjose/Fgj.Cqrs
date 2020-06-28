using Dapper;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;

namespace Fgj.Cqrs.SqlServer.Repositories
{
    public class ProfileSqlServerRepository : BaseSqlServerRepository, IProfileSqlServerRepository
    {
        public ProfileSqlServerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Create(ProfileCreateCommand request)
        {
            const string sql = "" +
                " INSERT INTO " +
                " FgjCqrsProfile (IdType, Guid, Avatar, CpfCnpj, Address) " +
                "         VALUES (@IdType, @Guid, @Avatar, @CpfCnpj, @Address) " +
                " SELECT @@IDENTITY";

            return _unitOfWork.Connection.ExecuteScalar<int>(sql, request, _unitOfWork.Transaction);
        }

        public void Update(ProfileUpdateCommand request)
        {
            const string sql = "" +
                " UPDATE FgjCqrsProfile " +
                " SET IdType  = @IdType" +
                "   , Avatar  = @Avatar" +
                "   , CpfCnpj = @CpfCnpj" +
                "   , Address = @Address" +
                " WHERE Guid = @Guid";

            _unitOfWork.Connection.Execute(sql, request, _unitOfWork.Transaction);
        }

        public void Delete(ProfileDeleteCommand request)
        {
            const string sql = "" +
                " DELETE FgjCqrsProfile " +
                " WHERE Guid = @Guid";

            _unitOfWork.Connection.Execute(sql, request, _unitOfWork.Transaction);
        }
    }
}
