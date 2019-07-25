using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassAndMethod
{
    #region 1.default关键字的使用
    public class GenericClass1<T1, T2>
    {
        private T1 obj1;

        public GenericClass1()
        {
            //泛型使用的两种错误
            //obj1 = null;
            //obj1 = new T1(); //不能人为假定某种类型，因为这种类型也许没有构造方法，也许是私有的

            //解决方法：default关键字
            obj1 = default(T1); //如果T1是引用类型，就赋值null，如果是值类型就给默认值 ，如果是结构体，则成员的具体默认值取决于成员的类型
        }
    }

    #endregion

    #region 2.1 添加约束类型的泛型类

    public class GenericClass2<T1, T2, T3>
        where T1 : struct //类型必须是结构类型
        where T2 : class  //类型必须是引用类型
        where T3 : new()  //在这个类中，类型必须有一个无参数的构造方法，且必须把这个约束放到最后。
                          // 其他类型-->基类类型  where T2：T1{}  表示T2必须与T1类型相同或者继承自T1
                          // 接口类型（类型必须是接口或者实现了接口）
    {
        //产品列表
        public List<T2> ProductList { get; set; }

        //产品发行者
        public T3 Publisher { get; set; }


        public GenericClass2()
        {
            ProductList = new List<T2>();
            Publisher = new T3();
        }

        /// <summary>
        /// 购买第几个产品
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public T2 BuyProduct(T1 num)
        {
            //  return ProductList[num]; //直接写是错误的
            dynamic index = num;
            return ProductList[index];
        }
    }

    #endregion

    #region 2.2 根据泛型类要求设计参数（实际开发中可以设计很多这样符合要求的类）

    class Course
    {
        public string CourseName { get; set; }//课程名称
        public int Period { get; set; } //课程学习周期

    }

    class Teacher
    {
        public Teacher() { }
        public string Name { get; set; }
        public int Count { get; set; }//授课数量
    }

    #endregion
}
