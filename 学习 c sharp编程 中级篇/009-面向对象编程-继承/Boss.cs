using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_面向对象编程_继承 {
    class Boss : Enemy{
        //public override void Move()//重写 ： 原来的方法不存在了
        //{
        //    Console.WriteLine("这里是Boss的移动方法");
        //}
        public new void Move()//当子类里面有一个签名和父类相同的方法的时候，就会把父类中的方法隐藏
        {//隐藏： 只是把父类中的方法隐藏了，看不到了，实际这个方法还存在
            Console.WriteLine("这里是Boss的移动方法");
        }
        public void Attack()
        {

            //AI();
            //Move();
            ////hp = 100;
            //HP = 100;//父类里面公有是数据和函数成员才可以在子类里面访问
            Move();
            Console.WriteLine("Boss正在进行攻击");
        }
    }
}
