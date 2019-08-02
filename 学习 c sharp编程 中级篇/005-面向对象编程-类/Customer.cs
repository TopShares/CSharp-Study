using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_面向对象编程_类 {
    //在这里我们定义了一个新的类叫做Customer，也可以说定义了一个新的类型叫做Customer
    class Customer
    {
        //数据成员：里面包含了4个字段
        public string name;
        public string address;
        public int age;
        public string buyTime;
        //函数成员：定义了一个方法
        public void Show()
        {
            Console.WriteLine("名字："+name);
            Console.WriteLine("年龄："+age);
            Console.WriteLine("地址："+address);
            Console.WriteLine("购买时间:"+buyTime);
        }
    }
}
