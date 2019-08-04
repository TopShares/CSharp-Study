using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Ruanmou.CoreDemo.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .ConfigureServices(services => services.AddSingleton<Framework.Interface.IPhone, Framework.Service.AndroidPhone>())
                //注册2
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()//主要注册管道内容
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
