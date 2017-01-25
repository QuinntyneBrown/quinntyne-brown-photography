using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using static QuinntyneBrownPhotography.ApiConfiguration;

[assembly: OwinStartup(typeof(QuinntyneBrownPhotography.Web.Startup))]

namespace QuinntyneBrownPhotography.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
                Install(config, app);
            });
        }
    }
}
