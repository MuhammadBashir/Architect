using Architect.Handlers.LogsHandlers;
using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Architect.Modules
{
    public class MediatorModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = typeof(MediatorModules).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(currentAssembly)
                .InNamespaceOf<LogsHandler>()
                .Where(IsMediatorImplementation)
                .AsImplementedInterfaces()
                .AsSelf();
            
        }


        private static bool IsMediatorImplementation(Type type)
        {
            return type.IsClosedTypeOf(typeof(IRequest<>))
                || type.IsClosedTypeOf(typeof(IRequestHandler<>))
                || type.IsClosedTypeOf(typeof(IRequestHandler<,>));

        }
    }
}
