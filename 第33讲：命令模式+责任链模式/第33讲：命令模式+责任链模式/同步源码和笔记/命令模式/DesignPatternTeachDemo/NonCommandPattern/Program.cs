using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonCommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //紧耦合的设计
            Receiver receiver = new Receiver();
            receiver.Method1();
            receiver.Method2();
            receiver.Method3();

            receiver.Method1();
            receiver.Method3();


            Console.Read();

            //缺点：客户端和执行者之间紧密耦合。任务执行可能非常乱。并且任务执行是随机的。还有，任务执行后，不可撤销。
            //希望：任务能够批量有序进行，并且根据要能够撤销。

            //现实举例：我们在商城购物，商品订单提交、客户信息提交、支付信息。都是批量完成。




        }
    }
}
