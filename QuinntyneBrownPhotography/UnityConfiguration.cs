using QuinntyneBrownPhotography.Security;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Services;
using QuinntyneBrownPhotography.Utilities;
using Microsoft.Practices.Unity;

namespace QuinntyneBrownPhotography
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
