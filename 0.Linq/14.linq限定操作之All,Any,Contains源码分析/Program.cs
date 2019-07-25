using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    public class Program
    {
        static void Main(string[] args)
        {
            //只要名称相等，那么就认为两个类是相等的

            var personList = new List<Person>() {
                 new Person() { Name="mary", Age=20 },
                 new Person() { Name="mary", Age=25 }
            };

            //var b = personList.Contains(new Person() { Name = "mary", Age = 25 }, new MyComparer());

            var list = personList.Distinct(new MyComparer()).ToList();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class MyComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}



//foreach (var num in nums)
//{
//    if (num % 10 != 0)
//    {
//        return false;
//    }
//}

//return true;