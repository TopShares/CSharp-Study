using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ruanmou.CoreDemo.DB;
using Microsoft.EntityFrameworkCore;
using Ruanmou.CoreDemo.Framework.Interface;
using Ruanmou.CoreDemo.Framework.Service;
using Microsoft.AspNetCore.Http;

namespace Ruanmou.CoreDemo.MVC
{
    public class Startup
    {
        /// <summary>
        /// 构造函数  完成初始化配置
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 这个方法会在项目启动的时候被调用，并且EFDbContext会被注册到ASP.NET Core自带的IOC中，以后就可以在别的地方直接注入EFDbContext了（下面会用到）。
        /// Configuration.GetConnectionString("SqlServer")这是去读系统的配置，系统配置都在appsettings.json文件中，需要手动添加一下配置，添加完成后类似于：
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<EFDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            // Add framework services.
            services.AddMvc();
            services.AddSession();//使用session

            services.AddTransient<IHeadphone, Headphone>();//注册1
            services.AddTransient<IMicrophone, Microphone>();
            services.AddTransient<IPower, Power>();
            services.AddTransient<IPhone, ApplePhone>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 预先注入的
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "apiroute",
                   template: "api/{controller}/{action}/{id}",
                   defaults: new { controller = "Users", action = "Get", id = 0 });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
