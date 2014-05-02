using System.Web.Http;
using GetItDone.Data;
using GetItDone.Infrastructure;
using Microsoft.Owin;
using Owin;
using StructureMap;
using StructureMap.Web.Pipeline;

[assembly: OwinStartup(typeof(GetItDone.Startup))]

namespace GetItDone
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<TicketsContext>().Use<TicketsContext>().LifecycleIs<HttpContextLifecycle>();
            });

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            app.UseWebApi(config);

            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(ObjectFactory.Container);
        }
    }
}
