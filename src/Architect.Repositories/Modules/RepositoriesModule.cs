using Architect.Infrastructure.Common;
using Architect.Repositories.SqlRepositories;
using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Architect.Repositories.Modules
{
    public class RepositoriesModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = typeof(RepositoriesModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(currentAssembly)
                .InNamespaceOf<LogsRepository>()
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<IConnectionFactory>(c => GetConnectionFactory(c, "DefaultConnectionString"));
        }

        private static SqlConnectionFactory GetConnectionFactory(IComponentContext context, string connectionStringKey)
        {
            var connectionString = context.Resolve<IConfiguration>().GetConnectionString(connectionStringKey);
            return new SqlConnectionFactory(connectionString);
        }
    }
}
