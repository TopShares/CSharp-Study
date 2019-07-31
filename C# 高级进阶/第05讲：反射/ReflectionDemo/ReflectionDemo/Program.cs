using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Diagnostics;

namespace ReflectionDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //  程序依据需求的不同，耦合度不断的变化，开发者应该对这一些列变化深入掌握，才能更好的把握.Net原理

            #region 【1】普通对象的创建：性能最好，最容易理解，耦合度最高

            Console.WriteLine("\r\n【1】普通对象的创建----------------------------------");
            Student student1 = new Student();
            Console.WriteLine(student1.GetEntityTypeById());

            #endregion

            #region 【2】基于接口的对象创建：接口更好的体现面向抽象编程，一定程度解耦

            Console.WriteLine("\r\n【2】基于接口的对象创建-----------------------------");
            IQueryService student2 = new Student();
            Console.WriteLine(student2.GetEntityTypeById());

            #endregion

            #region 【3】反射的基本使用

            Console.WriteLine("\r\n【3】反射的基本使用----------------------------------");
            Assembly ass1 = Assembly.Load("ReflectionDemo");//在当前运行目录下根据程序集名称加载

            string path = System.IO.Directory.GetCurrentDirectory() + "\\ReflectionDemo.exe";
            Assembly ass2 = Assembly.LoadFile(path);//使用完整的路径加载程序集文件
            Assembly ass3 = Assembly.LoadFrom("ReflectionDemo.exe");//根据程序集文件名称，加载当前运行目录下的程序集

            //观察程序集对象给我们提供的信息
            foreach (var item in ass1.GetTypes())//Type表示当前程序集中所能找到的可用类型
            {
                Console.WriteLine(item.Name + " \t" + item);
            }

            #endregion

            #region 【4】基于反射的对象创建

            Console.WriteLine("\r\n【4】基于反射的对象创建-----------------------------");

            Type studentType = ass1.GetType("ReflectionDemo.Student");//根据一个类或接口的完全限定名，得到这个类型，这个类型可以是我目前使用的各种类型：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。

            Student student3 = (Student)Activator.CreateInstance(studentType);//Activator并非反射中的类
            Student student4 = (Student)Assembly.Load("ReflectionDemo").CreateInstance("ReflectionDemo.Student");
            IQueryService student5 = (Student)Assembly.Load("ReflectionDemo").CreateInstance("ReflectionDemo.Student");
            Console.WriteLine(student3.GetEntityTypeById());
            Console.WriteLine(student4.GetEntityTypeById());
            Console.WriteLine(student5.GetEntityTypeById());

            #endregion

            #region 【5】反射的基本使用（对象的延迟创建：简单工厂，抽象工厂...）

            Console.WriteLine("\r\n【5】反射在简单工厂中的使用-------------------------");
            IQueryService student6 = SimpleFactory.GetEntity();
            Console.WriteLine(student6.GetEntityTypeById());

            #endregion

            #region 【6】在反射中使用构造方法

            Console.WriteLine("\r\n【6】在反射中使用构造方法-----------------------");
            Type stuType = Assembly.Load("ReflectionDemo").GetType("ReflectionDemo.Student");

            //获取程序集中指定类型的构造方法
            ConstructorInfo[] ctors = studentType.GetConstructors();
            Console.WriteLine("当前类型中构造函数的总数：" + ctors.Length);
            //显示所有的构造方法在IL中的名称（在IL中都是.ctor,可以通过ILDASM工具查看）
            foreach (ConstructorInfo item in ctors)
            {
                Console.WriteLine(item.Name);
            }

            //通过构造方法创建对象（请用断点调试下面的三条语句）
            object stuObj1 = Activator.CreateInstance(stuType);//调用无参数的构造方法
            object stuObj2 = Activator.CreateInstance(stuType, new object[] { 1001 });//调用一个参数的构造方法
            object stuObj3 = Activator.CreateInstance(stuType, new object[] { 1001, "小李子" });//调用两个参数的构造方法

            #endregion

            #region 【7】单利模式中私有构造方法调用

            Console.WriteLine("\r\n【7】单利模式中私有构造方法调用--------------");
            President newPresident = President.GetPresident();
            newPresident.SayHello();

            Type presidentType = Assembly.Load("ReflectionDemo").GetType("ReflectionDemo.President");
            object president = Activator.CreateInstance(presidentType, true);//true表示可以匹配私有构造方法（请断点调试观察）

            #endregion

            #region 【8】泛型类中使用反射创建对象

            Console.WriteLine("\r\n【8】泛型类中使用反射创建对象--------------");

            //泛型类在IL中和普通类名称是不一样的，请大家通过ILDASM查看，比如Instructor2`2 后面的“ `2 ” 如果是三个泛型参数，则后面是3
            //也可以通过控制台，直接查看输出，比如【3】中的输出
            Type genericInstructorType = Assembly.Load("ReflectionDemo").GetType("ReflectionDemo.Instructor2`2");
            Type commonType = genericInstructorType.MakeGenericType(new Type[] { typeof(string), typeof(string) });
            object objInstructor = Activator.CreateInstance(commonType);
            ((Instructor2<string, string>)objInstructor).SayHello("计算机系", "辅导员");

            #endregion

            #region 【9】基于反射调用实例公有方法、私有方法、静态方法

            Console.WriteLine("\r\n【9】基于反射调用实例公有方法、私有方法、静态方法--------------");

            Type teacherType = Assembly.Load("ReflectionDemo").GetType("ReflectionDemo.Teacher");
            object teacher = Activator.CreateInstance(teacherType);

            //以下输出内容为：属性对应的方法、自定义的各种方法、通过继承获得的方法（特别注意，这里全部是公有方法！）
            foreach (MethodInfo item in teacherType.GetMethods())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\r\n-----------------------------------------------------");
            //通过方法名获取方法
            MethodInfo method = teacherType.GetMethod("SayHello");
            method.Invoke(teacher, null);//调用无参数方法使用null         

            MethodInfo method1 = teacherType.GetMethod("Teach", new Type[] { typeof(int) });
            method1.Invoke(teacher, new object[] { 1 });//调用1个参数的方法

            MethodInfo method2 = teacherType.GetMethod("Teach", new Type[] { typeof(int), typeof(string) });
            method2.Invoke(teacher, new object[] { 1, "第3章" });//调用2个参数的方法

            MethodInfo method3 = teacherType.GetMethod("Teach", new Type[] { typeof(int), typeof(string), typeof(string) });
            method3.Invoke(teacher, new object[] { 1, "第3章", ".Net反射技术" });//调用3个参数的方法

            Console.WriteLine("\r\n-----------------------------------------------------");
            MethodInfo method4 = teacherType.GetMethod("PrivateGetSalary", BindingFlags.Instance | BindingFlags.NonPublic);
            method4.Invoke(teacher, null);//调用私有方法

            Console.WriteLine("\r\n-----------------------------------------------------");
            MethodInfo method5 = teacherType.GetMethod("Lecture", new Type[] { typeof(string) });
            method5.Invoke(teacher, new object[] { ".Net反射的原理和应用" });//调用静态方法
            method5.Invoke(null, new object[] { ".Net反射的原理和应用" });//调用静态方法第一个实例可以为null,实例方法调用则不能省略

            Console.WriteLine("\r\n-----------------------------------------------------");
            MethodInfo method6 = teacherType.GetMethod("TeachAdvancedCourse");
            MethodInfo genericMethod6 = method6.MakeGenericMethod(typeof(string), typeof(int));
            genericMethod6.Invoke(teacher, new object[] { "8:00-10:00", 2 });


            #endregion

            #region 【10】基于反射调用字段和属性

            Console.WriteLine("\r\n【10】基于反射调用公有属性和字段-------------------");

            //显示全部属性
            foreach (PropertyInfo item in teacherType.GetProperties())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\r\n--------------------------------------------------");

            //显示全部字段
            foreach (FieldInfo item in teacherType.GetFields())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\r\n--------------------------------------------------");

            //给属性赋值
            PropertyInfo property = teacherType.GetProperty("Department");
            property.SetValue(teacher, ".Net教学组");
            Console.WriteLine(property.GetValue(teacher));

            //给字段赋值
            FieldInfo field = teacherType.GetField("Company");
            field.SetValue(teacher, "腾讯课堂");
            Console.WriteLine(field.GetValue(teacher));

            //典型应用：查看自定有ORM中Select方法的封装...

            #endregion

            #region 【11】关于反射的性能测试和优化

            Console.WriteLine("\r\n【11】关于反射的性能测试和优化-------------------");

            long time1 = 0;
            long time2 = 0;
            long time3 = 0;

            //普通方法
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Teacher myTeacher = new Teacher();
                myTeacher.Test();
            }
            sw1.Stop();
            time1 = sw1.ElapsedMilliseconds;

            //反射方法（大概是普通方法的500多倍）
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Teacher myTeacher = (Teacher)Assembly.Load("ReflectionDemo").CreateInstance("ReflectionDemo.Teacher");
                myTeacher.Test();
            }
            sw2.Stop();
            time2 = sw2.ElapsedMilliseconds;

            //优化反射方法（和普通方法相差无几）
            Stopwatch sw3 = new Stopwatch();
            sw3.Start();
            Type tType = Assembly.Load("ReflectionDemo").GetType("ReflectionDemo.Teacher");
            for (int i = 0; i < 1000000; i++)
            {
                Teacher myTeacher = (Teacher)Activator.CreateInstance(tType);
                myTeacher.Test();
            }
            sw3.Stop();
            time3 = sw3.ElapsedMilliseconds;

            Console.WriteLine($"普通方法：{time1}\t反射方法：{time2}  优化反射方法：{time3}");

            #endregion

            Console.Read();
        }
    }
}
