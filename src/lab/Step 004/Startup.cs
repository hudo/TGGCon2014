using System.Web.Http;
using AutoMapper;
using GetItDone.Data;
using GetItDone.Domain;
using GetItDone.Infrastructure;
using GetItDone.ViewModel;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
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
            ObjectFactory.Initialize(x => x.For<TicketsContext>().Use<TicketsContext>().LifecycleIs<HttpContextLifecycle>());

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("notes", "api/tickets/{ticketid}/{controller}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            // structuremap ioc/di for webapi controllers
            config.DependencyResolver = new StructureMapDependencyResolver(ObjectFactory.Container);

            // replace pascal case with camel case and use string enums
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver= new CamelCasePropertyNamesContractResolver();
            //jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            // plugin webapi to owin pipeline
            app.UseWebApi(config);

            // Automapper configuration

            Mapper.CreateMap<Ticket, TicketModel>()
                .ForMember(x => x.CreatedBy, m => m.MapFrom(s => s.CreatedBy.FirstName + " " + s.CreatedBy.LastName));

            Mapper.CreateMap<TicketModel, Ticket>()
                .ForMember(x => x.CreatedBy, m => m.Ignore());
        }
    }
}
