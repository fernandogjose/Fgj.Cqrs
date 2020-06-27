using System;
using System.Data;

namespace Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitTransaction();

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }
    }
}
