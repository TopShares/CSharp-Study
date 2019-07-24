using ORM.DAL;
using ORM.Models;
using System;
using System.Collections.Generic;

namespace TestORM
{
    class Program
    {
        #region 测试ORM中Insert方法

        static void Main(string[] args)
        {
            Console.WriteLine("大家好！今天我们学习的主题是：自定义ORM框架开发！");
            Console.WriteLine("以下测试是的ORM中的Insert方法：\r\n");

            //封装对象
            Students student = new Students()
            {
                StudentName = "ORM用户03",
                Gender = "女",
                Birthday = Convert.ToDateTime("1997-10-10"),
                StudentIdNo = "120223199710101513",
                PhoneNumber = "022-99888890",
                StudentAddress = "ORM用户地址不详",
                CardNo = "1000003",
                ClassId = 1,
                Age = DateTime.Now.Year - Convert.ToDateTime("1997-10-10").Year,
                StuImage = ""
            };
            //调用ORM实现保存
            int result = new ORM.DAL.StudentService().AddStudent(student);
            Console.WriteLine(result);
            Console.Read();
        }

        #endregion

        #region 测试ORM中Selete对象自动封装
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("大家好！今天我们学习的主题是：自定义ORM框架开发！");
        //    Console.WriteLine("以下测试是的ORM中Select查询后自动封装对象的方法：\r\n");

        //    List<Students> stuList = new StudentService().GetStudentByClass("软件1班");
        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId + "\t" + item.StudentName + "\t" + item.Gender + "\t" + item.PhoneNumber);
        //    }
        //    Console.Read();
        //}

        #endregion

        #region 测试ORM中Update方法
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("大家好！今天我们学习的主题是：自定义ORM框架开发！");
        //    Console.WriteLine("以下测试是的ORM中的Update方法：\r\n");

        //    //封装对象
        //    Students student = new Students()
        //    {
        //        StudentName = "修改ORM用户5",
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1997-10-10"),
        //        StudentIdNo = "120223199710101000",
        //        PhoneNumber = "022-9988800",
        //        StudentAddress = "ORM用户地址修改",
        //        CardNo = "10055515",
        //        ClassId = 1,
        //        Age = DateTime.Now.Year - Convert.ToDateTime("1997-10-10").Year,
        //        StuImage = "",
        //        StudentId = 100005   //这个具体的数值，请根据自己数据库的值选择
        //    };
        //    //调用ORM实现修改
        //    int result = new ORM.DAL.StudentService().ModifyStudent(student);
        //    Console.WriteLine(result);
        //    Console.Read();
        //}

        #endregion

        #region 测试ORM中Delete方法

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("大家好！今天我们学习的主题是：自定义ORM框架开发！");
        //    Console.WriteLine("以下测试是的ORM中的Delete方法：\r\n");

        //    //封装对象
        //    Students student = new Students()
        //    {
        //        StudentId = 100034  //这个具体的数值，请根据自己数据库的值选择
        //    };
        //    //调用ORM实现删除
        //    int result = new ORM.DAL.StudentService().DeleteStudent(student);
        //    Console.WriteLine(result);
        //    Console.Read();
        //}

        #endregion

    }
}
