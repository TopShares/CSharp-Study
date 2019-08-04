using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 1 表达式树和表达式目录树
    /// 2 解析表达式目录树，生成sql
    /// 3 表达式树的拼装链接
    /// 4 作业
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今晚学习表达式树Expression");
                ExpressionTest.Show();
                //ExpressionVisitorTest.Show();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
