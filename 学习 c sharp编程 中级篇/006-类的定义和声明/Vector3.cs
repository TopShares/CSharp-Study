using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_类的定义和声明 {
    public class Vector3//设置为public 这样才别 的项目中才可以访问
    {
        //我们定义了一个构造函数，那么编译器不会为我们提供构造函数了
        public Vector3()
        {
            Console.WriteLine("Vector3的构造函数被调用了");
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            length = Length();
        }
        //编程规范上 习惯把所有的字段 设置为private ，只可以在类内部访问，不可以通过对象访问
        private float x, y, z, length;
        private int age;
        //private string name;

        //public String Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        public string Name { get; set; }//编译器会自动给我们提供一个字段，来存储name


        public int Age
        {
            set
            {
                //通过set方法 在设置值之前做一些校验的工作  属性的更多好处，需要在写代码过程中体会
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public float X// 也可以叫做get set方法
        {
            get { return x; }
            set { x = value; }//如果在get 或者 set前面加上 private，表示这个块只能在类内部调用
        }
        //为字段提供set方法，来设置字段的值
        public void SetX(float x)
        {
            //如果我们直接在方法内部访问同名的变量的时候，优先访问最近 (形参)
            //我们可以通过this.表示访问的是类的字段或者方法
            this.x = x;
        }

        public void SetY(float y)
        {
            this.y = y;
        }

        public void SetZ(float z)
        {
            this.z = z;
        }

        public float Length() {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        //定义属性
        public int MyIntProperty {
            set {
                Console.WriteLine("属性中set块被调用");
                Console.WriteLine("在set块中访问value的值是："+value);
            }
            //如果没有get块，就不能通过属性取值了
            get {
                Console.WriteLine("属性中的get块被调用 ");
                return 100;
            }
        }
    }
}
