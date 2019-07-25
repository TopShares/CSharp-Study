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
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Person>() {
                 new Person() { ID=1, Name="jack", Age=22 },
                 new Person() { ID=1, Name="john", Age=32 },
                 new Person() { ID=2, Name="mary", Age=20 }
            };

            var query = list.OrderBy(i => i.ID).ToList();

            var query2 = list.OrderBy(i => i.ID).ThenByDescending(i => i.Age).ToList();
        }
    }

    class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}