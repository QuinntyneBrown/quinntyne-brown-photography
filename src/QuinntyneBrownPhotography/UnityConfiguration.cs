using QuinntyneBrownPhotography.Security;
using QuinntyneBrownPhotography.Features.Core;
using Microsoft.Practices.Unity;
using MediatR;
using QuinntyneBrownPhotography.Data;
using System.Linq;
using System;

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
            
            container.RegisterInstance(AuthConfiguration.LazyConfig);

            container.RegisterType<IMediator, Mediator>();

            var classes = AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly)
                .Where(x => x.Name.Contains("Controller") == false && x.FullName.Contains("Data.Models") == false)
                .ToList();

            container.RegisterTypes(classes, WithMappings.FromAllInterfaces, GetName, GetLifetimeManager);
            container.RegisterInstance<SingleInstanceFactory>(t => container.IsRegistered(t) ? container.Resolve(t) : null);
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));


            return container;
        }

        static bool IsNotificationHandler(Type type)
            => type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));

        static LifetimeManager GetLifetimeManager(Type type)
            => IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;

        static string GetName(Type type)
            => IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
    }
}
