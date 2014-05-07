using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

namespace OWINWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("web started");
                Console.ReadKey();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                ctx.Response.ContentType = "text/html";
                await ctx.Response.WriteAsync("hello from TGG!<br/>");
                await next();
            });

            app.Use<MyMiddleware>();
        }
    }

    public class MyMiddleware : OwinMiddleware
    {
        public MyMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Middleware called: " + context.Request.Uri);
            await context.Response.WriteAsync("middlewara called with url: " + context.Request.Uri);
            await Next.Invoke(context);
        }
    }
}
