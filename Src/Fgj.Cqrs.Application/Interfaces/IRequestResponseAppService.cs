﻿using Fgj.Cqrs.Application.ViewModels;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Application.Interfaces
{
    public interface IRequestResponseAppService
    {
        Task AddAsync(RequestResponseAddRequestViewModel request);
    }
}
