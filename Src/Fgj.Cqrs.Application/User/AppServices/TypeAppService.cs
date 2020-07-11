using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.Share.ViewModels;
using Fgj.Cqrs.Application.ViewModels;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Queries;
using System.Collections.Generic;

namespace Fgj.Cqrs.Application.AppServices
{
    public class TypeAppService : ITypeAppService
    {
        private readonly ITypeSqlServerRepository _typeSqlServerRepository;

        public TypeAppService(ITypeSqlServerRepository typeSqlServerRepository)
        {
            _typeSqlServerRepository = typeSqlServerRepository;
        }

        public ResponseViewModel GetAll()
        {
            IEnumerable<TypeGetAllResponseQuery> typeGetAllResponseQuery = _typeSqlServerRepository.GetAll();
            return new ResponseViewModel(true, typeGetAllResponseQuery);
        }
    }
}
