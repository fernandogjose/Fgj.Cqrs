using Fgj.Cqrs.Application.AppServices;
using Fgj.Cqrs.Application.Blog.AppServices;
using Fgj.Cqrs.Application.Blog.Interfaces;
using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Domain.Blog.Commands;
using Fgj.Cqrs.Domain.Blog.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Interfaces.Validations;
using Fgj.Cqrs.Domain.Share.Pipelines;
using Fgj.Cqrs.Domain.Validations;
using Fgj.Cqrs.MongoDb.Helpers;
using Fgj.Cqrs.MongoDb.Repositories;
using Fgj.Cqrs.SqlServer.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Fgj.Cqrs.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // MongoDB Repository
            services.AddSingleton<MongoDbHelper>();
            services.AddTransient<IRequestResponseMongoDbRepository, RequestResponseMongoDbRepository>();
            services.AddTransient<IBlogMongoDbRepository, BlogMongoDbRepository>();

            // Sql Server Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(Environment.GetEnvironmentVariable("FGJ-CQRS-SQL-CONNECTION")));
            services.AddTransient<IUserSqlServerRepository, UserSqlServerRepository>();
            services.AddTransient<IProfileSqlServerRepository, ProfileSqlServerRepository>();
            services.AddTransient<ITypeSqlServerRepository, TypeSqlServerRepository>();

            // Application
            services.AddTransient<IRequestResponseAppService, RequestResponseAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<ITypeAppService, TypeAppService>();
            services.AddTransient<IBlogAppService, BlogAppService>();

            // Command e Handler
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatePipeline<,>));
            services.AddMediatR(typeof(RequestResponseCreateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UserCreateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UserUpdateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UserDeleteCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProfileCreateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProfileUpdateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProfileDeleteCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BlogCreateCommand).GetTypeInfo().Assembly);

            // Validations
            services.AddTransient<IUserValidation, UserValidation>();
        }
    }
}