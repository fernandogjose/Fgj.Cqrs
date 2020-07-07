using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface ITypeSqlServerRepository
    {
        IEnumerable<TypeGetAllResponseQuery> GetAll();
    }
}
