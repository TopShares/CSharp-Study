using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_栈 {
    class Program {
        static void Main(string[] args) {
            //1,使用BCL中的Stack<T>
            //Stack<char> stack = new Stack<char>();
            //2,使用我们自己的顺序栈
            //IStackDS<char> stack = new SeqStack<char>(30);
            //3,使用我们自己的链栈
            IStackDS<char> stack = new LinkStack<char>();

            stack.Push('a');
            stack.Push('b');
            stack.Push('c');//栈顶数据
            Console.WriteLine("push a b c之后的数据个数为："+stack.Count);
            char temp = stack.Pop();//取得栈顶数据，并把栈顶的数据删除
            Console.WriteLine("pop 之后得到的数据是："+temp);
            Console.WriteLine("pop 之后栈中数据的个数:"+stack.Count);
            char temp2 = stack.Peek();//取得栈顶的数据，不删除
            Console.WriteLine("peek 之后得到的数据是：" + temp2);
            Console.WriteLine("peek 之后栈中数据的个数:" + stack.Count);

            stack.Clear();

            Console.WriteLine("clear 之后栈中数据的个数:" + stack.Count);
            //Console.WriteLine("空栈的时候，取得栈顶的值："+stack.Peek());// 出现异常
            //当空栈的时候，不要进行peek或者pop操作 ，否则会出现异常

            Console.ReadKey();
        }
    }
}
