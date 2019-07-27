using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    //以前用法：自动属性不能在声明的时候初始化
    //class Student
    //{
    //    public Student()
    //    {
    //        StudentId = 1001;
    //        Name = "张欣欣";
    //        Age = 25;
    //    }
    //    public int StudentId { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public string Gender
    //    {
    //        get { return Gender; }
    //    }
    //}

    //新用法：声明的同时可以初始化，并且允许只读属性初始化
    class Student
    {
        public int StudentId { get; set; } = 1001;
        public string Name { get; set; } = "张欣欣";
        public int Age { get; set; } = 25;
        public string Gender { get; } = "男";
    }

}
