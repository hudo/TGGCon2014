using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using GetItDone.Data;
using GetItDone.Domain;
using GetItDone.Infrastructure;
using GetItDone.ViewModel;
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
            ObjectFactory.Initialize(x => x.For<TicketsContext>().Use<TicketsContext>().LifecycleIs<HttpContextLifecycle>());

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("notes", "api/tickets/{ticketid}/{controller}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            config.DependencyResolver = new StructureMapDependencyResolver(ObjectFactory.Container);

            app.UseWebApi(config);

            Mapper.CreateMap<Ticket, TicketModel>()
                .ForMember(x => x.CreatedBy, m => m.MapFrom(s => s.CreatedBy.FirstName + " " + s.CreatedBy.LastName));

            Mapper.CreateMap<TicketNote, NoteModel>()
                .ForMember(x => x.CreatedBy, m => m.MapFrom(s => s.CreatedBy.FirstName + " " + s.CreatedBy.LastName));
        }
    }
}
