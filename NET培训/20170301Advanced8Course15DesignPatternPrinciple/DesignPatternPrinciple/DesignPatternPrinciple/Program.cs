using DesignPatternPrinciple.LOD;
using DesignPatternPrinciple.LSP;
using DesignPatternPrinciple.SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple
{
    /// <summary>
    /// 1.  单一职责原则（Single Responsibility Principle）
    /// 2.  里氏替换原则（Liskov Substitution Principle）
    /// 3.  依赖倒置原则（Dependence Inversion Principle）
    /// 4.  接口隔离原则（Interface Segregation Principle）
    /// 5.  迪米特法则  （Law Of Demeter）
    /// 6.  开闭原则    (Open Closed Principle)
    /// 
    /// 这些是原则、建议、常规做法，并不是严格标准
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的设计模式六大原则");
                //SRPShow.Show();
                //LSPShow.Show();
                LODShow.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
