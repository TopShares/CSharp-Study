using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_值类型和引用类型___程序运行时候内存的占用 {
    class Program {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
           // Test3();
            //Test4();
            Test5 ();
            
            Console.ReadKey();
        }

        static void Test1()
        {
            int i = 34;
            int j = 34;
            int temp = 334;
            char c = 'a';
            bool b = true;
        }

        static void Test2()
        {
            int i = 34;
            int j = 234;
            string name = "siki";

        }

        static void Test3()
        {
            string name = "siki";
            string name2 = "taikr";
            name = name2;
            name = "google";
            Console.WriteLine(name+":"+name2);
        }

        static void Test4()
        {
            Vector3 v = new Vector3();
            v.x = 100;
            v.y = 100;
            v.z = 100;
            Vector3 v2 = new Vector3();
            v2.x = 200;
            v2.y = 200;
            v2.z = 200;
            v2 = v;
            v2.x = 300;
            Console.WriteLine(v.x);
        }

        static void Test5()
        {
            Vector3[] vArray = new Vector3[]{ new Vector3(), new Vector3(), new Vector3() };//如果数组是一个值类型的数组，那么数组中直接存储值，如果是一个引用类型的数组（数组中存储的是引用类型），那么数组中存储的是引用（内存地址）
            Vector3 v1 = vArray[0];
            vArray[0].x = 100;
            v1.x = 200;
            Console.WriteLine(vArray[0].x);
        }
    }
}
