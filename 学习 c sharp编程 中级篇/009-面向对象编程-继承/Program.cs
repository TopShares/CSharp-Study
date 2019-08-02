using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_面向对象编程_继承 {
    class Program {
        static void Main(string[] args) {
            //Boss boss = new Boss();
            ////boss.AI();//继承：父类里面所有的数据成员和函数成员都会继承到子类里面
            //boss.Attack();

            //Enemy enemy;
            //enemy = new Boss();//父类声明的对象，可以使用子类去构造  子类声明的对象不可以使用父类构造
            ////enemy虽然使用父类进行了声明，但是使用了子类构造，所以本质上是一个子类类型的，我们可以强制类型转换转换成子类类型
            //Boss boss = (Boss)enemy;
            //boss.Attack();

            //Enemy enemy = new Enemy();
            //Boss boss =(Boss) enemy;//一个对象是什么类型的  主要看它是通过什么构造的  这里enemy使用了父类的构造函数，所以只有父类中的字段和方法， 不能被强制转换成子类

            //Boss boss = new Boss();
            ////boss.Attack();
            //boss.AI();

            //Enemy enemy = new Enemy();
            //enemy.AI();

            //Enemy boss = new Boss();
            //boss.Move();//隐藏方法： 如果使用子类声明的对象，调用隐藏方法会调用子类的，如果使用父类声明对象，那么就会调用父类中的隐藏方法

            //Crow crow = new Crow();
            //crow.Fly();

            //Bird bird = new Crow();//我们可以通过抽象类去声明对象 但是不可以去构造
            //bird.Fly();


            Console.ReadKey();
        }
    }
}
