 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_练习题 {
    class Program {
        //static void Main(string[] args) {
        //}
    }

    abstract class BaseClass {
        public virtual void MethodA() { Console.WriteLine("BaseClass"); }
        public virtual void MethodB() { }
    }
    class Class1 : BaseClass {
        public void MethodA() { Console.WriteLine("Class1"); }//如果一个虚函数 在子类中没有通过override关键字，那么这个方法就没有被重写，而是被隐藏了
        public override void MethodB() { }
    }
    class Class2 : Class1 {
        new public void MethodB() { }
    }
    class MainClass {
        //public static void Main(string[] args) { 
        //    //Class2 o = new Class2(); o.MethodA();

        //    Class1 o  = new Class1();
        //    BaseClass o2 = o;
        //    o2.MethodA();
        //    o.MethodA();
        //    Console.ReadKey();
        //}
    }

    public abstract class A {
        public A() { Console.WriteLine('A'); }
        public virtual void Fun() { Console.WriteLine("A.Fun()"); }
    }
    public class B : A {
        public B() { Console.WriteLine('B'); }
        public new void Fun() { Console.WriteLine("B.Fun()"); }
        //public static void Main() { A a = new B(); a.Fun(); }
    } 

    public abstract class Animal{
	public abstract void Eat();
}
public class Tiger:Animal{
	public override void Eat(){
        Console.WriteLine("老虎吃动物");
}
}
public class Tigress:Tiger{
//    static void Main(){
//        Tigress tiger=new Tigress();
//        tiger.Eat();
//}

}

public class Student {
    public virtual void Exam() {
        Console.WriteLine("学生都要考试");
    }
}
public class Undergraduate : Student {
    public new void Exam() {
        base.Exam();
        Console.WriteLine("大学生有选择考试科目的权利");
    }
}
public class Test {
    static void Main() {
        Student stu = new Undergraduate();
        stu.Exam();
    }
}
}
