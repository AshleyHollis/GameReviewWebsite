using Autofac;
using Northwind.Application.Games.Queries;
using Northwind.Common;
using Northwind.Infrastructure;

namespace Northwind.WebApi.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetAllGamesQuery).Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterType<MachineDateTime>().As<IDateTime>();
        }
    }
}