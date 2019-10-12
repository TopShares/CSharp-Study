using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Class1
{
    static void Main(string[] args)
    {
        //ArrayList list = new ArrayList();

        //list.Add("3");

        //list.Add(1);

        //list.Add(new int[] { 1, 2, 3 });

        //foreach (var item in list)
        //{
        //    Console.WriteLine(item);
        //}

        //List<int> list = new List<int>();

        //list.Add(10);

        //list.Add(20);

        //MyList<Person> list = new MyList<Person>();

        //list.Add(new Person());

        //list.Add(new Person());

        Dictionary<int, int> dic = new Dictionary<int, int>();
    }
}

public class Person { }

public class MyList<T> where T : class
{
    public static List<T> list = new List<T>();

    public void Add(T t)
    {
        list.Add(t);
    }

    public void Remove(T t)
    {
        list.Remove(t);
    }
}