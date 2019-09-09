using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication1.Middleware;
using Nancy.Owin;
using Nancy;
using System.Web.Http;

namespace WebApplication1
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncommingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine($"Request took: {watch.ElapsedMilliseconds} ms");
                }
            });

            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            app.UseWebApi(httpConfig);

            app.UseNancy(config => config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound));
            // app.Map("/nancy", mappedApp => mappedApp.UseNancy());

            //app.Use(async (ctx, next) => {
            //    await ctx.Response.WriteAsync("<html><head></head><body><h1>Testing<h1></body></html>");
            //});
        }
    }
}