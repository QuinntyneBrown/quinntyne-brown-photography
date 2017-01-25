using QuinntyneBrownPhotography.Security;
using QuinntyneBrownPhotography.Utilities;
using QuinntyneBrownPhotography.Utilities;
using Microsoft.Practices.Unity;
using MediatR;
using QuinntyneBrownPhotography.Data;

namespace QuinntyneBrownPhotography
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<QuinntyneBrownPhotographyDataContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
