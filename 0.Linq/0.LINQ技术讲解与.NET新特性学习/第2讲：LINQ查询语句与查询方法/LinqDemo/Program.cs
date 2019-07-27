using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class Program
    {
        #region  示例1：不使用LINQ查询数组

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };
        //    List<int> list = new List<int>();
        //    foreach (int item in nums)
        //    {
        //        if (item % 2 != 0)
        //            list.Add(item);
        //    }
        //    list.Sort();
        //    list.Reverse();
        //    foreach (int item in list)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例2：使用LINQ技术查询数组

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };

        //    var list = from num in nums
        //               where num % 2 != 0
        //               orderby num descending
        //               select num;

        //    foreach (int item in list)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadLine();
        //}

        #endregion

        #region 示例3：扩展方法Select()应用

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };

        //    var list = nums.Select(item => item * item);
        //    foreach (int item in list)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        #endregion

        #region  示例4：扩展方法Where()应用

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };

        //    var list = nums
        //        .Where(item => item % 2 == 0)
        //        .Select(i => i * i);

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例5：扩展方法OrderBy()应用

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };
        //    var list = nums
        //        .Where(item => item % 2 == 0)
        //        .Select(i => i * i)
        //        .OrderBy(item => item);
        //    foreach (int i in list)
        //    {
        //        Console.WriteLine(i);
        //    }

        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    string[] nums = { "张勇", "王琦", "刘静", "赵鑫鑫",
        //                        "杜丽", "马俊才", "那英", "成龙", };

        //    var list = nums
        //        .Where(item => item.Length == 2)
        //        .Select(item => item)
        //        .OrderByDescending(item => item.Substring(0, 1));
        //    foreach (string item in list)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例6：扩展方法GroupBy()应用
        //static void Main(string[] args)
        //{
        //    string[] nums = { "张勇", "王琦", "刘静", "赵鑫鑫",
        //                        "杜丽", "马俊才", "那英", "成龙","王丽", "杜宇","马晓","刘丽","马大哈",};

        //    var list = nums
        //        .Where(item => item.Length == 2)
        //        .Select(item => item)
        //        .GroupBy(item => item.Substring(0, 1));

        //    foreach (var groupItem in list)
        //    {
        //        Console.WriteLine("-------------------");
        //        Console.WriteLine("分组字段：{0}", groupItem.Key);

        //        foreach (var item in groupItem)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }



        //    Console.ReadLine();
        //}

        #endregion

        #region  示例7：断点调试LINQ的查询时机
        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };

        //    var list = nums
        //        .Where(item => item % 2 == 0)
        //        .Select(item => item * item)
        //        .OrderBy(item => item);

        //    foreach (int i in list)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    Console.ReadLine();
        //}

        #endregion

        #region 示例8：查询的立即执行

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 7, 2, 6, 5, 4, 9, 13, 20 };

        //    var list = nums
        //        .Where(item => item % 2 == 0)
        //        .Select(item => item * item)
        //        .OrderBy(item => item)
        //        .Count();

        //    Console.WriteLine(list.ToString ());
        //    Console.ReadLine();
        //}

        #endregion

        #region  示例9：from子句的简单使用

        //static void Main(string[] args)
        //{
        //    ArrayList values = new ArrayList();
        //    for (int i = 0; i < 10; i++) { values.Add(i); }
        //    var list = from int item in values
        //               where item % 2 == 0
        //               select item;
        //    foreach (int item in list) { Console.WriteLine(item); }
        //    Console.ReadLine();
        //}

        #endregion

        #region 示例10：复合from子句的使用

        //static void Main(string[] args)
        //{
        //    Student obj1 = new Student()
        //    {
        //        StuId = 1001,
        //        StuName = "学员1",
        //        ScoreList = new List<int>() { 90, 78, 54 }
        //    };
        //    Student obj2 = new Student()
        //    {
        //        StuId = 1002,
        //        StuName = "学员2",
        //        ScoreList = new List<int>() { 95, 88, 90 }
        //    };
        //    Student obj3 = new Student()
        //    {
        //        StuId = 1003,
        //        StuName = "学员3",
        //        ScoreList = new List<int>() { 79, 76, 89 }
        //    };
        //    //将学员封装到集合中
        //    List<Student> stuList = new List<Student>() { obj1, obj2, obj3 };
        //    //查询成绩包含95分以上的学员
        //    var result = from stu in stuList
        //                 from score in stu.ScoreList
        //                 where score >= 95
        //                 select stu;
        //    //显示查询结果
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item.StuName);
        //    }


        //    Console.ReadLine();
        //}

        #endregion

        #region 示例11：多个from子句查询的使用

        //static void Main(string[] args)
        //{
        //    Student obj1 = new Student() { StuId = 1001, StuName = "学员1" };
        //    Student obj2 = new Student() { StuId = 1009, StuName = "学员9" };
        //    Student obj3 = new Student() { StuId = 1012, StuName = "学员12" };
        //    Student obj4 = new Student() { StuId = 1003, StuName = "学员3" };
        //    Student obj5 = new Student() { StuId = 1019, StuName = "学员19" };
        //    Student obj6 = new Student() { StuId = 1006, StuName = "学员6" };

        //    List<Student> stuList1 = new List<Student>() { obj1, obj2, obj3 };
        //    List<Student> stuList2 = new List<Student>() { obj4, obj5, obj6 };

        //    //查询学好大于1010的学员
        //    var result = from stu1 in stuList1
        //                 where stu1.StuId >= 1010
        //                 from stu2 in stuList2
        //                 where stu2.StuId >= 1010
        //                 select new { stu1, stu2 };
        //    //显示查询结果
        //    foreach (var item in result )
        //    {
        //        Console.WriteLine(item.stu1.StuName+"   "+item.stu1.StuId);
        //        Console.WriteLine(item.stu2.StuName + "   " + item.stu2.StuId);
        //    }

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例12：聚合函数Count

        //static void Main(string[] args)
        //{
        //    Student obj1 = new Student() { StuId = 1001, StuName = "学员1" };
        //    Student obj2 = new Student() { StuId = 1009, StuName = "学员9" };
        //    Student obj3 = new Student() { StuId = 1012, StuName = "学员12" };
        //    Student obj4 = new Student() { StuId = 1003, StuName = "学员3" };
        //    Student obj5 = new Student() { StuId = 1019, StuName = "学员19" };
        //    Student obj6 = new Student() { StuId = 1006, StuName = "学员6" };
        //    List<Student> stuList = new List<Student>() { obj1, obj2, obj3, obj4, obj5, obj6 };

        //    var count1 = (from c in stuList
        //                  where c.StuId > 1010
        //                  select c).Count();

        //    var count2 = stuList.Where(c => c.StuId > 1010).Count();
        //    Console.WriteLine("count1={0}  count2={1}",count1,count2);


        //    Console.ReadLine();
        //}
        #endregion

        #region 示例13：聚合函数Max、Min、Average

        //static void Main(string[] args)
        //{
        //    Student obj1 = new Student() { StuId = 1001, Age = 22, StuName = "学员1" };
        //    Student obj2 = new Student() { StuId = 1009, Age = 21, StuName = "学员9" };
        //    Student obj3 = new Student() { StuId = 1012, Age = 25, StuName = "学员12" };
        //    Student obj4 = new Student() { StuId = 1003, Age = 23, StuName = "学员3" };
        //    Student obj5 = new Student() { StuId = 1019, Age = 27, StuName = "学员19" };
        //    Student obj6 = new Student() { StuId = 1006, Age = 24, StuName = "学员6" };
        //    List<Student> stuList = new List<Student>() { obj1, obj2, obj3, obj4, obj5, obj6 };

        //    var maxAge = (from s in stuList
        //                  select s.Age).Max();
        //    var minAge = stuList
        //              .Select(s => s.Age).Min();
        //    var avgAge = (from s in stuList
        //                  select s.Age).Average();
        //    var sumAge = (from s in stuList
        //                  select s.Age).Sum();

        //    Console.WriteLine("maxAge={0} minAge={1} avgAge={2} sumAge={3}", 
        //        maxAge, minAge, avgAge,sumAge);

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例14：排序类ThenBy的使用

        //static void Main(string[] args)
        //{

        //    Student obj1 = new Student() { StuId = 1001, Age = 22, StuName = "学员1" };
        //    Student obj2 = new Student() { StuId = 1009, Age = 21, StuName = "学员9" };
        //    Student obj3 = new Student() { StuId = 1012, Age = 25, StuName = "学员12" };
        //    Student obj4 = new Student() { StuId = 1003, Age = 23, StuName = "学员3" };
        //    Student obj5 = new Student() { StuId = 1019, Age = 27, StuName = "学员19" };
        //    Student obj6 = new Student() { StuId = 1006, Age = 24, StuName = "学员6" };
        //    List<Student> stuList = new List<Student>() { obj1, obj2, obj3, obj4, obj5, obj6 };

        //    var stus1 = from s in stuList
        //                orderby s.StuName, s.Age, s.StuId
        //                select s;

        //    var stus2 = stuList
        //        .OrderBy(s => s.StuName)
        //        .ThenBy(s => s.Age)
        //        .ThenBy(s => s.StuId)
        //        .Select(p => p);

        //    foreach (var s in stus1)
        //    {
        //        Console.WriteLine(s.StuName);
        //    }

        //    Console.WriteLine("----------------------");

        //    foreach (var s in stus2)
        //    {
        //        Console.WriteLine(s.StuName);
        //    }

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例15：分区类查询
        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //    var list1 = nums.Skip(1).Take(3);
        //    var list2 = nums.SkipWhile(i => i % 3 != 0)
        //                     .TakeWhile(i => i % 2 != 0);

        //    foreach (var item in list1) { Console.WriteLine(item); }
        //    Console.WriteLine("------------");
        //    foreach (var item in list2) { Console.WriteLine(item); }

        //    Console.ReadLine();
        //}

        #endregion

        #region 示例16：集合类查询Distinct

        //static void Main(string[] args)
        //{
        //    int[] nums = { 1, 2, 2, 6, 5, 6, 7, 8, 8 };
        //    var list = nums.Distinct();

        //    foreach (var item in list) { Console.WriteLine(item); }

        //    Console.ReadLine();
        //}

        #endregion

        #region  示例17：生成类查询

        //static void Main(string[] args)
        //{
        //var nums1 = Enumerable.Range(1, 10);
        //  var nums2 = Enumerable.Repeat("LINQ best！", 10);

        //  foreach (var item in nums1) { Console.WriteLine(item); }
        //  Console.WriteLine("------------");
        //  foreach (var item in nums2) { Console.WriteLine(item); }


        //    Console.ReadLine();
        //}

        #endregion
    }
}
