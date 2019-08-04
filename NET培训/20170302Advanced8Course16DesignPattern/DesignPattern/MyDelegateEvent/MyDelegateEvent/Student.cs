using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Study()
        {
            Console.WriteLine("学习.net高级班公开课");
        }

        public static void StudyAdvanced()
        {
            Console.WriteLine("学习.net高级班vip课");
        }

        public static void Show()
        {
            Console.WriteLine("123");
        }
    }
}
