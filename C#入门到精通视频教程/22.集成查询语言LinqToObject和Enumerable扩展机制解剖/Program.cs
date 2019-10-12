using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Class1
{
    static void Main(string[] args)
    {
        int[] nums = { 10, 20, 30, 40, 50, 60 };

        //这个就是简单的linq语句
        //var query = from n in nums
        //            where n % 20 == 0
        //            select n;

        //统计一下各个数字出现的次数
        //int[] nums = { 10, 30, 20, 10, 30 };

        //var query = from n in nums
        //            group n
        //            by n into g
        //            select new
        //            {
        //                g.Key,
        //                count = g.Count()
        //            };

        //var list = query.ToList();

        //foreach (var item in list)
        //{
        //    Console.WriteLine("num={0}, count={1}", item.Key, item.count);
        //}

        //我们用where方法来实现第一个条件查询的操作
        //var query = nums.Where(i => i % 20 == 0).ToList();

        //Console.WriteLine(string.Join(",", query));

        //求nums中的最小值。 最普通的方法，我们需要自己去写for得到最大值，或者最小值。。。
        //                   如果我们使用linq的话，或者叫扩展发放，那么我们就可以最简化的方法得到结果。。。。

        var min = nums.Min();

        var max = nums.Max();

        //我需要跳过第一个数字，取后面的两个数
        var segments = nums.Skip(1).Take(2);

        var avg = nums.Average();

    }
}