using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = GetNums();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<int> GetNums()
        {
            var nums = new List<int>() { 1, 2 };

            foreach (var num in nums)
            {
                yield return num;
            }
        }
    }
}