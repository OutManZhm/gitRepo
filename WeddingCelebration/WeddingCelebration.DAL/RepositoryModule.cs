using Autofac;
using Autofac.Extras.DynamicProxy;
using WeddingCelebration.IDAL;

namespace WeddingCelebration.DAL
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkIInterceptor>();
            builder.RegisterType<DBContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InterceptedBy(typeof(UnitOfWorkIInterceptor))
                .InstancePerLifetimeScope();
        }
    }
}
