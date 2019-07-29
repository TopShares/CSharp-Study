using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _014_反射和特性 {
    class Program {
        static void Main(string[] args) {
            //每一个类对应一个type对象，这个type对象存储了这个类 有哪些方法跟哪些数据 哪些成员
            //MyClass my = new MyClass();//一个类中的数据 是存储在对象中的， 但是type对象只存储类的成员
            //Type type = my.GetType();//通过对象获取这个对象所属类 的Type对象
            //Console.WriteLine(type.Name);//获取类的名字
            //Console.WriteLine(type.Namespace);//获取所在的命名空间
            //Console.WriteLine(type.Assembly);
            //FieldInfo[] array= type.GetFields();//只能获取public 字段
            //foreach (FieldInfo info in array)
            //{
            //    Console.Write(info.Name+" ");
            //}
            //PropertyInfo[] array2 = type.GetProperties();
            //foreach (PropertyInfo info in array2)
            //{
            //    Console.Write(info.Name+" ");
            //}
            //MethodInfo[] array3 = type.GetMethods();
            //foreach (MethodInfo info in array3)
            //{
            //    Console.Write(info.Name+" ");
            //}
            //通过type对象可以获取它对应的类的所有成员（public）

            MyClass my = new MyClass();
            Assembly assem =  my.GetType().Assembly;//通过类的type对象获取它所在的程序集 Assembly
            Console.WriteLine(assem.FullName);
            Type[] types = assem.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
            Console.ReadKey();
        }
    }
}
