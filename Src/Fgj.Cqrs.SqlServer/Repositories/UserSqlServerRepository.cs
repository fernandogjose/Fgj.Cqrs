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
                " FgjCqrsUser (Guid, IdProfile, Name, Email) " +
                "      VALUES (@Guid, @IdProfile, @Name, @Email) " +
                " SELECT @@IDENTITY";

            return _unitOfWork.Connection.ExecuteScalar<int>(sql, request, _unitOfWork.Transaction);
        }

        public void Update(UserUpdateCommand request)
        {
            const string sql = "" +
                " UPDATE FgjCqrsUser" +
                " SET Name  = @Name" +
                "   , Email = @Email" +
                " WHERE Guid = @Guid";

            _unitOfWork.Connection.Execute(sql, request, _unitOfWork.Transaction);
        }

        public void Delete(UserDeleteCommand request)
        {
            const string sql = "" +
                " DELETE FgjCqrsUser " +
                " WHERE Guid = @Guid";

            _unitOfWork.Connection.Execute(sql, request, _unitOfWork.Transaction);
        }

        public IEnumerable<UserGetAllResponseQuery> GetAll()
        {
            const string sql = "" +
                " SELECT FgjCqrsUser.IdProfile, FgjCqrsUser.Guid as GuidUser, FgjCqrsUser.Name, FgjCqrsUser.Email, " +
                "        FgjCqrsProfile.Guid as GuidProfile, FgjCqrsProfile.Avatar, FgjCqrsProfile.CpfCnpj, FgjCqrsProfile.Address," +
                "        FgjCqrsType.Description as Type" +
                " FROM FgjCqrsUser " +
                " INNER JOIN FgjCqrsProfile ON FgjCqrsUser.IdProfile = FgjCqrsProfile.Id" +
                " INNER JOIN FgjCqrsType ON FgjCqrsProfile.IdType = FgjCqrsType.Id";

            return _unitOfWork.Connection.Query<UserGetAllResponseQuery>(sql, _unitOfWork.Transaction);
        }

        public UserGetResponseQuery GetByName(string request)
        {
            const string sql = "" +
                " SELECT IdProfile, Guid, Name, Email " +
                " FROM FgjCqrsUser " +
                " WHERE Name = @Name";

            return _unitOfWork.Connection.QueryFirstOrDefault<UserGetResponseQuery>(sql, new { Name = request }, _unitOfWork.Transaction);
        }

        public UserGetResponseQuery GetByGuid(string request)
        {
            const string sql = "" +
                " SELECT IdProfile, Guid, Name, Email " +
                " FROM FgjCqrsUser " +
                " WHERE Guid = @Guid";

            return _unitOfWork.Connection.QueryFirstOrDefault<UserGetResponseQuery>(sql, new { Guid = request }, _unitOfWork.Transaction);
        }
    }
}
