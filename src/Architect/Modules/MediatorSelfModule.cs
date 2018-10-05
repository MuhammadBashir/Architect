using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MediatR;

namespace Architect.Modules
{
    public class MediatorSelfModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mediatrAssembly = typeof(IMediator).Assembly;

            builder.RegisterAssemblyTypes(mediatrAssembly)
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}
