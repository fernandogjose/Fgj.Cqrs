using Fgj.Cqrs.Application.AppServices;
using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Pipelines;
using Fgj.Cqrs.MongoDb.Helpers;
using Fgj.Cqrs.MongoDb.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Fgj.Cqrs.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Mongo Repository
            services.AddSingleton<MongoDbHelper>();
            services.AddTransient<IRequestResponseMongoDbRepository, RequestResponseMongoDbRepository>();

            // Repository
            //services.AddTransient<IDbConnection>(x => new SqlConnection(appSettings.SqlServer.ConnectionString));
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IDadosConfiguracaoRepository, DadosConfiguracaoRepository>();

            // Application
            services.AddTransient<IRequestResponseAppService, RequestResponseAppService>();

            // Command e Handler
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidacaoCommand<,>));
            services.AddMediatR(typeof(RequestResponseAdicionarCommand).GetTypeInfo().Assembly);
        }
    }
}