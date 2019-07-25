using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory factory)
        {
            var logger = factory.CreateLogger("test");

            //app.Map(new PathString("/filter"), (builder) =>
            //{
            //    builder.Run(async (context) =>
            //    {
            //        logger.LogInformation("B before");

            //        await context.Response.WriteAsync("当前是filter的逻辑!");

            //        logger.LogInformation("B after");
            //    });
            //});

            ////更加灵活
            //app.MapWhen(context => context.Request.Path.Value.StartsWith("/filterwhen"), (builder) =>
            //{
            //    builder.Run(async (context) =>
            //    {
            //        logger.LogInformation("C before");

            //        await context.Response.WriteAsync("当前是 filterwhen 的逻辑!");

            //        logger.LogInformation("C after");
            //    });
            //});

            app.UseWhen(context => context.Request.Path.Value.StartsWith("/usewhen"), (builder) =>
            {
                //builder.Run(async (context) =>
                //{
                //    logger.LogInformation("D before");

                //    await context.Response.WriteAsync("当前是 usewhen 的逻辑!");

                //    logger.LogInformation("D after");
                //});

                //我不返回，我只往后面传
                builder.Use(async (context, next) =>
                {
                    logger.LogInformation("E before");
                    await next();
                    logger.LogInformation("E after");
                });
            });

            //app.MapWhen(context => context.Request.Path.Value.StartsWith("/usewhen"), (builder) =>
            //{
            //    //builder.Run(async (context) =>
            //    //{
            //    //    logger.LogInformation("D before");

            //    //    await context.Response.WriteAsync("当前是 usewhen 的逻辑!");

            //    //    logger.LogInformation("D after");
            //    //});

            //    //我不返回，我只往后面传
            //    builder.Use(async (context, next) =>
            //    {
            //        logger.LogInformation("E before");
            //        await next();
            //        logger.LogInformation("E after");
            //    });
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
