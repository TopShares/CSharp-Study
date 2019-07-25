using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //cache的最大限制是：100
            MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions()
            {
            });

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            //var cacheOptions = new MemoryCacheEntryOptions()
            //{
            //    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10),  //10s过期
            //};

            //cacheOptions.RegisterPostEvictionCallback((key, value, reason, obj) =>
            //{
            //    Console.WriteLine(reason);
            //});

            //cacheOptions.AddExpirationToken(new CancellationChangeToken(tokenSource.Token));

            //memoryCache.Set("key", "value", cacheOptions);


            ////System.Threading.Thread.Sleep(2000);

            //tokenSource.CancelAfter(1000 * 2);



            for (int i = 0; i < 100; i++)
            {
                memoryCache.Set<string>(i.ToString(), i.ToString(), new MemoryCacheEntryOptions()
                {
                });
            }

            memoryCache.Compact(0.2);

            Console.Read();
        }
    }
}
