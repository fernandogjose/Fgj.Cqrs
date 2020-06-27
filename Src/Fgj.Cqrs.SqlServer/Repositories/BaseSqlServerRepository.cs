using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using System;

namespace Fgj.Cqrs.SqlServer.Repositories
{
    public abstract class BaseSqlServerRepository : IDisposable
    {
        protected readonly string _connectionString;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseSqlServerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Connection.Close();
                _unitOfWork.Connection.Dispose();
            }
        }
    }
}