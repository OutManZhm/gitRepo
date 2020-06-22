using Autofac;
using WeddingCelebration.IService;

namespace WeddingCelebration.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IWeddBaseService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
