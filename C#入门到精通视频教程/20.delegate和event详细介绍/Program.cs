using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//委托
public delegate void SubEventHandler();

public abstract class Subject
{
    //事件的定义方式
    public event SubEventHandler SubEvent;

    protected void FireAway()
    {
        if (this.SubEvent != null)
            this.SubEvent();
    }
}
public class Cat : Subject
{
    public void Cry()
    {
        Console.WriteLine("cat cryed.");
        this.FireAway();
    }
}
public abstract class Observer
{
    public Observer(Subject sub)
    {
        sub.SubEvent += new SubEventHandler(Response);
    }
    public abstract void Response();
}
public class Mouse : Observer
{
    private string name;
    public Mouse(string name, Subject sub) : base(sub)
    {
        this.name = name;
    }
    public override void Response()
    {
        Console.WriteLine(name + " attempt to escape!");
    }
}
public class Master : Observer
{
    public Master(Subject sub) : base(sub) { }
    public override void Response()
    {
        Console.WriteLine("host waken");
    }
}
class Class1
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        Mouse mouse1 = new Mouse("mouse1", cat);
        Mouse mouse2 = new Mouse("mouse2", cat);
        Master master = new Master(cat);
        cat.Cry();
    }
}