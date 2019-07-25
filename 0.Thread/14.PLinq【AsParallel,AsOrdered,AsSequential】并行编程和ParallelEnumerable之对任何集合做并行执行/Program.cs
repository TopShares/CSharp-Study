using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            var nums = Enumerable.Range(0, 2).ToList();

            nums[0] = 10000;

            var query = from n in nums.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount)
                                                   .WithCancellation(source.Token)
                                                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                   .WithMergeOptions(ParallelMergeOptions.Default)
                        select new
                        {
                            thread = GetThreadID(),
                            num = n
                        };

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }

        static int GetThreadID()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}


