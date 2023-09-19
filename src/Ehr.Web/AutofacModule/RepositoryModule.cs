using System.Reflection;
using Autofac;
using Ehr.Infrastructure.SqlServer;
using Ehr.Core.IRepository;

namespace Ehr.Web.AutofacModule
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(EhrRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            
            Assembly assembly = Assembly.Load("Ehr.Infrastructure");

            var t =
            builder.RegisterAssemblyTypes(assembly)
            .Where(a => a.Name.EndsWith("Repository") && !a.IsInterface && !a.IsAbstract && a.IsPublic);

            builder.RegisterAssemblyTypes(assembly)
            .Where(a => a.Name.EndsWith("Repository") && !a.IsInterface && !a.IsAbstract && a.IsPublic)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        }
    }
}