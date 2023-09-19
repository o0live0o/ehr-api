using System.Reflection;
using Autofac;
using Ehr.Application.DingDing;

namespace Ehr.Web.AutofacModule
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DingDingAuthService>().InstancePerLifetimeScope();

            Assembly assembly = Assembly.Load("Ehr.Application");
            builder.RegisterAssemblyTypes(assembly)
            .Where(a => a.Name.EndsWith("Service") && !a.IsInterface && !a.IsAbstract && a.IsPublic)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        }
    }
}