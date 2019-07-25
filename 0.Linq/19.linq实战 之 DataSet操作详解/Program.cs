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
            var table = BuildTable();

            var query = from n in table.AsEnumerable()
                        group n by n.Field<int?>("Age") into grp
                        let mykey = grp.Key                           //将当前分组的key给了一个mykey的局部变量
                        orderby mykey descending
                        select new
                        {
                            Age = grp.Key,
                            Count = grp.Count()
                        };

        }

        static DataTable BuildTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Age", typeof(int)));

            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var row = table.NewRow();

                row.SetField<string>("Name", "jack" + rand.Next(0, 1000));
                row.SetField<int>("Age", rand.Next(20, 30));


                //row["Name"] = "jack" + rand.Next(0, 1000);
                //row["Age"] = rand.Next(20, 30);

                table.Rows.Add(row);
            }

            return table;
        }
    }
}