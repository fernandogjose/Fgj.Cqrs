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
            const string sql = "INSERT INTO FgjCqrsProfile (IdType, Avatar, CpfCnpj, Address) VALUES (@IdType, @Avatar, @CpfCnpj, @Address) SELECT @@IDENTITY";
            return _unitOfWork.Connection.ExecuteScalar<int>(sql, request, _unitOfWork.Transaction);
        }

        //public IEnumerable<ComunicadoListarResponseQuery> Listar()
        //{
        //    string sql = @"SELECT Comunicado.Id
        //                        , Comunicado.CreateDate AS Data
        //                        , Comunicado.Title AS Titulo
        //                        , Comunicado.Description AS Descricao
        //                     , Grupo.Description AS Grupo
        //                   FROM CrmComunication AS Comunicado(nolock)
        //                   INNER JOIN CrmGroup AS Grupo on Comunicado.GroupId = Grupo.Id
        //                   WHERE Comunicado.SchoolId = 1";

        //    using var connection = _unitOfWork.Connection;
        //    IEnumerable<ComunicadoListarResponseQuery> response = connection.Query<ComunicadoListarResponseQuery>(sql);

        //    return response;
        //}
    }
}
